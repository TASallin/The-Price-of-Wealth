public class USB : Item {
	
	public USB () {name = "USB"; description = "Attack for 1 damage without removing charge. If you miss, gain 2 charge. Repeatable"; price = 2;}
	
	public override TimedMethod[] Use() {
		Party.AddItem(this);
		if (!Attacks.EvasionCheck(Party.GetEnemy(), Party.GetPlayer().GetAccuracy())) {
			Party.GetPlayer().SetCharge(Party.GetPlayer().GetCharge() + 2);
		}
		return new TimedMethod[] {new TimedMethod(60, "StagnantAttack", new object[] {
		    true, 1, 1, Party.GetPlayer().GetAccuracy(), false, false, false})};
	}
}