public class MysteryGoo : Item {
	
	public MysteryGoo () {name = "Mystery Goo"; description = "Throw it at the enemy!"; price = 1;}
	
	public override TimedMethod[] Use () {
		System.Random rng = new System.Random();
		int seed = rng.Next(11);
		int magnitude = rng.Next(10) + 1;
		Character targ = Party.GetEnemy();
		if (!Attacks.EvasionCycle(Party.GetPlayer(), targ)) {
			return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {"The goo fell sadly to the ground, splattering uselessly"})};
		}
		
		if (seed == 0) {
			targ.SetPower(targ.GetPower() - magnitude / 2);
			return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {"The goo disrupted power by " + (magnitude/2).ToString() 
			    + " points"})};
		} else if (seed == 1) {
			targ.SetDefense(targ.GetDefense() - magnitude / 2);
			return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {"The goo drained defense by " + (magnitude/2).ToString()})};
		} else if (seed == 2) {
			targ.GainAccuracy(magnitude / 2 * -1);
			return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {"The goo reduced accuracy by " + (magnitude/2).ToString()})};
		} else if (seed == 3) {
			targ.SetCharge(targ.GetCharge() - magnitude);
			return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {"The goo stuck to the target's hands. Charge -" 
			    + magnitude.ToString()})};
		} else if (seed == 4) {
			targ.SetGuard(targ.GetGuard() - magnitude);
			return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {"The goo broke the target's guard by " + magnitude.ToString()})};
		} else if (seed == 5) {
			targ.status.Goop();
			return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {"The goo revealed to be slime goop, trapping target"})};
		} else if (seed == 6) {
			targ.status.Poison(magnitude / 3 + 1);
			return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {"The goo was a deadly poison with a degree of " 
			    + (magnitude/3 + 1).ToString()})};
		} else if (seed == 7) {
			targ.status.Sleep();
			return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {"The goo caused the target to fall asleep"})};
		} else if (seed == 8) {
			targ.status.Blind(magnitude);
			return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {"The goo stuck to the target's eyes"})};
		} else if (seed == 9) {
			Status.NullifyAttack(targ); Status.NullifyDefense(targ);
			return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {"The goo countered buffs to attack and defense"})};
		} else {
			targ.SetEvasion(targ.GetEvasion() - targ.GetDexterity());
			return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {"The goo solidified midair and turned into a rock!"}),
			new TimedMethod(60, "StagnantAttack", new object[] {true, magnitude, magnitude, Party.GetPlayer().GetAccuracy(), true, true, false})};
		}
	}
	
}