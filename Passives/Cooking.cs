public class Cooking : Passive {
	
	public Cooking(Character c) {self = c; name = "Cooking"; description = "party restores 2 hp when starting a battle";}
	
	public override TimedMethod[] Initialize (bool player) {
		Character[] current;
		if (player) {
			current = Party.members;
		} else {
			current = Party.enemies;
		}
		foreach (Character c in current) {
			if (c != null) {
				c.Heal(2);
			}
		}
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {self.ToString() + "'s cooking restored health"})};
	}
}