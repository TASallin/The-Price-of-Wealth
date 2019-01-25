public class Regeneration : Passive {
	
	public Regeneration (Character c) {self = c; name = "Regeneration"; description = "Gain 2 health every turn";}
	
	public override TimedMethod[] Initialize(bool player) {
		return self.status.Regenerate(2);
	}
}