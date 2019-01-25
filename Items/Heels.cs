public class Heels : Item {
	
	int uses;
	
	public Heels () {name = "Heels"; description = "Attack with piercing. Usable 10 more times"; uses = 10; price = 3;}
	public Heels (int uses) {name = "Heels"; this.uses = uses; description = "Attack with piercing. Usable " + uses.ToString() + " more times";}
	
	public override TimedMethod[] Use() {
		Party.AddItem(new Heels(uses - 1));
		return new TimedMethod[] {new TimedMethod(0, "StagnantAttack", new object[] {true, Party.GetPlayer().GetStrength(),
	    	Party.GetPlayer().GetStrength() + 5, Party.GetPlayer().GetAccuracy(), true, true, true})};
	}
}