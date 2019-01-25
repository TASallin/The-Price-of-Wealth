using System.Collections.Generic;

public class ArtEasyBattleR : BattleEvent {
	
	public ArtEasyBattleR() {
		int seed = rng.Next(10);
		Character[] enemies;
		if (seed < 3) {
			enemies = new Character[] {new DanceMajor()};
			text = "Dance";
		} else if (seed < 6) {
			enemies = new Character[] {new MusicMajor()};
			text = "Music";
		} else if (seed == 6) {
			enemies = new Character[] {new CulinaryMajor()};
			text = "Culinary";
		} else if (seed == 7) {
			enemies = new Character[] {new EnglishMajor()};
			text = "English";
		} else if (seed == 8) {
			enemies = new Character[] {new HistoryMajor()};
			text = "History";
		} else {
			enemies = new Character[] {new PoliticalScientist()};
			text = "Pol-Sci";
		}
		options1 = new LinkedList<TimedMethod>();
		options1.AddLast(new TimedMethod(0, "Battle", new object[] {enemies}));
		optionText1 = "Fight";
	}
}