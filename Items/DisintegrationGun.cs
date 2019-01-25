public class DisintegrationGun : Item {
	
	public DisintegrationGun() {name = "Disintegration Gun"; description = "Deals 20 damage"; price = 5;}
	
	public override TimedMethod[] Use () {
		return new TimedMethod[] {new TimedMethod(60, "StagnantAttack", new object[] {
			true, 20, 20, Party.GetPlayer().GetAccuracy(), true, true, false})};
	}
}