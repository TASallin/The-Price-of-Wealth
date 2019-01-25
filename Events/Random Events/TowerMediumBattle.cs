using System.Collections.Generic;

public class TowerMediumBattle : BattleEvent {
	
	public TowerMediumBattle() {
		int seed = rng.Next(10);
		Character[] enemies;
		if (seed < 2) {
			enemies = new Character[] {new Administrator()};
			text = "Administrator";
		} else if (seed == 2) {
			enemies = new Character[] {new PoliticalScientist(), new BusinessMajor()};
			text = "Funded campaign";
		} else if (seed == 3) {
			enemies = new Character[] {new CSMajor(), new SecurityHologram()};
			text = "Hack prevention";
		} else if (seed == 4) {
			enemies = new Character[] {new Representative(), new BusinessMajor()};
			text = "Business pair";
		} else if (seed == 5) {
			enemies = new Character[] {new Janitor(), new Cop()};
			text = "2 staff";
		} else if (seed == 6) {
			enemies = new Character[] {new PoliticalScientist(), new PoliticalScientist()};
			text = "Opposite parties";
		} else if (seed == 7) {
			enemies = new Character[] {new CJMajor(), new SecurityHologram()};
			text = "Extra security";
		} else if (seed == 8) {
			enemies = new Character[] {new TeachingAssistant(), new HistoryMajor(), new EnglishMajor()};
			text = "Tour guides";
		} else {
			enemies = new Character[] {new Representative(), new Representative(), new Representative()};
			text = "3 representatives";
		}
		options1 = new LinkedList<TimedMethod>();
		options1.AddLast(new TimedMethod(0, "Battle", new object[] {enemies}));
		optionText1 = "Fight";
	}
}