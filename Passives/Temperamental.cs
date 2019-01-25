public class Temperamental : Quirk {
	
	bool used;
	
	public Temperamental (Character c) {
		self = c; used = false; name = "Temperamental"; description = "Drastically increase attack the first time you go under 1/2 HP";
	}
	
	public override TimedMethod[] CheckLead (bool player) {
		if (!used && self.GetMaxHP() - self.GetHealth() > self.GetHealth()) {
		    used = true;
			self.SetCharge(self.GetCharge() + 5);
			return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {
			self.ToString() + " is filled with rage"})};
		}
		return new TimedMethod[0];
	}
	
	public override TimedMethod[] Initialize(bool player) {
		used = false;
		return new TimedMethod[0];
	}
}