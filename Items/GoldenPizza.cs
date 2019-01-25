public class GoldenPizza : Item {
	
	public GoldenPizza() {name = "Golden Pizza"; description = "Restores 100 hp and cures poison"; selects = true; price = 6;}
	
	public override TimedMethod[] UseSelected(int i) {
		Party.members[i].Heal(100);
		Party.members[i].status.poisoned = 0;
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {
			Party.members[i].GetName() + " ate the golden pizza. Despite the food coloring, it was exquisite"})};
	}

    public override void UseOutOfCombat(int i) {
		UseSelected(i);
	}
}