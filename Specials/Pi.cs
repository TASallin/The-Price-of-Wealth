public class Pi : Special {
	
	public Pi () {name = "Pi"; description = "Cause the enemy to become apathetic"; baseCost = 3; modifier = 0;}
	
	public override TimedMethod[] UseSupport(int i) {
		if (Attacks.EvasionCycle(Party.members[i], Party.GetEnemy())) {
			Party.GetEnemy().status.CauseApathy(3);
		}
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {
			Party.members[i].ToString() + "Recited so much Pi it could lower self-esteem"})};
	}
}