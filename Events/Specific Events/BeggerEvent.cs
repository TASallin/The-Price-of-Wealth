using System.Collections.Generic;

public class BeggerEvent : Event {
	
	public BeggerEvent() {
		Item[] items = Party.GetItems();
		List<int> indexes = new List<int>();
		for (int i = 0; i < 10; i++) {
			if (items[i] != null) {indexes.Add(i);}
		}
		if (indexes.Count > 0) {
		    System.Random rng = new System.Random();
		    int index = rng.Next(indexes.Count);
			Item wanted = items[index];
			text = "A begger asks for your " + wanted.GetName();
			options1 = new LinkedList<TimedMethod>();
			options1.AddLast(new TimedMethod(0, "LoseItem", new object[] {index}));
			options1.AddLast(new TimedMethod(0, "GainSP", new object[] {10}));
			options1.AddLast(new TimedMethod("Resolve"));
			optionText1 = "Give the requested item. Gain 10 SP";
		} else {
			text = "A begger is here, but your bag is empty";
		}
		options2 = new LinkedList<TimedMethod>();
		options2.AddLast(new TimedMethod(0, "GainSP", new object[] {-5}));
		options2.AddLast(new TimedMethod(0, "Heal", new object[] {2}));
		options2.AddLast(new TimedMethod("Resolve"));
		optionText2 = "Offer 5 SP. Party heals for 2 hp";
		options3 = new LinkedList<TimedMethod>();
		options3.AddLast(new TimedMethod("Resolve"));
		optionText3 = "Refuse";
		
		
	}
	
	
}