using System.Collections.Generic;

public class ResearchEasyBattleR : BattleEvent {
	
	public ResearchEasyBattleR() {
		int seed = rng.Next(10);
		Character[] enemies;
		if (seed < 3) {
			enemies = new Character[] {new ChemistryMajor()};
			text = "Chemistry";
		} else if (seed < 5) {
			enemies = new Character[] {new AerospaceEngineer()};
			text = "Aerospace";
		} else if (seed < 7) {
			enemies = new Character[] {new MathMajor()};
			text = "Math";
		} else if (seed == 7) {
			enemies = new Character[] {new PsychMajor()};
			text = "Psychology";
		} else if (seed == 8) {
			enemies = new Character[] {new CSMajor()};
			text = "Computer science";
		} else {
			enemies = new Character[] {new MechanicalEngineer()};
			text = "Mechanical engineer";
		}
		options1 = new LinkedList<TimedMethod>();
		options1.AddLast(new TimedMethod(0, "Battle", new object[] {enemies}));
		optionText1 = "Fight";
	}
}