package edu.elon.subway;

public class LockedState implements State {

	private Turnstile2 turnstile;
	
	public LockedState (Turnstile2 t) {
		this.turnstile = t;
	}
	
	@Override
	public String coin() {
		turnstile.setState(turnstile.getUnlockedState());
		return "unlocking";
	}

	@Override
	public String pass() {
		return "triggering alarm";
	}
	
	public String toString() {
		return "LOCKED";
	}

}
