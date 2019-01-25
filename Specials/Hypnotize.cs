public class Hypnotize : Special {
	
	public Hypnotize() {name = "Hypnotize"; description = "Put the enemy to sleep"; baseCost = 4; modifier = 0;}
	
	public override TimedMethod[] Use () {
		return new TimedMethod[] {new TimedMethod(0, "Audio", new object[] {"Skill1"}), Party.GetEnemy().status.Sleep()[0]};
	}
}