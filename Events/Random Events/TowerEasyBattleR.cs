using System.Collections.Generic;

public class TowerEasyBattleR : BattleEvent {
	
	public TowerEasyBattleR() {
		int seed = rng.Next(10);
		Character[] enemies;
		if (seed < 2) {
			enemies = new Character[] {new BusinessMajor()};
			text = "Business";
		} else if (seed < 4) {
			enemies = new Character[] {new PoliticalScientist()};
			text = "Pol-Sci";
		} else if (seed < 6) {
			enemies = new Character[] {new CJMajor()};
			text = "Criminal Justice";
		} else if (seed == 6) {
			enemies = new Character[] {new EnglishMajor()};
			text = "English";
		} else if (seed == 7) {
			enemies = new Character[] {new MechanicalEngineer()};
			text = "Mechanical Engineer";
		} else if (seed == 8) {
			enemies = new Character[] {new MathMajor()};
			text = "Math";
		} else {
			enemies = new Character[] {new HistoryMajor()};
			text = "History";
		}
		options1 = new LinkedList<TimedMethod>();
		options1.AddLast(new TimedMethod(0, "Battle", new object[] {enemies}));
		optionText1 = "Fight";
	}
}