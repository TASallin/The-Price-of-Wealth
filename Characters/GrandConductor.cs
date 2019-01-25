public class GrandConductor : Conductor {
	
	public GrandConductor() {
		health = 30; maxHP = 30; dexterity = 5; type = "Grand Conductor"; passive = new Directive(this);
		champion = true; cycle = 0; CreateDrops();
	}
	
	public override TimedMethod[] AI () {
		System.Random rng = new System.Random();
		int num = rng.Next(4);
		if (Party.enemyCount <= 2) {
			return Summon();
		}
		if (cycle == 0) {
			cycle++;
			return CountIn();
		} else if (num == 0) {
			return Forte();
		} else if (num == 1) {
			return Piano();
		} else if (num == 2) {
			return Allegro();
		} else {
			return Largo();
		}
	}
	
	public override TimedMethod[] CountIn () {
		foreach (Character c in Party.enemies) {
			if (c != null && c.GetAlive()) {
				c.GainCharge(10);
			}
		}
		return new TimedMethod[] {new TimedMethod(0, "Audio", new object[] {"ConductorCount"}),
		    new TimedMethod(60, "Log", new object[] {ToString() + " initiated the performance. All charge up"})};
	}
	
	public TimedMethod[] Forte() {
		foreach (Character c in Party.enemies) {
			if (c != null && c.GetAlive()) {
				c.GainPower(3);
			}
		}
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {ToString() + " called upon a forte. All power up"})};
	}
	
	public TimedMethod[] Piano() {
		foreach (Character c in Party.enemies) {
			if (c != null && c.GetAlive()) {
				c.Heal(6);
			}
		}
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {ToString() + " called upon a piano. Team was healed"})};
	}
	
	public TimedMethod[] Allegro() {
		foreach (Character c in Party.enemies) {
			if (c != null && c.GetAlive()) {
				c.GainEvasion(8); c.GainAccuracy(1);
			}
		}
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {ToString() + " called upon an allegro. All speed up"})};
	}
	
	public TimedMethod[] Largo() {
		foreach (Character c in Party.enemies) {
			if (c != null && c.GetAlive()) {
				c.GainGuard(5); c.GainDefense(1);
			}
		}
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {ToString() + " called upon a largo. All defense up"})};
	}
	
	public TimedMethod[] Summon() {
	System.Random rng = new System.Random();
		int seed;
		Character current;
		for (int i = 0; i < 2; i++) {
			seed = rng.Next(6);
			if (seed == 0) {
				current = new DanceMajor();
			} else if (seed == 1) {
				current = new PizzaCultist();
			} else if (seed == 2) {
				current = new HistoryMajor();
			} else {
				current = new MusicMajor();
			}
			current.SetRecruitable(false);
			Party.AddEnemy(current);
		}
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {ToString() + " led more performers to the scene"})};
    }
	
	public override void CreateDrops () {
		drops = ItemDrops.GuaranteedDrop(new Item[] {new Metronome()}, ItemDrops.Amount(1, 2), new Baton()); 
	}
	
	public override Item[] Loot () {
		System.Random rng = new System.Random();
		int sp = 8 + rng.Next(5);
		Party.UseSP(sp * -1);
		Item[] dropped = drops;
		drops = new Item[0];
		return dropped;
	}
	
	public override string[] CSDescription () {
		return new string[] {"Grand Conductor - Forget the neverending underlings, just take out this one",
		    "If we can power up while they switch positions it'll be better for us"};
	}
}