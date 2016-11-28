package edu.elon.template.applet;

import java.awt.Button;
import java.awt.Dimension;
import java.awt.GridLayout;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

import javax.swing.BoxLayout;
import javax.swing.JApplet;
import javax.swing.JPanel;
import javax.swing.JTextField;

public class CalculatorApplet extends JApplet {

	private double operandOne;
	private String operationToCompute;
	
	@Override
	public void init() {
		JTextField inputField = new JTextField();
		inputField.setMaximumSize(new Dimension(Integer.MAX_VALUE,
				1));
		
		JPanel buttonPanel = new JPanel();
		buttonPanel.setLayout(new GridLayout(4,4));
		
		Button seven = new Button("7");
		seven.addActionListener(new ActionListener(){
			@Override
			public void actionPerformed(ActionEvent arg0) {
				inputField.setText(inputField.getText() + "7");
			}
		});
		buttonPanel.add (seven);
		
		Button eight = new Button("8");
		eight.addActionListener(new ActionListener(){
			@Override
			public void actionPerformed(ActionEvent arg0) {
				inputField.setText(inputField.getText() + "8");
			}
		});
		buttonPanel.add (eight);
		
		Button nine = new Button("9");
		nine.addActionListener(new ActionListener(){
			@Override
			public void actionPerformed(ActionEvent arg0) {
				inputField.setText(inputField.getText() + "9");
			}
		});
		buttonPanel.add (nine);
		
		Button divide = new Button("/");
		divide.addActionListener(new ActionListener(){
			@Override
			public void actionPerformed(ActionEvent arg0) {
				operandOne = Double.parseDouble(inputField.getText());
				operationToCompute = "divide";
				inputField.setText("");
			}
		});
		buttonPanel.add (divide);
		
		Button four = new Button("4");
		four.addActionListener(new ActionListener(){
			@Override
			public void actionPerformed(ActionEvent arg0) {
				inputField.setText(inputField.getText() + "4");
			}
		});
		buttonPanel.add (four);
		
		Button five = new Button("5");
		five.addActionListener(new ActionListener(){
			@Override
			public void actionPerformed(ActionEvent arg0) {
				inputField.setText(inputField.getText() + "5");
			}
		});
		buttonPanel.add (five);
		
		Button six = new Button("6");
		six.addActionListener(new ActionListener(){
			@Override
			public void actionPerformed(ActionEvent arg0) {
				inputField.setText(inputField.getText() + "6");
			}
		});
		buttonPanel.add (six);
		
		Button multiply = new Button("*");
		multiply.addActionListener(new ActionListener(){
			@Override
			public void actionPerformed(ActionEvent arg0) {
				operandOne = Double.parseDouble(inputField.getText());
				operationToCompute = "multiply";
				inputField.setText("");
			}
		});
		buttonPanel.add (multiply);
		
		Button one = new Button("1");
		one.addActionListener(new ActionListener(){
			@Override
			public void actionPerformed(ActionEvent arg0) {
				inputField.setText(inputField.getText() + "1");
			}
		});
		buttonPanel.add (one);
		
		Button two = new Button("2");
		two.addActionListener(new ActionListener(){
			@Override
			public void actionPerformed(ActionEvent arg0) {
				inputField.setText(inputField.getText() + "2");
			}
		});
		buttonPanel.add (two);
		
		Button three = new Button("3");
		three.addActionListener(new ActionListener(){
			@Override
			public void actionPerformed(ActionEvent arg0) {
				inputField.setText(inputField.getText() + "3");
			}
		});
		buttonPanel.add (three);
		
		Button subtract = new Button("-");
		subtract.addActionListener(new ActionListener(){
			@Override
			public void actionPerformed(ActionEvent arg0) {
				operandOne = Double.parseDouble(inputField.getText());
				operationToCompute = "subtract";
				inputField.setText("");
			}
		});
		buttonPanel.add (subtract);
		
		Button zero = new Button("0");
		zero.addActionListener(new ActionListener(){
			@Override
			public void actionPerformed(ActionEvent arg0) {
				inputField.setText(inputField.getText() + "0");
			}
		});
		buttonPanel.add (zero);
		
		Button decimalPoint = new Button(".");
		decimalPoint.addActionListener(new ActionListener(){
			@Override
			public void actionPerformed(ActionEvent arg0) {
				inputField.setText(inputField.getText() + ".");
			}
		});
		buttonPanel.add (decimalPoint);
		
		Button equals = new Button("=");
		equals.addActionListener(new ActionListener(){
			@Override
			public void actionPerformed(ActionEvent arg0) {
				double operandTwo = Double.parseDouble(inputField.getText());
				double result = 0.0;
				if (operationToCompute.equals("add")){
					result = operandTwo+operandOne;
				} else if (operationToCompute.equals("subtract")){
					result= operandOne - operandTwo;
				} else if (operationToCompute.equals("multiply")){
					result= operandOne * operandTwo;
				} else if (operationToCompute.equals("divide")){
					result= operandOne / operandTwo;
				}
				inputField.setText(Double.toString(result));
			}
		});
		buttonPanel.add (equals);
		
		Button add = new Button("+");
		add.addActionListener(new ActionListener(){
			@Override
			public void actionPerformed(ActionEvent arg0) {
				operandOne = Double.parseDouble(inputField.getText());
				operationToCompute = "add";
				inputField.setText("");
			}
		});
		buttonPanel.add (add);
		
		setLayout(new BoxLayout(getContentPane(),BoxLayout.PAGE_AXIS));
		
		
		add(inputField);
		add(buttonPanel);
	}
	
}
