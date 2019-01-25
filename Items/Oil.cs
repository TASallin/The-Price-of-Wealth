public class Oil : Item {
	
	public Oil() {name = "Oil"; description = "Lowers defense"; price = 2;}
	
	public override TimedMethod[] Use () {
		if (Attacks.EvasionCycle(Party.GetPlayer(), Party.GetEnemy())) {
			Party.GetEnemy().SetDefense(Party.GetEnemy().GetDefense() - 2);
		}
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {"Defense decreased by 2"})};
	}
}