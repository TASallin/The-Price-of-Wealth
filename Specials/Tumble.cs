public class Tumble : Special {
	
	public Tumble() {name = "Tumble"; description = "Double your evasion"; baseCost = 3; modifier = 0;}
	
	public override TimedMethod[] Use () {
		Party.GetPlayer().SetEvasion(Party.GetPlayer().GetEvasion() * 2);
		return new TimedMethod[] {new TimedMethod(0, "Audio", new object[] {"Skill1"}),
		    new TimedMethod(60, "Log", new object[] {"Evasion was doubled"})};
	}
}