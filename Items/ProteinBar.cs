public class ProteinBar : Item {
	
	public ProteinBar() {name = "Protein Bar"; description = "Restores 5 hp. You gain 1 power"; selects = true; price = 2;}
	
	public override TimedMethod[] UseSelected(int i) {
		Party.members[i].Heal(5);
		Party.members[i].SetPower(Party.members[i].GetPower() + 1);
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {Party.members[i].GetName() + " ate a protein bar. Yay protein."})};
	}

    public override void UseOutOfCombat(int i) {
		UseSelected(i);
	}
}