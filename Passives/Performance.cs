public class Performance : Passive {
		
	public Performance (Character c) {
		self = c; name = "Performance"; description = "Your team cannot be put to sleep";
	}
	
	public override TimedMethod[] Initialize (bool player) {
		Character[] team;
		if (player) {
			team = Party.members;
		} else {
			team = Party.enemies;
		}
		foreach (Character c in team) {
			if (c != null) {
				c.status.sleepImmune = true;
			}
		}
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {self.ToString() +  " began a performance"})};
	}
}