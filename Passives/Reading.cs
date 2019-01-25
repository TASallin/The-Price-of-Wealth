public class Reading : Passive {
	
	public Reading (Character c) {self = c; name = "Reading"; description = "On each turn not in the lead, gain 1 HP and 2 charge";}
	
	public override TimedMethod[] Check(bool player) {
		self.Heal(1); self.SetCharge(self.GetCharge() + 1);
		return new TimedMethod[0];
	}
}