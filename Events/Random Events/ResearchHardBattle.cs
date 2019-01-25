using System.Collections.Generic;

public class ResearchHardBattle : BattleEvent {
	
	public ResearchHardBattle() {
		int seed = rng.Next(10);
		Character[] enemies;
		if (seed < 2) {
			enemies = new Character[] {new Janitor(), new ChemistryMajor(), new Slime(), new ChemistryMajor()};
			text = "The poison party";
		} else if (seed < 4) {
			enemies = new Character[] {new LabRobot(), new TeachingAssistant(), new Instructor(), new Researcher()};
			text = "Lecture and lab";
		} else if (seed < 6) {
			enemies = new Character[] {new Slime(), new Slime(), new Slime(), new Slime()};
			text = "The slimes are endless";
		} else if (seed < 8) {
			enemies = new Character[] {new Researcher(), new Researcher(), new CSMajor(), new SecurityHologram()};
			text = "Expirimental AI";
		} else {
			enemies = new Character[] {new ChemistryMajor(), new Researcher(), new LabRobot(), new Researcher()};
			text = "Endless research";
		}
		options1 = new LinkedList<TimedMethod>();
		options1.AddLast(new TimedMethod(0, "Battle", new object[] {enemies}));
		optionText1 = "Fight";
	}
}