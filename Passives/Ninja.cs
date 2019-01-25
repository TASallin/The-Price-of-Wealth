public class Ninja : Quirk {
	
	public Ninja (Character c) {
		self = c; name = "Ninja"; description = "You are immune to blind and start fights with evasion equal to your accuracy";
	}
	
	public override TimedMethod[] Initialize (bool player) {
		self.status.blindImmune = true;
		self.SetEvasion(self.GetEvasion() + self.GetAccuracy());
		return new TimedMethod[0];
	}
}