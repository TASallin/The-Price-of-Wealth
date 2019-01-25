using System.Collections.Generic;

public class TowerHardBattle : BattleEvent {
	
	public TowerHardBattle() {
		int seed = rng.Next(10);
		Character[] enemies;
		if (seed < 2) {
			enemies = new Character[] {new AerospaceEngineer(), new MechanicalEngineer(), new AerospaceEngineer(), new MechanicalEngineer()};
			text = "ENGINEERS";
		} else if (seed < 4) {
			enemies = new Character[] {new PsychMajor(), new BusinessMajor(), new Representative(), new Representative()};
			text = "Marketing Team";
		} else if (seed < 6) {
			enemies = new Character[] {new Administrator(), new Cop()};
			text = "Guarded admin";
		} else if (seed < 8) {
			enemies = new Character[] {new PoliticalScientist(), new BusinessMajor(), new CJMajor(), new EnglishMajor()};
			text = "Students of the tower";
		} else {
			enemies = new Character[] {new Conductor(), new Representative(), new Researcher(), new Administrator()};
			text = "Mobile strategy";
		}
		options1 = new LinkedList<TimedMethod>();
		options1.AddLast(new TimedMethod(0, "Battle", new object[] {enemies}));
		optionText1 = "Fight";
	}
}