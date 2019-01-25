public class CEO : Character {
	
	int cycle;
	int summonCount;
	int monopoly;
	bool horiz;
	bool vert;
	
	
	public CEO () {
		health = 100; maxHP = 100; strength = 5; power = 0; charge = 0; defense = 0; guard = 0;
		baseAccuracy = 14; accuracy = 14; dexterity = 2; evasion = 0; type = "CEO"; passive = new Passive(this);
		quirk = Quirk.GetQuirk(this); special = null; player = false; champion = true; recruitable = false;
		cycle = 0; summonCount = -1; monopoly = 0; horiz = false; vert = false; CreateDrops();
	}
	
	public override TimedMethod[] EnemyTurn () {
		if (horiz) {guard += 5;}
		if (vert) {charge += 5;}
		power += monopoly * Party.usedItems;
		defense += monopoly * Party.usedItems;
		//TimedMethod[] extra = status.Check(this);
		if (GetAsleep() || GetStunned() || GetPassing()) {
			status.passing = false;
			return new TimedMethod[0];
		} else { 
		    return AI();
		}
	}
	
	public override TimedMethod[] AI () {
		System.Random rng = new System.Random();
		if (summonCount == 2) {
			return Switch();
		}
		if (cycle == 0) {
			cycle++;
			if (rng.Next(2) == 0) {
				return Contraband();
			} else {
				return Monopoly();
			}
		} else if (cycle == 1) {
			cycle++;
			return Summon();
		} else if (cycle == 2) {
			cycle++;
			return Switch();
		} else if (cycle == 3) {
			cycle++;
			return Integration(rng);
		} else if (cycle == 4) {
			cycle++;
			return Attack();
		} else if (cycle == 5) {
			cycle++;
			return Stack();
		} else {
			cycle = 3;
			return Attack();
		}
	}
	
	public TimedMethod[] Contraband() {
		TimedMethod[] poisonPart;
		if (Attacks.EvasionCycle(this, Party.GetPlayer())) {
			poisonPart = Party.GetPlayer().status.Poison(3);
		} else {
			poisonPart = new TimedMethod[] {new TimedMethod(60, "Log", new object[] {""})};
		}
		return new TimedMethod[] {new TimedMethod(0, "Audio", new object[] {"CEOLaugh"}),
		    new TimedMethod(60, "Log", new object[] {"The CEO used contraband"}), poisonPart[0]};
	}
	
	public TimedMethod[] Monopoly () {
		monopoly++;
		return new TimedMethod[] {new TimedMethod(0, "Audio", new object[] {"CEOLaugh"}),
		    new TimedMethod(60, "Log",new object[] {"The CEO has a monopoly. Items will give him power and defense"})};
	}
	
	public TimedMethod[] Integration(System.Random rng) {
		summonCount++;
		if (horiz) {
			horiz = false;
			vert = true;
			return new TimedMethod[] {new TimedMethod(0, "Audio", new object[] {"CEOTaunt"}),
			    new TimedMethod(60, "Log",new object[] {"The CEO switched to vertical integration. Attack is increasing"})};
		} else if (vert) {
			horiz = true;
			vert = false;
			return new TimedMethod[] {new TimedMethod(0, "Audio", new object[] {"CEOTaunt"}),
			    new TimedMethod(60, "Log",new object[] {"The CEO switched to horizontal integration. Guard is increasing"})};
		} else {
			if (rng.Next(2) == 0) {
			    horiz = true;
				return new TimedMethod[] {new TimedMethod(0, "Audio", new object[] {"CEOTaunt"}), new TimedMethod(60, "Log",new object[] {
					"The CEO has horizontal integration. Guard will increase by 5 at the start of his turns"})};
			} else {
			    vert = true;
				return new TimedMethod[] {new TimedMethod(0, "Audio", new object[] {"CEOTaunt"}), new TimedMethod(60, "Log",new object[] {
					"The CEO has vertical integration. Charge will increase by 5 at the start of his turns"})};
			}			
		}
	}
	
	public TimedMethod[] Attack() {
		summonCount++;
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {"The CEO attacked"}),
		    new TimedMethod(0, "AudioNumbered", new object[] {"Attack", 3, 4}),
	    	new TimedMethod(0, "StagnantAttack", new object[] {false, 5, 5, GetAccuracy(), true, true, false})};
	}
	
	public TimedMethod[] Stack() {
		summonCount++;
		if (monopoly > 0) {
			monopoly++;
			return new TimedMethod[] {new TimedMethod(0, "Audio", new object[] {"CEOLaugh"}),
			    new TimedMethod(60, "Log",new object[] {"The power of the monopoly grows"})};
		} else {
			return Contraband();
		}
	}
	
	public TimedMethod[] Summon() {
		System.Random rng = new System.Random();
		int seed;
		Character current;
		for (int i = 0; i < 2; i++) {
			seed = rng.Next(6);
			if (seed == 0) {
				current = new Instructor();
			} else if (seed == 1) {
				current = new MusicMajor();
			} else if (seed == 2) {
				current = new MathMajor();
			} else if (seed == 3) {
				current = new CulinaryMajor();
			} else if (seed == 4) {
				current = new Researcher();
			} else {
				current = new MechanicalEngineer();
			}
			current.SetRecruitable(false);
			Party.AddEnemy(current);
		}
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {"The CEO attracted 2 customers"})};
	}
	
	public TimedMethod[] Switch() {
		if (GetGooped()) {
			status.gooped = false;
			return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {"The CEO cleaned the goop and hated it"})};
		}
		for (int i = 1; i < 4; i++) {
			if (Party.enemies[i] != null && Party.enemies[i].GetAlive()) {
				Party.enemySlot = i + 1;
				summonCount = 0;
				return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {"The CEO put a customer in front"}),
				    new TimedMethod(0, "EnemySwitch", new object[] {Party.enemySlot, 1})};
			}
		}
		return Summon ();
	}
	
	public override string SpecificBarText () {
		if (monopoly > 0) {
			return "Monopoly " + monopoly.ToString();
		} else if (cycle == 0) {
			return "";
		} else {
		    return "Contraband";
		}
	}
	
	public override void CreateDrops() {
		drops = ItemDrops.FromPool(new Item[] {new Smartphone(), new Shuttle(), new Donut(), new Briefcase(), new Coffee(), new Defibrilator(),
		    new Textbook()}, ItemDrops.Amount(2, 5));
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
		return new string[] {"This is The CEO. He has a ton of hp",
		    "He can either poison us or cause himself to gain power and defense for every item we play",
			"He'll also set up systems to give him guard and charge every turn", 
		    "Most importantly, he has an endless supply of custormers to summon and will hide behind them"}; 
	}
}