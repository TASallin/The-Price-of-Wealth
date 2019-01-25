public class SlimeGoo : Item {
	
	public SlimeGoo () {name = "Slime Goo"; description = "Goops the enemy";}
	
	public override TimedMethod[] Use() {
		if (Attacks.EvasionCycle(Party.GetPlayer(), Party.GetEnemy())) {
			return Party.GetEnemy().status.Goop();
		} else {
		    return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {"miss"})};
		}
	}
}