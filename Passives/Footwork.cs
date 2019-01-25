public class Footwork : Passive {
	
	public Footwork(Character c) {self = c; name = "Footwork"; description = "Gain 3 evasion each turn";}
	
	public override TimedMethod[] CheckLead(bool player) {
		self.SetEvasion(self.GetEvasion() + 3);
		return new TimedMethod[0];
	}
	
	
	public override TimedMethod[] Initialize(bool player) {
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {self.ToString() + " began their routine"})};
	}
}