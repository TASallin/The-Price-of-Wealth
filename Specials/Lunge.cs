public class Lunge : Special {
	
	public Lunge() {name = "Lunge"; description = "Switch in and attack"; baseCost = 2; modifier = 0;}
	
	public override TimedMethod[] UseSupport (int i) {
		return new TimedMethod[] {new TimedMethod(30, "SwitchTo", new object[] {i}), new TimedMethod(60, "Attack", new object[] {0})};
	}
}