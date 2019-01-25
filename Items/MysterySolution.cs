public class MysterySolution : Item {
	
	public MysterySolution () {name = "Mystery Solution"; description = "Drink it!"; selects = true; price = 1;}
	
	public override TimedMethod[] UseSelected (int i) {
		System.Random rng = new System.Random();
		int seed = rng.Next(9);
		int magnitude = rng.Next(10) + 1;
		Character self = Party.members[i];
		if (seed == 0) {
			self.SetPower(self.GetPower() + magnitude / 2);
			return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {"It made you stronger by " + (magnitude/2).ToString() 
			    + " points"})};
		} else if (seed == 1) {
			self.SetDefense(self.GetDefense() + magnitude / 2);
			return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {"High iron raised defense by " + (magnitude/2).ToString()})};
		} else if (seed == 2) {
			self.GainAccuracy(magnitude / 2);
			return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {"It helps with focus. Accuracy +  " + (magnitude/2).ToString()})};
		} else if (seed == 3) {
			self.SetCharge(self.GetCharge() + magnitude);
			return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {"It was spicy. Charge + " + magnitude.ToString()})};
		} else if (seed == 4) {
			self.SetGuard(self.GetGuard() + magnitude);
			return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {"It gave guard somehow, increasing by " + magnitude.ToString()})};
		} else if (seed == 5) {
			self.SetEvasion(self.GetEvasion() + magnitude);
			return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {"Caffeine increased evasion by " + magnitude.ToString()})};
		} else if (seed == 6) {
			self.status.blinded = 0; self.status.poisoned = 0; self.status.asleep = 0; self.status.stunned = 0; self.status.gooped = false;
			return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {"It was a panacea. Negative effects removed"})};
		} else if (seed == 7) {
			Status.NullifyAttack(self); Status.NullifyDefense(self);
			return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {"Attack and defense were reset"})};
		} else {
			self.Heal(magnitude);
			return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {"It's a healing elixer. HP + " + magnitude.ToString()})};
		}
	}
	
}