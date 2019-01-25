public class AccuracyPotion : Item {
	
	public AccuracyPotion() {
    	name = "Accuracy Potion"; description = "+1 Accuracy. Wouldn't it be great if Tristan remembered anything from Chem to name this right?";
	    selects = true; price = 11;
	}
	
	public override TimedMethod[] UseSelected(int i) {
		Party.AddItem(new Flask());
		Party.members[i].SetBaseAccuracy(Party.members[i].GetBaseAccuracy() + 1);
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {Party.members[i].GetName() + " Got more focused!"})};
	}

    public override void UseOutOfCombat(int i) {
		UseSelected(i);
	}
}