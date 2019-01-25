using System.Collections.Generic;

public class SymphonyEvent : Event {
	
	public SymphonyEvent() {
		text = "A grand conductor's symphony";
		optionText1 = "Fight";
	}
	
	public override void Enact () {
		System.Random rng = new System.Random();
		int num = rng.Next(4);
		Character[] enemies;
		if (num == 0) {
			enemies = new Character[] {new GrandConductor(), new MusicMajor(), new DanceMajor(), new MusicMajor()};
		} else if (num == 1) {
			enemies = new Character[] {new GrandConductor(), new MusicMajor(), new MusicMajor(), new MusicMajor()};
		} else if (num == 2) {
			enemies = new Character[] {new GrandConductor(), new EnglishMajor(), new DanceMajor(), new MusicMajor()};
		} else {
			enemies = new Character[] {new GrandConductor(), new MusicMajor(), new PoliticalScientist(), new DanceMajor()};
		}
		options1 = new LinkedList<TimedMethod>();
		options1.AddLast(new TimedMethod(0, "Battle", new object[] {enemies}));
	}
}