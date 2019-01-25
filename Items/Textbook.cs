public class Textbook : Item {
	
	public Textbook() {name = "Textbook"; description = "Heavy and inaccurate as a weapon"; price = 2;}
	
	public override TimedMethod[] Use() {
		string message = Party.GetPlayer().GetName() + " swung the textbook, sending pages everywhere";
		TimedMethod[] returned = new TimedMethod[] {new TimedMethod(60, "Log", new object[] {message}),
		new TimedMethod(30, "StagnantAttack", new object[] {
			true, Party.GetPlayer().GetStrength() + 5, Party.GetPlayer().GetStrength() + 9, Party.GetPlayer().GetAccuracy() / 2, true, true, false})};
		return returned;
	}
}