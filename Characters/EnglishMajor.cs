public class EnglishMajor : Character {
	
	public EnglishMajor() {
		health = 15; maxHP = 15; strength = 2; power = 0; charge = 0; defense = 0; guard = 0;
		baseAccuracy = 14; accuracy = 14; dexterity = 4; evasion = 0; type = "English Major"; passive = new Reading(this);
		quirk = Quirk.GetQuirk(this); special = new Quote(); special2 = new Read(); 
		player = false; champion = false; recruitable = true; CreateDrops();
	}
	
	public override TimedMethod[] AI () {
		System.Random rng = new System.Random();
		int num = rng.Next(10);
		if (num < 4) {
			return Attack();
		} else if (num < 7) {
			return Insult();
		} else {
			return Argument();
		}
	}
	
	public override TimedMethod[] BasicAttack() {
		TimedMethod[] attackPart;
		if (Party.BagContains(new Metronome())) {
			attackPart = Attacks.Attack(this, Party.GetEnemy(), strength + 2, strength + 2, GetAccuracy(), true, true, false);
		} else {
		    attackPart = Attacks.Attack(this, Party.GetEnemy());
		}
		TimedMethod switchPart = new TimedMethod(0, "Log", new object[] {""});
		if (Party.playerCount > 1) {
	    	int steps = new System.Random().Next(Party.playerCount - 1);
		    for (int i = 0; i < 4; i++) {
			    if (Party.members[i] != null && Party.members[i].GetAlive() && i != Party.playerSlot - 1) {
				    if (steps == 0) {
					   	switchPart = new TimedMethod(60, "SwitchTo", new object[] {i + 1});
    				} else {
	    				steps--;
		    		}
		    	}
    		}
     	}
		TimedMethod[] moves = new TimedMethod[attackPart.Length + 2];
		moves[0] = new TimedMethod(0, "AudioNumbered", new object[] {"Attack", 1, 2});
		attackPart.CopyTo(moves, 1);
		moves[moves.Length - 1] = switchPart;
		return moves;
	}
	
	public TimedMethod[] Attack () {
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {ToString() + " swung a dictionary"}),
		new TimedMethod(0, "AudioNumbered", new object[] {"Attack", 1, 2}),
		new TimedMethod(0, "Attack", new object[] {false})};
	}
	
	public TimedMethod[] Insult() {
		if (Attacks.EvasionCycle(this, Party.GetPlayer())) {
	    	Party.GetPlayer().GainCharge(3);
		    Party.GetPlayer().GainDefense(-2);
			return new TimedMethod[] {new TimedMethod(0, "Audio", new object[] {"EnglishTaunt"}), 
			    new TimedMethod(60, "Log", new object[] {ToString() + " insulted in old English. Defense down and charge up"})};
		} else {
			return new TimedMethod[] {new TimedMethod(0, "Audio", new object[] {"EnglishTaunt"}), 
			    new TimedMethod(60, "Log", new object[] {ToString() + " insulted in old English. It went over your head"})};
		}
	}
	
	public TimedMethod[] Argument() {
		power = System.Math.Max(power, 0); charge = System.Math.Min(charge + 5, 5);
		return new TimedMethod[] {new TimedMethod(0, "Audio", new object[] {"Blah"}), new TimedMethod(60, "Log", new object[] {
			ToString() + " constructed an argument. Attack debuffs removed and charge up"})};
	}
	
	public override void CreateDrops() {
		drops = ItemDrops.FromPool(new Item[] {new Pencil(), new Pencil(), new Pencil(), new Textbook(), new Curry(), new Coffee()},
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
		return new string[] {"English Major - Tristan can't think of anything witty to say about this right now",
	    	"Here is some text that should be patched out later"};
	}
		
}