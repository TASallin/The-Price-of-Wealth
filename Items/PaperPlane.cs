public class PaperPlane : Item {
	
	public PaperPlane () {name = "Paper Plane"; description = "A blinding projectile"; price = 2;}
	
	public override TimedMethod[] Use () {
		TimedMethod[] blindPart;
		if (Party.GetPlayer().GetAccuracy() > Party.GetEnemy().GetEvasion()) {
			blindPart = Party.GetEnemy().status.Blind(5);
		} else {
			blindPart = new TimedMethod[] {new TimedMethod(0, "Log", new object[] {""})};
		}
		TimedMethod[] attackPart = new TimedMethod[] {new TimedMethod(60, "StagnantAttack", new object[] {
			true, Party.GetPlayer().GetStrength(), Party.GetPlayer().GetStrength() + 2, Party.GetPlayer().GetAccuracy(), true, true, false})};
		TimedMethod[] total = new TimedMethod[2];
		attackPart.CopyTo(total, 0);
		blindPart.CopyTo(total, 1);
		return total;
	}
	
}