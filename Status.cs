public class Status {
	
	Character self;
	public int asleep;
	public int poisoned;
	public int stunned;
	public bool gooped;
	public int blinded;
	public int regeneration;
	public bool passing;
	public int apathetic;
	public int caffeine;
	public bool sleepImmune;
	public bool poisonImmune;
	public bool stunImmune;
	public bool goopImmune;
	public bool blindImmune;
	public bool waking;
	public static int catalyst;
	public static bool firewall;
	
	public Status (Character c) {
		self = c; asleep = 0; poisoned = 0; stunned = 0; gooped = false; blinded = 0; caffeine = 0; waking = false; regeneration = 0; passing = false;
		apathetic = 0; sleepImmune = false; poisonImmune = false; stunImmune = false; goopImmune = false; blindImmune = false;
	}
	
	public TimedMethod[] CheckLead() {
		TimedMethod[] messages = new TimedMethod[0];
		TimedMethod[] temp;
		if (poisoned > 0) {
			self.SetHealth(System.Math.Max(self.GetHealth() - poisoned, 0));
			    temp = new TimedMethod[messages.Length + 1];
				messages.CopyTo(temp, 0);
				temp[messages.Length] = new TimedMethod(60, "Log", new object[] {self.ToString() + " took " + poisoned.ToString() + " poison damage"});
				messages = temp;
			if (self.GetHealth() == 0) {
			    TimedMethod[] dead = Party.CheckDeath();
				temp = new TimedMethod[messages.Length + dead.Length];
				messages.CopyTo(temp, 0);
			    dead.CopyTo(temp, messages.Length);
				messages = temp;
				return messages;
			}
		}
		if (apathetic > 0) {
			System.Random rng = new System.Random();
			if (rng.Next(10) < 3) {
				passing = true;
				apathetic--;
				temp = new TimedMethod[messages.Length + 1];
				messages.CopyTo(temp, 0);
				temp[messages.Length] = new TimedMethod(60, "Log", new object[] {self.ToString() + " struggled to care"});
				messages = temp;
			}
		}
		TimedMethod[] regular = Check();
		temp = new TimedMethod[messages.Length + regular.Length];
		messages.CopyTo(temp, 0);
		regular.CopyTo(temp, messages.Length);
		messages = temp;
		return messages;
	}
	
	public TimedMethod[] Check () {
		string message = "";
		TimedMethod[] messages = new TimedMethod[0];
		TimedMethod[] temp;
		if (caffeine > 0) {
			caffeine--;
			if (caffeine == 0) {
				//self.SetPower(self.GetPower() - 10); self.GainAccuracy(-10);
				caffeine = -5;
				temp = new TimedMethod[messages.Length + 1];
				messages.CopyTo(temp, 0);
				temp[messages.Length] = new TimedMethod(60, "Log", new object[] {self.ToString() + " crashed"});
				messages = temp;
			}
		} else if (caffeine < 0) {
			caffeine++;
			if (caffeine == 0) {
				//self.SetPower(self.GetPower() + 5); self.GainAccuracy(5);
				temp = new TimedMethod[messages.Length + 1];
				messages.CopyTo(temp, 0);
				temp[messages.Length] = new TimedMethod(60, "Log", new object[] {self.ToString() + " recovered"});
				messages = temp;
			}
		}
		if (regeneration > 0) {
			self.Heal(regeneration);
		}
		if (blinded > 0) {
			blinded--;
		}
		if (asleep > 0) {
	        int threshold = new System.Random().Next(6) + 1;
			if (waking || threshold <= asleep) {
				asleep = 0; waking = false;
				temp = new TimedMethod[messages.Length + 1];
				messages.CopyTo(temp, 0);
				temp[messages.Length] = new TimedMethod(60, "Log", new object[] {self.ToString() + " woke up"});
				messages = temp;
			} else {
				asleep++;
				temp = new TimedMethod[messages.Length + 1];
				messages.CopyTo(temp, 0);
				temp[messages.Length] = new TimedMethod(60, "Log", new object[] {self.ToString() + " is asleep"});
				messages = temp;
			}
		}
		if (stunned > 0) {
			stunned--;
			if (stunned > 0) {
				temp = new TimedMethod[messages.Length + 1];
				messages.CopyTo(temp, 0);
				temp[messages.Length] = new TimedMethod(60, "Log", new object[] {self.ToString() + " is stunned"});
				messages = temp;
			}
		}
		if (passing == true) {
			//passing = false;
			temp = new TimedMethod[messages.Length + 1];
			messages.CopyTo(temp, 0);
			temp[messages.Length] = new TimedMethod(60, "Log", new object[] {self.ToString() + " skipped their turn"});
			messages = temp;
		}
		return messages;
	}
	
	public static void NullifyAttack (Character c) {
		c.SetCharge(0); c.SetPower(0);
	}
	
	public static void NullifyDefense (Character c) {
		c.SetGuard(0); c.SetDefense(0);
	}
	
	public TimedMethod[] Poison (int amount) {
		if (!poisonImmune) {
			if (poisoned >= amount + catalyst) {
				return new TimedMethod[] {new TimedMethod(0, "Log", new object[] {""})};
			} else {
			    poisoned = amount + catalyst;
			    return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {self.ToString() + " is poisoned"})};
			}
		}
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {self.ToString() + " is immune to poison"})};
	}
	
	public TimedMethod[] Regenerate (int amount) {
		regeneration = System.Math.Max(amount, regeneration);
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {self.ToString() + " is recovering health"})};
	}
	
	public TimedMethod[] StackPoison (int amount) {
	    if (!poisonImmune) {
			poisoned = poisoned + amount + catalyst;
			return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {self.ToString() + " is poisoned"})};
		}
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {self.ToString() + " is immune to poison"})};
	}
	
	public TimedMethod[] Sleep () {
		if (!sleepImmune && asleep == 0 && caffeine <= 0) {
			asleep = 1;
			return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {self.ToString() + " fell asleep"})};
		}
		if (asleep == 0) {
		    return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {self.ToString() + " is immune to sleep"})};
		}
		return new TimedMethod[] {new TimedMethod(0, "Log", new object[] {""})};
	}
	
	public void Awake() {
	    if (asleep > 0) {waking = true;}	
	}
	
	public TimedMethod[] Stun (int amount) {
		System.Random rng = new System.Random();
		if (!stunImmune && stunned == 0 && rng.Next(2) == 0) {
			stunned = amount;
			return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {"Stunned"})};
		}
		if (stunned == 0) {
		    return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {self.ToString() + " was not stunned"})};
		}
		return new TimedMethod[] {new TimedMethod(0, "Log", new object[] {""})};
	}
	
	public TimedMethod[] Goop () {
		if (!goopImmune) {
			gooped = true;
			return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {self.ToString() + " is gooped"})};
		}
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {self.ToString() + " is immune to goop"})};
	}
	
	public TimedMethod[] Blind (int amount) {
		if (!blindImmune) {
			blinded += amount;
			return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {self.ToString() + " is blinded"})};
		}
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {self.ToString() + " is immune to blind"})};
	}
	
	public TimedMethod[] Pass () {
		passing = true;
		return new TimedMethod[0];
	}
	
	public TimedMethod[] CauseApathy (int amount) {
		apathetic = System.Math.Max(amount, apathetic);
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {self.ToString() + " became apathetic"})};
	}
	
	public void Coffee () {
		caffeine = 5; //self.SetPower(self.GetPower() + 5); self.GainAccuracy(5);
	}
	
	public int CoffeeEffect() {
		if (caffeine > 0) {
			return 5;
		} else if (caffeine < 0) {
			return -5;
		} else {
			return 0;
	    }
	}
	
	public string DescriptorText() {
		string s = "";
		if (asleep > 0) {
			s += "Asleep - Can not take actions until awoken (randomly or through damage)\n";
		}
		if (stunned > 0) {
			s += "Stunned - Can not take actions for " + stunned.ToString() + " turns\n";
		}
		if (poisoned > 0) {
		    s += "Poisoned - While in the lead, take " + poisoned.ToString() + " damage at the start of their turn\n";
	    }
		if (gooped) {
			s += "Gooped - Can not take defensive actions or switch out. Skip turn to clean\n";
		}
		if (blinded > 0) {
			s += "Blinded - Accuracy is reduced by " + blinded.ToString() + ", recovers by 1 each turn\n";
		}
		if (apathetic > 0) {
			s += "Apathy - Chance to skip turns\n";
		}
		if (regeneration > 0) {
			s += "Regeneration - Recover " + regeneration.ToString() + " hp every turn";
		}
		return s;
	}
	
	public string BarText() {
		string s = "";
		if (asleep > 0) {
			s += "Asleep ";
		}
		if (stunned > 0) {
			s += "Stunned ";
		}
		if (poisoned > 0) {
		    s += "Poisoned ";
	    }
		if (gooped) {
			s += "Gooped ";
		}
		if (blinded > 0) {
			s += "Blinded ";
		}
		if (apathetic > 0) {
			s += "Apathy";
		}
		if (regeneration > 0) {
			s += "Regeneration ";
		}
		return s;
	}
	
	public void PostBattle() {
		asleep = 0; poisoned = 0; stunned = 0; gooped = false; blinded = 0; waking = false; catalyst = 0; regeneration = 0; passing = false;
		apathetic = 0; sleepImmune = false; poisonImmune = false; stunImmune = false; goopImmune = false; blindImmune = false; firewall = false;
	}
}