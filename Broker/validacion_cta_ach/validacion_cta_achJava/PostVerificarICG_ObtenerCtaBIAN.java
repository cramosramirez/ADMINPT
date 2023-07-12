import com.ibm.broker.javacompute.MbJavaComputeNode;
import com.ibm.broker.plugin.MbElement;
import com.ibm.broker.plugin.MbException;
import com.ibm.broker.plugin.MbMessage;
import com.ibm.broker.plugin.MbMessageAssembly;
import com.ibm.broker.plugin.MbOutputTerminal;
import java.sql.CallableStatement;
import java.sql.Connection;
import java.sql.SQLException;


public class PostVerificarICG_ObtenerCtaBIAN extends MbJavaComputeNode {

	public void evaluate(MbMessageAssembly inAssembly) throws MbException {
		MbOutputTerminal out = getOutputTerminal("out");
		MbOutputTerminal alt = getOutputTerminal("alternate");

		MbMessage inMessage = inAssembly.getMessage();
		MbMessageAssembly outAssembly = null;
		//VARIABLES DE CONECCION
		String configurableService = "COB_BVIRTUAL";
		
		try {
			// create new message as a copy of the input
			MbMessage outMessage = new MbMessage(inMessage);
			outAssembly = new MbMessageAssembly(inAssembly, outMessage);
			// ----------------------------------------------------------
			// Add user code below
			//Obtener variable global
			MbElement environment =  inAssembly.getGlobalEnvironment().getRootElement();
			String cuenta = environment.getFirstElementByPath("Variables/JSON/Data/cuenta").getValue().toString();
			int tipoCta = Integer.parseInt(environment.getFirstElementByPath("Variables/JSON/Data/tipo").getValue().toString());
			String bic = environment.getFirstElementByPath("Variables/banco").getValue().toString();
			int moneda = Integer.parseInt(environment.getFirstElementByPath("Variables/JSON/Data/moneda").getValue().toString());
			String iban;
			
			try {  
				if(tipoCta == 1){
					tipoCta = 3;
				} else{
					tipoCta = 4;
				}
				if(moneda == 1){
					moneda = 0;
				} else{
					moneda = 1;
				}
                // Realiza la conexión a la BD a través del Servicio Configurable
				String spCall = "exec cob_bvirtual..sp_be_convierte_iban_ach " + "?.?.?.?.?.?.?";
                // Realiza la conexión a la BD a través del Servicio Configurable
                Connection conn = getJDBCType4Connection(configurableService, JDBC_TransactionType.MB_TRANSACTION_AUTO);
                conn.setAutoCommit(true);
                // Prepara la llamada al SP
                CallableStatement statement = conn.prepareCall(spCall);
                // Setea los parámetros del SP
                statement.setString(1, "OIBAN");
                statement.setString(2, cuenta);
                statement.setString(3, bic);
                statement.setInt(4, moneda);
                statement.setInt(5, tipoCta);
                statement.setString(6, "1");
                statement.registerOutParameter(7, java.sql.Types.VARCHAR);
                statement.execute();
                iban = statement.getString(7);
                // Ejecuta el SP y cierra el statement
                if(iban != null && iban.length()> 1){
                	environment.getFirstElementByPath("Variables/JSON/Data/cuenta").setValue(iban);
                	copyMessageHeaders(inMessage, outMessage); 
                	statement.close();
                	out.propagate(outAssembly, false);
                }else{
                	copyMessageHeaders(inMessage, outMessage);
                	statement.close();
                	MbElement padre1 = environment.getFirstElementByPath("Variables");
                    MbElement padre2 = padre1.createElementAsLastChild(MbElement.TYPE_NAME, "EsbHeader", null);
                    MbElement padre5 = padre2.createElementAsLastChild(MbElement.TYPE_NAME_VALUE, "Code", "2");
                    MbElement padre3 = padre2.createElementAsLastChild(MbElement.TYPE_NAME_VALUE, "Reason", "No se pudo cambiar la cuenta IBAN");
                    MbElement padre4 = padre2.createElementAsLastChild(MbElement.TYPE_NAME_VALUE, "DetailRetCode", "No se puedo cambiar la cuenta IBAN");
                	alt.propagate(outAssembly, false);
                }
            } catch (SQLException ex) {                
                // Genera el mensaje de respuesta
               copyMessageHeaders(inMessage, outMessage); 
	            int inicio = ex.getMessage().indexOf("[");
	            int fin = ex.getMessage().indexOf("]", inicio + 1);
               	String Final = ex.getMessage().substring(fin + 1,ex.getMessage().length());
                MbElement padre1 = environment.getFirstElementByPath("Variables");
                MbElement padre2 = padre1.createElementAsLastChild(MbElement.TYPE_NAME, "EsbHeader", null);
                MbElement padre5 = padre2.createElementAsLastChild(MbElement.TYPE_NAME_VALUE, "Code", "2");
                MbElement padre3 = padre2.createElementAsLastChild(MbElement.TYPE_NAME_VALUE, "Reason", Final);
                MbElement padre4 = padre2.createElementAsLastChild(MbElement.TYPE_NAME_VALUE, "DetailRetCode", ex.getMessage());
                alt.propagate(outAssembly, false);
            }
		
		} catch (Exception e) {
			MbElement environment =  inAssembly.getGlobalEnvironment().getRootElement();
			MbElement padre1 = environment.getFirstElementByPath("Variables");
            MbElement padre2 = padre1.createElementAsLastChild(MbElement.TYPE_NAME, "EsbHeader", null);
            MbElement padre5 = padre2.createElementAsLastChild(MbElement.TYPE_NAME_VALUE, "Code", "2");
            MbElement padre3 = padre2.createElementAsLastChild(MbElement.TYPE_NAME_VALUE, "Reason", "No se puedo cambiar la cuenta IBAN");
            MbElement padre4 = padre2.createElementAsLastChild(MbElement.TYPE_NAME_VALUE, "DetailRetCode", e.getMessage());
			// Consider replacing Exception with type(s) thrown by user code
			// Example handling ensures all exceptions are re-thrown to be handled in the flow
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
