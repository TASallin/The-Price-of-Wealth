public class CSMajor : Character {
    
	public int attacks;
	
    public CSMajor() {
        health = 16; maxHP = 16; strength = 2; power = 0; charge = 0; defense = 0; guard = 0; 
		baseAccuracy = 18; accuracy = 18; dexterity = 4; evasion = 0; type = "CS Major"; passive = new WikiHPedia(this);
		quirk = Quirk.GetQuirk(this); special = new Recursion(); special2 = new Internet(); player = false; champion = false; recruitable = true;
		attacks = 0; CreateDrops();
	}

	
	public override TimedMethod[] AI () {
		System.Random rnd = new System.Random();
		int seed = rnd.Next(10);
		TimedMethod[] moves;
		if (seed > 9 - attacks) {
			moves = new TimedMethod[attacks + 2];
			moves[0] = new TimedMethod(60, "Log", new object[] {"The " + ToString() + " used recursion"});
			moves[1] = new TimedMethod(0, "Audio", new object[] {"Skill1"});
			for (int i = 1; i < attacks; i++) {
				moves[i + 1] = new TimedMethod(0, "StagnantAttack", new object[] {false, 2, 3, GetAccuracy(), true, false, false});
			}
			moves[attacks + 1] = new TimedMethod(0, "StagnantAttack", new object[] {false, 2, 3, GetAccuracy(), true, true, false});
		} else if (seed < 6) {
			attacks++;
			moves = new TimedMethod[] {new TimedMethod(60, "Log", new object[] {"The " + ToString() + " chucked a monitor "}),
			    new TimedMethod(0, "AudioNumbered", new object[] {"Attack", 1, 2}),
			    new TimedMethod(0, "StagnantAttack", new object[] {false, 2, 6, GetAccuracy(), true, true, false})};
		} else {
			evasion += 8;
			moves = new TimedMethod[] {new TimedMethod(60, "Log", new object[] {"The " + ToString() + " googled you"})
			, new TimedMethod(60, "Log", new object[] {"They now know general information about your major. Also evasion increased"})};
		}
		return moves;
	}
	
	public override TimedMethod[] BasicAttack() {
		attacks++;
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
	
	public override void CreateDrops() {
		drops = ItemDrops.FromPool(new Item[] {new Smartphone(), new Wire(), new Smartphone(), new Smartphone(), new Smartphone(), new Smartphone(),
	    	new Pizza(), new Pencil(), new Coffee(), new USB()}, ItemDrops.Amount(1, 2));
	}
	
	public override Item[] Loot () {
		System.Random rnd = new System.Random();
		int sp = 2 + rnd.Next(3);
		Party.UseSP(sp * -1);
		Item[] dropped = drops;
		drops = new Item[0];
		return dropped;
	}
	
	public virtual void PostBattle() {
		attacks = 0; power = 0; charge = 0; defense = 0; guard = 0; evasion = 0; accuracy = baseAccuracy; status.PostBattle();
	}
	
	public override string[] CSDescription() {
		return new string[] {"CS Major - Apparently they always use the internet to know things about people instead of regular interaction",
		    "...that's a complete lie.", "They have low attack power, but if the battle gets dragged out they'll attack more times a turn"};
    }
}