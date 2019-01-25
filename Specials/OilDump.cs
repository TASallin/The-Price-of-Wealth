public class OilDump : Special {
	
	public OilDump() {name = "Oil Dump"; description = "Goop enemy and lower their defense"; baseCost = 2; modifier = 0;}
	
	public override TimedMethod[] Use () {
		if (Attacks.EvasionCycle(Party.GetPlayer(), Party.GetEnemy())) {
			Party.GetEnemy().GainDefense(-2);
		    return new TimedMethod[] {new TimedMethod(0, "Audio", new object[] {"Skill2"}), Party.GetEnemy().status.Goop()[0]};
		} else {
			return new TimedMethod[] {new TimedMethod(0, "Audio", new object[] {"Skill2"}), new TimedMethod(60, "Log", new object[] {"miss"})};
		}	
	}
}