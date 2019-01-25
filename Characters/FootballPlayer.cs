public class FootballPlayer : Character {
    
    public FootballPlayer() {
        health = 20; maxHP = 20; strength = 5; power = 0; charge = 0; defense = 0; guard = 0;
		baseAccuracy = 10; accuracy = 10; dexterity = 2; evasion = 0; type = "Football Player"; passive = new PepTalk(this);
		quirk = Quirk.GetQuirk(this); special2 = new Rally(); special = new Charge();
		player = false; champion = false; recruitable = true; CreateDrops();
	}

	
	public override TimedMethod[] AI () {
		System.Random rnd = new System.Random();
		int seed = rnd.Next(10);
		TimedMethod[] moves;
		if (seed < 5) {
			moves = new TimedMethod[] {new TimedMethod(60, "Log", new object[] {"The " + ToString() + " tackled "}),
			    new TimedMethod(0, "AudioNumbered", new object[] {"Attack", 3, 4}),
			    new TimedMethod(0, "StagnantAttack", new object[] {false, 5, 5, GetAccuracy(), true, true, false})};
		} else if (seed < 8) {
			moves = new TimedMethod[] {new TimedMethod(0, "Audio", new object[] {"Skill2"}),
			    new TimedMethod(60, "Log", new object[] {"The " + ToString() + " is rallying. Team power has increased"})};
			foreach (Character current in Party.enemies) {
				if (current != null && current.GetAlive()) {
					current.GainPower(1);
				}
			}
		} else {
			moves = new TimedMethod[] {new TimedMethod(60, "Log", new object[] {"The " + ToString() + " is guarding. Guard + 5"})
			, new TimedMethod("GetEnemy")};
			SetGuard(GetGuard() + 5);
		}
		return moves;
	}
	
	public override TimedMethod[] BasicAttack() {
		TimedMethod[] attackPart;
		if (Party.BagContains(new Metronome())) {
			attackPart = Attacks.Attack(this, Party.GetEnemy(), strength + 4, strength + 4, GetAccuracy(), true, true, false);
		} else {
		    attackPart = Attacks.Attack(this, Party.GetEnemy(), strength + 2, strength + 7, GetAccuracy(), true, true, false);
		}
		TimedMethod[] moves = new TimedMethod[attackPart.Length + 1];
		moves[0] = new TimedMethod(0, "AudioNumbered", new object[] {"Attack", 3, 4});
		attackPart.CopyTo(moves, 1);
		return moves;
	}
	
	public override void CreateDrops() {
		drops = ItemDrops.FromPool(new Item[] {new Whistle(), new Pizza(), new ProteinBar(), new Milk(), new Pizza(), new ProteinBar(), new Milk()},
		    ItemDrops.Amount(1, 2));
	}
	
	public override Item[] Loot () {
		System.Random rnd = new System.Random();
		int sp = 2 + rnd.Next(3);
		Party.UseSP(sp * -1);
		Item[] dropped = drops;
		drops = new Item[0];
		return dropped;
	}
	
	public override string[] CSDescription () {
		return new string[] {"Sports Media Major - a member of the football team. Attacks, buffs, and defends", 
		"A pretty straightforward opponent, but he will give his team temporary attack at the start of their turn, so watch out for that"};
	}
}