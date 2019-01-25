public class Pizza : Item {
	
	public Pizza() {name = "Pizza"; description = "Restores 10 hp"; selects = true; price = 2;}
	
	public override TimedMethod[] UseSelected(int i) {
		Party.members[i].Heal(10);
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {
			Party.members[i].GetName() + " ate a pizza. Technically it was free pizza!"})};
	}

    public override void UseOutOfCombat(int i) {
		UseSelected(i);
	}
}