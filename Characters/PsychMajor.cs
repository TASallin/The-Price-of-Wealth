public class PsychMajor : Character {
	
	public PsychMajor() {
		health = 16; maxHP = 16; strength = 3; power = 0; charge = 0; defense = 0; guard = 0;
		baseAccuracy = 16; accuracy = 16; dexterity = 4; evasion = 0; type = "Psychology Major"; passive = new Persuasive(this);
		quirk = Quirk.GetQuirk(this); special = new Hypnotize(); special2 = new Encouragement();
		player = false; champion = false; recruitable = true; CreateDrops();
	}
	
	public override TimedMethod[] AI () {
		System.Random rng = new System.Random();
		int num = rng.Next(10);
		if (num < 5) {
			return Attack();
		} else if (num < 8) {
			return Sleep();
		} else {
			return Nothing();
		}
	}
	
	public override TimedMethod[] BasicAttack() {
		TimedMethod apathyPart;
		if (Attacks.EvasionCheck(Party.GetEnemy(), GetAccuracy())) {
			apathyPart = Party.GetEnemy().status.CauseApathy(1)[0];
		} else {
			apathyPart = new TimedMethod(0, "Log", new object[] {""});
		}
		TimedMethod[] attackPart;
		if (Party.BagContains(new Metronome())) {
			attackPart = Attacks.Attack(this, Party.GetEnemy(), strength + 2, strength + 2, GetAccuracy(), true, true, false);
		} else {
		    attackPart = Attacks.Attack(this, Party.GetEnemy());
		}
		TimedMethod[] moves = new TimedMethod[attackPart.Length + 2];
		moves[0] = new TimedMethod(0, "AudioNumbered", new object[] {"Attack", 1, 2});
		attackPart.CopyTo(moves, 1);
		moves[moves.Length - 1] = apathyPart;
		return moves;
	}
	
	public TimedMethod[] Attack() {
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {ToString() + " threw a dried brain"}),
		    new TimedMethod(0, "AudioNumbered", new object[] {"Attack", 1, 2}),
		    new TimedMethod(0, "Attack", new object[] {false})};
	}
	
	public TimedMethod[] Sleep() {
		TimedMethod[] sleepPart;
		if (Attacks.EvasionCycle(this, Party.GetPlayer())) {
			sleepPart = Party.GetPlayer().status.Sleep();
		} else {
			sleepPart = new TimedMethod[] {new TimedMethod(60, "Log", new object[] {"And nothing happened"})};
		}
		return new TimedMethod[] {new TimedMethod(0, "Audio", new object[] {"Skill1"}),
		    new TimedMethod(60, "Log", new object[] {ToString() + " let the pendulum sway"}), sleepPart[0]};
	}
	
	public TimedMethod[] Nothing() {
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {ToString() + " was inhibited by superego"})};
	}
	
	public override void CreateDrops() {
		drops = ItemDrops.GuaranteedDrop(new Item[] {new Whistle(), new Smartphone(), new Rice(), new PaperPlane()}, 
		    ItemDrops.Amount(1, 2), new Pendulum());
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
		return new string[] {"Psychology Major - Can read minds, make people quit smoking, and trap our brains in an infinite dimension",
	    	"Or was that psychiatry? Whatever. Just don't get hypnotized"};
	}
}