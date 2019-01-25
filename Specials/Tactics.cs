public class Tactics : Special {
	
	public Tactics () {name = "Tactics"; description = "Party gains 2 accuracy and 4 evasion"; baseCost  = 4; modifier = 0;}
	
	public override TimedMethod[] UseSupport(int i) {
		foreach (Character c in Party.members) {
			if (c != null & c.GetAlive()) {
				c.GainAccuracy(2);
				c.GainEvasion(4);
			}
		}
		return new TimedMethod[] {new TimedMethod(0, "Audio", new object[] {"Skill2"}), 
		    new TimedMethod(60, "Log", new object[] {Party.members[i].ToString() + " implemented tactics"})};
	}
}