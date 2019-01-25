using System.Collections.Generic;

public class SportsEasyBattleP : BattleEvent {
	
	public SportsEasyBattleP() {
		int seed = rng.Next(10);
		Character[] enemies;
		if (seed < 4) {
			enemies = new Character[] {new Coach()};
			text = "Coach";
		} else if (seed < 6) {
			enemies = new Character[] {new Cop()};
			text = "Cop";
		} else if (seed < 8) {
			enemies = new Character[] {new Representative()};
			text = "Representative";
		} else if (seed == 8) {
			enemies = new Character[] {new Criminal()};
			text = "Criminal";
		} else {
			enemies = new Character[] {new Chef()};
			text = "Chef";
		}
		options1 = new LinkedList<TimedMethod>();
		options1.AddLast(new TimedMethod(0, "Battle", new object[] {enemies}));
		optionText1 = "Fight";
	}
}