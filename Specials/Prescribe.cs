public class Prescribe : Special {
	
	public Prescribe () {name = "Prescribe"; description = "Heal yourself and cure poison"; baseCost = 3; modifier = 0;}
	
	public override TimedMethod[] UseSupport(int i) {
		System.Random rng = new System.Random();
		int amount = rng.Next(8) + 5;
		Party.members[i].Heal(amount);
		Party.members[i].status.poisoned = 0;
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {Party.members[i].ToString() + " healed " + amount.ToString() + " hp"})};
	}
}