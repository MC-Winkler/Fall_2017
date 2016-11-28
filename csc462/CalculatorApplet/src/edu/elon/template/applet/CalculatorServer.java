package edu.elon.template.applet;

import javax.naming.Context;
import javax.naming.InitialContext;

public class CalculatorServer {

	public static void main(String args[]) {
	    try {
	      System.out.println("Constructing server implementations...");

	      Calculator c1 = new CalculatorImplementation();

	      System.out.println("Binding server implementations to registry...");
	      Context namingContext = new InitialContext();
	      namingContext.bind("rmi:calculator", c1);
	      System.out.println("Waiting for invocations from clients...");
	    } catch (Exception e) {
	      e.printStackTrace();
	    }
	  }
	
}
