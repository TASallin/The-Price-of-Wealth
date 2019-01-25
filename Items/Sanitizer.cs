public class Sanitizer : Item {
	
	public Sanitizer() {name = "Sanitizer"; description = "Recover from poisoned, gooped, and blinded"; price = 2;}

	public override TimedMethod[] Use () {
		Party.GetPlayer().status.poisoned = 0;
		Party.GetPlayer().status.gooped = false;
		Party.GetPlayer().status.blinded = 0;
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {"Negative effects were removed"})};
	}
	
}