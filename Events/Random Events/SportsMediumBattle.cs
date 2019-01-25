using System.Collections.Generic;

public class SportsMediumBattle : BattleEvent {
	
	public SportsMediumBattle() {
		int seed = rng.Next(10);
		Character[] enemies;
		if (seed  < 2) {
			enemies = new Character[] {new Coach(), new FootballPlayer()};
			text = "Coach +1";
		} else if (seed == 2) {
			enemies = new Character[] {new FootballPlayer(), new FootballPlayer()};
			text = "2 players";
		} else if (seed == 3) {
			enemies = new Character[] {new ShuttleDriver(), new CulinaryMajor()};
			text = "Food truck";
		} else if (seed == 4) {
			enemies = new Character[] {new FootballPlayer(), new DanceMajor()};
			text = "Football and cheerleader";
		} else if (seed == 5) {
			enemies = new Character[] {new Representative(), new Coach()};
			text = "Sponsorship deal";
		} else if (seed == 6) {
			enemies = new Character[] {new MechanicalEngineer(), new CSMajor()};
			text = "Technical difficulties";
		} else if (seed == 7) {
			enemies = new Character[] {new CJMajor(), new Coach()};
			text = "Guarded coach";
		} else if (seed == 8) {
			enemies = new Character[] {new HistoryMajor(), new CulinaryMajor(), new MathMajor()};
			text = "Some fans";
		} else {
			enemies = new Character[] {new Instructor(), new Representative(), new TeachingAssistant()};
			text = "Some possessed fans";
		}
		options1 = new LinkedList<TimedMethod>();
		options1.AddLast(new TimedMethod(0, "Battle", new object[] {enemies}));
		optionText1 = "Fight";
	}
}