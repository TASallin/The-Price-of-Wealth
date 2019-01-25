using System;

public class Quote : Special {
	
	public Quote() {
		name = "Quote"; 
		description = "Party recovers from negative stats, poisoned, asleep, and stunned, gaining 3 charge. Cost to use this triples for the fight";
	    baseCost = 3;
		modifier = 0;
	}
	
	public override TimedMethod[] Use () {
		modifier += GetCost() * 2;
		foreach (Character c in Party.members) {
			if (c != null && c.GetAlive()) {
				c.SetPower(Math.Max(c.GetPower(), 0)); c.SetDefense(Math.Max(c.GetDefense(), 0));
				c.SetCharge(Math.Max(c.GetCharge() + 3, 3)); c.SetGuard(Math.Max(c.GetGuard(), 0));
				c.status.poisoned = 0; c.status.asleep = 0; c.status.stunned = 0;
			}
		}
		return new TimedMethod[] {new TimedMethod(0, "Audio", new object[] {"Skill1"}), 
		    new TimedMethod(60, "Log", new object[] {Party.GetPlayer().ToString() + " read an inspiring quote"})};
	}
}