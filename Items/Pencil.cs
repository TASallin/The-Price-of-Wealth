public class Pencil : Item {
	
	public Pencil () {name = "Pencil"; description = "Attack with moderate power"; price = 1;}
	
	public override TimedMethod[] Use () {
		return new TimedMethod[] {new TimedMethod(60, "StagnantAttack", new object[] {
			true, Party.GetPlayer().GetStrength() + 3, Party.GetPlayer().GetStrength() + 3, Party.GetPlayer().GetAccuracy(), true, true, false})};
	}
}