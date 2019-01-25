public class Berserk : Quirk {
	
	public Berserk (Character c) {self = c; name = "Berserk"; description = "Has 5 power and -5 defense";}
	
	public override TimedMethod[] Initialize (bool player) {
		self.GainPower(5);
		self.SetDefense(self.GetDefense() - 5);
		return new TimedMethod[0];
	}
	
}