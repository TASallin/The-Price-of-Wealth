public class CentralAI : SecurityHologram {
	
	int energy;
	
	public CentralAI() {
	    health = 40; maxHP = 40; defense = 1; type = "Central AI"; passive = new ForceField(this); champion = true; energy = 100;
    }
	
	public override TimedMethod[] AI () {
		System.Random rng = new System.Random();
		int num = rng.Next(10);
		if (!Status.firewall) {
			energy -= 100;
			return Firewall();
		} else if (energy == 100) {
			energy -= 100;
			return Disintegrate();
		} else if (num < 3) {
			energy += 25;
			return Flash();
		} else if (num < 6) {
			energy += 25;
			return Disrupt();
		} else if (num < 9 && energy <= 50) {
			energy += 50;
			return Charge();
		} else {
			energy += 25;
			return Discharge();
		}
	}
	
	public TimedMethod[] Disintegrate () {
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {ToString() + " activated the DISINTIGRATION BEAM"}),
	    	new TimedMethod(0, "StagnantAttack", new object[] {false, 20, 20, GetAccuracy(), true, true, false})};
	}
	
	public TimedMethod[] Charge() {
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {ToString() + " stored energy"})};
	}
	
	public TimedMethod[] Disrupt () {
		if (Attacks.EvasionCycle(this, Party.GetPlayer())) {
			return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {ToString() + " fired a disruptive wave"}),
    			Party.GetPlayer().status.Stun(3)[0]};
		}
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {ToString() + " missed a disruptive wave"})};
	}
	
	public override void CreateDrops() {
		drops = ItemDrops.GuaranteedDrop(new Item[] {new Wire(), new USB()}, ItemDrops.Amount(2, 3), new DisintegrationGun());
	}
	
	public override string SpecificBarText() {
        return "Energy: " + energy.ToString() + "%";
	}
	
	public override Item[] Loot() {
		System.Random rnd = new System.Random();
		int sp = 8 + rnd.Next(6);
		Party.UseSP(sp * -1);
		Item[] dropped = drops;
		drops = new Item[0];
		return dropped;
	}
	
	public override string[] CSDescription () {
		return new string[] {"Central AI - Like a regular hologram, wired to a room with a disintegration gun",
		    "Keep an eye on its energy level for when it will use the big attack"};
	}
}