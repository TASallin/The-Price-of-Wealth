public class Milk : Item {
	
	public Milk() {name = "Milk"; description = "Restores 5 hp and cure poison"; selects = true; price = 2;}
	
	public override TimedMethod[] UseSelected(int i) {
		Party.members[i].Heal(5);
		Party.members[i].status.poisoned = 0;
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {Party.members[i].GetName() + " ate the milk. It tasted like milk."})};
	}

    public override void UseOutOfCombat(int i) {
		UseSelected(i);
	}
}