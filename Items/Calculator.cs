public class Calculator : Item {
	
	public Calculator() {name = "Calculator"; description = "Gain 5 accuracy. Reusable"; price = 2;}
	
	public override TimedMethod[] Use() {
		Party.GetPlayer().GainAccuracy(5);
		Party.AddItem(this);
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {"Accuracy was increased"})};
	}

}