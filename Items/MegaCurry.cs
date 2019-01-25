public class MegaCurry : Item {
	
	public MegaCurry() {name = "Mega Curry"; description = "Restores 15 hp. You gain 20 charge"; selects = true; price = 11;}
	
	public override TimedMethod[] UseSelected(int i) {
		Party.members[i].Heal(15);
		Party.members[i].SetCharge(Party.members[i].GetCharge() + 20);
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {Party.members[i].GetName() + " ate the MEGACURRY. You feel on-fire"})};
	}

    public override void UseOutOfCombat(int i) {
		UseSelected(i);
	}
}