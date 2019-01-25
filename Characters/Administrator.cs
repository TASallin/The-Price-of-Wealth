public class Administrator : Character {
	
	int cycle;
	
	public Administrator() {
		health = 22; maxHP = 22; strength = 3; power = 0; charge = 0; defense = 0; guard = 0;
		baseAccuracy = 13; accuracy = 13; dexterity = 2; evasion = 0; type = "Administrator"; passive = new Leader(this);
		quirk = Quirk.GetQuirk(this); special = null; player = false; champion = false; recruitable = false;
		cycle = 0; CreateDrops();
	}
	
	public override TimedMethod[] AI () {
		//System.Random rng = new System.Random();
		//int num = rng.Next(10);
		if (cycle == 0) {
			cycle++;
			return Summon();
		} else if (Party.enemyCount > 1) {
			return Switch();
		} else if (cycle == 1) {
			cycle++;
			return Fire();
		} else {
			return Attack();
		}
	}
	
	public TimedMethod[] Summon() {
		System.Random rng = new System.Random();
		int seed;
		Character current;
		for (int i = 0; i < 2; i++) {
			seed = rng.Next(6);
			if (seed == 0) {
				current = new Instructor();
			} else if (seed == 1) {
				current = new Researcher();
			} else if (seed == 2) {
				current = new Janitor();
			} else if (seed == 3) {
				current = new Cop();
			} else if (seed == 4) {
				current = new TeachingAssistant();
			} else {
				current = new ShuttleDriver();
			}
			current.SetRecruitable(false);
			Party.AddEnemy(current);
		}
		return new TimedMethod[] {new TimedMethod(60, "Audio", new object[] {"AdminSummon"}),
    		new TimedMethod(60, "Log", new object[] {ToString() + " called in two underlings"})};
	}
	
	public TimedMethod[] Switch() {
		if (GetGooped()) {
			status.gooped = false;
			return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {ToString() + " cleaned the goop"})};
		}
		int former = Party.enemySlot;
		for (int i = 0; i < 4; i++) {
			if (i != Party.enemySlot - 1 && Party.enemies[i] != null && Party.enemies[i].GetAlive()) {
				Party.enemySlot = i + 1;
				return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {ToString() + " ordered the underling to fight"}),
				    new TimedMethod(0, "EnemySwitch", new object[] {Party.enemySlot, former})};
			}
		}
		return Attack();
	}
	
	public TimedMethod[] Fire () {
		charge += 10;
		return new TimedMethod[] {new TimedMethod(60, "Audio", new object[] {"AdminFired"}),
		    new TimedMethod(60, "Log", new object[] {ToString() + " fired the underlings in anger. Charge +10"})};
	}
	
	public TimedMethod[] Attack() {
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {ToString() + " attacked"}), 
		    new TimedMethod(0, "StagnantAttack", new object[] {false, 3, 3, GetAccuracy(), true, true, false})};
	}
	
	public override void CreateDrops() {
		drops = ItemDrops.GuaranteedDrop(new Item[] {new Briefcase()}, ItemDrops.Amount(1, 2), new PinkSlip());
	}
	
	public override Item[] Loot () {
		System.Random rng = new System.Random();
		int sp = 4 + rng.Next(3);
		Party.UseSP(sp * -1);
		Item[] dropped = drops;
		drops = new Item[0];
		return dropped;
	}
	
	public override string[] CSDescription () {
		return new string[] {"Administrator - Get ready to deal with backup that gets powered up by him",
		    "The moment after we defeat their employees is when the administrator is the most powerful"};
	}
}