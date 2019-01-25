public class Expirimentor : Researcher {
	
	int cycle;
	
	public Expirimentor() {
		health = 35; maxHP = 35; type = "Expirimentor"; passive = new Passive(this); champion = true; cycle = 0;
	}
	
	public override TimedMethod[] AI () {
		System.Random rng = new System.Random();
		int num = rng.Next(10);
		if (cycle == 0) {
			return Mutate();
		} else if (cycle == 1 && Party.enemyCount > 1) {
			return Switch();
		} else if (cycle == 1) {
			return Trap();
		} else if (cycle == 2 || num < 4) {
			return Mystery();
		} else {
			return Attack();
		}
	}
	
	public TimedMethod[] Trap() {
		cycle++;
		if (Attacks.EvasionCycle(this, Party.GetPlayer())) {
			return new TimedMethod[] {new TimedMethod(60, "Audio", new object[] {"ExpirimentorTrap"}), new TimedMethod(60, "Log", new object[] {
				ToString() + " used an overly complex mouse trap"}), Party.GetPlayer().status.Goop()[0]};
		} else {
			return new TimedMethod[] {new TimedMethod(60, "Audio", new object[] {"ExpirimentorTrap"}), new TimedMethod(60, "Log", new object[] {
				ToString() + " used such an overly complex mouse trap it was easy to avoid"})};
		}
	}
	
	public TimedMethod[] Attack() {
		if (Attacks.EvasionCheck(Party.GetPlayer(), GetAccuracy())) {
			Party.GetPlayer().GainCharge(-4);
		}
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {ToString() + " swung heated metal"}),
		    new TimedMethod(0, "StagnantAttack", new object[] {false, 6, 6, GetAccuracy(), true, true, false})};
	}
	
	public TimedMethod[] Mystery() {
		if (!Attacks.EvasionCycle(this, Party.GetPlayer())) {
			return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {ToString() + " splashed chemicals...on the floor"})};
		}
		cycle = 3;
		System.Random rng = new System.Random();
		int num = rng.Next(6);
		TimedMethod[] statusPart;
		if (num == 0) {
			statusPart = Party.GetPlayer().status.Poison(rng.Next(3) + 1);
		} else if (num == 1) {
			statusPart = Party.GetPlayer().status.Blind(rng.Next(8) + 1);
		} else if (num == 2) {
			statusPart = Party.GetPlayer().status.Sleep();
		} else if (num == 3) {
			statusPart = Party.GetPlayer().status.Stun(rng.Next(3) + 2);
		} else if (num == 4) {
			Status.NullifyAttack(Party.GetPlayer()); Status.NullifyDefense(Party.GetPlayer());
			statusPart = new TimedMethod[] {new TimedMethod(60, "Log", new object[] {"Attack and defense were reset"})};
		} else {
			Party.GetPlayer().SetEvasion(Party.GetPlayer().GetEvasion() - Party.GetPlayer().GetDexterity());
			int dmg = rng.Next(10) + 1;
			return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {ToString() + " splashed chemicals...what did they do?"}),
			    new TimedMethod(0, "StagnantAttack", new object[] {false, dmg, dmg, GetAccuracy(), true, true, false})};
		}
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {ToString() + " splashed chemicals...what did they do?"}), statusPart[0]};
	}
	
	public TimedMethod[] Mutate() {
		cycle++;
		System.Random rng = new System.Random();
		int num;
		foreach (Character c in Party.enemies) {
			if (c != null) {
				num = rng.Next(5);
				if (num == 0) {
					c.SetPassive(new ForceField(c));
				} else if (num == 1) {
					c.SetPassive(new Dodgy(c));
				} else if (num == 2) {
					c.SetPassive(new Ill(c));
				} else if (num == 3) {
					c.SetPassive(new Accurate(c));
				} else {
					c.SetPassive(new Regeneration(c));
				}
			}
		}
		return new TimedMethod[] {new TimedMethod(60, "Audio", new object[] {"ExpirimentorObserve"}), 
		    new TimedMethod(60, "Log", new object[] {ToString() + " sprayed a gas around his \"team\""})};
	}
	
	public TimedMethod[] Switch () {
		if (GetGooped()) {
			status.gooped = false;
			return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {ToString() + " escaped the goop"})};
		}
		if (Party.enemyCount > 1) {
			int former = Party.enemySlot;
			for (int i = 0; i < 4; i++) {
				if (i != Party.enemySlot - 1 && Party.enemies[i] != null && Party.enemies[i].GetAlive()) {
					Party.enemySlot = i + 1;
					return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {ToString() + " put a test subject in front "}),
					    new TimedMethod(0, "EnemySwitch", new object[] {Party.enemySlot, former})};
				}
			}
		}
		return new TimedMethod[0];
	}
	
	public override void CreateDrops() {
		drops = ItemDrops.FromPool(new Item[] {new MysteryGoo(), new MysterySolution(), new MysteryGoo(), new MysterySolution()},
    		ItemDrops.Amount(2, 4));
	}
	
	public override Item[] Loot () {
		System.Random rng = new System.Random();
		int sp = 5 + rng.Next(5);
		Party.UseSP(sp * -1);
		Item[] dropped = drops;
		drops = new Item[0];
		return dropped;
	}
	
	public override string[] CSDescription () {
		return new string[] {"Expirimentor - illegally offers extra credit in exchange for test subjects",
		    "If we have a way to beat him first, we might be able to recruit one of the others"};
	}
}