public class PizzaCultist : Character {
	
	protected int pizzas;
	protected int sequence;
	
	public PizzaCultist() {
		health = 20; maxHP = 20; strength = 3; power = 0; charge = 0; defense = 0; guard = 0;
		baseAccuracy = 11; accuracy = 11; dexterity = 3; evasion = 0; type = "Pizza Cultist"; passive = new Passive(this);
		quirk = Quirk.GetQuirk(this); special = null; player = false; champion = false; recruitable = false; CreateDrops();
		pizzas = 3; sequence = 0;
	}
	
	public override TimedMethod[] AI () {
		if (sequence == 0) {
		    System.Random rng = new System.Random();
			sequence = rng.Next(3) + 1;
		}
		if (pizzas > 0) {
			pizzas--;
			if (sequence == 1) {
				sequence++;
				return CheeseSpell();
			} else if (sequence == 2) {
				sequence++;
				return TomatoSpell();
			} else {
				sequence = 1;
				return PepperoniSpell();
			}
		} else {
			if (sequence == 5) {
				System.Random rng = new System.Random();
				if (rng.Next(2) == 0) {
					return Sulk();
				} else {
					return Attack();
				}
			} else if (sequence == 4) {
				sequence++;
				return Despair();
			} else {
			    sequence = 4;
				return Slicer();
			}
		}
	}
	
	public virtual TimedMethod[] CheeseSpell () {
		TimedMethod[] blindPart;
		if (Attacks.EvasionCycle(this, Party.GetPlayer())) {
		    blindPart = Party.GetPlayer().status.Blind(6);
		} else {
			blindPart = new TimedMethod[] {new TimedMethod(60, "Log", new object[] {"It missed completely"})};
		}
		return new TimedMethod[] {new TimedMethod(0, "AudioAmount", new object[] {"CultistSpell", 2}), 
		    new TimedMethod(60, "Log", new object[] {ToString() + " cast CHEESE SPELL!"}), blindPart[0]};
	}
	
	public virtual TimedMethod[] TomatoSpell () {
		TimedMethod[] goopPart;
		if (Attacks.EvasionCycle(this, Party.GetPlayer())) {
		    goopPart = Party.GetPlayer().status.Goop();
		} else {
			goopPart = new TimedMethod[] {new TimedMethod(60, "Log", new object[] {"It missed completely"})};
		}
		return new TimedMethod[] {new TimedMethod(0, "AudioAmount", new object[] {"CultistSpell", 2}), 
		    new TimedMethod(60, "Log", new object[] {ToString() + " cast TOMATO SPELL!"}), goopPart[0]};
	}
	
	public virtual TimedMethod[] PepperoniSpell () {
		TimedMethod move;
		if (GetAccuracy() > Party.GetPlayer().GetEvasion()) {
		    move = new TimedMethod(0, "AttackAll", new object[] {false, 2, 2, accuracy, true});
		} else {
			move = new TimedMethod(0, "StagnantAttack", new object[] {false, 2, 2, accuracy, true, true, false});
		}
		return new TimedMethod[] {new TimedMethod(0, "AudioAmount", new object[] {"CultistSpell", 2}), 
		    new TimedMethod(60, "Log", new object[] {ToString() + " cast PEPPERONI SPELL!"}), move};
	}
	
	public virtual TimedMethod[] Slicer () {
	    return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {ToString() + " chucked the pizza slicer"}),
		    new TimedMethod(0, "AudioNumbered", new object[] {"Attack", 5, 6}),
		    new TimedMethod(0, "StagnantAttack", new object[] {false, 10, 10, GetAccuracy(), true, true, false})};	
	}
	
	public virtual TimedMethod[] Attack () {
		 return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {ToString() + " attacked sadly"}),
		    new TimedMethod(0, "StagnantAttack", new object[] {false, 2, 2, GetAccuracy(), true, true, false})};
	}
	
	public TimedMethod[] Despair () {
		return new TimedMethod[] {new TimedMethod(0, "Audio", new object[] {"CultistOut"}), 
		    new TimedMethod(60, "Log", new object[] {ToString() + " ran out of pizzas"})};
	}
	
	public TimedMethod[] Sulk () {
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {ToString() + " wished he had more pizza"})};
	}
	
	public override void CreateDrops() {
		drops = new Item[] {new Pizza()};
	}
	
	public override Item[] Loot () {
		System.Random rnd = new System.Random();
		int sp = 3 + rnd.Next(3);
		Party.UseSP(sp * -1);
		Item[] food = new Item[pizzas];
		while (pizzas > 0) {
		    pizzas--;
			food[pizzas] = new Pizza();
		}
		return food;
	}
	
	public override string SpecificBarText () {
		return "pizzas: " + pizzas.ToString();
	}
	
	public override string[] CSDescription () {
		return new string[] {"Pizza Cultist - A member of a top secret organization that terrorizes the populace through the use of excessive pizza",
		    "They actually think they're casting magic spells. They aren't",
			"If they run out of pizzas, they won't be much of a threat",
     		"But if we beat them before that happens, we get to keep the pizza. You can use statuses like sleep to help with this"};
	}
	
}