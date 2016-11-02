
public class Turnstile {

	private MachineState currentState;

	public MachineState getCurrentState() {
		return currentState;
	}

	public enum MachineState {
		LOCKED, UNLOCKED
	};

	public Turnstile(boolean initiallyLocked) {
		if (initiallyLocked) {
			this.currentState = MachineState.LOCKED;
		} else {
			this.currentState = MachineState.UNLOCKED;
		}
	}

	public String coin() {
		if (currentState == MachineState.LOCKED) {
			System.out.println("unlocking");
			currentState = MachineState.UNLOCKED;
			return "unlocking";
		} else {
			System.out.println("triggering 'thank you' light");
			return "triggering 'thank you' light";
		}
	}

	public String pass() {
		if (currentState == MachineState.LOCKED) {
			System.out.println("triggering alarm");
			return ("triggering alarm");
		} else {
			System.out.println("locking");
			currentState = MachineState.LOCKED;
			return "locking";
		}
	}
}
