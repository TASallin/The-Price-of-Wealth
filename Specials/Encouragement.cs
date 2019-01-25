public class Encouragement : Special {
	
	public Encouragement () {name = "Encouragement"; description = "lead recovers from negative stats and gains 4 charge"; baseCost = 2; modifier = 0;}
	
	public override TimedMethod[] UseSupport(int i) {
		Party.GetPlayer().SetCharge(System.Math.Max(Party.GetPlayer().GetCharge() + 4, 4));
		Party.GetPlayer().SetGuard(System.Math.Max(Party.GetPlayer().GetGuard(), 0));
		Party.GetPlayer().SetPower(System.Math.Max(Party.GetPlayer().GetPower(), 0));
		Party.GetPlayer().SetDefense(System.Math.Max(Party.GetPlayer().GetDefense(), 0));
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {Party.GetPlayer().ToString() + " is feeling better"})};
	}
}