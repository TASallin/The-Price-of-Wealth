public class Football : Item {
	
	public Football() {name = "Football"; description = "Attack for moderate damage. If you hit, get this item back"; price = 4;}
	
	public override TimedMethod[] Use () {
		if (Attacks.EvasionCheck(Party.GetEnemy(), Party.GetPlayer().GetAccuracy())) {
			Party.AddItem(this);
		}
		return new TimedMethod[] {new TimedMethod(60, "StagnantAttack", new object[] {
			true, Party.GetPlayer().GetStrength() + 3, Party.GetPlayer().GetStrength() + 3, Party.GetPlayer().GetAccuracy(), true, true, false})};
	}
}