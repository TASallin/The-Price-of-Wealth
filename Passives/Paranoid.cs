public class Paranoid : Quirk {
	
	public Paranoid(Character c) {
		self = c;	name = "Paranoid"; description = "You run away immediately instead of after 1 turn. Gain 5 evasion on turn 1";
	}
	
	public override TimedMethod[] Initialize(bool player) {
		self.SetEvasion(self.GetEvasion() + 5);
		return new TimedMethod[0];
	}
	
}