public class Shuttle : Item {
	
	public Shuttle() {name = "Shuttle"; description = "Provides a quick escape. Warning: low on gas"; price = 2;}
	
	public override TimedMethod[] Use() {
		if (Party.area == "Dungeon") {
			return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {"no driving indoors :("})};
		} else {
		    return  new TimedMethod[] {new TimedMethod(60, "Log", new object[] {"Time to go"}),
		        new TimedMethod("Flee")};
		}
	}
}