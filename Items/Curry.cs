public class Curry : Item {
	
	public Curry() {name = "Curry"; description = "Restores 5 hp. You gain 5 charge"; selects = true; price = 2;}
	
	public override TimedMethod[] UseSelected(int i) {
		Party.members[i].Heal(5);
		Party.members[i].SetCharge(Party.members[i].GetCharge() + 5);
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {Party.members[i].GetName() + " ate the curry. It was spicy."})};
	}

    public override void UseOutOfCombat(int i) {
		UseSelected(i);
	}
}