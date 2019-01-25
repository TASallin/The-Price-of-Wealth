using System.Collections.Generic;

public class ArtHardBattle : BattleEvent {
	
	public ArtHardBattle() {
		int seed = rng.Next(10);
		Character[] enemies;
		if (seed < 2) {
			enemies = new Character[] {new EnglishMajor(), new MusicMajor(), new CulinaryMajor(), new DanceMajor()};
			text = "Liberal art association";
		} else if (seed < 4) {
			enemies = new Character[] {new Conductor(), new MusicMajor(), new MusicMajor(), new MusicMajor()};
			text = "Orchestra";
		} else if (seed < 6) {
			enemies = new Character[] {new PoliticalScientist(), new EnglishMajor(), new CJMajor(), new PoliticalScientist()};
			text = "Activists";
		} else if (seed < 8) {
			enemies = new Character[] {new Conductor(), new DanceMajor(), new DanceMajor(), new DanceMajor()};
			text = "Dance program";
		} else {
			enemies = new Character[] {new HistoryMajor(), new EnglishMajor(), new MusicMajor(), new BusinessMajor()};
			text = "Theater program";
		}
		options1 = new LinkedList<TimedMethod>();
		options1.AddLast(new TimedMethod(0, "Battle", new object[] {enemies}));
		optionText1 = "Fight";
	}
}