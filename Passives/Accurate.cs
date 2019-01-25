public class Accurate : Passive {
	
	public Accurate (Character c) {self = c; name = "Accurate"; description = "Gains accuracy at the start of each turn";}
	
	
	public override TimedMethod[] CheckLead(bool player) {
		self.GainAccuracy(1);
		return new TimedMethod[0];
	}

	public override TimedMethod[] Initialize(bool player) {
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {self.ToString() + " is reading enemy movements"})};
	}
}