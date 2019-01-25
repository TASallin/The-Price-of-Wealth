public class Filibuster : Special {
	
	public Filibuster() {name = "Filibuster"; description = "put everyone to sleep, even yourself"; baseCost = 4; modifier = 0;}
	
	public override TimedMethod[] UseSupport(int i) {
		foreach (Character c in Party.members) {
			if (c != null && c.GetAlive()) {
				c.status.Sleep();
			}
		}
		foreach (Character c in Party.enemies) {
			if (c != null && c.GetAlive()) {
				c.status.Sleep();
			}
		}
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {Party.members[i].ToString() + " wouldn't stop talking"})};
	}
}