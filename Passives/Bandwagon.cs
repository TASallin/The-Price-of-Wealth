public class Bandwagon : Quirk {
	
	public Bandwagon (Character c) {
		self = c; name = "Bandwagon"; description = "At the start of your turn, copy your enemy's attack and defense stats";
	}
	
	public override TimedMethod[] CheckLead (bool player) {
		Character enemy;
		if (player) {
			enemy = Party.GetEnemy();
		} else {
			enemy = Party.GetPlayer();
		}
		self.SetPower(enemy.GetPower()); self.SetCharge(enemy.GetCharge());
		self.SetDefense(enemy.GetDefense()); self.SetGuard(enemy.GetGuard());
		return new TimedMethod[0];
	}
}