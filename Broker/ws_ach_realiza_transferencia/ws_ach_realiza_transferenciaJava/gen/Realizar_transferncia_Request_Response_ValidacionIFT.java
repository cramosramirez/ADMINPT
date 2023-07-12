package gen;

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

public class Realizar_transferncia_Request_Response_ValidacionIFT extends
		MbJavaComputeNode {

	public void evaluate(MbMessageAssembly inAssembly) throws MbException {
		MbOutputTerminal out = getOutputTerminal("out");
		MbOutputTerminal alt = getOutputTerminal("alternate");

		MbMessage inMessage = inAssembly.getMessage();
		MbMessageAssembly outAssembly = null;
		
		//VARIABLES DE CONECCION
		String configurableService = "COB_BVIRTUAL";	
		ResultSet rs = null;
		String spCall = "exec cob_bvirtual..sp_limite_trans_tif " + "?.?";
		CallableStatement statement;
				
		try {
			// create new message as a copy of the input
			MbMessage outMessage = new MbMessage(inMessage);
			outAssembly = new MbMessageAssembly(inAssembly, outMessage);
			MbElement environment =  inAssembly.getGlobalEnvironment().getRootElement();
			
			 
				try{
					Connection conn = getJDBCType4Connection(configurableService, JDBC_TransactionType.MB_TRANSACTION_AUTO);
		            conn.setAutoCommit(true);
			
					// Prepara la llamada al SP sp_ach_actualiza_sol_deb            
					statement = conn.prepareCall(spCall);					
					String operacion = "C";
					Integer mis = Integer.parseInt(environment.getFirstElementByPath("Variables/mis_valida_ift").getValue().toString());
					String traPro_valida_ift = environment.getFirstElementByPath("Variables/traPro_valida_ift").getValue().toString();
					
					if(traPro_valida_ift.equals("IFT")){
						statement.setString(1,operacion);
						statement.setInt(2,mis);
						rs = statement.executeQuery();
						Integer Resultado = null;

						if (rs.next()){
							Resultado = rs.getInt(1);
						}
						rs.close();	
						statement.close();	
						
						//copyMessageHeaders(inMessage, outMessage);
						if(Resultado == 2){
		                    MbElement padre1 = environment.getFirstElementByPath("Variables");
		                    MbElement padre2 = padre1.createElementAsLastChild(MbElement.TYPE_NAME, "EsbHeader", Resultado);
		                    padre2.createElementAsLastChild(MbElement.TYPE_NAME_VALUE, "Reason", "Has alcanzado el límite de transacciones TIF.");
		                    alt.propagate(outAssembly, false);
		                    return;
						}	
					}
					out.propagate(outAssembly, false);
				}catch (SQLException ex) {                
		            // Genera el mensaje de respuesta
		            //copyMessageHeaders(inMessage, outMessage); 
		            int inicio = ex.getMessage().indexOf("[");
		            int fin = ex.getMessage().indexOf("]", inicio + 1);
		           	String Final = ex.getMessage().substring(fin + 1,ex.getMessage().length());           	
		            MbElement padre1 = environment.getFirstElementByPath("Variables");
		            MbElement padre2 = padre1.createElementAsLastChild(MbElement.TYPE_NAME, "EsbHeader", null);
		            padre2.createElementAsLastChild(MbElement.TYPE_NAME_VALUE, "Reason", Final);
		            padre2.createElementAsLastChild(MbElement.TYPE_NAME_VALUE, "DetailRetCode", ex.getMessage());
		            padre2.createElementAsLastChild(MbElement.TYPE_NAME_VALUE, "Code", "4");
		            alt.propagate(outAssembly, false);
		        }		
				
				
		} catch (MbException e) {
			MbElement environment =  inAssembly.getGlobalEnvironment().getRootElement();
			MbElement padre1 = environment.getFirstElementByPath("Variables");
            MbElement padre2 = padre1.createElementAsLastChild(MbElement.TYPE_NAME, "EsbHeader", null);
            MbElement padre3 = padre2.createElementAsLastChild(MbElement.TYPE_NAME_VALUE, "Reason", "En estos momentos no puede procesarse la asociacion de cuenta, por favor intente mas tarde.");
            MbElement padre4 = padre2.createElementAsLastChild(MbElement.TYPE_NAME_VALUE, "DetailRetCode", e.getMessage());
			throw e;
		} catch (RuntimeException e) {
			MbElement environment =  inAssembly.getGlobalEnvironment().getRootElement();
			MbElement padre1 = environment.getFirstElementByPath("Variables");
            MbElement padre2 = padre1.createElementAsLastChild(MbElement.TYPE_NAME, "EsbHeader", null);
            MbElement padre3 = padre2.createElementAsLastChild(MbElement.TYPE_NAME_VALUE, "Reason", "En estos momentos no puede procesarse la asociacion de cuenta, por favor intente mas tarde.");
            MbElement padre4 = padre2.createElementAsLastChild(MbElement.TYPE_NAME_VALUE, "DetailRetCode", e.getMessage());
			throw e;
		} catch (Exception e) {
			MbElement environment =  inAssembly.getGlobalEnvironment().getRootElement();
			MbElement padre1 = environment.getFirstElementByPath("Variables");
            MbElement padre2 = padre1.createElementAsLastChild(MbElement.TYPE_NAME, "EsbHeader", null);
            MbElement padre3 = padre2.createElementAsLastChild(MbElement.TYPE_NAME_VALUE, "Reason", "En estos momentos no puede procesarse la asociacion de cuenta, por favor intente mas tarde.");
            MbElement padre4 = padre2.createElementAsLastChild(MbElement.TYPE_NAME_VALUE, "DetailRetCode", e.getMessage());
			throw e;
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
