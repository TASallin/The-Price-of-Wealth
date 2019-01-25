using System.Collections.Generic;

public class DiningMediumBattle : BattleEvent {
	
	public DiningMediumBattle() {
		int seed = rng.Next(10);
		Character[] enemies;
		if (seed  == 0) {
			enemies = new Character[] {new PizzaCultist(), new PizzaCultist()};
			text = "Cult grunts";
		} else if (seed == 1) {
			enemies = new Character[] {new Criminal(), new PizzaCultist()};
			text = "Cult and brute";
		} else if (seed == 2) {
			enemies = new Character[] {new PizzaCultist(), new Chef()};
			text = "Cult supplier";
		} else if (seed == 3) {
			enemies = new Character[] {new Slime(), new Chef()};
			text = "Suspicious meal";
		} else if (seed == 4) {
			enemies = new Character[] {new Chef(), new Doctor()};
			text = "Double healer";
		} else if (seed == 5) {
			enemies = new Character[] {new CulinaryMajor(), new Chef()};
			text = "Apprentice chef";
		} else if (seed == 6) {
			enemies = new Character[] {new PsychMajor(), new Slime()};
			text = "The food is sentient?";
		} else if (seed == 7) {
			enemies = new Character[] {new CJMajor(), new Criminal()};
			text = "Food theif";
		} else if (seed == 8) {
			enemies = new Character[] {new MathMajor(), new MusicMajor(), new ChemistryMajor()};
			text = "Some customers";
		} else {
			enemies = new Character[] {new Representative(), new Instructor(), new ShuttleDriver()};
			text = "Some possessed customers";
		}
		options1 = new LinkedList<TimedMethod>();
		options1.AddLast(new TimedMethod(0, "Battle", new object[] {enemies}));
		optionText1 = "Fight";
	}
}