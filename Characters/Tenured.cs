public class Tenured : Instructor {
	
	
	public Tenured () {
		health = 35; maxHP = 35; strength = 3; dexterity = 4; type = "Tenured"; passive = new Leader(this);
		quirk = Quirk.GetQuirk(this); champion = true; recruitable = false;
		cycle = true; turn1 = true; CreateDrops();
	}
	
	public override TimedMethod[] AI () {
		if (turn1) {
			turn1 = false;
		    return Lecture();
		} else if (cycle && health < maxHP / 2) {
		    cycle = false;
			return Coffee();
		} else {
			System.Random rng = new System.Random();
			int num = rng.Next(10);
			if (num < 4) {
				return Attack();
			} else if (num < 6) {
				return Insult();
			} else if (num < 8) {
				return HighHorse();
			} else {
				return Lecture();
			}
		}
	}
	
	public TimedMethod[] Attack() {
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {ToString() + " attacked"}),
		    new TimedMethod(0, "AudioNumbered", new object[] {"Attack", 5, 6}),
		    new TimedMethod(0, "StagnantAttack", new object[] {false, 3, 3, GetAccuracy(), true, true, false})};
	}
	
	public TimedMethod[] Coffee() {
		status.Coffee();
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {ToString() + " drank the coffee"})};
	}
	
	public TimedMethod[] HighHorse () {
		power += 3; guard += 4; evasion += 4;
		return new TimedMethod[] {new TimedMethod(0, "Audio", new object[] {"Skill3"}),
		    new TimedMethod(60, "Log", new object[] {ToString() + " gloated about her position"})};
	}
	
	public TimedMethod[] Insult () {
		if (Attacks.EvasionCycle(this, Party.GetPlayer())) {
			Party.GetPlayer().GainGuard(-6);
			Party.GetPlayer().GainCharge(-6);
		}
		charge += 5;
		return new TimedMethod[] {new TimedMethod(0, "Audio", new object[] {"Skill3"}),
		    new TimedMethod(60, "Log", new object[] {ToString() + " called you a failure, worthless, ect"})};
	}
	
	public override TimedMethod[] Lecture () {
		TimedMethod[] sleepPart;
		if (Attacks.EvasionCycle(this, Party.GetPlayer())) {
		    sleepPart = Party.GetPlayer().status.Sleep();
			Status.NullifyAttack(Party.GetPlayer()); Status.NullifyDefense(Party.GetPlayer());
		} else {
			sleepPart = new TimedMethod[] {new TimedMethod(0, "Audio", new object[] {"Blah"}),
			    new TimedMethod(60, "Log", new object[] {"It went over your head"})};
		}
		return new TimedMethod[] {new TimedMethod(0, "Audio", new object[] {"Blah"}),
		    new TimedMethod(60, "Log", new object[] {ToString() + " lectured"}), sleepPart[0]};
	}
	
	public override void CreateDrops() {
		drops = ItemDrops.GuaranteedDrop(new Item[] {new Textbook(), new Pencil(), new Textbook(), new Pencil(), new Textbook(), new Pencil(),
		    new Textbook(), new Pencil(), new Textbook(), new Pencil(), new USB(), new VotedBadge()}, ItemDrops.Amount(1, 4), new Coffee());
	}
	
	public override Item[] Loot () {
		System.Random rnd = new System.Random();
		int sp = 4 + rnd.Next(8);
		Party.UseSP(sp * -1);
		Item[] dropped = drops;
		drops = new Item[0];
		return dropped;
	}
	
	
	public override string[] CSDescription () {
		return new string[] {"Tenured - An instructor that has more job security",
		    "They're much more agressive than regular instructors and have coffee privilages",
		    "This battle could get very out of hand if it isn't ended quickly"};
	}
}