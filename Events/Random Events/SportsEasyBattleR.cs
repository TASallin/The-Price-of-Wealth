using System.Collections.Generic;

public class SportsEasyBattleR : BattleEvent {
	
	public SportsEasyBattleR() {
		int seed = rng.Next(10);
		Character[] enemies;
		if (seed < 5) {
			enemies = new Character[] {new FootballPlayer()};
			text = "Football";
		} else if (seed < 7) {
			enemies = new Character[] {new MusicMajor()};
			text = "Music";
		} else if (seed == 7) {
			enemies = new Character[] {new CJMajor()};
			text = "Criminal justice";
		} else if (seed == 8) {
			enemies = new Character[] {new BusinessMajor()};
			text = "Business";
		} else {
			enemies = new Character[] {new DanceMajor()};
			text = "Dance";
		}
		options1 = new LinkedList<TimedMethod>();
		options1.AddLast(new TimedMethod(0, "Battle", new object[] {enemies}));
		optionText1 = "Fight";
	}
}