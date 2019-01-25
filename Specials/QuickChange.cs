public class QuickChange : Special {
	
	public QuickChange() {name = "QuickChange"; description = "Switch out without consuming your turn"; baseCost = 5; modifier = 0; selects = true;}
	
	public override TimedMethod[] UseSelects(int i) {
		return new TimedMethod[] {new TimedMethod(0, "SwitchTo", new object[] {i}), new TimedMethod("ContinueTurn")};
	}
}