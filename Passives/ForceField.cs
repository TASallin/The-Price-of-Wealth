public class ForceField : Passive {
	
	public ForceField(Character c) {self = c; name = "Force field"; description = "Gain 3 block every turn";}
	
	public override TimedMethod[] CheckLead(bool player) {
		self.SetGuard(self.GetGuard() + 3);
		return new TimedMethod[0];
	}
	
	public override TimedMethod[] Initialize(bool player) {
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {self.ToString() + " is protected by a force field"})};
	}

}