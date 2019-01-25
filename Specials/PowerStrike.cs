public class PowerStrike : Special {
	
	public PowerStrike() {name = "Power Strike"; description = "Attack for your basic attack's max damage"; baseCost = 2; modifier = 0;}
	
	public override TimedMethod[] Use() {
		if (Party.BagContains(new Metronome())) {
			return new TimedMethod[] {new TimedMethod(0, "StagnantAttack", new object[] {
			    true, Party.GetPlayer().GetStrength() + 2, Party.GetPlayer().GetStrength() + 2, Party.GetPlayer().GetAccuracy(), true, true, false})};
		} else {
	    	return new TimedMethod[] {new TimedMethod(0, "StagnantAttack", new object[] {
			    true, Party.GetPlayer().GetStrength() + 4, Party.GetPlayer().GetStrength() + 4, Party.GetPlayer().GetAccuracy(), true, true, false})};
		}
	}
}