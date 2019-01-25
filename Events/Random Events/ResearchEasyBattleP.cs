using System.Collections.Generic;

public class ResearchEasyBattleP : BattleEvent {
	
	public ResearchEasyBattleP() {
		int seed = rng.Next(10);
		Character[] enemies;
		if (seed < 4) {
			enemies = new Character[] {new Researcher()};
			text = "Research";
		} else if (seed < 6) {
			enemies = new Character[] {new LabRobot()};
			text = "Robot";
		} else if (seed < 8) {
			enemies = new Character[] {new Slime()};
			text = "Slime";
		} else if (seed == 8) {
			enemies = new Character[] {new TeachingAssistant()};
			text = "TA";
		} else {
			enemies = new Character[] {new Janitor()};
			text = "Janitor";
		}
		options1 = new LinkedList<TimedMethod>();
		options1.AddLast(new TimedMethod(0, "Battle", new object[] {enemies}));
		optionText1 = "Fight";
	}
}