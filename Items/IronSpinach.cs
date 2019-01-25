public class IronSpinach : Item {
	
	public IronSpinach() {name = "Iron Spinach"; description = "Restores 15 hp. You gain 5 defense"; selects = true; price = 11;}
	
	public override TimedMethod[] UseSelected(int i) {
		Party.members[i].Heal(15);
		Party.members[i].SetDefense(Party.members[i].GetDefense() + 5);
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {
			Party.members[i].GetName() + " ate the iron spinach. It tasted pretty bad"})};
	}

    public override void UseOutOfCombat(int i) {
		UseSelected(i);
	}
}