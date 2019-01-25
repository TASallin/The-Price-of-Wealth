public class SecurityHologram : Character {
	
	public SecurityHologram() {
	    health = 18; maxHP = 18; strength = 2; power = 0; charge = 0; defense = 1; guard = 0;
		baseAccuracy = 19; accuracy = 19; dexterity = 2; evasion = 0; type = "Security Hologram"; passive = new Vaccinated(this);
		quirk = Quirk.GetQuirk(this); special = null; player = false; champion = false; recruitable = false; CreateDrops();
    }
	
	public override TimedMethod[] AI () {
		System.Random rng = new System.Random();
		int num = rng.Next(10);
		if (!Status.firewall) {
			return Firewall();
		} else if (num < 5) {
			return Flash();
		} else {
			return Discharge();
		}
	}
	
	public TimedMethod[] Firewall() {
		Status.firewall = true;
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {ToString() + " set up a firewall around itself and your lead"})}; 
	}
	
	public TimedMethod[] Flash() {
		TimedMethod[] blindPart;
		if (Attacks.EvasionCheck(Party.GetPlayer(), GetAccuracy())) {
			blindPart = Party.GetPlayer().status.Blind(3);
		} else {
			blindPart = new TimedMethod[] {new TimedMethod(0, "Log", new object[] {""})};
		}
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {ToString() + " fired photons"}),
	    	new TimedMethod(0, "StagnantAttack", new object[] {false, 2, 2, GetAccuracy(), true, true, false}), blindPart[0]};
	}
	
	public TimedMethod[] Discharge() {
		TimedMethod move;
		string message;
		if (Attacks.EvasionCheck(Party.GetPlayer(), GetAccuracy())) {
		    move = new TimedMethod(0, "AttackAll", new object[] {false, 3, 3, GetAccuracy(), true});
			message = ToString() + " discharged electricity";
		} else {
			move = new TimedMethod(0, "StagnantAttack", new object[] {false, 3, 3, GetAccuracy(), true, true, false});
			message = ToString() + " discharged electricity...but just missed";
		}
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {message}), move};
	}
	
	public override void CreateDrops() {
		drops = ItemDrops.GuaranteedDrop(new Item[] {new Wire()}, ItemDrops.Amount(1, 2), new USB());
	}
	
	public override Item[] Loot() {
		System.Random rnd = new System.Random();
		int sp = 3 + rnd.Next(3);
		Party.UseSP(sp * -1);
		Item[] dropped = drops;
		drops = new Item[0];
		return dropped;
	}
	
	public override string[] CSDescription () {
		return new string[] {"Security Hologram - Tied down to the laptop its projected from",
		    "The firewall it creates presents a serious problem if anyone switches out",
			"They can also attack the entire team at once"};
	}
}