using UnityEngine;

public static class ItemDrops {
	
	static System.Random rng = new System.Random();
	
	public static Item[] FromPool (Item[] pool, int amount) {
	    Item[] drops = new Item[amount];
		//System.Random rng = new System.Random();
		for (int i = 0; i < amount; i++) {
			int num = rng.Next(pool.Length - i);
			drops[i] = pool[num];
			pool[num] = pool[pool.Length - i - 1];
		}
		return drops;
	}
	
	public static int Amount(int min, int max) {
		//System.Random rng = new System.Random();
		int num = rng.Next((int)System.Math.Pow(2, max - min + 1) - 1);
		//Debug.Log(num.ToString());
		int ceil = 1;
		for (int i = max; i >= min; i--) {
			if (num < ceil) {
                return i;
			}
			ceil += (int)System.Math.Pow(2, 1 + max - i);
		}
		return min;
	}
	
	public static Item[] GuaranteedDrop (Item[] pool, int amount, Item needed) {
		Item[] randoms = FromPool(pool, amount - 1);
		Item[] drops = new Item[amount];
		drops[0] = needed;
		randoms.CopyTo(drops, 1);
		return drops;
	}
	
	public static Item[] AnyFood (int amount) {
		Item[] pool = new Item[] {new Pizza(), new Donut(), new Curry(), new Celery(), new ProteinBar(), new Milk(), new Rice()};
		Item[] drops = new Item[amount];
		System.Random rng = new System.Random();
		for (int i = 0; i < amount; i++) {
			drops[i] = pool[rng.Next(7)];
		}
		return drops;
	}
	
	
	
}