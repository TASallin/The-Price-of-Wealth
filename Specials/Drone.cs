public class Drone : Special {
	
	public Drone() {name = "Drone"; description = "Fire your drone and attack simultaneously"; baseCost = 3; modifier = 0;}

    public override TimedMethod[] Use() {
		return new TimedMethod[] {new TimedMethod(0, "StagnantAttack", new object[] {true, Party.GetPlayer().GetStrength(),
		Party.GetPlayer().GetStrength() + 4, Party.GetPlayer().GetAccuracy(), true, false, false}),
		    new TimedMethod(0, "StagnantAttack", new object[] {true, Party.GetPlayer().GetStrength(),
		    Party.GetPlayer().GetStrength() + 4, Party.GetPlayer().GetAccuracy(), true, true, false})};
    }
}