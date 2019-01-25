public class Instructor : Character {
	
	protected bool cycle;
	protected bool turn1;
	
	public Instructor () {
		health = 14; maxHP = 14; strength = 1; power = 0; charge = 0; defense = 0; guard = 0;
		baseAccuracy = 15; accuracy = 15; dexterity = 3; evasion = 0; type = "Instructor"; passive = new Passive(this);
		quirk = Quirk.GetQuirk(this); special = null; player = false; champion = false; recruitable = false;
		cycle = false; turn1 = true; CreateDrops();
	}
	
	public override TimedMethod[] AI () {
		if (turn1) {
			cycle = true; turn1 = false;
		    return Lecture();
		} else if (cycle) {
		    if (Party.GetPlayer().GetAsleep()) {
				charge = charge + 2;
				return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {ToString() + " is seething. Charge+2"}),
				    new TimedMethod("GetEnemy")};
			} else {
				cycle = false;
				return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {ToString() + " unleashed her wrath"}),
				    new TimedMethod(0, "AudioNumbered", new object[] {"Attack", 1, 2}),
				    new TimedMethod(0, "StagnantAttack", new object[] {false, 1, 1, GetAccuracy(), true, true, false})};
			}
		} else {
			System.Random rnd = new System.Random();
			if (rnd.Next(3) != 0) {
				return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {ToString() + " attacked"}),
				    new TimedMethod(0, "AudioNumbered", new object[] {"Attack", 1, 2}),
   				    new TimedMethod(0, "StagnantAttack", new object[] {false, 1, 1, GetAccuracy(), true, true, false})};
			} else {
				cycle = true;
				return Lecture();
			}
		}
	}
	
	public virtual TimedMethod[] Lecture () {
		TimedMethod[] sleepPart;
		if (Attacks.EvasionCycle(this, Party.GetPlayer())) {
		    sleepPart = Party.GetPlayer().status.Sleep();
		} else {
			sleepPart = new TimedMethod[] {new TimedMethod(60, "Log", new object[] {"It went over your head"})};
		}
		return new TimedMethod[] {new TimedMethod(0, "Audio", new object[] {"Blah"}),
		    new TimedMethod(60, "Log", new object[] {ToString() + " lectured"}), sleepPart[0]};
	}
	
	public override void CreateDrops() {
		drops = ItemDrops.FromPool(new Item[] {new Textbook(), new Pencil(), new Textbook(), new Pencil(), new Textbook(), new Pencil(),
		    new Textbook(), new Pencil(), new Textbook(), new Pencil(), new Coffee()}, ItemDrops.Amount(1, 2));
	}
	
	public override Item[] Loot () {
		System.Random rnd = new System.Random();
		int sp = 3 + rnd.Next(4);
		Party.UseSP(sp * -1);
		Item[] dropped = drops;
		drops = new Item[0];
		return dropped;
	}
	
	
	public override string[] CSDescription () {
		return new string[] {"Instructor - The website seems to be rather condescneding about them not being researchers",
		    "Also what do they teach? That would be an important thing to differentiate",
		    "If you fall asleep during lecture, they'll get irritated and charge their attack until you wake up. So try not to do that"};
	}
}