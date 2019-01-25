public class Trumpet : Special {
    
	public Trumpet() {name = "Trumpet"; description = "Reset enemy attack"; baseCost = 2; modifier = 0;}

    public override TimedMethod[] Use() {
        string message = Party.GetEnemy() + " lost attack";
		Status.NullifyAttack(Party.GetEnemy());
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {message})};
    }
}