package edu.elon.subway;

class Turnstile1 {

	private MachineState state;
	
	public enum MachineState {
		LOCKED, UNLOCKED
	}
	
	public Turnstile1(){
		this.state = MachineState.LOCKED;
	}
	
	public MachineState getState () {
		return this.state;
	}
	
	public String coin() {
		if (state == MachineState.LOCKED){
			System.out.println("unlocking");
			state = MachineState.UNLOCKED;
			return "unlocking";
		} else {
			System.out.println("triggering thank you light");
			return "triggering thank you light";
		}
	}
	
	public String pass() {
		if (state == MachineState.LOCKED){
			System.out.println("triggering alarm");
			return "triggering alarm";
		} else {
			System.out.println("letting patron through");
			state = MachineState.LOCKED;
			return "letting patron through";
		}
	}
	
}
