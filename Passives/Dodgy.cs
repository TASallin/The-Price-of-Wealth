public class Dodgy : Passive {
	
	public Dodgy(Character c) {self = c; name = "Dodgy"; description = "Gain 2 evasion each turn";}
	
	public override TimedMethod[] CheckLead(bool player) {
		self.SetEvasion(self.GetEvasion() + 2);
		return new TimedMethod[0];
	}
	
	
	public override TimedMethod[] Initialize(bool player) {
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {self.ToString() + " Is being evasive"})};
	}
}