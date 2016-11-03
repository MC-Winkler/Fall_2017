package edu.elon.subway;

public class Turnstile2 {

	State unlockedState;
	State lockedState;
	State state = lockedState;
	
	public Turnstile2() {
		unlockedState = new UnlockedState(this);
		lockedState = new LockedState(this);
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
