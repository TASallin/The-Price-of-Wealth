public class Handcuffs : Special {
	
	public Handcuffs() {name = "Handcuffs"; description = "Switch in and goop the enemy"; baseCost = 2; modifier = 0;}
	
	public override TimedMethod[] UseSupport (int i) {
		TimedMethod[] goopPart;
		if (Attacks.EvasionCycle(Party.members[i], Party.GetEnemy())) {
		    goopPart = Party.GetEnemy().status.Goop();
		} else {
			goopPart = new TimedMethod[] {new TimedMethod(60, "Log", new object[] {"Miss"})};
		}
		return new TimedMethod[] {new TimedMethod(30, "SwitchTo", new object[] {i}), goopPart[0]};
	}
}