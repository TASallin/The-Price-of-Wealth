public class Pendulum : Item {
	
	public Pendulum () {name = "Pendulum"; description = "Put the enemy to sleep. It's very accurate"; price = 2;}
	
	public override TimedMethod[] Use () {
		if (Attacks.EvasionCycle(Party.GetPlayer().GetAccuracy() * 2, Party.GetEnemy())) {
			return Party.GetEnemy().status.Sleep();
		} else {
			return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {"miss"})};
		}
	}
}