using System.Collections.Generic;

public class CultLeaderEvent : Event {
	
	public CultLeaderEvent() {
		text = "The pizza cult's leader";
		optionText1 = "Fight";
	}
	
	public override void Enact () {
		System.Random rng = new System.Random();
		int num = rng.Next(4);
		Character[] enemies;
		if (num == 0) {
			enemies = new Character[] {new CultLeader(), new PizzaCultist(), new PizzaCultist(), new PizzaCultist()};
		} else if (num == 1) {
			enemies = new Character[] {new CultLeader(), new PizzaCultist(), new PizzaCultist()};
		} else if (num == 2) {
			enemies = new Character[] {new PizzaCultist(), new CultLeader(), new PizzaCultist(), new PizzaCultist()};
		} else {
			enemies = new Character[] {new CultLeader(), new PizzaCultist(), new PizzaCultist(), new Criminal()};
		}
		options1 = new LinkedList<TimedMethod>();
		options1.AddLast(new TimedMethod(0, "Battle", new object[] {enemies}));
	}
}