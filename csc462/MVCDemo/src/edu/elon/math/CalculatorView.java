package edu.elon.math;

import java.awt.BorderLayout;
import java.awt.Button;
import java.awt.Dimension;
import java.awt.FlowLayout;
import java.awt.GridLayout;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.rmi.RemoteException;
import java.util.Observable;
import java.util.Observer;

import javax.swing.BoxLayout;
import javax.swing.JFrame;
import javax.swing.JPanel;
import javax.swing.JTextField;

public class CalculatorView extends JFrame implements CalculatorObserver {
	
	ModelInterface model;
	ControllerInterface controller;
	JTextField inputField;

	public CalculatorView(ModelInterface model, ControllerInterface controller) {
		this.model = model;
		this.controller = controller;
		model.registerObserver(this);
		
		JFrame frame = new JFrame("Calculator");
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);

		inputField = new JTextField();
		inputField.setMaximumSize(new Dimension(Integer.MAX_VALUE, 1));

		JPanel buttonPanel = new JPanel();
		buttonPanel.setLayout(new GridLayout(4, 4));

		Button seven = new Button("7");
		seven.addActionListener(new ActionListener() {
			@Override
			public void actionPerformed(ActionEvent arg0) {
				controller.numberPressed("7");
			}
		});
		buttonPanel.add(seven);

		Button eight = new Button("8");
		eight.addActionListener(new ActionListener() {
			@Override
			public void actionPerformed(ActionEvent arg0) {
				controller.numberPressed("8");
			}
		});
		buttonPanel.add(eight);

		Button nine = new Button("9");
		nine.addActionListener(new ActionListener() {
			@Override
			public void actionPerformed(ActionEvent arg0) {
				controller.numberPressed("9");
			}
		});
		buttonPanel.add(nine);

		Button divide = new Button("/");
		divide.addActionListener(new ActionListener() {
			@Override
			public void actionPerformed(ActionEvent arg0) {
				controller.dividePressed();
			}
		});
		buttonPanel.add(divide);

		Button four = new Button("4");
		four.addActionListener(new ActionListener() {
			@Override
			public void actionPerformed(ActionEvent arg0) {
				controller.numberPressed("4");
			}
		});
		buttonPanel.add(four);

		Button five = new Button("5");
		five.addActionListener(new ActionListener() {
			@Override
			public void actionPerformed(ActionEvent arg0) {
				controller.numberPressed("5");
			}
		});
		buttonPanel.add(five);

		Button six = new Button("6");
		six.addActionListener(new ActionListener() {
			@Override
			public void actionPerformed(ActionEvent arg0) {
				controller.numberPressed("6");
			}
		});
		buttonPanel.add(six);

		Button multiply = new Button("*");
		multiply.addActionListener(new ActionListener() {
			@Override
			public void actionPerformed(ActionEvent arg0) {
				controller.multiplyPressed();
			}
		});
		buttonPanel.add(multiply);

		Button one = new Button("1");
		one.addActionListener(new ActionListener() {
			@Override
			public void actionPerformed(ActionEvent arg0) {
				controller.numberPressed("1");
			}
		});
		buttonPanel.add(one);

		Button two = new Button("2");
		two.addActionListener(new ActionListener() {
			@Override
			public void actionPerformed(ActionEvent arg0) {
				controller.numberPressed("2");
			}
		});
		buttonPanel.add(two);

		Button three = new Button("3");
		three.addActionListener(new ActionListener() {
			@Override
			public void actionPerformed(ActionEvent arg0) {
				controller.numberPressed("3");
			}
		});
		buttonPanel.add(three);

		Button subtract = new Button("-");
		subtract.addActionListener(new ActionListener() {
			@Override
			public void actionPerformed(ActionEvent arg0) {
				controller.subtractPressed();
			}
		});
		buttonPanel.add(subtract);

		Button zero = new Button("0");
		zero.addActionListener(new ActionListener() {
			@Override
			public void actionPerformed(ActionEvent arg0) {
				controller.numberPressed("0");
			}
		});
		buttonPanel.add(zero);

		Button decimalPoint = new Button(".");
		decimalPoint.addActionListener(new ActionListener() {
			@Override
			public void actionPerformed(ActionEvent arg0) {
				controller.decimalPointPressed();
			}
		});
		buttonPanel.add(decimalPoint);

		Button equals = new Button("=");
		equals.addActionListener(new ActionListener() {
			@Override
			public void actionPerformed(ActionEvent arg0) {
				controller.solvePressed();
			}
		});
		buttonPanel.add(equals);

		Button add = new Button("+");
		add.addActionListener(new ActionListener() {
			@Override
			public void actionPerformed(ActionEvent arg0) {
				controller.addPressed();
			}
		});
		buttonPanel.add(add);

		frame.add(inputField, BorderLayout.NORTH);
		frame.add(buttonPanel, BorderLayout.CENTER);

		frame.setVisible(true);
	}

	@Override
	public void update() {
		String currentValue = model.getCurrentValue();
		inputField.setText(currentValue);
	}

}