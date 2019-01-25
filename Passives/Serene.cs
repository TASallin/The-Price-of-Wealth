public class Serene : Quirk {
	
	public Serene(Character c) {self = c; name = "Serene"; description = "attack and defense stats cannot fall below 0. Immune to sleep and stun";}
	
	public override TimedMethod[] CheckLead(bool player) {
		self.SetCharge(System.Math.Max(self.GetCharge(), 0)); self.SetGuard(System.Math.Max(self.GetGuard(), 0));
		self.SetPower(System.Math.Max(self.GetPower(), 0)); self.SetDefense(System.Math.Max(self.GetDefense(), 0));
		return new TimedMethod[0];
	}
	
	public override TimedMethod[] Initialize(bool player) {
		self.status.sleepImmune = true; self.status.stunImmune = true;
		return new TimedMethod[0];
	}
}