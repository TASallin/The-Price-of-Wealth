public class Warsong : Special {
	
	public Warsong () {name = "War Song"; description = "Party gains 3 charge and guard"; baseCost = 5; modifier = 0;}
	
	public override TimedMethod[] UseSupport(int i) {
		foreach (Character c in Party.members) {
			if (c != null && c.GetAlive()) {
				c.GainCharge(3); c.GainGuard(3);
			}
		}
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {Party.members[i].ToString() + " gave an inspiring song"})};
	}

}