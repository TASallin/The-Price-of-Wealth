using System.Collections.Generic;

public class ArtMediumBattle : BattleEvent {
	
	public ArtMediumBattle() {
		int seed = rng.Next(10);
		Character[] enemies;
		if (seed  < 2) {
			enemies = new Character[] {new Conductor(), new MusicMajor()};
			text = "Tiny band";
		} else if (seed < 4) {
			enemies = new Character[] {new MusicMajor(), new DanceMajor()};
			text = "Twin arts";
		} else if (seed == 4) {
			enemies = new Character[] {new CJMajor(), new PoliticalScientist()};
			text = "Guarded candidate";
		} else if (seed == 5) {
			enemies = new Character[] {new HistoryMajor(), new EnglishMajor()};
			text = "Writing Pair";
		} else if (seed == 6) {
			enemies = new Character[] {new PizzaCultist(), new HistoryMajor()};
			text = "History of cult";
		} else if (seed == 7) {
			enemies = new Character[] {new Conductor(), new Conductor()};
			text = "Conduct-off";
		} else if (seed == 8) {
			enemies = new Character[] {new Conductor(), new MusicMajor(), new MusicMajor()};
			text = "Small band";
		} else {
			enemies = new Character[] {new Conductor(), new Instructor(), new DanceMajor()};
			text = "Guest speaker in art";
		}
		options1 = new LinkedList<TimedMethod>();
		options1.AddLast(new TimedMethod(0, "Battle", new object[] {enemies}));
		optionText1 = "Fight";
	}
}