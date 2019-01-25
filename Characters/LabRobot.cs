public class LabRobot : Character {
	
	public LabRobot() {
		health = 12; maxHP = 12; strength = 4; power = 0; charge = 0; defense = 0; guard = 0;
		baseAccuracy = 10; accuracy = 10; dexterity = 3; evasion = 0; type = "Lab Robot"; passive = new Dodgy(this);
		quirk = Quirk.GetQuirk(this); special = null; player = false; champion = false; recruitable = false; CreateDrops();
	}
	
	public override TimedMethod[] AI () {
		if (accuracy < 20) {
			return Download();
		}
		System.Random rng = new System.Random ();
		int num = rng.Next(10);
		if (num < 4) {
			return Beam();
		} else if (num < 7) {
			return Slice();
		} else {
			return Reinforce();
		}
	}
	
	public TimedMethod[] Download() {
		accuracy += 89; evasion += 30;
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {
			ToString() + " downloaded relevant information. Accuracy and evasion way up"})};
	}
	
	public TimedMethod[] Beam() {
		if (Attacks.EvasionCheck(Party.GetPlayer(), GetAccuracy())) {
			Party.GetPlayer().GainDefense(-1);
		}
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {ToString() + " fired a beam"}),
		    new TimedMethod(0, "StagnantAttack", new object[] {false, 3, 3, GetAccuracy(), true, true, false})};
	}
	
	public TimedMethod[] Slice() {
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {ToString() + " slashed"}),
		    new TimedMethod(0, "StagnantAttack", new object[] {false, 7, 7, GetAccuracy(), true, true, false})};
	}
	
	public TimedMethod[] Reinforce() {
		defense++;
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {ToString() + " reinforced itself. Defense + 1"})};
	}
	
	public override void CreateDrops() {
		drops = ItemDrops.GuaranteedDrop(new Item[] {new Wire(), new Wire(), new Wire(), new USB()}, ItemDrops.Amount(1, 2), new Wire());
	}
	
	public override Item[] Loot () {
		System.Random rng = new System.Random();
		int sp = 3 + rng.Next(4);
		Party.UseSP(sp * -1);
	    Item[] dropped = drops;
		drops = new Item[0];
		return dropped;
	}
	
	public override string[] CSDescription () {
		return new string[] {"Lab Robot - Performs tasks like melt and cut through metal",
		    "They're also very fast and difficult to damage"};
	}
}