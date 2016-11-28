package edu.elon.math;

public class ControllerImplementation implements ControllerInterface {
	
	ModelInterface model;
	CalculatorView view;
	
	public ControllerImplementation (ModelInterface model) {
		this.model = model;
		view = new CalculatorView(model, this);
	}

	@Override
	public void numberPressed(String input) {
		model.numberPressed(input);
	}

	@Override
	public void dividePressed() {
		model.setOperandOneCurrent();
		model.setOperation("divide");
		model.clearCurrentValue();
	}

	@Override
	public void multiplyPressed() {
		model.setOperandOneCurrent();
		model.setOperation("multiply");
		model.clearCurrentValue();
	}

	@Override
	public void subtractPressed() {
		model.setOperandOneCurrent();
		model.setOperation("subtract");
		model.clearCurrentValue();
	}

	@Override
	public void addPressed() {
		model.setOperandOneCurrent();
		model.setOperation("add");
		model.clearCurrentValue();
	}

	@Override
	public void decimalPointPressed() {
		model.decimalPoint();
	}

	@Override
	public void solvePressed() {
		model.setOperandTwoCurrent();
		model.solve();
	}

}