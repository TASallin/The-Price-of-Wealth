public class Janitor : Character {
	
	public Janitor() {
		health = 24; maxHP = 24; strength = 2; power = 0; charge = 0; defense = 0; guard = 0;
		baseAccuracy = 12; accuracy = 12; dexterity = 2; evasion = 0; type = "Janitor"; passive = new Passive(this);
		quirk = Quirk.GetQuirk(this); special = null; player = false; champion = false; recruitable = false; CreateDrops();
	}
	
	public override TimedMethod[] AI () {
		if ((GetPoisoned() || GetGooped() || GetBlinded()) && new System.Random().Next(2) == 0) {
			return Clean();
		}
		System.Random rng = new System.Random();
		int num = rng.Next(10);
		if (num < 4) {
			return Broom();
		} else if (num < 7) {
			return Chemicals();
		} else {
			return Exhaust();
		}
	}
	
	public TimedMethod[] Clean() {
		status.gooped = false;
		status.blinded = 0;
		status.poisoned = 0;
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {ToString() + " cleaned negative effects"})};
	}
	
	public TimedMethod[] Broom() {
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {ToString() + " swung a broom"}),
		    new TimedMethod(0, "AudioNumbered", new object[] {"Attack", 3, 4}),
		    new TimedMethod(0, "Attack", new object[] {false})};
	}
	
	public TimedMethod[] Chemicals() {
		TimedMethod[] poisonPart;
		if (Attacks.EvasionCycle(this, Party.GetPlayer())) {
			poisonPart = Party.GetPlayer().status.StackPoison(1);
			Party.GetPlayer().GainPower(-1);
			Party.GetPlayer().GainDefense(-1);
		} else {
			poisonPart = new TimedMethod[] {new TimedMethod(60, "Log", new object[] {"They missed"})};
		}
		return new TimedMethod[] {new TimedMethod(0, "Audio", new object[] {"Skill2"}), 
		    new TimedMethod(60, "Log", new object[] {ToString() + " sprayed toxic, weakening chemicals"}), poisonPart[0]};
	}
	
	public TimedMethod[] Exhaust() {
		TimedMethod[] poisonPart;
		TimedMethod[] blindPart;
		if (Attacks.EvasionCycle(this, Party.GetPlayer())) {
			poisonPart = Party.GetPlayer().status.StackPoison(1);
			blindPart = Party.GetPlayer().status.Blind(5);
		} else {
			poisonPart = new TimedMethod[] {new TimedMethod(60, "Log", new object[] {"They missed"})};
			blindPart = new TimedMethod[] {new TimedMethod(0, "Log", new object[] {""})};
		}
		return new TimedMethod[] {new TimedMethod(0, "Audio", new object[] {"Skill2"}),
		    new TimedMethod(60, "Log", new object[] {ToString() + " released exhaust fumes"}), poisonPart[0], blindPart[0]};
	}
	
	public override void CreateDrops() {
		drops = ItemDrops.GuaranteedDrop(new Item[] {new Sanitizer(), new SlimeGoo(), new ToxicSolution(), new Antibiotics(), new Milk()},
		   ItemDrops.Amount(1, 3), new Sanitizer());
	}
	
	public override Item[] Loot () {
	    System.Random rng = new System.Random();
		int sp = 4 + rng.Next(4);
		Party.UseSP(sp * -1);
		Item[] dropped = drops;
		drops = new Item[0];
		return dropped;
    }	
	
	public override string[] CSDescription () {
		return new string[] {"Janitor - Works with poisons and other debuffs",
		    "Unlike other poisons, the janitors' stack in severity as they are used",
		    "Since switching out inexcplicably halts the toxins, utilize that if it gets too severe"};
	}
}