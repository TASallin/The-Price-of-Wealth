using System.Collections.Generic;

public class ResearchMediumBattle : BattleEvent {
	
	public ResearchMediumBattle() {
		int seed = rng.Next(10);
		Character[] enemies;
		if (seed  < 2) {
			enemies = new Character[] {new Researcher(), new ChemistryMajor()};
			text = "Research standard";
		} else if (seed == 2) {
			enemies = new Character[] {new Janitor(), new Slime()};
			text = "Cleaning the experiment";
		} else if (seed == 3) {
			enemies = new Character[] {new Slime(), new Slime()};
			text = "The slimes multiply";
		} else if (seed == 4) {
			enemies = new Character[] {new LabRobot(), new MechanicalEngineer()};
			text = "Roboticist";
		} else if (seed == 5) {
			enemies = new Character[] {new LabRobot(), new Researcher()};
			text = "Metal assistant";
		} else if (seed == 6) {
			enemies = new Character[] {new ChemistryMajor(), new TeachingAssistant()};
			text = "Sparse lab";
		} else if (seed == 7) {
			enemies = new Character[] {new AerospaceEngineer(), new Researcher()};
			text = "Rocket studies";
		} else if (seed == 8) {
			enemies = new Character[] {new ChemistryMajor(), new MathMajor(), new AerospaceEngineer()};
			text = "Undergraduate research";
		} else {
			enemies = new Character[] {new Researcher(), new Researcher(), new Researcher()};
			text = "3 Researchers";
		}
		options1 = new LinkedList<TimedMethod>();
		options1.AddLast(new TimedMethod(0, "Battle", new object[] {enemies}));
		optionText1 = "Fight";
	}
}