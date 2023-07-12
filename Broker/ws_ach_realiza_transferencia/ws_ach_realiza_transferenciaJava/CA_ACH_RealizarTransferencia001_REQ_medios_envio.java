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

public class CA_ACH_RealizarTransferencia001_REQ_medios_envio extends
		MbJavaComputeNode {

	 public void evaluate(MbMessageAssembly inAssembly) throws MbException {
	        MbOutputTerminal out = getOutputTerminal("out");
	        MbOutputTerminal alt = getOutputTerminal("alternate");

	        MbMessage inMessage = inAssembly.getMessage();
	        MbMessageAssembly outAssembly = null;
	        //VARIABLES DE CONECCION
	        
	        
	        try {
	            // create new message as a copy of the input
	            MbMessage outMessage = new MbMessage(inMessage);
	            outAssembly = new MbMessageAssembly(inAssembly, outMessage);
	            //Obtener variable global
	            MbElement environment =  inAssembly.getGlobalEnvironment().getRootElement();
	            //Integer login= Integer.parseInt(environment.getFirstElementByPath("Variables/mis").getValue().toString());
	            //String strLogin= environment.getFirstElementByPath("Variables/mis").getValue().toString();
	            Integer originador = Integer.parseInt(environment.getFirstElementByPath("Variables/mis").getValue().toString());
	            String OriginatorIdentification = environment.getFirstElementByPath("Variables/originador").getValue().toString();
	            Integer tipoUsuario= Integer.parseInt(environment.getFirstElementByPath("Variables/tipoUsuario").getValue().toString());
	            MbElement padre1 = environment.getFirstElementByPath("Variables");
	                try{
	                    if(tipoUsuario == 1){
	                        String configurableService = "COB_BVIRTUAL";
	                        String spCall = "exec cob_bvirtual..sp_be_envio_notificacion  " + "?.?";
	                        ResultSet rs = null;
	                        // Realiza la conexión a la BD a través del Servicio Configurable
	                        Connection conn = getJDBCType4Connection(configurableService, JDBC_TransactionType.MB_TRANSACTION_AUTO);
	                        conn.setAutoCommit(true);
	                        // Prepara la llamada al SP
	                        CallableStatement statement = conn.prepareCall(spCall);
	                        
	                        // Setea los parámetros del SP
	                        statement.setInt(1, originador);
	                        statement.setInt(2, 29);
	                        // Ejecuta el SP y cierra el statement
	                        rs = statement.executeQuery();
	                        int i = 0;
	                        String celular = "";
	                        String mensaje = "";
	                        while (rs.next()) {
	                            celular = rs.getString(3);
	                            mensaje = rs.getString(1);
	                            i = i + 1;
	                        }                        
	                        if (i > 0) {
	                            padre1.createElementAsLastChild(MbElement.TYPE_NAME_VALUE, "celular", celular).getValueAsString();
	                            padre1.createElementAsLastChild(MbElement.TYPE_NAME_VALUE, "mensaje", mensaje).getValueAsString();
	                            statement.close();
	                            conn.close();
	                            out.propagate(outAssembly, false);                        
	                        }
	                        else{
	                            MbElement padre2 = padre1.createElementAsLastChild(MbElement.TYPE_NAME, "EsbHeader", null);
	                            padre2.createElementAsLastChild(MbElement.TYPE_NAME_VALUE, "Reason", "LA TRANSFERENCIA NO PUEDE SER PROCESADA");
	                            padre2.createElementAsLastChild(MbElement.TYPE_NAME_VALUE, "DetailRetCode", "LA TRANSFERENCIA NO PUEDE SER PROCESADA");
	                            padre2.createElementAsLastChild(MbElement.TYPE_NAME_VALUE, "Code", "4");
	                            statement.close();
	                            conn.close();
	                            alt.propagate(outAssembly, false);
	                        }
	                    }else if(tipoUsuario == 2){
	                            String configurableService = "COB_BVIRTUAL";
	                            String spCall = "exec cob_bvirtual..sp_be_envio_notificacion  " + "?.?";
	                            ResultSet rs = null;
	                            // Realiza la conexión a la BD a través del Servicio Configurable
	                            Connection conn = getJDBCType4Connection(configurableService, JDBC_TransactionType.MB_TRANSACTION_AUTO);
	                            conn.setAutoCommit(true);
	                            // Prepara la llamada al SP
	                            CallableStatement statement = conn.prepareCall(spCall);
	                            statement.setInt(1, originador);
	                            statement.setInt(2, 29);
	                            rs = statement.executeQuery();
	                            int i = 0;
	                            String celular = "";
	                            String mensaje = "";
	                            while (rs.next()) {
	                                //celular = rs.getString(3);
	                                mensaje = rs.getString(1);
	                                i = i + 1;
	                            }                        
	                            if (i > 0) {
	                                //padre1.createElementAsLastChild(MbElement.TYPE_NAME_VALUE, "celular", celular).getValueAsString();
	                                padre1.createElementAsLastChild(MbElement.TYPE_NAME_VALUE, "mensaje", mensaje).getValueAsString();
	                                statement.close();
	                                //conn.close();
	                                //out.propagate(outAssembly, false);                        
	                            }
	                            else{
	                                MbElement padre2 = padre1.createElementAsLastChild(MbElement.TYPE_NAME, "EsbHeader", null);
	                                padre2.createElementAsLastChild(MbElement.TYPE_NAME_VALUE, "Reason", "LA TRANSFERENCIA NO PUEDE SER PROCESADA");
	                                padre2.createElementAsLastChild(MbElement.TYPE_NAME_VALUE, "DetailRetCode", "LA TRANSFERENCIA NO PUEDE SER PROCESADA");
	                                padre2.createElementAsLastChild(MbElement.TYPE_NAME_VALUE, "Code", "4");
	                                statement.close();
	                                conn.close();
	                                alt.propagate(outAssembly, false);
	                            }
	                            //OBTENER NUMERO DE TELEFONO EN EMPRESARIAL FINFUS
	                            String configurableServiceFinfus = "FINFUS";
	                            spCall = "exec cebs8qa..sp_ffi_tadmin_web  " + "?.?";
	                            //spCall = "exec finfus..sp_ffi_tadmin_web  " + "?.?";
	                            Connection connFinfus = getJDBCType4Connection(configurableServiceFinfus, JDBC_TransactionType.MB_TRANSACTION_AUTO);
	                            connFinfus.setAutoCommit(true);
	                            statement = connFinfus.prepareCall(spCall);
	                            statement.setInt(1, 30005);
	                            statement.setString(2, OriginatorIdentification);
	                            rs = statement.executeQuery();
	                            i = 0;
	                            while (rs.next()) {
	                                celular = rs.getString(1);
	                                //mensaje = rs.getString(1);
	                                i = i + 1;
	                            } 
	                            if (i > 0) {
	                                padre1.createElementAsLastChild(MbElement.TYPE_NAME_VALUE, "celular", celular).getValueAsString();
	                                statement.close();
	                                conn.close();
	                                connFinfus.close();
	                                out.propagate(outAssembly, false);                        
	                            }
	                            else{
	                                MbElement padre2 = padre1.createElementAsLastChild(MbElement.TYPE_NAME, "EsbHeader", null);
	                                padre2.createElementAsLastChild(MbElement.TYPE_NAME_VALUE, "Reason", "LA TRANSFERENCIA NO PUEDE SER PROCESADA");
	                                padre2.createElementAsLastChild(MbElement.TYPE_NAME_VALUE, "DetailRetCode", "LA TRANSFERENCIA NO PUEDE SER PROCESADA");
	                                padre2.createElementAsLastChild(MbElement.TYPE_NAME_VALUE, "Code", "4");
	                                statement.close();
	                                conn.close();
	                                alt.propagate(outAssembly, false);
	                            }
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
