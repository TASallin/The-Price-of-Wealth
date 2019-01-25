public class CulinaryMajor : Character {

    public CulinaryMajor() {
		health = 22; maxHP = 22; strength = 3; power = 0; charge = 0; defense = 0; guard = 0;
		baseAccuracy = 12; accuracy = 12; dexterity = 2; evasion = 0; type = "Culinary Major"; passive = new Cooking(this);
		quirk = Quirk.GetQuirk(this); special2 = new Feast(); special = new Cook();
		player = false; champion = false; recruitable = true; CreateDrops();
	}
	
	public override TimedMethod[] AI () {
		System.Random rng = new System.Random();
		int num = rng.Next(10);
		if (num < 3) {
			return Attack();
		} else if (num == 3) {
			return Eat("steak");
		} else if (num == 4) {
			return Eat("fish");
		} else if (num == 5) {
			return Eat("bread");
		} else {
			return Feast();
		}
	}
	
	public override TimedMethod[] BasicAttack() {
		if (Attacks.EvasionCheck(Party.GetEnemy(), GetAccuracy())) {
			status.poisoned = 0;
			status.gooped = false;
		}
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
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {ToString() + " threw a cooking knife"}),
		    new TimedMethod(0, "AudioNumbered", new object[] {"Attack", 3, 4}),
		    new TimedMethod(0, "Attack", new object[] {false})};
	}
	
	public TimedMethod[] Eat (string food) {
		string message = "";
		switch (food) {
			case "steak": message = ToString() + " ate the steak. Attack increased + health up"; power += 2;
			    break;
			case "fish": message = ToString() + " ate the fish. Accuracy increased + health up"; accuracy += 2;
			    break;
			case "bread": message = ToString() + " ate the bread. Defense increased + health up"; defense += 2;
			    break;
		}
		Heal(5);
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {message})};
	}
	
	public TimedMethod[] Feast () {
		foreach (Character c in Party.enemies) {
			if (c != null) {
				c.Heal(3);
			}
		}
		return new TimedMethod[] {new TimedMethod(0, "Audio", new object[] {"Skill2"}), 
		    new TimedMethod(60, "Log", new object[] {ToString() + " distributed snacks. Party health up"})};
	}
	
	public override void CreateDrops() {
		drops = ItemDrops.AnyFood(ItemDrops.Amount(1, 3));
	}
	
	public override Item[] Loot () {
		System.Random rng = new System.Random();
		int sp = 2 + rng.Next(3);
		Party.UseSP(sp * -1);
		Item[] dropped = drops;
		drops = new Item[0];
		return dropped;
	}
	
	public override string[] CSDescription () {
		return new string[] {"Culinary Major - They're good at cooking and other food-related concepts",
		   "Don't question how they cook without any nearby heat source, especially in the middle of combat",
		   "Or their endless supply of food"};
		
	}
}