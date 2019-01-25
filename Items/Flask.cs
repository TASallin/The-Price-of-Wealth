public class Flask : Item {
	
    public Flask () {name = "Flask"; description = "Deals 1 damage. Can hold a liquid"; price = 1;}

    public override TimedMethod[] Use () {
	    return new TimedMethod[] {new TimedMethod(60, "StagnantAttack", new object[] {
			true, 1, 1, Party.GetPlayer().GetAccuracy(), true, true, false})};
	}	
}