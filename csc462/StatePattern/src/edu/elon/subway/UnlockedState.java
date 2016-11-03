package edu.elon.subway;

public class UnlockedState implements State {

	private Turnstile2 turnstile;
	
	public UnlockedState (Turnstile2 t) {
		this.turnstile = t;
	}
	
	@Override
	public String coin() {
		return "triggering thank you light";
	}

	@Override
	public String pass() {
		turnstile.setState(turnstile.getLockedState());
		return "triggering alarm";
	}

}
