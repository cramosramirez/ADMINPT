import java.util.UUID;

import com.ibm.broker.javacompute.MbJavaComputeNode;
import com.ibm.broker.plugin.MbElement;
import com.ibm.broker.plugin.MbException;
import com.ibm.broker.plugin.MbMessage;
import com.ibm.broker.plugin.MbMessageAssembly;
import com.ibm.broker.plugin.MbOutputTerminal;
import com.ibm.broker.plugin.MbUserException;


public class PostVerificarICG_Generar_UUID extends MbJavaComputeNode {

	public void evaluate(MbMessageAssembly inAssembly) throws MbException {
		MbOutputTerminal out = getOutputTerminal("out");
		//MbOutputTerminal alt = getOutputTerminal("alternate");

		MbMessage inMessage = inAssembly.getMessage();
		MbMessageAssembly outAssembly = null;
		try {
			// create new message as a copy of the input
			MbMessage outMessage = new MbMessage(inMessage);
			outAssembly = new MbMessageAssembly(inAssembly, outMessage);
			MbElement environment =  inAssembly.getGlobalEnvironment().getRootElement();
			UUID uuid = UUID.randomUUID();
	        String uuidAsString = uuid.toString();
	        
	        MbElement padre1 = environment.getFirstElementByPath("Variables");
            padre1.createElementAsLastChild(MbElement.TYPE_NAME_VALUE, "UUID", uuidAsString).getValueAsString();
            
            copyMessageHeaders(inMessage, outMessage);
        	out.propagate(outAssembly, false);
        	
		} catch (MbException e) {
			// Re-throw to allow Broker handling of MbException
			throw e;
		} catch (RuntimeException e) {
			// Re-throw to allow Broker handling of RuntimeException
			throw e;
		} catch (Exception e) {
			// Consider replacing Exception with type(s) thrown by user code
			// Example handling ensures all exceptions are re-thrown to be handled in the flow
			throw new MbUserException(this, "evaluate()", "", "", e.toString(),
					null);
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
