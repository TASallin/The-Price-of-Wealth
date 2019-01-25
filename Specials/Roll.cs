public class Roll : Special {
	
	public Roll() {name = "Roll"; description = "Gain 8 evasion"; baseCost = 1; modifier = 0;}
	
	public override TimedMethod[] Use() {
		Party.GetPlayer().GainEvasion(8);
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {Party.GetPlayer().ToString() + " gained 8 evasion"})};
	}
}