public class Ill : Quirk {
	public Ill (Character c) {self = c; name = "Ill"; description = "You are always mildly poisoned. Moderately poison enemies when in the lead";}
	
	public override TimedMethod[] CheckLead (bool player) {
		Character target;
		if (player) {
			target = Party.GetEnemy();
		} else {
			target = Party.GetPlayer();
		}
		return target.status.Poison(2);
	}
	
	public override TimedMethod[] Initialize (bool player) {
		self.status.Poison(1);
		return new TimedMethod[0];
	}
}