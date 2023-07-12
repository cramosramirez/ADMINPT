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

public class CA_ACH_RealizarTransferencia001_REQ_val_lista_negra extends
		MbJavaComputeNode {


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
			// ---------------------------------------------------------- Environment.ParticipantAccountRequestData_req.datos.Participant.Account.FinancialInstitutionIdentification;
			//Obtener variable global
			MbElement environment =  inAssembly.getGlobalEnvironment().getRootElement();
			Integer moneda = Integer.parseInt(environment.getFirstElementByPath("Variables/AccountMoneda").getValue().toString());
			Integer producto = Integer.parseInt(environment.getFirstElementByPath("Variables/AccountType").getValue().toString());
			String institucion = environment.getFirstElementByPath("Variables/AccountFinInstId").getValue().toString();
			String iban= environment.getFirstElementByPath("Variables/AccountNumber").getValue().toString();
//			if (producto == 1){
//				producto = 3;
//			}
//			else if (producto == 2){
//				producto = 4;
//			}
			MbElement padre1 = environment.getFirstElementByPath("Variables");
                	try{
                		String spCall = "exec cob_bvirtual..sp_be_lista_negra_ach  " + "?.?.?.?.?.?.?.?.?";
            			ResultSet rs = null;
            			// Realiza la conexión a la BD a través del Servicio Configurable
            			Connection conn = getJDBCType4Connection(configurableService, JDBC_TransactionType.MB_TRANSACTION_AUTO);
                        conn.setAutoCommit(true);
                        // Prepara la llamada al SP
                        CallableStatement statement = conn.prepareCall(spCall);
                        
                        // Setea los parámetros del SP
                        statement.setString(1, "VLN");
                        statement.setString(2, null);
                        statement.setString(3, iban);
                        statement.setString(4, institucion);
                        statement.setString(5, null);
                        statement.setInt(6, producto);
                        statement.setInt(7, moneda);
                        statement.setInt(8, 0);
                        statement.setString(9, null);
                        // Ejecuta el SP y cierra el statement
                        rs = statement.executeQuery();
                        int i = 0;
                        String validacion = "";
                        while (rs.next()) {
                        	validacion = rs.getString("validacion");
                        	i = i + 1;
                        }                        
                        if (i > 0) {
                        	if (validacion.equals("1")){
                            	statement.close();
                                conn.close();
                                out.propagate(outAssembly, false);
                            }
                        }
                        else{
                        	MbElement padre2 = padre1.createElementAsLastChild(MbElement.TYPE_NAME, "EsbHeader", null);
                            padre2.createElementAsLastChild(MbElement.TYPE_NAME_VALUE, "Reason", "CUENTA SE ENCUENTRA EN LISTA NEGRA");
                            padre2.createElementAsLastChild(MbElement.TYPE_NAME_VALUE, "DetailRetCode", "CUENTA SE ENCUENTRA EN LISTA NEGRA");
                            padre2.createElementAsLastChild(MbElement.TYPE_NAME_VALUE, "Code", "4");
                            statement.close();
                            conn.close();
                            alt.propagate(outAssembly, false);
                        }
                        

            		}
            		catch(SQLException ex){
            			 // Genera el mensaje de respuesta
                           copyMessageHeaders(inMessage, outMessage);
                           String Final;
                           String code;
                          
                           if (ex.getMessage().equals("JZ0R2: No result set for this query."))
                           {
                               Final = "LA TRANSFERENCIA NO PUEDE SER PROCESADA";
                               code = "4";
                           }
                           else{
                            int inicio = ex.getMessage().indexOf("[");
                            int fin = ex.getMessage().indexOf("]", inicio + 1);
                               Final = ex.getMessage().substring(fin + 1,ex.getMessage().length());
                               code = "4";
                           }
                              
                            //MbElement padre1 = environment.getFirstElementByPath("Variables");
                            MbElement padre2 = padre1.createElementAsLastChild(MbElement.TYPE_NAME, "EsbHeader", null);
                            padre2.createElementAsLastChild(MbElement.TYPE_NAME_VALUE, "Reason", Final);
                            padre2.createElementAsLastChild(MbElement.TYPE_NAME_VALUE, "DetailRetCode", ex.getMessage());
                            padre2.createElementAsLastChild(MbElement.TYPE_NAME_VALUE, "Code", code);
                            alt.propagate(outAssembly, false);
            		}
                
			} catch (MbException e) {
			// Re-throw to allow Broker handling of MbException
            MbElement environment =  inAssembly.getGlobalEnvironment().getRootElement();
            MbElement padre1 = environment.getFirstElementByPath("Variables");
            MbElement padre2 = padre1.createElementAsLastChild(MbElement.TYPE_NAME, "EsbHeader", null);
            padre2.createElementAsLastChild(MbElement.TYPE_NAME_VALUE, "Reason", "En estos momentos no puede procesarse la consulta, por favor intentemás tarde.");
            padre2.createElementAsLastChild(MbElement.TYPE_NAME_VALUE, "DetailRetCode", e.getMessage());
           
            throw e;
		} catch (RuntimeException e) {
			MbElement environment =  inAssembly.getGlobalEnvironment().getRootElement();
            MbElement padre1 = environment.getFirstElementByPath("Variables");
            MbElement padre2 = padre1.createElementAsLastChild(MbElement.TYPE_NAME, "EsbHeader", null);
            padre2.createElementAsLastChild(MbElement.TYPE_NAME_VALUE, "Reason", "En estos momentos no puede procesarse la consulta, por favor intentemás tarde.");
            padre2.createElementAsLastChild(MbElement.TYPE_NAME_VALUE, "DetailRetCode", e.getMessage());
            throw e;
		} catch (Exception e) {
			MbElement environment =  inAssembly.getGlobalEnvironment().getRootElement();
            MbElement padre1 = environment.getFirstElementByPath("Variables");
            MbElement padre2 = padre1.createElementAsLastChild(MbElement.TYPE_NAME, "EsbHeader", null);
            padre2.createElementAsLastChild(MbElement.TYPE_NAME_VALUE, "Reason", "En estos momentos no puede procesarse la conuslta, por favor intentemás tarde.");
            padre2.createElementAsLastChild(MbElement.TYPE_NAME_VALUE, "DetailRetCode", e.getMessage());
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
