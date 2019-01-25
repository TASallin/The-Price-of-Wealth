public class Tazer : Item {
	
	public Tazer() {name = "Tazer";	description = "A piercing attack that stuns"; price = 3;}
	
	public override TimedMethod[] Use () {
		TimedMethod[] stunPart;
		if (Attacks.EvasionCheck(Party.GetEnemy(), Party.GetPlayer().GetAccuracy())) {
		    stunPart = Party.GetEnemy().status.Stun(2);
		} else {
			stunPart = new TimedMethod[] {new TimedMethod(0, "Log", new object[] {""})};
		}
		TimedMethod[] attackPart = new TimedMethod[] {new TimedMethod(0, "StagnantAttack", new object[] {
			true, 6, 6, Party.GetPlayer().GetAccuracy(), true, true, true})};
		TimedMethod[] total = new TimedMethod[2];
		attackPart.CopyTo(total, 0);
		stunPart.CopyTo(total, 1);
		return total;
	}
	
}