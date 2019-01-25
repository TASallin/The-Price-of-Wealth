using System.Collections.Generic;

public class TowerEasyBattleP : BattleEvent {
	
	public TowerEasyBattleP() {
		int seed = rng.Next(10);
		Character[] enemies;
		if (seed < 4) {
			enemies = new Character[] {new Representative()};
			text = "Representative";
		} else if (seed < 6) {
			enemies = new Character[] {new SecurityHologram()};
			text = "Security Hologram";
		} else if (seed == 6) {
			enemies = new Character[] {new Criminal()};
			text = "Criminal";
		} else if (seed == 7) {
			enemies = new Character[] {new Janitor()};
			text = "Janitor";
		} else if (seed == 8) {
			enemies = new Character[] {new Cop()};
			text = "Cop";
		} else {
			enemies = new Character[] {new Instructor()};
			text = "Instructor";
		}
		options1 = new LinkedList<TimedMethod>();
		options1.AddLast(new TimedMethod(0, "Battle", new object[] {enemies}));
		optionText1 = "Fight";
	}
}