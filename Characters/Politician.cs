public class Politician : Character {
	
    int cycle;
	bool broken;
	
	public Politician() {
	    health = 60; maxHP = 60; strength = 3; power = 0; charge = 0; defense = 0; guard = 0; 
		baseAccuracy = 12; accuracy = 12; dexterity = 4; evasion = 0; type = "The Politician"; passive = new Passive(this);
		quirk = Quirk.GetQuirk(this); special = null; player = false; champion = true; recruitable = false;
		cycle = 0; broken = false; CreateDrops();
	}
	
	public override string ToString() {return "The Politician";}
	
	public override TimedMethod[] AI () {
		if (broken) {
			if (cycle < 2) {
				cycle++;
				return Weak();
			} else {
				cycle = 0;
				return SaveFace();
		    }
		} else {
		    if (cycle == 0) {
		    	cycle++;
	    		return CampaignDefense();
    		} else if (cycle == 1) {
		    	cycle++;
	    		return Filibuster();
     		} else if (cycle == 2) {
		    	cycle++;
	    	    return CampaignBalance();			
    		} else if (cycle == 3) {
		    	cycle++;
	    		return Veto();
    		} else if (cycle == 4) {
		    	cycle++;
	    		return CampaignOffense();
    		} else {
			    cycle = 0;
			    return Attack();
		    }
		}
	}
	
	public override TimedMethod[] EnemyTurn () {
		//TimedMethod[] extra = status.Check(this);
		if (GetAsleep() || GetStunned() || GetPassing()) {
			status.passing = false;
			if (!broken && (cycle == 1 || cycle == 3 || cycle == 5)) {
				broken = true; cycle = 0; defense = System.Math.Min(-1, defense - 2); power = System.Math.Min(-1, power - 2); evasion = 0;
				return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {"The promise has been broken! Voter support is 0!"})};
			}
			return new TimedMethod[0];
		} else { 
		    return AI();
		}
	}
	
	public TimedMethod[] CampaignDefense() {
		guard += 10; evasion += 10;
		return new TimedMethod[] {new TimedMethod(0, "Audio", new object[] {"Blah"}), new TimedMethod(60, "Log", new object[] {
			"The Politician campaigned with the promise of stalling votes"}), new TimedMethod(60, "Log", new object[] {
		    "It yielded defensive results"}), new TimedMethod("GetEnemy")};
	}
	
	public TimedMethod[] CampaignBalance() {
	    power += 1; defense += 1;
		return new TimedMethod[] {new TimedMethod(0, "Audio", new object[] {"Blah"}), new TimedMethod(60, "Log", new object[] {
			"The Politician campaigned with the promise of denying opposition"}), new TimedMethod(60, "Log", new object[] {
		    "It yielded balanced results"}), new TimedMethod("GetEnemy")};
	}
	
	public TimedMethod[] CampaignOffense() {
	    charge += 9; accuracy += 2;
		return new TimedMethod[] {new TimedMethod(0, "Audio", new object[] {"Blah"}), new TimedMethod(60, "Log", new object[] {
			"The Politician campaigned with the promise of destruction"}), new TimedMethod(60, "Log", new object[] {
		    "It yielded offensive results"}), new TimedMethod("GetEnemy")};
	}
	
	public TimedMethod[] Filibuster() {
		TimedMethod[] sleepPart;
		if (Attacks.EvasionCycle(this, Party.GetPlayer())) {
	        sleepPart = Party.GetPlayer().status.Sleep();
		} else {
			sleepPart = new TimedMethod[] {new TimedMethod(60, "Log", new object[] {"Ineffective"})};
		}
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {"The Politician filibustered"}), sleepPart[0]};
	}
	
	public TimedMethod[] Veto() {
		if (Attacks.EvasionCycle(this, Party.GetPlayer())) {
		    Status.NullifyAttack(Party.GetPlayer()); Status.NullifyDefense(Party.GetPlayer());
		}
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {"The Politician used the veto. Stats were countered"}),
		new TimedMethod("GetPlayer")};
    }
	
	public TimedMethod[] Attack() {
		return new TimedMethod[] {new TimedMethod(0, "Audio", new object[] {"PoliticianAttack"}), 
		    new TimedMethod(60, "Log", new object[] {"The Politician delivered the promised destruction"}),
		    new TimedMethod(0, "StagnantAttack", new object[] {false, 3, 3, GetAccuracy(), true, false, false}),
			new TimedMethod(0, "StagnantAttack", new object[] {false, 5, 5, GetAccuracy(), true, false, false}),
		    new TimedMethod(0, "StagnantAttack", new object[] {false, 7, 7, GetAccuracy(), true, true, false})};
	}
	
	public TimedMethod[] Weak() {
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {"The Politician attacked"}),
		    new TimedMethod(0, "StagnantAttack", new object[] {false, 3, 3, GetAccuracy(), true, true, false})};
	}
	
	public TimedMethod[] SaveFace() {
		evasion += 4;
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {"The Politician tried to save face. Evasion up"})};
	}
	
	public override void CreateDrops () {
		drops = ItemDrops.FromPool(new Item[] {new Smartphone(), new Pizza(), new Defibrilator(), new Briefcase(), new Antibiotics(), new Pendulum()},
		    ItemDrops.Amount(2, 4));
	}
	
	public override Item[] Loot () {
		System.Random rnd = new System.Random();
		int sp = 10 + rnd.Next(6);
		Party.UseSP(sp * -1);
		Item[] dropped = drops;
		drops = new Item[0];
		return dropped;
	}
	
	public override string[] CSDescription() {
		return new string[] {"This is The Politician. They'll frequently campaign to get stronger",
		    "They can put you to sleep, negate your stats, and if you take too long, they'll use a triple attack with their cane",
			"Apparently their weakness is in all the promises they make", 
		"But this doesn't answer the most important question...what party are they from?"}; 
	}
	
}