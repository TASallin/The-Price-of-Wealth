public class Feast : Special {
	
	public Feast () {name = "Feast"; description = "Restores 5 health to all party members"; baseCost = 7; modifier = 0; usableOut = true;}
	
	public override TimedMethod[] UseSupport (int i) {
		foreach (Character c in Party.members) {
			if (c != null && c.GetAlive()) {
				c.Heal(5);
			}
		}
	    return new TimedMethod[] {new TimedMethod(0, "Audio", new object[] {"Skill2"}), new TimedMethod(60, "Log", new object[] {"Party health +5"})};
	}
	
	public override void UseOutOfCombat () {
		Party.UseSP(GetCost());
		foreach (Character c in Party.members) {
			if (c != null) {
				c.Heal(5);
			}
		}
	}
	
}