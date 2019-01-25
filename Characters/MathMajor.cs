public class MathMajor : Character {
	
	int factorial;
	int answer;
	
	public MathMajor() {
        health = 14; maxHP = 14; strength = 2; power = 0; charge = 0; defense = 0; guard = 0;
		baseAccuracy = 20; accuracy = 20; dexterity = 3; evasion = 0; type = "Math Major"; passive = new Observant(this);
		quirk = Quirk.GetQuirk(this); special = new Factorial(); special2 = new Pi(); player = false; champion = false; recruitable = true;
		factorial = 0; answer = 1; CreateDrops();
	}
	
	public override TimedMethod[] AI () {
		if (factorial == 0) {
			return Prepare();
		} else {
			return Attack();
		}
	}
	
	public override TimedMethod[] BasicAttack() {
		TimedMethod[] attackPart;
		if (Party.BagContains(new Metronome())) {
			attackPart = Attacks.Attack(this, Party.GetEnemy(), strength + 2, strength + 2, GetAccuracy(), true, true, false);
		} else {
		    attackPart = Attacks.Attack(this, Party.GetEnemy());
		}
		accuracy += 1;
		TimedMethod[] moves = new TimedMethod[attackPart.Length + 1];
		moves[0] = new TimedMethod(0, "AudioNumbered", new object[] {"Attack", 5, 6});
		attackPart.CopyTo(moves, 1);
		return moves;
	}
	
	public override TimedMethod[] EnemyTurn () {
		TimedMethod[] extra = status.Check();
		if (GetAsleep() || GetStunned()) {
			factorial = 0;
			answer = 1;
			return extra;
		} else { 
		    return AI();
		}
	}
	
	public TimedMethod[] Prepare () {
		factorial = 1;
		return new TimedMethod[] {new TimedMethod(0, "Audio", new object[] {"Skill3"}),
		    new TimedMethod(60, "Log", new object[] {ToString() + " initiated the factorial function"})};
	}
	
	public TimedMethod[] Attack () {
		answer = answer * factorial;
		factorial++;
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {ToString() + " attacked"}),
		    new TimedMethod(0, "AudioNumbered", new object[] {"Attack", 5, 6}),
		    new TimedMethod(0, "StagnantAttack", new object[] {false, answer, answer, GetAccuracy(), true, true, false})};
	}
	
	public override void OnRecruit () {
		Party.AddLoot (new Calculator());
	}
	
	public override void CreateDrops() {
		drops = ItemDrops.GuaranteedDrop(new Item[] {new Pencil(), new Textbook(), new Pendulum(), new Celery()},
    		ItemDrops.Amount(1, 2), new Calculator()); 
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
		return new string[] {"Math Major - knowledge of functions lets them scale their attack power excessively", 
		"In addition, their team will gain accuracy as the fight goes on. Take them all out quickly"};
	}
}