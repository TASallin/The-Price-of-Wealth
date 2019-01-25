public class UnstableLiquid : Special {
	
	public UnstableLiquid () {
		name = "Unstable Liquid";
	    description = "if you have a flask, creates an explosive brew. Must be out of combat"; baseCost = 4;
        usableOut = true;
	    modifier = 0;
	}
	
	public override TimedMethod[] UseSupport (int i) {
		Party.UseSP(GetCost() * -1);
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {"You don't have time to do this"})};
	}
	
	public override void UseOutOfCombat () {
		for (int i = 0; i < 10; i++) {
			if (Party.GetItems()[i] != null && Party.GetItems()[i].GetType().Equals(typeof(Flask))) {
				Party.GetItems()[i] = new ExplosiveBrew();
				Party.UseSP(GetCost());
				break;
			}
		}
	}
}