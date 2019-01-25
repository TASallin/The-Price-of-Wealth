public class PreMed : Character {
	
	public PreMed() {
		health = 16; maxHP = 16; strength = 4; power = 0; charge = 0; defense = 0; guard = 0;
		baseAccuracy = 16; accuracy = 16; dexterity = 2; evasion = 0; type = "Pre-Med Student"; passive = new Precision(this);
		quirk = Quirk.GetQuirk(this); special = new Triage(); special2 = new Prescribe(); 
		player = false; champion = false; recruitable = true; CreateDrops();
	}
	
	public override TimedMethod[] AI () {
		System.Random rng = new System.Random();
		int num = rng.Next(10);
		if (num < 4) {
			return Treat();
		} else if (num < 7) {
			return Attack();
		} else {
			return Steroid();
		}
	}
	
	public override TimedMethod[] BasicAttack() {
		TimedMethod[] attackPart;
		if (Party.BagContains(new Metronome())) {
			attackPart = Attacks.Attack(this, Party.GetEnemy(), strength + 2, strength + 2, GetAccuracy(), true, true, true);
		} else {
		    attackPart = Attacks.Attack(this, Party.GetEnemy(), strength, strength + 5, GetAccuracy(), true, true, true);
		}
		TimedMethod[] moves = new TimedMethod[attackPart.Length + 1];
		moves[0] = new TimedMethod(0, "AudioNumbered", new object[] {"Attack", 1, 2});
		attackPart.CopyTo(moves, 1);
		return moves;
	}
	
	public TimedMethod[] Treat() {
		System.Random rng = new System.Random();
		Heal(8 + rng.Next(5));
		return new TimedMethod[] {new TimedMethod(0, "Audio", new object[] {"Skill1"}),
		    new TimedMethod(60, "Log", new object[] {ToString() + " healed themself"})};
	}
	
	public TimedMethod[] Attack () {
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {ToString() + " used a surgical knife"}),
		new TimedMethod(0, "AudioNumbered", new object[] {"Attack", 1, 2}),
		new TimedMethod(0, "StagnantAttack", new object[] {false, 4, 4, GetAccuracy(), true, true, true})};
	}
	
	public TimedMethod[] Steroid() {
		power += 2; defense -= 1;
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {ToString() + " used steroids. Power up and defense down"})};
	}
	
	public override void CreateDrops() {
		drops = ItemDrops.FromPool(new Item[] {new Defibrilator(), new Antibiotics(), new Sanitizer(), new Antibiotics(), new Sanitizer()},
		    ItemDrops.Amount(1, 2));
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
		return new string[] {"Pre-Med Student - Aside from the obvious healing, their attacks ignore most defenses",
	    	"They have ways to gain power as well, so try to beat them before they drag the fight out too long"};
	}
}