public class Observant : Passive {
	
	public Observant (Character c) {
		self = c; name = "Observant"; description = "When any party member starts their turn with a forecast to miss, they gain 3 accuracy";
	}
	
	public override TimedMethod[] Check (bool player) {
		Character atkr; Character targ;
		if (player) {
			atkr = Party.GetPlayer(); targ = Party.GetEnemy();
	    } else {
			atkr = Party.GetEnemy(); targ = Party.GetPlayer();
		}
		if (atkr.GetAccuracy() <= targ.GetEvasion()) {
			atkr.GainAccuracy(3);
			return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {atkr.ToString() + " observed " + targ.ToString() + "'s movements"})};
		} else {
			return new TimedMethod[0];
		}
	}
	
	public override TimedMethod[] CheckLead(bool player) {
		return Check(player);
	}
	
}