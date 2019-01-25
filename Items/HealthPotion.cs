public class HealthPotion : Item {
	
	public HealthPotion() {
    	name = "Health Potion"; description = "+3 MaxHP. Wouldn't it be great if Tristan remembered anything from Chem to name this right?";
	    selects = true; price = 11;
	}
	
	public override TimedMethod[] UseSelected(int i) {
		Party.AddItem(new Flask());
		Party.members[i].GainMaxHP(3);
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {Party.members[i].GetName() + " Got healthier!"})};
	}

    public override void UseOutOfCombat(int i) {
		UseSelected(i);
	}
}