import java.sql.CallableStatement;
import java.sql.Connection;
import java.sql.SQLException;
import java.sql.ResultSet;
import java.sql.Types;
import java.text.DecimalFormat;

import com.ibm.broker.javacompute.MbJavaComputeNode;
import com.ibm.broker.plugin.MbElement;
import com.ibm.broker.plugin.MbException;
import com.ibm.broker.plugin.MbMessage;
import com.ibm.broker.plugin.MbMessageAssembly;
import com.ibm.broker.plugin.MbOutputTerminal;
import com.ibm.broker.plugin.MbXMLNSC;

public class CA_ACH_RealizarTransferencia001_REQ_RegistraTransferencia extends
		MbJavaComputeNode {

	public void evaluate(MbMessageAssembly inAssembly) throws MbException {
		MbOutputTerminal out = getOutputTerminal("out");
		MbOutputTerminal alt = getOutputTerminal("alternate");
		MbMessage inMessage = inAssembly.getMessage();
		 
		MbMessageAssembly outAssembly = null;
		//VARIABLES DE CONECCION
		String configurableService = "gt_integrador";
		MbElement outRoot = null;
		ResultSet rs = null; 
		String codigo ;
    	String desc ;
        
		try {
			MbMessage outMessage = new MbMessage(inMessage);
			outAssembly = new MbMessageAssembly(inAssembly, outMessage);
			 
			//Obtener variable global			
			MbElement environment =  inAssembly.getGlobalEnvironment().getRootElement();
			 
//			String OriginatorIdentification = environment.getFirstElementByPath("DatosBitacora/OriginatorIdentification").getValue().toString();
//			String ParticipantName = environment.getFirstElementByPath("DatosBitacora/ParticipantName").getValue().toString();
//			String ParticipantIdentification = environment.getFirstElementByPath("DatosBitacora/ParticipantIdentification").getValue().toString();
			String FinancialInstitutionIdentification = environment.getFirstElementByPath("DatosBitacora/FinancialInstitutionIdentification").getValue().toString();
			String AccountNumber = environment.getFirstElementByPath("DatosBitacora/AccountNumber").getValue().toString();
//			String AccountType = environment.getFirstElementByPath("DatosBitacora/AccountType").getValue().toString();
			//String Amount = environment.getFirstElementByPath("DatosBitacora/Amount").getValue().toString();
			Double Amount = Double.valueOf(environment.getFirstElementByPath("DatosBitacora/Amount").getValue().toString());
			String TransactionType = environment.getFirstElementByPath("DatosBitacora/TransactionType").getValue().toString();
			String OriginAccountNumber = environment.getFirstElementByPath("DatosBitacora/OriginAccountNumber").getValue().toString();
//			String OriginAccountType = environment.getFirstElementByPath("DatosBitacora/OriginAccountType").getValue().toString();
			String TransactionProcessing = environment.getFirstElementByPath("DatosBitacora/TransactionProcessing").getValue().toString();
			//String AccountStandard = environment.getFirstElementByPath("DatosBitacora/AccountStandard").getValue().toString();
			String Description = environment.getFirstElementByPath("DatosBitacora/Description").getValue().toString();
//			String inst_financiera = environment.getFirstElementByPath("DatosBitacora/inst_financiera").getValue().toString();
//			String nom_cta_dest = environment.getFirstElementByPath("DatosBitacora/nom_cta_dest").getValue().toString();
			String moneda = environment.getFirstElementByPath("DatosBitacora/moneda").getValue().toString();
			String mis = environment.getFirstElementByPath("DatosBitacora/mis").getValue().toString();	
			String nombre_prod = environment.getFirstElementByPath("Variables/nombre_producto").getValue().toString();
			String digito_verif = environment.getFirstElementByPath("DatosInsfinanciera/digito_verif").getValue().toString();
			String adenda = environment.getFirstElementByPath("DatosAdenda/adenda").getValue().toString(); 
			String tran_code = environment.getFirstElementByPath("DatosTran/transaction_code").getValue().toString(); 
			String NomctaDest = environment.getFirstElementByPath("DatosBitacora/nom_cta_dest").getValue().toString(); //celd 11Ago2022
			String operacion;
			
			//CODIGO PARA DAR EL FORMATO QUE NECESITA LA BASE DE DATOS PARA EL MONTO DE LA TRANSFERENCIA
			DecimalFormat df = new DecimalFormat("0.00");
	        double inputAmount = Double.valueOf(Amount);
	        String AmountDecimal = df.format(inputAmount);
	        boolean isFound = AmountDecimal.indexOf(".") != -1 ? true : false;
	        String AmountNotPoint = "";
	        
	        if(isFound == true){
	            AmountNotPoint = AmountDecimal.replace(".", "");
	        }else{
	            AmountNotPoint = AmountDecimal + "00";
	        }
	        
			  
			if ( TransactionProcessing.toUpperCase().equals("ACH"))
			{
				operacion = "ACH";
			}else
			{
				operacion = "IFT";
			}
			
			//Integer retorno;
            String spCall = "exec gt_integrador..sp_ach_registra_transferencia " + "?,?,?,?,?,?,?,?,?,?,?,?,?,?,?";
            
            try {    
                // Realiza la conexión a la BD a través del Servicio Configurable
                Connection conn = getJDBCType4Connection(configurableService, JDBC_TransactionType.MB_TRANSACTION_AUTO);
                conn.setAutoCommit(true);
                // Prepara la llamada al SP
                CallableStatement statement = conn.prepareCall(spCall);
                // Setea los parámetros del SP
                //statement.registerOutParameter(1, java.sql.Types.INTEGER);                
                statement.setString(1, operacion); //@i_operacion char
                //statement.setString(2, Amount); //@i_Amount	varchar
                statement.setString(2, AmountNotPoint); //@i_Amount	varchar
                statement.setString(3,AccountNumber ); //@i_DfiAccountNumber	varchar
                statement.setNull(4,Types.VARCHAR ); //@i_DiscretionaryData	varchar
                statement.setString(5,OriginAccountNumber ); //@i_OriginatorAccount	varchar
                statement.setString(6,FinancialInstitutionIdentification );    //@i_ReceivingDfiId	varchar
                statement.setInt(7, Integer.parseInt(tran_code)); //@i_TransactionCode	int
                statement.setInt(8, Integer.parseInt(TransactionType)); //@i_TranType	int
                statement.setString(9,mis ); //@i_IndividualId	varchar
                statement.setString(10,nombre_prod ); //@i_IndividualName	varchar
                statement.setString(11,moneda ); //@i_moneda   varchar
                statement.setInt(12,Integer.parseInt(digito_verif) ); //@i_digito_ef
                statement.setString(13,adenda); //@i_adenda   varchar
                statement.setString(14,Description); //@i_adenda   varchar 
                statement.setString(15,NomctaDest );
                
                // Ejecuta el SP y cierra el statement
                rs = statement.executeQuery();
                                                                                                                 
                rs.next();
                           
                	codigo = rs.getString(1);
                	desc = rs.getString(2);
                	// Genera el mensaje de respuesta
                    outRoot = outMessage.getRootElement();                
                    MbElement outBody = outRoot.createElementAsLastChild(MbXMLNSC.PARSER_NAME);                
                    MbElement ConsultaRecResponse = outBody.createElementAsLastChild(MbElement.TYPE_NAME, "realizar_transferenciaResponse", null);
                    MbElement resultado_datos = ConsultaRecResponse.createElementAsLastChild(MbElement.TYPE_NAME, "resultado", null);
                                          	                	
                    resultado_datos.createElementAsFirstChild(MbElement.TYPE_NAME,"Codigo",codigo);
                    resultado_datos.createElementAsLastChild(MbElement.TYPE_NAME, "Descripcion",desc);                                	                	                	                                                                                                           
               
                    	 //Variables Environment para peticiones positivas
                        MbElement padre1 = environment.getFirstElementByPath("Variables");
                        MbElement padre2 = padre1.createElementAsLastChild(MbElement.TYPE_NAME, "EsbHeader", null);
                        padre2.createElementAsLastChild(MbElement.TYPE_NAME_VALUE, "Reason", "Transferencia realizada con éxito");
                    
                   
                    copyMessageHeaders(inMessage, outMessage);
                	rs.close();
                	statement.close();
                    
                	out.propagate(outAssembly, false);
               
                
            } catch (SQLException ex) {                
                // Genera el mensaje de respuesta
               copyMessageHeaders(inMessage, outMessage); 	                                       
                MbElement padre1 = environment.getFirstElementByPath("Variables");
                MbElement padre2 = padre1.createElementAsLastChild(MbElement.TYPE_NAME, "EsbHeader", null);
                MbElement padre3 = padre2.createElementAsLastChild(MbElement.TYPE_NAME_VALUE, "Reason", "Ocurrió un error al realizar la transferencia");
                MbElement padre4 = padre2.createElementAsLastChild(MbElement.TYPE_NAME_VALUE, "DetailRetCode", ex.getMessage());
                padre2.createElementAsLastChild(MbElement.TYPE_NAME_VALUE, "Code", "4");
                alt.propagate(outAssembly, false);
            }            
		} catch (MbException e) {
			// Re-throw to allow Broker handling of MbException
			MbElement environment =  inAssembly.getGlobalEnvironment().getRootElement();
			MbElement padre1 = environment.getFirstElementByPath("Variables");
            MbElement padre2 = padre1.createElementAsLastChild(MbElement.TYPE_NAME, "EsbHeader", null);
            MbElement padre3 = padre2.createElementAsLastChild(MbElement.TYPE_NAME_VALUE, "Reason", "En estos momentos no puede procesarse la transferencia, por favor intentemás tarde.");
            MbElement padre4 = padre2.createElementAsLastChild(MbElement.TYPE_NAME_VALUE, "DetailRetCode", e.getMessage());
            
            throw e;
		} catch (RuntimeException e) {
			MbElement environment =  inAssembly.getGlobalEnvironment().getRootElement();
			MbElement padre1 = environment.getFirstElementByPath("Variables");
            MbElement padre2 = padre1.createElementAsLastChild(MbElement.TYPE_NAME, "EsbHeader", null);
            MbElement padre3 = padre2.createElementAsLastChild(MbElement.TYPE_NAME_VALUE, "Reason", "En estos momentos no puede procesarse la transferencia, por favor intente más tarde.");
            MbElement padre4 = padre2.createElementAsLastChild(MbElement.TYPE_NAME_VALUE, "DetailRetCode", e.getMessage());
            throw e;
		} catch (Exception e) {
			MbElement environment =  inAssembly.getGlobalEnvironment().getRootElement();
			MbElement padre1 = environment.getFirstElementByPath("Variables");
            MbElement padre2 = padre1.createElementAsLastChild(MbElement.TYPE_NAME, "EsbHeader", null);
            MbElement padre3 = padre2.createElementAsLastChild(MbElement.TYPE_NAME_VALUE, "Reason", "En estos momentos no puede procesarse la transferencia, por favor intentemás tarde.");
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
