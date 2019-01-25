using System.Collections.Generic;

public class Inventory {
	
	public Item[] products;
	public Character[] hirelings;
	static System.Random rng = new System.Random();
	
	public Inventory(Item[] products, Character[] hirelings) {
		this.products = products; this.hirelings = hirelings;
	}
	
	public Inventory(string location) {
		products = new Item[0];
		hirelings = new Character[0];
		int numP = InitialStockP();
		int numH = InitialStockH();
		switch (location) {
			case "tower":
			    StockTower(numP, numH);
				break;
			case "dining":
			    StockDining(numP, numH);
				break;
			case "research":
			    StockResearch(numP, numH);
				break;
			case "sports":
			    StockSports(numP, numH);
				break;
			case "art":
			    StockArt(numP, numH);
				break;
			case "health":
			    StockHealth(numP, numH);
				break;
			case "lecture":
			    StockLecture(numP, numH);
				break;
		}
	}
	
	public void Restock (Item[] itemPool, Character[] hirePool, int productAmount, int hireAmount) {
	    Item[] newItems = new Item[productAmount + products.Length];
		//System.Random rng = new System.Random();
		for (int i = 0; i < productAmount; i++) {
			int num = rng.Next(itemPool.Length - i);
			newItems[i] = itemPool[num];
			itemPool[num] = itemPool[itemPool.Length - i - 1];
		}
		Character[] newHires = new Character[hireAmount + hirelings.Length];
		//System.Random rng = new System.Random();
		for (int i = 0; i < hireAmount; i++) {
			int num = rng.Next(hirePool.Length - i);
			newHires[i] = hirePool[num];
			hirePool[num] = hirePool[hirePool.Length - i - 1];
		}
		products.CopyTo(newItems, productAmount);
		hirelings.CopyTo(newHires, hireAmount);
		products = newItems;
		hirelings = newHires;
	}
	
	public int RestockAmountP () {
		return rng.Next(6 - products.Length);
	}
	
	public int RestockAmountH () {
		return rng.Next(4 - hirelings.Length);
	}
	
	public static int InitialStockP () {
		return rng.Next(4) + 2;
	}
	
	public static int InitialStockH () {
		return rng.Next(3) + 2;
	}
	
	public void RemoveP (Item i) {
		List<Item> final = new List<Item>();
		foreach (Item current in products) {
			if (i != current) {
				final.Add(current);
			}
		}
		products = final.ToArray();
	}
	
	public void RemoveH (Character c) {
	List<Character> final = new List<Character>();
		foreach (Character current in hirelings) {
			if (c != current) {
				final.Add(current);
			}
		}
		hirelings = final.ToArray();
	}
	
	public void StockTower(int productAmount, int hireAmount) {
		Restock(new Item[] {
			new Briefcase(), new PinkSlip(), new PaperPlane(), new Pencil(), new Smartphone(), new VotedBadge(), new Pendulum(), new Celery()},
		    new Character[] {new BusinessMajor(), new BusinessMajor(), new PoliticalScientist(), new CSMajor(), new AerospaceEngineer()},
			productAmount, hireAmount);
	}
	
	public void StockDining(int productAmount, int hireAmount) {
		Restock(new Item[] {
			new Celery(), new ProteinBar(), new Pizza(), new Curry(), new Rice(), new Milk(), new Donut(), new MysteryGoo()},
		    new Character[] {new CulinaryMajor(), new CulinaryMajor(), new EnglishMajor(), new FootballPlayer(), new HistoryMajor()},
			productAmount, hireAmount);
	}
	
	public void StockResearch(int productAmount, int hireAmount) {
		Restock(new Item[] {
			new ToxicSolution(), new ExplosiveBrew(), new MysteryGoo(), new MysterySolution(), new SlimeGoo(), new Sanitizer(), new Tazer(), new Flask()},
		    new Character[] {new ChemistryMajor(), new MathMajor(), new MechanicalEngineer(), new ChemistryMajor(), new CSMajor()},
			productAmount, hireAmount);
	}
	
	public void StockSports(int productAmount, int hireAmount) {
		Restock(new Item[] {
			new Oil(), new Pizza(), new Sword(), new ProteinBar(), new Smartphone(), new Football(), new Whistle(), new VotedBadge()},
		    new Character[] {new FootballPlayer(), new AerospaceEngineer(), new FootballPlayer(), new MusicMajor(), new MechanicalEngineer()},
			productAmount, hireAmount);
	}
	
	public void StockArt(int productAmount, int hireAmount) {
		Restock(new Item[] {
			new Tuba(), new Baton(), new Metronome(), new Heels(), new Sword(), new Whistle(), new Donut(), new Milk()},
		    new Character[] {new MusicMajor(), new DanceMajor(), new EnglishMajor(), new HistoryMajor(), new DanceMajor()},
			productAmount, hireAmount);
	}
	
	public void StockHealth(int productAmount, int hireAmount) {
		Restock(new Item[] {
			new Sanitizer(), new Antibiotics(), new Defibrilator(), new ToxicSolution(), new Rice(), new PinkSlip(), new Briefcase(), new Wire()},
		    new Character[] {new PreMed(), new PreMed(), new CJMajor(), new PsychMajor(), new ChemistryMajor()},
			productAmount, hireAmount);
	}
	
	public void StockLecture(int productAmount, int hireAmount) {
		Restock(new Item[] {
			new Pencil(), new Textbook(), new Whistle(), new Pizza(), new PaperPlane(), new Milk(), new Smartphone(), new USB()},
		    new Character[] {new CJMajor(), new MathMajor(), new PsychMajor(), new EnglishMajor(), new PoliticalScientist()},
			productAmount, hireAmount);
	}
	
	
}
