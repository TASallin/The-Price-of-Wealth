public class AerospaceEngineer : Character {
	
	public AerospaceEngineer() {
		health = 14; maxHP = 14; strength = 4; power = 0; charge = 0; defense = 0; guard = 0;
		baseAccuracy = 16; accuracy = 16; dexterity = 3; evasion = 0; type = "Aerospace Engineering Major"; passive = new Airstrike(this);
		quirk = Quirk.GetQuirk(this); special = new Drone(); special2 = new Rocket();
		player = false; champion = false; recruitable = true; CreateDrops();
	}
	
	public override TimedMethod[] AI () {
		System.Random rng = new System.Random();
		int num = rng.Next(10);
		if (num < 4) {
			return Drone();
		} else if (num < 7) {
			return Rocket();
		} else {
			return Exhaust();
		}
	}
	
	public override TimedMethod[] BasicAttack() {
		TimedMethod[] attackPart;
		if (Party.BagContains(new Metronome())) {
			attackPart = Attacks.Attack(this, Party.GetEnemy(), strength + 2, strength + 2, GetAccuracy(), true, true, false);
		} else {
		    attackPart = Attacks.Attack(this, Party.GetEnemy());
		}
		charge += 1;
		TimedMethod[] moves = new TimedMethod[attackPart.Length + 1];
		moves[0] = new TimedMethod(0, "AudioNumbered", new object[] {"Attack", 1, 2});
		attackPart.CopyTo(moves, 1);
		return moves;
	}
	
	public TimedMethod[] Drone () {
	    return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {ToString() + " fired the drone"}),
	        new TimedMethod(0, "StagnantAttack", new object[] {false, 3, 3, GetAccuracy(), true, false, false}),
		    new TimedMethod(0, "StagnantAttack", new object[] {false, 3, 3, GetAccuracy(), true, true, false})};
	}
	
	public TimedMethod[] Rocket () {
		TimedMethod[] stunPart;
		if (Attacks.EvasionCheck(Party.GetPlayer(), GetAccuracy() / 2)) {
			stunPart = Party.GetPlayer().status.Stun(2);
		} else {
			stunPart = new TimedMethod[] {new TimedMethod(60, "Log", new object[] {""})};
		}
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {ToString() + " launched an erratic rocket"}),
		    new TimedMethod(0, "StagnantAttack", new object[] {false, 8, 8, GetAccuracy() / 2, true, true, false}), stunPart[0]};
	}
	
	public TimedMethod[] Exhaust() {
		if (Attacks.EvasionCycle(this, Party.GetPlayer())) {
		    Party.GetPlayer().GainGuard(-5);
		    Party.GetPlayer().GainEvasion(-5);
		    return new TimedMethod[] {new TimedMethod(0, "AudioNumbered", new object[] {"Attack", 1, 2})
			    ,new TimedMethod(60, "Log", new object[] {ToString() + " Sprayed exhaust fumes. Evasion and guard decreased"})};
		} else {
			return new TimedMethod[] {new TimedMethod(0, "AudioNumbered", new object[] {"Attack", 1, 2}),
			    new TimedMethod(60, "Log", new object[] {ToString() + " Sprayed exhaust fumes. It missed"})};
		}
	}
	
	public override void CreateDrops () {
		drops = ItemDrops.GuaranteedDrop(new Item[] {new Oil(), new PaperPlane(), new Wire(), new Pizza(), new Smartphone()},
    		ItemDrops.Amount(1, 2), new PaperPlane());
	}
	
	public override Item[] Loot () {
		System.Random rnd = new System.Random();
		int sp = 2 + rnd.Next(3);
		Party.UseSP(sp * -1);
		Item[] dropped = drops;
		drops = new Item[0];
		return dropped;
	}
	
	public override string[] CSDescription () {
		return new string[] {"Aerospace Engineering Major - Works with flying things. Like that drone hovering around",
		    "At the start of the fight they'll call in a powerful air-strike. Don't be around for that",
		    "Despite all their attacks, they have a weak defense, and the air-strike will fail if they're not conscious"};
	}
}