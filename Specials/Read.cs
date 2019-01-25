public class Read : Special {
	
	public Read() {name = "Read"; description = "Gain 2 regeneration and fall asleep"; baseCost = 5; modifier = 0;}
	
	public override TimedMethod[] UseSupport (int i) {
		Party.members[i].status.Regenerate(2);
		Party.members[i].status.Sleep();
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {Party.members[i].ToString() + " is reading"})};
	}
}