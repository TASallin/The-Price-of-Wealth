public class Researcher : Character {
	
	public Researcher() {
		health = 16; maxHP = 16; strength = 1; power = 0; charge = 0; defense = 0; guard = 0;
		baseAccuracy = 16; accuracy = 16; dexterity = 2; evasion = 0; type = "Researcher"; passive = new Accurate(this);
		quirk = Quirk.GetQuirk(this); special = null; player = false; champion = false; recruitable = false; CreateDrops();
	}
	
	public override TimedMethod[] AI () {
		System.Random rng = new System.Random();
		int num = rng.Next(10);
		if (num < 4) {
			return Explosive();
		} else if (num < 7) {
			return Poison();
		} else {
			return Shock();
		}
	}
	
	public TimedMethod[] Explosive() {
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {ToString() + " threw an explosive flask"}),
		    new TimedMethod(0, "Audio", new object[] {"Skill3"}),
		    new TimedMethod(0, "StagnantAttack", new object[] {false, 6, 6, GetAccuracy(), true, true, false})};
	}
	
	public TimedMethod[] Poison() {
		TimedMethod[] poisonPart;
		if (Attacks.EvasionCycle(this, Party.GetPlayer())) {
			poisonPart = Party.GetPlayer().status.Poison(2);
		} else {
			poisonPart = new TimedMethod[] {new TimedMethod(60, "Log", new object[] {"miss"})};
		}
	    return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {ToString() + " threw a toxic brew"}),
		new TimedMethod(0, "Audio", new object[] {"Skill3"}), poisonPart[0]};
	}
	
	public TimedMethod[] Shock() {
		if (Attacks.EvasionCheck(Party.GetPlayer(), GetAccuracy())) {
			Status.NullifyDefense(Party.GetPlayer());
		}
	    return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {ToString() + " used electric wires"}),
		    new TimedMethod(0, "AudioNumbered", new object[] {"Attack", 5, 6}),
		    new TimedMethod(0, "StagnantAttack", new object[] {false, 2, 2, GetAccuracy(), true, true, true})};
	}
	
	public override void CreateDrops() {
		drops = ItemDrops.FromPool(new Item[] {new MysteryGoo(), new MysterySolution(), new MysteryGoo(), new MysterySolution(), new ToxicSolution(),
	        new Flask(), new Calculator(), new Sanitizer(), new Wire()}, ItemDrops.Amount(1, 2));
	}
	
	public override Item[] Loot () {
		System.Random rng = new System.Random();
		int sp = 2 + rng.Next(4);
		Party.UseSP(sp * -1);
		Item[] dropped = drops;
		drops = new Item[0];
		return dropped;
	}
	
	public override string[] CSDescription () {
		return new string[] {"Researcher - Expect plenty of flying chemicals and electricity",
		    "They'll also begin reading our movements as the battle goes on"};
	}
}