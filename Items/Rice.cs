public class Rice : Item {
	
	public Rice() {name = "Rice"; description = "Restores 7 hp. Resets attack and defense"; selects = true; price = 2;}
	
	public override TimedMethod[] UseSelected(int i) {
		Party.members[i].Heal(7);
		Status.NullifyAttack(Party.members[i]); Status.NullifyDefense(Party.members[i]);
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {Party.members[i].GetName() + " ate the rice. It was plain"})};
	}

    public override void UseOutOfCombat(int i) {
		UseSelected(i);
	}
}