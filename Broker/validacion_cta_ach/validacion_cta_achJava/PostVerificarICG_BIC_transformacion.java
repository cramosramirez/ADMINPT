import java.sql.CallableStatement;
import java.sql.Connection;
import java.sql.ResultSet;
import java.sql.SQLException;

import com.ibm.broker.javacompute.MbJavaComputeNode;
import com.ibm.broker.plugin.MbElement;
import com.ibm.broker.plugin.MbException;
import com.ibm.broker.plugin.MbMessage;
import com.ibm.broker.plugin.MbMessageAssembly;
import com.ibm.broker.plugin.MbOutputTerminal;
import com.ibm.broker.plugin.MbNode.JDBC_TransactionType;

public class PostVerificarICG_BIC_transformacion extends MbJavaComputeNode {

	public void evaluate(MbMessageAssembly inAssembly) throws MbException {
		MbOutputTerminal out = getOutputTerminal("out");
		MbOutputTerminal alt = getOutputTerminal("alternate");
		MbMessage inMessage = inAssembly.getMessage();
		MbMessageAssembly outAssembly = null;
		
        try {
			MbMessage outMessage = new MbMessage(inMessage);
			outAssembly = new MbMessageAssembly(inAssembly, outMessage);
			 
			//Obtener variable global
			MbElement environment =  inAssembly.getGlobalEnvironment().getRootElement();
			String bic = environment.getFirstElementByPath("Variables/JSON/Data/banco").getValue().toString();
			
			MbElement padre1 = environment.getFirstElementByPath("Variables");
           
			//verifica si el parametro de banco posee la terminacion correspondiente
			if(bic.length()>4){
				//si el bic fue armado desde el canal
				String subbic = bic.substring(0,4);
				MbElement padre2 = padre1.createElementAsLastChild(MbElement.TYPE_NAME_VALUE, "banco", subbic );
				environment.getFirstElementByPath("Variables/JSON/Data/banco").setValue(bicTransformaciion(subbic));
			} else{
				MbElement padre2 = padre1.createElementAsLastChild(MbElement.TYPE_NAME_VALUE, "banco", bic);
				environment.getFirstElementByPath("Variables/JSON/Data/banco").setValue(bicTransformaciion(bic));
			}
			copyMessageHeaders(inMessage, outMessage); 
			out.propagate(outAssembly, false);
			  
        } catch (MbException e) {
			MbElement environment =  inAssembly.getGlobalEnvironment().getRootElement();
			MbElement padre1 = environment.getFirstElementByPath("Variables");
			padre1.createElementAsLastChild(MbElement.TYPE_NAME, "DescError", "Ocurrio un error al obtener el bic del banco destino");
            MbElement padre2 = padre1.createElementAsLastChild(MbElement.TYPE_NAME, "EsbHeader", null);
            padre2.createElementAsLastChild(MbElement.TYPE_NAME_VALUE, "Reason", "Ocurrio un error al obtener el bic del banco destino");
            padre2.createElementAsLastChild(MbElement.TYPE_NAME_VALUE, "DetailRetCode", e.getMessage());
			throw e;
		} catch (RuntimeException e) {
			MbElement environment =  inAssembly.getGlobalEnvironment().getRootElement();
			MbElement padre1 = environment.getFirstElementByPath("Variables");
			padre1.createElementAsLastChild(MbElement.TYPE_NAME, "DescError", "Ocurrio un error al obtener el bic del banco destino");
			MbElement padre2 = padre1.createElementAsLastChild(MbElement.TYPE_NAME, "EsbHeader", null);
            padre2.createElementAsLastChild(MbElement.TYPE_NAME_VALUE, "Reason", "Ocurrio un error al obtener el bic del banco destino");
            padre2.createElementAsLastChild(MbElement.TYPE_NAME_VALUE, "DetailRetCode", e.getMessage());
			throw e;
		} catch (Exception e) {
			MbElement environment =  inAssembly.getGlobalEnvironment().getRootElement();
			MbElement padre1 = environment.getFirstElementByPath("Variables");
			padre1.createElementAsLastChild(MbElement.TYPE_NAME, "DescError", "Ocurrio un error al obtener el bic del banco destino");
            MbElement padre2 = padre1.createElementAsLastChild(MbElement.TYPE_NAME, "EsbHeader", null);
            padre2.createElementAsLastChild(MbElement.TYPE_NAME_VALUE, "Reason", "Ocurrio un error al obtener el bic del banco destino");
            padre2.createElementAsLastChild(MbElement.TYPE_NAME_VALUE, "DetailRetCode", e.getMessage());
		}
	}
	
	public String bicTransformaciion(String bic){
		String configurableService = "COBIS";
		ResultSet rs = null;
		try {
			String query = "select * from cobis..cl_banco_swift where bs_codigo_bic = " + "?";
			// Realiza la conexión a la BD a través del Servicio Configurable
			  Connection conn = getJDBCType4Connection(configurableService, JDBC_TransactionType.MB_TRANSACTION_AUTO);
              conn.setAutoCommit(true);
              // Prepara la llamada al SP
              CallableStatement statement = conn.prepareCall(query);
			try {
				statement.setString(1, bic);
                // Ejecuta el SP y cierra el statement
                rs = statement.executeQuery();
                String codigo_bic = "";
                String desc_bic = "";
                String complemento_bic = "";
                int i = 0;
                while (rs.next()) {
                    codigo_bic = rs.getString("bs_codigo_bdr");
                    desc_bic = rs.getString("bs_codigo_bic");
                    complemento_bic = rs.getString("bs_codigo_comp");
                    i = i + 1;
                }               
                // cierra el resultset y el statement
                rs.close();
                
				statement.close();
				if (i== 0) {
					return bic + "GTCG";
				} else {
					return bic + complemento_bic;
				}
			} catch (SQLException ex) {
				int inicio = ex.getMessage().indexOf("[");
	            int fin = ex.getMessage().indexOf("]", inicio + 1);
	           	String Final = ex.getMessage().substring(fin + 1,ex.getMessage().length());
	            return Final;
			}
		} catch (MbException e) {
			return e.getMessage();
		} catch (RuntimeException e) {
			return e.getMessage();
		} catch (Exception e) {
			return e.getMessage();
		}
	}
	
	public void copyMessageHeaders(MbMessage inMessage, MbMessage outMessage) throws MbException {
        MbElement outRoot = outMessage.getRootElement();
       // iterate though the headers starting with the first child of the root
        // element
        MbElement header = inMessage.getRootElement().getFirstChild();
        while (header != null && header.getNextSibling() != null)
        {
            // copy the header and add it to the out message
            outRoot.addAsLastChild(header.copy());
            // move along to next header
            header = header.getNextSibling();
        }
    }

}
