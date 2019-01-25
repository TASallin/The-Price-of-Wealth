public class HistoryMajor : Character {
    
    public HistoryMajor () {
		health = 22; maxHP = 22; strength = 4; power = 0; charge = 0; defense = 0; guard = 0; 
		baseAccuracy = 12; accuracy = 12; dexterity = 1; evasion = 0; type = "History Major"; passive = new Armored(this);
		quirk = Quirk.GetQuirk(this); special = new Joust(); special2 = new Tactics(); 
		player = false; champion = false; recruitable = true; CreateDrops();
	}	
	
	public override TimedMethod[] AI () {
		System.Random rng = new System.Random();
		int num = rng.Next(10);
		if (num < 5) {
			return Sword ();
		} else if (num < 8) {
			return Shield ();
		} else {
			return Tactics ();
		}
	}
	
	public override TimedMethod[] BasicAttack() {
		TimedMethod[] attackPart;
		if (Party.BagContains(new Metronome())) {
			attackPart = Attacks.Attack(this, Party.GetEnemy(), strength + 2, strength + 2, GetAccuracy(), true, true, false);
		} else {
		    attackPart = Attacks.Attack(this, Party.GetEnemy());
		}
		guard += 2;
		TimedMethod[] moves = new TimedMethod[attackPart.Length + 1];
		moves[0] = new TimedMethod(0, "AudioNumbered", new object[] {"Attack", 3, 4});
		attackPart.CopyTo(moves, 1);
		return moves;
	}
	
	public TimedMethod[] Sword () {
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {ToString() + " Swung the actual sword"}),
		    new TimedMethod(0, "AudioNumbered", new object[] {"Attack", 3, 4}),
		    new TimedMethod(0, "Attack", new object[] {false})};
	}
	
	public TimedMethod[] Shield () {
		int amount = new System.Random().Next(4, 9);
		guard += amount;
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {ToString() + " Shield bashed"}),
		    new TimedMethod(0, "AudioNumbered", new object[] {"Attack", 3, 4}),
		    new TimedMethod(0, "StagnantAttack", new object[] {false, 1, 3, GetAccuracy(), true, true, false})};
	}
	
	public TimedMethod[] Tactics () {
		foreach (Character c in Party.enemies) {
			if (c != null && c.GetAlive()) {
				c.GainAccuracy(2);
				c.GainEvasion(4);
			}
		}
		return new TimedMethod[] {new TimedMethod(0, "Audio", new object[] {"Skill2"}), 
		    new TimedMethod(60, "Log", new object[] {ToString() + " Implemented tactics. Party's" 
		    + "evasion and accuracy increased"})};
	}

    public override void CreateDrops() {
	drops = ItemDrops.GuaranteedDrop(new Item[] {new Textbook(), new Curry(), new Pencil(), new PaperPlane()},
    	ItemDrops.Amount(1, 2), new Sword());
	}
	
	public override Item[] Loot () {
		System.Random rnd = new System.Random();
		int sp = 2 + rnd.Next(3);
		Party.UseSP(sp * -1);
		Item[] dropped = drops;
		drops = new Item[0];
		return dropped;
	}
	
	public override string[] CSDescription() {
		return new string[] {"History Major - All those medieval knight sets they've had in a glass case are finally being used"
		, "They're strong in defense, and they know some weird tactics things. Use an item if you can't beat them normally"};
	}
}