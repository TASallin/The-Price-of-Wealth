public class CJMajor : Character {
	
	public CJMajor() {
		health = 19; maxHP = 19; strength = 4; power = 0; charge = 0; defense = 0; guard = 0;
		baseAccuracy = 12; accuracy = 12; dexterity = 3; evasion = 0; type = "Criminal Justice Major"; passive = new Outgun(this);
		quirk = Quirk.GetQuirk(this); special = new Taze(); special2 = new Handcuffs(); 
		player = false; champion = false; recruitable = true; CreateDrops();
	}
	
	public override TimedMethod[] AI () {
		System.Random rng = new System.Random();
		int num = rng.Next(10);
		if (num < 3) {
			return Tazer();
		} else if (num < 7) {
			return Baton();
		} else {
			return Handcuffs();
		}
	}
	
	public override TimedMethod[] BasicAttack() {
		if (Attacks.EvasionCheck(Party.GetEnemy(), GetAccuracy())) {
			Heal(2);
		}
		TimedMethod[] attackPart;
		if (Party.BagContains(new Metronome())) {
			attackPart = Attacks.Attack(this, Party.GetEnemy(), strength + 2, strength + 2, GetAccuracy(), true, true, false);
		} else {
		    attackPart = Attacks.Attack(this, Party.GetEnemy());
		}
		TimedMethod[] moves = new TimedMethod[attackPart.Length + 1];
		moves[0] = new TimedMethod(0, "AudioNumbered", new object[] {"Attack", 1, 2});
		attackPart.CopyTo(moves, 1);
		return moves;
	}
	
	public TimedMethod[] Tazer() {
		TimedMethod[] stunPart;
		if (Attacks.EvasionCheck(Party.GetPlayer(), GetAccuracy())) {
		    stunPart = Party.GetPlayer().status.Stun(2);
		} else {
			stunPart = new TimedMethod[] {new TimedMethod(0, "Log", new object[] {""})};
		}
	    return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {ToString() + " fired a tazer"}),
		    new TimedMethod(0, "AudioNumbered", new object[] {"Attack", 1, 2}),
		    new TimedMethod(0, "StagnantAttack", new object[] {false, 6, 6, GetAccuracy(), true, true, true}), stunPart[0]};
	}
	
	public TimedMethod[] Baton() {
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {ToString() + " attacked with a baton"}), 
		    new TimedMethod(0, "AudioNumbered", new object[] {"Attack", 1, 2}),
		    new TimedMethod(0, "Attack", new object[] {false})};
	}
	
	public TimedMethod[] Handcuffs() {
		TimedMethod[] goopPart;
		if (Attacks.EvasionCycle(this, Party.GetPlayer())) {
		    goopPart = Party.GetPlayer().status.Goop();
		} else {
			goopPart = new TimedMethod[] {new TimedMethod(60, "Log", new object[] {"Miss"})};
		}
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {ToString() + " Applied Handcuffs"}), goopPart[0]};
	}
	
	public override void CreateDrops() {
		drops = ItemDrops.GuaranteedDrop(new Item[] {new Donut(), new Coffee(), new Smartphone(), new Pencil()}, ItemDrops.Amount(1, 2),
		    new Tazer());
	}
	
	public override Item[] Loot () {
		System.Random rng = new System.Random();
		int sp = 3 + rng.Next(3);
		Party.UseSP(sp * -1);
		Item[] dropped = drops;
		drops = new Item[0];
		return dropped;
	}
	
	public override string[] CSDescription () {
		return new string[] {"Criminal Justice Major - Future cops and stuff. Particularly skilled at fighting",
		    "Depending on their level of motivation, this situation is either really good or bad for their job",
			"They get stronger the more charge their enemies have. Be mindful of your strategy"};
	}
}