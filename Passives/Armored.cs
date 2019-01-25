public class Armored : Passive {
	
    int formerHP;
	bool usedArmor;
	
	public Armored (Character c) {
		self = c; name = "Armored";
		description = "+1 defense. At the start of your turn, gain 1 guard if you didn't take damage last turn";
		formerHP = System.Int32.MaxValue;
	}
	
	public override TimedMethod[] CheckLead (bool player) {
		if (!usedArmor) {self.SetDefense(self.GetDefense() + 1); usedArmor = true;}
		if (self.GetHealth() >= formerHP) {
			self.SetGuard(self.GetGuard() + 1);
			formerHP = self.GetHealth();
			return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {self.ToString() + "'s guard increased"})};
		}
		formerHP = self.GetHealth();
		return new TimedMethod[0];
	}
	
	public override TimedMethod[] Initialize (bool player) {
		usedArmor = false;
		formerHP = System.Int32.MaxValue;
		return new TimedMethod[0];
	}
	
}