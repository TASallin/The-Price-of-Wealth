public class Recursion : Special {
	
	public Recursion () {name = "Recursion"; description = "Attack once for every basic attack this character used this combat";
	    baseCost = 2; modifier = 0;
	}
	
	public override TimedMethod[] Use () {
		CSMajor self = (CSMajor) Party.GetPlayer();
		int attacks = self.attacks;
	    TimedMethod[] moves = new TimedMethod[attacks + 1];
		moves[0] = new TimedMethod(0, "Audio", new object[] {"Skill1"});
		for (int i = 1; i < attacks; i++) {
			moves[i] = new TimedMethod(0, "StagnantAttack", new object[] {true, 2, 3, Party.GetPlayer().GetAccuracy(), true, false, false});
		}
		moves[attacks] = new TimedMethod(0, "StagnantAttack", new object[] {true, 2, 3, Party.GetPlayer().GetAccuracy(), true, true, false});
		return moves;
	}
}