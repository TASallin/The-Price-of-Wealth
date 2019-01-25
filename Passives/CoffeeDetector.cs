public class CoffeeDetector : Passive {
	
	bool used;
	
	public CoffeeDetector(Character c) {self = c; name = "CoffeeDetector"; description = "If the enemy drinks coffee, gain 10 power";}
	
	public override TimedMethod[] CheckLead(bool player) {
		Character enemy;
		if (player) {enemy = Party.GetEnemy();} else {enemy = Party.GetPlayer();}
		if (!used && enemy.status.caffeine > 0) {
			used = true; self.SetPower(self.GetPower() + 10);
			return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {self.ToString() + " became HYPER at the smell of coffee"})};
		}
		return new TimedMethod[0];
	}
	
	public override TimedMethod[] Initialize(bool player) {
		used = false;
		return new TimedMethod[0];
	}
}