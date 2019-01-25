public class Car : Passive {
	
	public Car (Character c) {self = c; name = "Car"; description = "Your team cannot be gooped";}
	
	public override TimedMethod[] Initialize (bool player) {
		Character[] team;
		if (player) {
			team = Party.members;
		} else {
			team = Party.enemies;
		}
		foreach (Character c in team) {
			if (c != null) {
				c.status.goopImmune = true;
			}
		}
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {self.ToString() +  "'s car prevents gooping"})};
	}
}