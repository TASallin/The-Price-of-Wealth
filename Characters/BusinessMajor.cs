public class BusinessMajor : Character {
	
	bool summoned;
	bool stolen;
	
	public BusinessMajor() {
		health = 18; maxHP = 18; strength = 3; power = 0; charge = 0; defense = 0; guard = 0;
		baseAccuracy = 15; accuracy = 15; dexterity = 3; evasion = 0; type = "Business Major"; passive = new Profit(this);
		quirk = Quirk.GetQuirk(this); special = new Bargain(); special2 = new ShadyDeal(); player = false; champion = false; recruitable = true;
		summoned = false; stolen = false; CreateDrops();
	}
	
	public override TimedMethod[] AI () {
		System.Random rng = new System.Random();
		int num = rng.Next(10);
		if (num < 4) {
			return Attack();
		} else if (num < 8) {
			return Invest();
		} else if (!stolen) {
			stolen = true;
			return Bargain();
		} else if (health < maxHP / 2 && !summoned) {
			summoned = true;
			return Advertise();
		} else {
			return Switch();
		}
	}
	
	public override TimedMethod[] BasicAttack() {
		System.Random rng = new System.Random();
		TimedMethod blindPart;
		if (rng.Next(10) < 6 && Attacks.EvasionCheck(Party.GetEnemy(), GetAccuracy())) {
			blindPart = Party.GetEnemy().status.Blind(2)[0];
		} else {
			blindPart = new TimedMethod(0, "Log", new object[] {""});
		}
		TimedMethod[] attackPart;
		if (Party.BagContains(new Metronome())) {
			attackPart = Attacks.Attack(this, Party.GetEnemy(), strength + 2, strength + 2, GetAccuracy(), true, true, false);
		} else {
		    attackPart = Attacks.Attack(this, Party.GetEnemy());
		}
		TimedMethod[] moves = new TimedMethod[attackPart.Length + 2];
		moves[0] = new TimedMethod(0, "AudioNumbered", new object[] {"Attack", 5, 6});
		attackPart.CopyTo(moves, 1);
		moves[moves.Length - 1] = blindPart;
		return moves;
	}
	
	public TimedMethod[] Attack () {
	    return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {ToString() + " threw the credit card"}),
		    new TimedMethod(0, "AudioNumbered", new object[] {"Attack", 5, 6}),
		    new TimedMethod(0, "StagnantAttack", new object[] {false, 4, 4, GetAccuracy(), true, true, false})};
	}
	
	public TimedMethod[] Invest() {
		power += 3; defense -= 1;
		return new TimedMethod[] {new TimedMethod(0, "Audio", new object[] {"Skill3"}),
		    new TimedMethod(60, "Log", new object[] {ToString() + " invested. Power+3 and Defense-1"})};
	}
	
	public TimedMethod[] Bargain() {
		if (Attacks.EvasionCycle(this, Party.GetPlayer())) {
		    return new TimedMethod[] {new TimedMethod(0, "Audio", new object[] {"Steal1"}), 
			new TimedMethod(60, "Log", new object[] {ToString() + " made a bargain"}), Party.StealItem()[0]};
		} else {
            return new TimedMethod[] {new TimedMethod(0, "Audio", new object[] {"Steal1"}),
			    new TimedMethod(60, "Log", new object[] {ToString() + " failed to make a bargain"})};
		}			
	}
	
	public TimedMethod[] Advertise() {
		if (Party.enemyCount < 4) {
		    System.Random rng = new System.Random();
	    	int seed;
    		Character current;
		    seed = rng.Next(6);
		    if (seed == 0) {
	    		current = new DanceMajor();
    		} else if (seed == 1) {
			    current = new CSMajor();
		    } else if (seed == 2) {
	    		current = new FootballPlayer();
    		} else if (seed == 3) {
			    current = new CJMajor();
		    } else if (seed == 4) {
	    		current = new ChemistryMajor();
    		} else {
		    	current = new AerospaceEngineer();
	    	}
    		Party.AddEnemy(current);
		    return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {ToString() + " advertised"}),
			    new TimedMethod(60, "Log", new object[] {current.ToString() + " showed up"})};
		} else {
			return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {ToString() + " advertised, but it failed"})};
		}
	}
	
	public TimedMethod[] Switch () {
		if (GetGooped()) {
			return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {ToString() + " tried to switch out but is stuck"})};
		}
		int former = Party.enemySlot;
		for (int i = 0; i < 4; i++) {
			if (i != Party.enemySlot - 1 && Party.enemies[i] != null && Party.enemies[i].GetAlive()) {
				Party.enemySlot = i + 1;
				return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {ToString() + " switched out"}),
				    new TimedMethod(0, "EnemySwitch", new object[] {Party.enemySlot, former})};
			}
		}
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {ToString() + " was halted by taxes"})};
	}
	
	public override void CreateDrops() {
		drops = ItemDrops.FromPool(new Item[] {new Calculator(), new Shuttle(), new ProteinBar(), new Whistle()}, ItemDrops.Amount(1, 2));
	}
	
	public override Item[] Loot () {
		System.Random rng = new System.Random();
		int sp = 2 + rng.Next(3);
		Party.UseSP(sp * -1);
		Item[] dropped = drops;
		drops = new Item[0];
		return dropped;
	}
	
	public override string[] CSDescription () {
		return new string[] {"Business Major - Watch our stuff, they're going to steal it and call it a sale. Also using items makes them stronger",
	    	"Although that would be pretty nice to use ourselves. If you go for a recruit, do it before any customers are attracted"};
	}
}