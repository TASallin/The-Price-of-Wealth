using System.Collections.Generic;

public class ExpirimentorEvent : Event {
	
	public ExpirimentorEvent() {
		text = "The expirimentor";
		optionText1 = "Fight";
	}
	
	public override void Enact () {
		System.Random rng = new System.Random();
		int num;
		Character[] enemies = new Character[4];
		enemies[0] = new Expirimentor();
		for (int i = 1; i < 4; i++) {
			num = rng.Next(10);
			if (num == 0) {
				enemies[i] = new MathMajor();
			} else if (num == 1) {
				enemies[i] = new EnglishMajor();
			} else if (num == 2) {
				enemies[i] = new MechanicalEngineer();
			} else if (num == 3) {
				enemies[i] = new ChemistryMajor();
			} else if (num == 4) {
				enemies[i] = new FootballPlayer();
			} else if (num == 5) {
				enemies[i] = new CJMajor();
			} else if (num == 6) {
				enemies[i] = new PsychMajor();
			} else if (num == 7) {
				enemies[i] = new CSMajor();
			} else if (num == 8) {
				enemies[i] = new CulinaryMajor();
			} else {
				enemies[i] = new BusinessMajor();
			}
		}
		options1 = new LinkedList<TimedMethod>();
		options1.AddLast(new TimedMethod(0, "Battle", new object[] {enemies}));
	}
}