public class Brew : Special {
	
	public Brew () {name = "Brew"; description = "if you have a flask, creates a toxic brew. Must be out of combat"; baseCost = 4;
    usableOut = true; modifier = 0;}
	
	public override TimedMethod[] Use () {
		Party.UseSP(GetCost() * -1);
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {"You don't have time to do this"})};
	}
	
	public override void UseOutOfCombat () {
		for (int i = 0; i < 10; i++) {
			if (Party.GetItems()[i] != null && Party.GetItems()[i].GetType().Equals(typeof(Flask))) {
				Party.GetItems()[i] = new ToxicSolution();
				Party.UseSP(GetCost());
				break;
			}
		}
	}
}