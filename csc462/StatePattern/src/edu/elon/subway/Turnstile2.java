package edu.elon.subway;

public class Turnstile2 {

	State unlockedState;
	State lockedState;
	State state;
	
	public Turnstile2() {
		unlockedState = new UnlockedState(this);
		lockedState = new LockedState(this);
		state = lockedState;
	}
	
	public String coin() {
		return state.coin();
	}
	
	public String pass() {
		return state.pass();
	}
		
	public State getUnlockedState() {
		return unlockedState;
	}
	
	public State getLockedState() {
		return lockedState;
	}
	
	public State getState() {
		return state;
	}
	
	public void setState(State state){
		this.state = state;
	}

}
