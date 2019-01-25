public class Precision : Passive {
	
	public Precision(Character c) {self = c; name = "Precision"; description = "Your basic attack is piercing and you are immune to blinding";}
	
	public override TimedMethod[] Initialize(bool player) {
		self.status.blindImmune = true;
		return new TimedMethod[0];
	}
}