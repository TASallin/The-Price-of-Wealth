public class Joust : Special {
	
	public Joust() {name = "Joust"; description = "Trade with the enemy"; baseCost = 4; modifier = 0;}

    public override TimedMethod[] Use() {
		Party.GetPlayer().SetGuard(Party.GetPlayer().GetGuard() + Party.GetEnemy().GetCharge() / 2);
		return new TimedMethod[] {new TimedMethod(0, "AudioNumbered", new object[] {"Attack", 3 ,4}), 
		    new TimedMethod(0, "StagnantAttack", new object[] {true, 8, 8, Party.GetPlayer().GetAccuracy(), true, true, false}),
		    new TimedMethod(0, "StagnantAttack", new object[] {false, 1, 1, Party.GetEnemy().GetAccuracy(), true, true, false})};
    }
}