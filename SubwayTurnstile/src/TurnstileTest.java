import static org.junit.Assert.*;

import org.junit.Test;

public class TurnstileTest {

	@Test
	public void testCoin() {
		Turnstile t1 = new Turnstile(true);
		AssertEquals("LOCKED", t1.getCurrentState().toString());
	}

	@Test
	public void testPass() {
		fail("Not yet implemented");
	}

}
