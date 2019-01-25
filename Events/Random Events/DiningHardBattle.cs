using System.Collections.Generic;

public class DiningHardBattle : BattleEvent {
	
	public DiningHardBattle() {
		int seed = rng.Next(10);
		Character[] enemies;
		if (seed < 2) {
			enemies = new Character[] {new ShuttleDriver(), new Representative(), new Cop(), new Doctor()};
			text = "Full bus";
		} else if (seed < 4) {
			enemies = new Character[] {new CulinaryMajor(), new PizzaCultist(), new Chef()};
			text = "Cook party";
		} else if (seed < 6) {
			enemies = new Character[] {new Criminal(), new PizzaCultist(), new Chef(), new PizzaCultist()};
			text = "The cult's revenge";
		} else if (seed < 8) {
			enemies = new Character[] {new Chef(), new CulinaryMajor(), new TeachingAssistant(), new FootballPlayer()};
			text = "Food discount";
		} else {
			enemies = new Character[] {new Janitor(), new Slime(), new CulinaryMajor()};
			text = "Closing time";
		}
		options1 = new LinkedList<TimedMethod>();
		options1.AddLast(new TimedMethod(0, "Battle", new object[] {enemies}));
		optionText1 = "Fight";
	}
}