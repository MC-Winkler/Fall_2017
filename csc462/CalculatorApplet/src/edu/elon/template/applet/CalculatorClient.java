package edu.elon.template.applet;

import javax.naming.Context;
import javax.naming.InitialContext;

public class CalculatorClient {

	public static void main(String[] args) {
	    System.setProperty("java.security.policy", "client.policy");
	    System.setSecurityManager(new SecurityManager());
	    String url = "rmi://localhost/";
	    if (args.length == 1) {
	      url = "rmi://" + args[0] + "/";
	    }
	    // change to "rmi://yourserver.com/"
	    // when server runs on remote machine yourserver.com
	    try {
	      Context namingContext = new InitialContext();
	      Calculator c1 = (Calculator) namingContext.lookup(url + "calculator");
	      CalculatorGUI c2 = new CalculatorGUI(c1);

	    } catch (Exception e) {
	      e.printStackTrace();
	    }
	  }
	
}
