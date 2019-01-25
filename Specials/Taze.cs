public class Taze : Special {
	
	public Taze() {name = "Taze"; description = "A piercing attack that stuns"; baseCost = 6; modifier = 0;}
	
	public override TimedMethod[] Use () {
		if (Attacks.EvasionCheck(Party.GetEnemy(), Party.GetPlayer().GetAccuracy())) {
		    Party.GetEnemy().status.Stun(2);
		}
		return new TimedMethod[] {new TimedMethod(0, "AudioNumbered", new object[] {"Attack", 1 ,2}),
		    new TimedMethod(0, "StagnantAttack", new object[] {true, 6, 6, Party.GetPlayer().GetAccuracy(), true, true, true})};
	}
	
}