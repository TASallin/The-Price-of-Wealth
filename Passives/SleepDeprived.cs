public class SleepDeprived : Quirk {
	
	public SleepDeprived (Character c) {
		self = c; name = "Sleep Deprived"; description = "So used to all-nighters that regular things won't cause them to fall asleep";
	}
	
	public override TimedMethod[] Initialize (bool player) {
		self.status.sleepImmune = true;
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {"No sleep for " + self.ToString()})};
	}
}