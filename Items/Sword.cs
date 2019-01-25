public class Sword : Textbook {
	
	public Sword() {name = "Actual Sword"; description = "Wow! An actual sword"; price = 3;}
	
	public override TimedMethod[] Use() {
		string message = Party.GetPlayer().GetName() + " attacked with the sword. It broke immediately";
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {message}),
		    new TimedMethod(0, "StagnantAttack", new object[] {
				true, Party.GetPlayer().GetStrength() + 7, Party.GetPlayer().GetStrength() + 11, Party.GetPlayer().GetAccuracy(), true, true, false})};
	}
}