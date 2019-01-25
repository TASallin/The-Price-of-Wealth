public class ToxicSolution : Item {
	
    public ToxicSolution () {name = "Toxic Solution"; description = "Poisons the enemy"; price = 2;}

    public override TimedMethod[] Use () {
	    Party.AddItem(new Flask());
		if (Attacks.EvasionCycle(Party.GetPlayer(), Party.GetEnemy())) {
			return Party.GetEnemy().status.Poison(2);
		} else {
			return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {"miss"})};
		}
	}	
}