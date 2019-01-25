public class Rally : Special {
    
    public Rally() {name = "Rally"; description = "team gains 1 power"; baseCost = 2; modifier = 0;}

    public override TimedMethod[] UseSupport(int i) {
		foreach (Character c in Party.members) {
		    if (c != null && c.GetAlive()) {
		        c.SetPower(c.GetPower() + 1);
			}
		}
		return new TimedMethod[] {new TimedMethod(0, "Audio", new object[] {"Skill2"}), 
		    new TimedMethod(60, "Log", new object[] {"All party members gained 1 power"})};
    }		
} 