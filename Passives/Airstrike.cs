public class Airstrike : Passive {
	
	int counter;
	
	public Airstrike (Character c) {self = c; name = "Air-Strike"; description = "Calls in an accurate and powerful missile that lands after 5 turns";}
	
	public override TimedMethod[] Initialize (bool player) {
		counter = 5;
		return new TimedMethod[0];
	}

	public override TimedMethod[] Check (bool player) {
		if (counter > 0) {
			counter--;
			return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {(counter + 1).ToString() + " turns until the air-strike"})};
		} else if (counter == 0) {
			counter = -1;
			return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {"The missile has landed!"}),
			    new TimedMethod(60, "StagnantAttack", new object[] {player, 15, 15, 30, false, true, false})};
		} else {
			return new TimedMethod[0];
		}
	}
	
	public override TimedMethod[] CheckLead (bool player) {
		return Check(player);
	}
	
	public override TimedMethod[] Deactivate (bool player) {
	    if (counter > 0) {
			return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {"The missile lost its target"})};
		}
		return new TimedMethod[0];
	}
	
}