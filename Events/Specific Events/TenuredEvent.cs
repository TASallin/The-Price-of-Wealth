using System.Collections.Generic;

public class TenuredEvent : Event {
	
	public TenuredEvent() {
		text = "A tenured faculty";
		optionText1 = "Fight";
	}
	
	public override void Enact () {
		System.Random rng = new System.Random();
		int num = rng.Next(4);
		Character[] enemies;
		if (num == 0) {
			enemies = new Character[] {new TeachingAssistant(), new Tenured()};
		} else if (num == 1) {
			enemies = new Character[] {new Instructor(), new Tenured()};
		} else if (num == 2) {
			enemies = new Character[] {new Tenured()};
		} else {
			enemies = new Character[] {new Researcher(), new Tenured()};
		}
		options1 = new LinkedList<TimedMethod>();
		options1.AddLast(new TimedMethod(0, "Battle", new object[] {enemies}));
	}
}