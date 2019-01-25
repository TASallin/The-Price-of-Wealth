public class Representative : Character {
	
	int cycle;
	
	public Representative() {
		health = 16; maxHP = 16; strength = 3; power = 0; charge = 0; defense = 0; guard = 0;
		baseAccuracy = 11; accuracy = 11; dexterity = 3; evasion = 0; type = "Representative"; passive = new Profit(this);
		quirk = Quirk.GetQuirk(this); special = null; player = false; champion = false; recruitable = false;
		cycle = 0; CreateDrops();
	}
	
	public override TimedMethod[] AI () {
		if (cycle == 0) {
			return Steal();
		} else if (cycle == 1) {
			return Read();
		} else {
			return Attack();
		}
	}
	
	public TimedMethod[] Steal() {
		TimedMethod[] attempt = Party.StealItem();
		if (attempt[0].args[0] == "Nothing was stolen" || attempt[0].args[0] == "A briefcase prevents theft") {
			cycle = -1;
		} else {
			cycle = 1;
		}
		return new TimedMethod[] {new TimedMethod(0, "Audio", new object[] {"Steal1"}), 
		    new TimedMethod(60, "Log", new object[] {ToString() + " demanded to see resumes"}), attempt[0]};
	}
	
	public TimedMethod[] Read() {
		cycle = 2;
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {ToString() + " read the resume, shaking his head"})};
	}
	
	public TimedMethod[] Attack() {
		int dmg;
		string message;
		if (cycle == 2) {
			dmg = 10;
			message = " rejected you";
		} else {
			dmg = 2;
			message = " attacked normally";
		}
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {ToString() + message}),
            new TimedMethod(0, "AudioNumbered", new object[] {"Attack", 5, 6}),		
		    new TimedMethod(0, "StagnantAttack", new object[] {false, dmg, dmg, GetAccuracy(), true, true, false})};
	}
	
	public override void CreateDrops() {
	    drops = ItemDrops.GuaranteedDrop(new Item[] {new PinkSlip(), new Coffee()}, ItemDrops.Amount(1, 2), new Briefcase());
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
		return new string[] {"Representative - Their gameplan is pretty straightforward",
		    "steal whatever looks like a resume, get mad at it, then attack",
			"If they fail the steal, they get a lot weaker, but items will make them stronger"};
	}
}