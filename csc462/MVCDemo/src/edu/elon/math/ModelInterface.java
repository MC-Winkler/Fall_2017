package edu.elon.math;

import java.util.Observer;

public interface ModelInterface {
	
	void numberPressed (String input);
	
	void divide();
	
	void multiply();
	
	void subtract();
	
	void add();
	
	void solve();
	
	void decimalPoint();
	
	void setOperandOneCurrent();
	
	void setOperandTwoCurrent();
	
	void setOperation(String operation);
	
	void registerObserver(CalculatorObserver o);
	
	void removeObserver (CalculatorObserver o);
	
	void notifyObservers();
	
	String getCurrentValue();
	
	void clearCurrentValue();
}