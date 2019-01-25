public class TeachingAssistant : Character {
    
    public TeachingAssistant() {
        health = 17; maxHP = 17; strength = 3; power = 0; charge = 0; defense = 0; guard = 0;
		baseAccuracy = 14; accuracy = 14; dexterity = 3; evasion = 0; type = "Teaching Assistant"; passive = new CoffeeDetector(this);
		quirk = Quirk.GetQuirk(this); special = null; player = false; champion = false; recruitable = false; CreateDrops();
	}
	
	public override TimedMethod[] AI () {
		System.Random rng = new System.Random();
		int num = rng.Next(10);
		if (num < 4) {
			return Attack();
		} else if (num < 8) {
			return Grade();
		} else {
			return Laziness();
		}
	}
	
	public TimedMethod[] Attack () {
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {ToString() + " tossed a paperweight"}),
		   new TimedMethod(0, "AudioNumbered", new object[] {"Attack", 1, 2}),
	    	new TimedMethod(0, "StagnantAttack", new object[] {false, 2, 5, GetAccuracy(), true, true, false})};
	}
	
	public TimedMethod[] Grade () {
		if (Attacks.EvasionCycle(this, Party.GetPlayer())) {
		    Party.UseSP(3);
		}
		return new TimedMethod[] {new TimedMethod(0, "Audio", new object[] {"Skill1"}),
		    new TimedMethod(60, "Log", new object[] {ToString() + " returned grades. -3 SP"})};
	}
	
	public TimedMethod[] Laziness () {
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {ToString() + " is procrastinating"})};
	}
	
	public override void CreateDrops () {
		drops = ItemDrops.FromPool(new Item[] {new Donut(), new Coffee(), new Pizza(), new Pencil(), new Pencil(), new Smartphone()},
    		ItemDrops.Amount(1, 2));
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
		return new string[] {"Teaching Assistant - Not so broke college students. Their grading has the power to remove our energy",
	    	"They get very resentful if you drink coffee near them. Too many all nighters?"};
	}
	
}