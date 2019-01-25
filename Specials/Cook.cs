public class Cook : Special {
	
	public Cook () {
		name = "Cook";
	    description = "Procure a random food item. Must be out of combat"; baseCost = 3;
        usableOut = true;
	    modifier = 0;
	}
	
	public override TimedMethod[] Use () {
		Party.UseSP(GetCost() * -1);
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {"You don't have time to do this"})};
	}
	
	public override void UseOutOfCombat () {
		Item[] dish = ItemDrops.AnyFood(1);
		Party.AddItem(dish[0]);
		Party.UseSP(GetCost());
	}
}