public class Slime : Character {
	
	public Slime() {
		health = 10; maxHP = 10; strength = 1; power = 0; charge = 0; defense = 0; guard = 0;
		baseAccuracy = 10; accuracy = 10; dexterity = 1; evasion = 0; type = "Slime"; passive = new Splitter(this);
		quirk = Quirk.GetQuirk(this); special = null; player = false; champion = false; recruitable = false; CreateDrops();
	}
	
	public override TimedMethod[] AI () {
		System.Random rng = new System.Random();
		int num = rng.Next(10);
		if (num < 3) {
			return Slam();
		} else if (num < 7) {
			return Heal();
		} else {
			return Creep();
		}
	}
	
	public TimedMethod[] Slam() {
		TimedMethod[] poisonPart;
		if (Attacks.EvasionCheck(Party.GetPlayer(), GetAccuracy())) {
			poisonPart = Party.GetPlayer().status.Poison(2);
		} else {
			poisonPart = new TimedMethod[] {new TimedMethod(0, "Log", new object[] {""})};
		}
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {ToString() + " made a ramming attack"}),
    		new TimedMethod(0, "StagnantAttack", new object[] {false, 4, 4, GetAccuracy(), true, true, false}), poisonPart[0]};
	}
	
	public TimedMethod[] Heal() {
		Heal(5);
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {ToString() + " is regenerating"})};
	}
	
	public TimedMethod[] Creep() {
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {ToString() + " crept forward"})};
	}
	
	public override void Damage (int amount) {
		health = System.Math.Max(health - amount, 0);
		Party.GetPlayer().status.gooped = true;
		if (health > 0) {
			Character splitted = new Slime();
			Party.AddEnemy(splitted);
			splitted.SetHealth(health);
			splitted.SetQuirk(quirk.Clone());
			Splitter castPassive = (Splitter) passive;
			castPassive.split = true;
		}
	}

	public override void CreateDrops() {
    	drops = ItemDrops.FromPool(new Item[] {new SlimeGoo(), new SlimeGoo(), new SlimeGoo(), new SlimeGoo(), new MysteryGoo()},
    		ItemDrops.Amount(0, 1));
	}
	
	public override Item[] Loot () {
		System.Random rng = new System.Random();
		int sp = 1;
		Party.UseSP(sp * -1);
		return drops;
	}
	
	public override string[] CSDescription () {
		return new string[] {"Slime - abominations created by science. Or bad cooking",
		    "They split every time hit it if it doesn't die, and we'll get slimed on top of it",
			"We can use its slowness to our advantage, so try to set up and kill it at once"};
	}
}