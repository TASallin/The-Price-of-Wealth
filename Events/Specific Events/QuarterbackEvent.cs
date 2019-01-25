using System.Collections.Generic;

public class QuarterbackEvent : Event {
	
	public QuarterbackEvent() {
		text = "The quarterback";
		optionText1 = "Fight";
	}
	
	public override void Enact () {
		System.Random rng = new System.Random();
		int num = rng.Next(4);
		Character[] enemies;
		if (num == 0) {
			enemies = new Character[] {new Quarterback(), new FootballPlayerQ(), new FootballPlayerQ(), new FootballPlayerQ()};
		} else if (num == 1) {
			enemies = new Character[] {new Quarterback(), new Coach()};
		} else if (num == 2) {
			enemies = new Character[] {new Quarterback(), new FootballPlayerQ(), new CulinaryMajor()};
		} else {
			enemies = new Character[] {new Quarterback(), new FootballPlayerQ(), new Coach()};
		}
		options1 = new LinkedList<TimedMethod>();
		options1.AddLast(new TimedMethod(0, "Battle", new object[] {enemies}));
	}
}