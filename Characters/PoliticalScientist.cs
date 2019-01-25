public class PoliticalScientist : Character {
	
	public PoliticalScientist() {
		health = 21; maxHP = 21; strength = 3; power = 0; charge = 0; defense = 0; guard = 0;
		baseAccuracy = 13; accuracy = 13; dexterity = 4; evasion = 0; type = "Political Science Major"; passive = new Democracy(this);
		quirk = Quirk.GetQuirk(this); special = new Campaign(); special2 = new Filibuster();
		player = false; champion = false; recruitable = true; CreateDrops();
	}
	
	public override TimedMethod[] AI () {
		System.Random rng = new System.Random();
		int num = rng.Next(10);
		Democracy castPassive = (Democracy)passive;
		if (num < 4 || castPassive.promise == 1) {
			castPassive.promise = 0;
			return Attack();
		} else if (num < 8) {
			castPassive.promise = 2;
			return Campaign();
		} else {
		    return Debate();
		}
	}
	
	public override TimedMethod[] BasicAttack() {
		System.Random rng = new System.Random();
		TimedMethod stunPart;
		if (rng.Next(10) < 5 && Attacks.EvasionCheck(Party.GetEnemy(), GetAccuracy())) {
			stunPart = Party.GetEnemy().status.Stun(2)[0];
		} else {
			stunPart = new TimedMethod(0, "Log", new object[] {""});
		}
		Democracy castPassive = (Democracy)passive;
		castPassive.attacked = true;
		TimedMethod[] attackPart;
		if (Party.BagContains(new Metronome())) {
			attackPart = Attacks.Attack(this, Party.GetEnemy(), strength + 2, strength + 2, GetAccuracy(), true, true, false);
		} else {
		    attackPart = Attacks.Attack(this, Party.GetEnemy());
		}
		TimedMethod[] moves = new TimedMethod[attackPart.Length + 2];
		moves[0] = new TimedMethod(0, "AudioNumbered", new object[] {"Attack", 1, 2});
		attackPart.CopyTo(moves, 1);
		moves[moves.Length - 1] = stunPart;
		return moves;
	}
	
	public TimedMethod[] Attack () {
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {ToString() + " swung the campaign sign"}),
		    new TimedMethod(0, "AudioNumbered", new object[] {"Attack", 1, 2}),
		    new TimedMethod(0, "StagnantAttack", new object[] {false, 4, 4, GetAccuracy(), true, true, false})};
	}
	
	public TimedMethod[] Campaign () {
		power += 1; defense += 1; charge += 2; guard += 2;
		return new TimedMethod[] {new TimedMethod(0, "Audio", new object[] {"Blah"}),
		    new TimedMethod(60, "Log", new object[] {ToString() + " campaigned with the promise of action"})};
	}
	
	public TimedMethod[] Debate () {
	    charge += 4; Party.GetPlayer().GainCharge(4);
		return new TimedMethod[] {new TimedMethod(0, "Audio", new object[] {"Skill1"}),
		    new TimedMethod(60, "Log", new object[] {ToString() + " began debating. All charge up"})};
	}
	
	public override void CreateDrops () {
		drops = ItemDrops.GuaranteedDrop(new Item[] {new Coffee(), new Sanitizer(), new Celery(), new Pencil()}, ItemDrops.Amount(1, 2),
		    new VotedBadge()); 
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
		return new string[] {"Political Science Major - Frequently makes promises to attack in exchange for support",
	    	"So if they don't attack, they lose their support. They're also stronger if their team outnumbers us"};
	}
		
}