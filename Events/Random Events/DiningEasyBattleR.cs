using System.Collections.Generic;

public class DiningEasyBattleR : BattleEvent {
	
	public DiningEasyBattleR() {
		int seed = rng.Next(10);
		Character[] enemies;
		if (seed < 4) {
			enemies = new Character[] {new CulinaryMajor()};
			text = "Culinary";
		} else if (seed == 4) {
			enemies = new Character[] {new FootballPlayer()};
			text = "Football";
		} else if (seed == 5) {
			enemies = new Character[] {new PoliticalScientist()};
			text = "Pol-Sci";
		} else if (seed == 6) {
			enemies = new Character[] {new PsychMajor()};
			text = "Psychology";
		} else if (seed == 7) {
			enemies = new Character[] {new AerospaceEngineer()};
			text = "Aerospace";
		} else if (seed == 8) {
			enemies = new Character[] {new BusinessMajor()};
			text = "Business";
		} else {
			enemies = new Character[] {new CJMajor()};
			text = "Criminal justice";
		}
		options1 = new LinkedList<TimedMethod>();
		options1.AddLast(new TimedMethod(0, "Battle", new object[] {enemies}));
		optionText1 = "Fight";
	}
}