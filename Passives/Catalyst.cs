public class Catalyst : Passive {
	
	public Catalyst (Character c) {self = c; name = "Catalyst"; description = "You are immune to poison and everyone's poisons are more effective";}
	
	public override TimedMethod[] Initialize (bool player) {
		Status.catalyst++;
		self.status.poisonImmune = true;
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {"A catalyst is strengthening poison"})};
	}
}