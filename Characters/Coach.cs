public class Coach : Character {
	
	public Coach() {
	    health = 21; maxHP = 21; strength = 2; power = 0; charge = 0; defense = 0; guard = 0;
		baseAccuracy = 16; accuracy = 16; dexterity = 2; evasion = 0; type = "Coach"; passive = new DefeatDepower(this);
		quirk = Quirk.GetQuirk(this); special = null; player = false; champion = false; recruitable = false; CreateDrops();
    }
	
	public override TimedMethod[] AI () {
		System.Random rng = new System.Random();
		int num = rng.Next(10);
		if (num < 4) {
			return Rally();
		} else if (num < 7) {
			return Attack();
		} else {
			return Switch();
		}
	}
	
	public TimedMethod[] Rally() {
		foreach (Character c in Party.enemies) {
			if (c != null && c.GetAlive()) {
				c.GainPower(3);
			}
		}
		return new TimedMethod[] {new TimedMethod(0, "Audio", new object[] {"Skill2"}),
		    new TimedMethod(60, "Log", new object[] {ToString() + " gave a pep talk. Team power increased"})};
	}
	
	public TimedMethod[] Attack() {
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {ToString() + " threw a football"}),
		    new TimedMethod(0, "AudioNumbered", new object[] {"Attack", 3, 4}),
	    	new TimedMethod(0, "StagnantAttack", new object[] {false, 3, 3, GetAccuracy(), true, true, false})};
	}
	
	public TimedMethod[] Switch () {
		if (GetGooped()) {
			status.gooped = false;
			return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {ToString() + " escaped the goop"})};
		}
		if (Party.enemyCount > 1) {
			int former = Party.enemySlot;
			for (int i = 0; i < 4; i++) {
				if (i != Party.enemySlot - 1 && Party.enemies[i] != null && Party.enemies[i].GetAlive()) {
					Party.enemySlot = i + 1;
					    return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {ToString() + " quickly switched to " 
					    + Party.GetEnemy().ToString() + ", who attacked"}), new TimedMethod(0, "EnemySwitch", new object[] {Party.enemySlot, former}),
   						new TimedMethod(60, "Attack", new object[] {false})};
				}
			}
		}
		Party.AddEnemy(new FootballPlayer());
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {ToString() + " called a backup player"})};
	}
	
	public override void CreateDrops() {
		drops = ItemDrops.GuaranteedDrop(new Item[] {new Pizza(), new ProteinBar(), new ProteinBar()}, ItemDrops.Amount(1, 2), new Whistle());
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
		return new string[] {"Coach - Very good at buffing their team, and can switch and attack in the same turn",
		    "However, their buffs don't hold up well if their team members get defeated"};
	}
}