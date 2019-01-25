public class DexPotion : Item {
	
	public DexPotion() {
    	name = "Dex Potion"; description = "+1 Dexterity. Wouldn't it be great if Tristan remembered anything from Chem to name this right?";
	    selects = true; price = 11;
	}
	
	public override TimedMethod[] UseSelected(int i) {
		Party.AddItem(new Flask());
		Party.members[i].GainDexterity(1);
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {Party.members[i].GetName() + " Got faster!"})};
	}

    public override void UseOutOfCombat(int i) {
		UseSelected(i);
	}
}