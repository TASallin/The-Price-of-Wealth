using System.Collections.Generic;

public class SportsHardBattle : BattleEvent {
	
	public SportsHardBattle() {
		int seed = rng.Next(10);
		Character[] enemies;
		if (seed < 2) {
			enemies = new Character[] {new Coach(), new FootballPlayer(), new Representative(), new MusicMajor()};
			text = "Head coach";
		} else if (seed < 4) {
			enemies = new Character[] {new Coach(), new FootballPlayer(), new FootballPlayer(), new FootballPlayer()};
			text = "Visiting team";
		} else if (seed < 6) {
			enemies = new Character[] {new FootballPlayer(), new FootballPlayer(), new FootballPlayer(), new FootballPlayer()};
			text = "Excessive athletes";
		} else if (seed < 8) {
			enemies = new Character[] {new Conductor(), new MusicMajor(), new DanceMajor()};
			text = "Marching band";
		} else {
			enemies = new Character[] {new Representative(), new BusinessMajor(), new FootballPlayer(), new CSMajor()};
			text = "Top sponsor";
		}
		options1 = new LinkedList<TimedMethod>();
		options1.AddLast(new TimedMethod(0, "Battle", new object[] {enemies}));
		optionText1 = "Fight";
	}
}