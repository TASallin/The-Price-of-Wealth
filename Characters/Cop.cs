public class Cop : Character {
	
    //bool attacked;
	
	public Cop() {
		health = 18; maxHP = 18; strength = 4; power = 0; charge = 0; defense = 0; guard = 0;
		baseAccuracy = 15; accuracy = 15; dexterity = 4; evasion = 0; type = "Cop"; passive = new Outgun(this);
		quirk = Quirk.GetQuirk(this); special = null; player = false; champion = false; recruitable = false; CreateDrops();
		//attacked = false;
	}
	
	public override TimedMethod[] AI () {
		System.Random rng = new System.Random();
		int num = rng.Next(10);
		if (health < maxHP && num > 2 && num < 5) {
			return Shoot();
		} else if (num < 4) {
			return Donut();
		} else if (num < 7) {
			return Whistle();
		} else {
			return Tazer();
		}
	}
	
	public TimedMethod[] Tazer() {
		TimedMethod[] stunPart;
		if (Attacks.EvasionCheck(Party.GetPlayer(), GetAccuracy())) {
		    stunPart = Party.GetPlayer().status.Stun(2);
		} else {
			stunPart = new TimedMethod[] {new TimedMethod(0, "Log", new object[] {""})};
		}
	    return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {ToString() + " fired a tazer"}),
            new TimedMethod(0, "AudioNumbered", new object[] {"Attack", 3, 4}),		
		    new TimedMethod(0, "StagnantAttack", new object[] {false, 6, 6, GetAccuracy(), true, true, true}), stunPart[0]};
	}
	
	public TimedMethod[] Shoot() {
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {ToString() + " shot a pistol"}), 
		    new TimedMethod(0, "AudioNumbered", new object[] {"Attack", 3, 4}),
		    new TimedMethod(0, "StagnantAttack", new object[] {false, 10, 10, GetAccuracy(), true, true, false})};
	}
	
	public TimedMethod[] Donut() {
		Heal(15); power -= 1; defense -= 1;
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {ToString() + " ate a donut"})};
	}
	
	public TimedMethod[] Whistle() {
		if (Attacks.EvasionCycle(this, Party.GetPlayer())) {
			Status.NullifyAttack(Party.GetPlayer());
			return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {ToString() + " blew a whistle. Attack was reset"})};
		} else {
			return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {ToString() + " blew a whistle, and nothing happened"})};
		}
	}
	
	public override void CreateDrops () {
		drops = ItemDrops.FromPool(new Item[] {new Donut(), new Donut(), new Donut(), new Tazer(), new Tazer(), new Whistle()},
		    ItemDrops.Amount(1, 3));
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
		return new string[] {"Cop - Not really serving and protecting anymore",
		    "They can't use their gun until we deal damage to them, and their donut supply will lower their stats"};
	}
}