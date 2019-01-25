using System.Collections.Generic;

public class ArtEasyBattleP : BattleEvent {
	
	public ArtEasyBattleP() {
		int seed = rng.Next(10);
		Character[] enemies;
		if (seed < 2) {
			enemies = new Character[] {new Conductor()};
			text = "Conductor";
		} else if (seed < 6) {
			enemies = new Character[] {new Instructor()};
			text = "Instructor";
		} else if (seed < 8) {
			enemies = new Character[] {new Janitor()};
			text = "Janitor";
		} else if (seed == 8) {
			enemies = new Character[] {new Criminal()};
			text = "Criminal";
		} else {
			enemies = new Character[] {new PizzaCultist()};
			text = "Cultist";
		}
		options1 = new LinkedList<TimedMethod>();
		options1.AddLast(new TimedMethod(0, "Battle", new object[] {enemies}));
		optionText1 = "Fight";
	}
}