package edu.elon.subway;

import static org.junit.Assert.*;

import org.junit.Test;

public class Turnstile2Test {

	@Test
	public void testCoin() {
		Turnstile2 t = new Turnstile2();
		assertEquals(t.getState().toString(), "LOCKED");
		assertEquals(t.coin(), "unlocking");
		assertEquals(t.getState().toString(), "UNLOCKED");
		assertEquals(t.coin(), "triggering thank you light");
		assertEquals(t.getState().toString(), "UNLOCKED");
	}

	@Test
	public void testPass() {
		Turnstile2 t = new Turnstile2();
		assertEquals(t.getState().toString(), "LOCKED");
		assertEquals(t.pass(), "triggering alarm");
		assertEquals(t.getState().toString(), "LOCKED");
		assertEquals(t.coin(), "unlocking");
		assertEquals(t.getState().toString(), "UNLOCKED");
		assertEquals(t.pass(), "letting patron through");
		assertEquals(t.getState().toString(), "LOCKED");
	}

}
