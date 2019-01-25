public class Bargain : Special {
	
	public Bargain() {name = "Bargain"; description = "Steal one of the enemy's items (you will not get it after combat)"; baseCost = 2; modifier = 0;}
	
	public override TimedMethod[] Use () {
		bool space = false;
		Item[] bag = Party.GetItems();
		for (int i = 0; i < 10; i++) {
			if (bag[i] == null) {
				space = true;
				break;
			}
		}
		if (!space) {
			return new TimedMethod[] {new TimedMethod(0, "Audio", new object[] {"Steal1"}), 
			    new TimedMethod(60, "Log", new object[] {"Your bag is full!"})};
		}
		Item[] stealable = Party.GetEnemy().drops;
		if (stealable.Length > 0) {
    		System.Random rng = new System.Random();
		    int num = rng.Next(stealable.Length);
	     	Item stolen = stealable[num];
    		Item[] newDrops = new Item[stealable.Length - 1];
		    int j = 0;
	    	for (int i = 0; i < stealable.Length; i++) {
    			if (i != num) {
				    newDrops[j] = stealable[i];
			    	j++;
		    	}
	    	}
    		Party.GetEnemy().drops = newDrops;
		    Party.AddItem(stolen);
		    return new TimedMethod[] {new TimedMethod(0, "Audio", new object[] {"Steal1"}), 
		        new TimedMethod(60, "Log", new object[] {stolen.GetName() + " was stolen"})};
		}
		return new TimedMethod[] {new TimedMethod(0, "Audio", new object[] {"Steal1"}), 
		        new TimedMethod(60, "Log", new object[] {"Nothing to steal"})};
	}
}