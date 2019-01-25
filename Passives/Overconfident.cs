public class Overconfident : Quirk {
	
	bool powered;
	
	public Overconfident (Character c) {self = c; name = "Overconfident"; description = "Powered up at max hp";}
	
	public override TimedMethod[] CheckLead (bool player) {
		if (powered && self.GetHealth() < self.GetMaxHP()) {
			powered = false;
			self.SetPower(self.GetPower() - 3);
			self.SetDefense(self.GetDefense() - 2);
			return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {self.ToString() + " is giving up"})};
		} else if (!powered && self.GetHealth() == self.GetMaxHP()) {
			powered = true;
			self.SetPower(self.GetPower() + 3);
			self.SetDefense(self.GetDefense() + 2);
			return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {self.ToString() + " has extreme confidence"})};
		} else {
			return new TimedMethod[0];
		}
	}
	
	public override TimedMethod[] Initialize (bool player) {
		powered = false;
		return new TimedMethod[0];
	}
}