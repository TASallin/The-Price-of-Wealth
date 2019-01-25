public class Coffee : Item {
	
	public Coffee () {name = "Coffee"; description = "An amazing drink. Yields immediate results"; selects = true; price = 5;}
	
	public override TimedMethod[] UseSelected (int i) {
		Party.members[i].status.Coffee();
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {Party.members[i].ToString() + " gained the power of caffeine"})};
	}
	
	public override void UseOutOfCombat (int i) {
		UseSelected(i);
	}
}