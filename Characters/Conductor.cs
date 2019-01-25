public class Conductor : Character {
	
	protected int cycle;
	
	public Conductor() {
		health = 19; maxHP = 19; strength = 3; power = 0; charge = 0; defense = 0; guard = 0;
		baseAccuracy = 12; accuracy = 12; dexterity = 4; evasion = 0; type = "Conductor"; passive = new Directive(this);
		quirk = Quirk.GetQuirk(this); special = null; player = false; champion = false; recruitable = false;
		cycle = 0; CreateDrops();
	}
	
	public override TimedMethod[] AI () {
		System.Random rng = new System.Random();
		int num = rng.Next(10);
		if (cycle == 0) {
			return CountIn();
		} else if (num < 4) {
			return Forte();
		} else if (num < 8) {
			return Piano();
		} else {
			return Finale();
		}
	}
	
	public virtual TimedMethod[] CountIn () {
		cycle++;
		foreach (Character c in Party.enemies) {
			if (c != null && c.GetAlive()) {
				c.GainCharge(5);
			}
		}
		return new TimedMethod[] {new TimedMethod(0, "Audio", new object[] {"ConductorCount"}),
		    new TimedMethod(60, "Log", new object[] {ToString() + " initiated the performance. All charge up"})};
	}
	
	public virtual TimedMethod[] Forte() {
		if (Attacks.EvasionCheck(Party.GetPlayer(), GetAccuracy())) {
			Status.NullifyAttack(Party.GetPlayer());
		}
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {ToString() + " caused a forte"}),
		    new TimedMethod(0, "StagnantAttack",new object[] {false, 3, 3, GetAccuracy(), true, true, false})};
	}
	
	public virtual TimedMethod[] Piano() {
		foreach (Character c in Party.enemies) {
			if (c != null && c.GetAlive()) {
				c.Heal(3);
			}
		}
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {ToString() + " caused a piano. Team was healed"})};
	}
	
	public TimedMethod[] Finale() {
		int dmg = 5;
		for (int i = 0; i < 4; i++) {
			if (i != Party.enemySlot - 1 && Party.enemies[i] != null && Party.enemies[i].GetAlive()) {
				Party.enemies[i].SetHealth(0); Party.enemies[i].SetAlive(false); Party.enemyCount--;
				dmg += 5;
			}
		}
		if (dmg > 0) {
			return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {ToString() + " did the finale. All team members deleted"}),
		    new TimedMethod(0, "StagnantAttack",new object[] {false, dmg, dmg, GetAccuracy(), true, true, false})};
		} else {
			return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {ToString() + " attacked with the baton"}),
		    new TimedMethod(0, "StagnantAttack",new object[] {false, 3, 3, GetAccuracy(), true, true, false})};
		}
	}
	
	public override void CreateDrops () {
		drops = ItemDrops.FromPool(new Item[] {new Tuba(), new Whistle(), new Baton(), new Metronome()}, ItemDrops.Amount(1, 2)); 
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
		return new string[] {"Conductor - Their entire team positioning will constantly change",
		    "They can buff or heal their team as well. And if they end the show on their own terms, it will be ugly"};
	}
}