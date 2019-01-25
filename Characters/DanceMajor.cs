public class DanceMajor : Character {
	
	public DanceMajor() {
		health = 16; maxHP = 16; strength = 2; power = 0; charge = 0; defense = 0; guard = 0;
		baseAccuracy = 14; accuracy = 14; dexterity = 5; evasion = 0; type = "Dance Major"; passive = new Footwork(this);
		quirk = Quirk.GetQuirk(this); special = new Tumble(); special2 = new Lunge();
		player = false; champion = false; recruitable = true; CreateDrops();
	}
	
	public override TimedMethod[] AI () {
		System.Random rng = new System.Random();
		int num = rng.Next(10);
		if (num < 5) {
			return Attack();
		} else if (num < 8) {
			return Dodge();
		} else {
			return Finish();
		}
	}
	
	public override TimedMethod[] BasicAttack() {
		TimedMethod[] attackPart;
		if (Party.BagContains(new Metronome())) {
			attackPart = Attacks.Attack(this, Party.GetEnemy(), strength + 2, strength + 2, GetAccuracy(), true, true, false);
		} else {
		    attackPart = Attacks.Attack(this, Party.GetEnemy());
		}
		evasion += 3;
		TimedMethod[] moves = new TimedMethod[attackPart.Length + 1];
		moves[0] = new TimedMethod(0, "AudioNumbered", new object[] {"Attack", 1, 2});
		attackPart.CopyTo(moves, 1);
		return moves;
	}
	
	public TimedMethod[] Attack() {
		evasion += 5;
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {ToString() + " made a darting attack"}),
		    new TimedMethod(0, "AudioNumbered", new object[] {"Attack", 1, 2}),
		    new TimedMethod(0, "StagnantAttack", new object[] {false, 3, 3, GetAccuracy(), true, true, false})};
	}
	
	public TimedMethod[] Dodge() {
		evasion += 10;
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {ToString() + " is dodging"})};
	}
	
	public TimedMethod[] Finish() {
		int atk = evasion;
		evasion = 0;
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {ToString() + " used their positioning for a big attack"}),
		    new TimedMethod(0, "AudioNumbered", new object[] {"Attack", 1, 2}),
		    new TimedMethod(0, "StagnantAttack", new object[] {false, atk, atk, GetAccuracy(), true, true, false})};
	}
	
	public override void CreateDrops() {
		drops = ItemDrops.GuaranteedDrop(new Item[] {new Sanitizer(), new Smartphone(), new Whistle(), new Smartphone(), new Smartphone()},
		    ItemDrops.Amount(1, 2), new Heels());
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
		return new string[] {"Dance Major - Of everyone we could encounter, they seem to be the hardest to hit",
		    "They gain evasion with each passing turn. They can also convert it into attack power"};
	}
}