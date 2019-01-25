public class Tuba : Item {
	
	public Tuba() {name = "Tuba"; description = "Reset attack and defense on opponent"; price = 2;}
	
	public override TimedMethod[] Use() {
		if (Attacks.EvasionCycle(Party.GetPlayer(), Party.GetEnemy())) {
		    Status.NullifyAttack(Party.GetEnemy()); Status.NullifyDefense(Party.GetEnemy());
		}
		string message = Party.GetPlayer().GetName() + " blasted the tuba!";
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {message})};
	}
}