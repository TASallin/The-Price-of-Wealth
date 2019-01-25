public static class Attacks {
	
	
	public static TimedMethod[] Attack (Character atkr, Character targ) {
		return Attack(atkr, targ, atkr.GetStrength(), atkr.GetStrength() + 5, atkr.GetAccuracy(), true, true, false);
	}
	
	public static TimedMethod[] StagnantAttack (Character atkr, Character targ, int lower, int upper, bool certainHit, bool usesPower) {
		int acc = System.Int32.MaxValue;
		if (!certainHit) {
			acc = atkr.GetAccuracy();
		}
		return Attack(atkr, targ, lower, upper, acc, usesPower, true, false);
	}
	
	public static TimedMethod[] Attack(Character atkr, Character targ, int lower, int upper, int accuracy, bool usesPower, bool consumeCharge, bool piercing) {
		string text;
		if (accuracy > targ.GetEvasion()) {
			System.Random rnd = new System.Random();
			int power = 0;
			if (usesPower) {
				power = atkr.GetPower() + atkr.GetCharge();
			} else if (consumeCharge) {
				power = atkr.GetCharge();
			}
			int defense = targ.GetGuard() + targ.GetDefense();
			if (piercing) {defense = System.Math.Min(0, defense);}
			int damage = System.Math.Max(power + rnd.Next(lower, upper) - defense, 0);
			//targ.SetHealth(targ.GetHealth() - damage);
		    targ.Damage(damage);
			text = targ.ToString() + " takes " + damage.ToString() + " damage";
			if (targ.GetHealth() <= 0) {
				targ.SetHealth(0);
				text = targ.ToString() + " takes " + damage.ToString() + " critical damage";
			}
			targ.SetGuard(0);
			if (accuracy < System.Int32.MaxValue) {
			    targ.DexCheck();
			}
		} else {
		    targ.SetEvasion(System.Math.Max(targ.GetEvasion() - accuracy, 0));
			text = "miss";
		}
		if (consumeCharge) {
		    atkr.SetCharge(0);
		}
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {text})};
	}
	
	public static bool EvasionCycle(int accuracy, Character targ) {
		if (accuracy > targ.GetEvasion()) {
			targ.DexCheck();
			return true;
		} else {
			targ.SetEvasion(System.Math.Max(targ.GetEvasion() - accuracy, 0));
			return false;
		}
	}
	
	public static bool EvasionCycle(Character atkr, Character targ) {
		return EvasionCycle(atkr.GetAccuracy(), targ);
	}
	
	public static bool EvasionCheck(Character targ, int accuracy) {
		return (targ.GetEvasion() < accuracy);
	}
	
}