public class Democracy : Passive {
	
	public int promise;
	public bool attacked;
	
	public Democracy (Character c) {
		self = c; name = "Democracy"; description = "Each turn, gain charge and guard equal to your party size minus the enemy party size";
	}
	
	public override TimedMethod[] CheckLead(bool player) {
		TimedMethod[] promisePart = new TimedMethod[] {new TimedMethod(0, "Log", new object[] {""})};
		if (promise == 2) {
			promise--;
		} else if (promise == 1 && attacked) {
			promise--;
		} else if (promise == 1) {
			self.SetPower(self.GetPower() - 4);
			self.SetDefense(self.GetDefense() - 4);
			promise--;
			self.GetSpecial().modifier += 10;
			promisePart = new TimedMethod[] {new TimedMethod(60, "Log", new object[] {"The promise was broken! power and defense -4"})};
		}
		attacked = false;
		int advantage;
		if (player) {
			advantage = Party.playerCount - Party.enemyCount;
		} else {
			advantage = Party.enemyCount - Party.playerCount;
		}
		self.SetCharge(self.GetCharge() + advantage);
		self.SetGuard(self.GetGuard() + advantage);
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {
			ToString() + " has an advantage of " + advantage.ToString()}), promisePart[0]};
	}
	
	public override TimedMethod[] Initialize(bool player) {
		promise = 0; attacked = false;
		return new TimedMethod[0];
	}
}