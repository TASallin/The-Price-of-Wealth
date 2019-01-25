public class Quarterback : FootballPlayer {
    
	int cycle; 
	
    public Quarterback() {
        health = 55; maxHP = 55; defense = 1; type = "Quarterback"; passive = new Recovery(this);
		special = new Rally(); champion = true; recruitable = true; cycle = 0;
	}

	
	public override TimedMethod[] AI () {
		System.Random rnd = new System.Random();
		int num = rnd.Next(10);
		if (cycle == 0 && health < maxHP / 2) {
			cycle++;
			return Switch();
		}
		if (num < 4) {
			return Attack();
		} else if (num < 8) {
			return Charge();
		} else {
			return Foul();
		}
	}
	
	public override TimedMethod[] BasicAttack() {
		Democracy castPassive = (Democracy)passive;
		castPassive.attacked = true;
		TimedMethod[] attackPart;
		if (Party.BagContains(new Metronome())) {
			attackPart = Attacks.Attack(this, Party.GetEnemy(), strength + 2, strength + 2, GetAccuracy(), true, true, false);
		} else {
		    attackPart = Attacks.Attack(this, Party.GetEnemy());
		}
		TimedMethod[] moves = new TimedMethod[attackPart.Length + 1];
		moves[0] = new TimedMethod(0, "AudioNumbered", new object[] {"Attack", 3, 4});
		attackPart.CopyTo(moves, 1);
		return moves;
	}
	
	public TimedMethod[] Attack () {
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {"The " + ToString() + " tackled "}),
		    new TimedMethod(0, "AudioNumbered", new object[] {"Attack", 3, 4}),
			new TimedMethod(0, "StagnantAttack", new object[] {false, 5, 5, GetAccuracy(), true, true, false})};
	}
	
	public TimedMethod[] Foul () {
		TimedMethod[] stunPart;
		if (Attacks.EvasionCheck(Party.GetPlayer(), GetAccuracy())) {
			Party.GetPlayer().GainDefense(-1);
			stunPart = Party.GetPlayer().status.Stun(2);
		} else {
			stunPart = new TimedMethod[] {new TimedMethod(0, "Log", new object[] {""})};
		}
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {"The " + ToString() + " committed a foul "}),
		    new TimedMethod(0, "AudioNumbered", new object[] {"Attack", 3, 4}),
			new TimedMethod(0, "StagnantAttack", new object[] {false, 2, 2, GetAccuracy(), true, true, false}), stunPart[0]};
	}
	
	public TimedMethod[] Charge () {
		if (health > maxHP / 2) {charge += 4;} else {charge += 9;}
		return new TimedMethod[] {new TimedMethod(0, "Audio", new object[] {"QuarterbackLaugh"}),
		    new TimedMethod(60, "Log", new object[] {"The " + ToString() + " Prepared to charge"})};
	}
	
	public TimedMethod[] Switch () {
		if (GetGooped()) {
			return Charge();
		}
		if (Party.enemyCount > 1) {
			int former = Party.enemySlot;
			for (int i = 0; i < 4; i++) {
				if (i != Party.enemySlot - 1 && Party.enemies[i] != null && Party.enemies[i].GetAlive()) {
					Party.enemySlot = i + 1;
					return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {ToString() + " switched out begrudgingly "}),
					    new TimedMethod(0, "EnemySwitch", new object[] {Party.enemySlot, former})};
				}
			}
		}
		return Charge();
	}
	
	public override void CreateDrops() {
		drops = ItemDrops.GuaranteedDrop(new Item[] {new Whistle(), new Pizza(), new ProteinBar(), new Milk(), new Pizza(),
    		new ProteinBar(), new Milk()}, ItemDrops.Amount(1, 4), new Football());
	}
	
	public override Item[] Loot () {
		System.Random rnd = new System.Random();
		int sp = 8 + rnd.Next(5);
		Party.UseSP(sp * -1);
        Item[] dropped = drops;
		drops = new Item[0];
		return dropped;	}
	
	public override string[] CSDescription () {
		return new string[] {"Quarterback - Like a regular football player but stronger and vainer", 
		"I wonder if we could figure out how to recruit this person"};
	}
}