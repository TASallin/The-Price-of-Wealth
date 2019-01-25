public class Triage : Special {
	
	public Triage () {name = "Triage"; description = "Restore all party members to 1/2 hp, including unconscious ones"; baseCost = 20; modifier = 0;}
	
	public override TimedMethod[] Use () {
		foreach (Character c in Party.members) {
			if (c != null) {
				if (!c.GetAlive()) {
					Party.playerCount++;
				    c.SetAlive(true);
				}
				c.SetHealth(System.Math.Max(c.GetHealth(), c.GetMaxHP() / 2));
			}
		}
		return new TimedMethod[] {new TimedMethod(0, "Audio", new object[] {"Skill1"}),
		    new TimedMethod(60, "Log", new object[] {Party.GetPlayer().ToString() + " used all resources to heal"})};
	}
	
	public override void UseOutOfCombat () {
		Party.UseSP(GetCost());
		Use();
	}
}