public class ShuttleDriver : Character {
	
	int fleeing;
	
	public ShuttleDriver() {
        health = 24; maxHP = 24; strength = 3; power = 0; charge = 0; defense = 1; guard = 0; 
		baseAccuracy = 14; accuracy = 14; dexterity = 3; evasion = 0; type = "Shuttle Driver"; passive = new Passive(this);
		quirk = Quirk.GetQuirk(this); special = null; player = false; champion = false; recruitable = false; CreateDrops();
		fleeing = 0;
	}
	
	public override TimedMethod[] AI () {
		System.Random rng = new System.Random();
		int n = rng.Next(10);
		if (fleeing == 1) {
		    return Rev ();
		} else if (fleeing == 2) {
			return RunOver();
		} else if (health < maxHP / 2) {
			return Prepare ();
		} else if (n < 4) {
			return Complain();
		} else if (n < 7) {
			return Beer();
		} else {
			return Attack();
		}
	}
	
	public TimedMethod[] Prepare() {
		fleeing = 1; evasion += 5;
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {ToString() + " retreated inside the shuttle"})};
	}
	
	public TimedMethod[] Rev() {
		fleeing = 2;
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {ToString() + " revved the engines"})};
	}
	
	public TimedMethod[] Complain() {
		int num;
		if (power < 2) {
			num = 2;
		} else {
			num = 1;
		}
		power += num;
		return new TimedMethod[] {new TimedMethod(0, "Audio", new object[] {"Skill2"}), 
		new TimedMethod(60, "Log", new object[] {ToString() 
		+ " complained about money, people, and politics. Power + " + num.ToString()}), new TimedMethod("GetEnemy")};
	}
	
	public TimedMethod[] Beer() {
		health = System.Math.Min(health + 7, maxHP);
		accuracy -= 2; defense -= 1;
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {ToString() 
		+ " drank a beer. +7hp, defense and accuracy down"}), new TimedMethod("GetEnemy")};
	}
	
	public TimedMethod[] Attack() {
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {ToString() + " Attacked"}),
		    new TimedMethod(0, "AudioNumbered", new object[] {"Attack", 3, 4}),
		    new TimedMethod(0, "StagnantAttack", new object[] {false, 3, 3, GetAccuracy(), true, true, false})};
	}
	
	public TimedMethod[] RunOver() {
		TimedMethod move;
		string message;
		if (GetAccuracy() > Party.GetPlayer().GetEvasion()) {
		    move = new TimedMethod(0, "AttackAll", new object[] {false, 10, 10, GetAccuracy(), true});
			message = ToString() + " Ran everyone over";
		} else {
			move = new TimedMethod(0, "StagnantAttack", new object[] {false, 10, 10, GetAccuracy(), true, true, false});
			message = ToString() + " Ran everyone over...but just missed";
		}
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {message}), move
		    , new TimedMethod("WinDelay")};
	}
	
	public override void CreateDrops() {
		drops = ItemDrops.GuaranteedDrop(new Item[] {new Pizza(), new Donut(), new Oil(), new Rice(), new Milk()},
		    ItemDrops.Amount(1, 3), new Shuttle());
	}
	
	public override Item[] Loot() {
		System.Random rnd = new System.Random();
		int sp = 4 + rnd.Next(3);
		Party.UseSP(sp * -1);
		Item[] dropped = drops;
		drops = new Item[0];
		return dropped;
	}
	
	public override string[] CSDescription () {
		return new string[] {"Shuttle Driver - complete with the actual bus and a neverending supply of beer...",
		    "The more they drink, the less dangerous they become, but if they complain they'll get more dangerous...not helpful",
			"Also when they have low hp, they'll begin a process of running us over with the shuttle",
		    "If you can't take them out in time, be sure to run as soon as they start preparing"};
	}
}