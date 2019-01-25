using System.Collections.Generic;
using UnityEngine.SceneManagement;

public static class Areas {
	
	public static Queue<Event> tower;
	public static Queue<Event> dining;
	public static Queue<Event> research;
	public static Queue<Event> lecture;
	public static Queue<Event> sports;
	public static Queue<Event> art;
	public static Queue<Event> health;
	public static Event[] tower1;
	public static Event[] dining1;
	public static Event[] research1;
	public static Event[] lecture1;
	public static Event[] sports1;
	public static Event[] art1;
	public static Event[] health1;
	public static string location;
	public static Event followUp;
	public static Inventory currentShop;
	public static Dictionary<string, bool> cleared;
	public static Dictionary<string, Inventory> shops;
	
	public static void Initialize () {
		EventGetter.BeginGame();
		tower1 = EventGetter.CreateTower();
		dining1 = EventGetter.CreateDining();
		research1 = EventGetter.CreateResearch();
	    sports1 = EventGetter.CreateSports();
		art1 = EventGetter.CreateArts();
		health1 = EventGetter.CreateHealth();
		lecture1 = EventGetter.CreateLecture();
		EventGetter.PlaceBosses(tower1, dining1, research1, sports1, art1, health1, lecture1);
		tower = new Queue<Event>(tower1);
		dining = new Queue<Event>(dining1);
		research = new Queue<Event>(research1);
		sports = new Queue<Event>(sports1);
		art = new Queue<Event>(art1);
		health = new Queue<Event>(health1);
		lecture = new Queue<Event>(lecture1);
		followUp = null;
		Time.timeUnit = 0;
		cleared = new Dictionary<string, bool>(); cleared.Add("tower", false); cleared.Add("dining", false); cleared.Add("research", false);
	    cleared.Add("sports", false); cleared.Add("art", false); cleared.Add("health", false); cleared.Add("lecture", false);
		shops = new Dictionary<string, Inventory>(); shops.Add("tower", new Inventory("tower")); shops.Add("dining", new Inventory("dining"));
		shops.Add("research", new Inventory("research")); shops.Add("sports", new Inventory("sports")); shops.Add("art", new Inventory("art"));
		shops.Add("health", new Inventory("health")); shops.Add("lecture", new Inventory("lecture"));
		location = "overworld";
		Map.selectedLocation = "lecture";
		Map.currentPosition = "lecture";
	}
	
	public static Event Next() {
		switch (location) {
			case "tower": 
			    if (tower.Count == 0) {
					cleared["tower"] = true;
					Time.Increment(5);
					SceneManager.LoadScene("Overworld");
				} else {
			        return tower.Dequeue();
			    }
				break;
			case "dining": 
		    	if (dining.Count == 0) {
					cleared["dining"] = true;
					Time.Increment(5);
					SceneManager.LoadScene("Overworld");
				} else {
			        return dining.Dequeue();
			    }
			    break;
			case "research": 
		    	if (research.Count == 0) {
					cleared["research"] = true;
					Time.Increment(5);
					SceneManager.LoadScene("Overworld");
				} else {
			        return research.Dequeue();
			    }
			    break;
			case "sports": 
		    	if (sports.Count == 0) {
					cleared["sports"] = true;
					Time.Increment(5);
					SceneManager.LoadScene("Overworld");
				} else {
			        return sports.Dequeue();
			    }
			    break;
            case "art": 
		    	if (art.Count == 0) {
					cleared["art"] = true;
					Time.Increment(5);
					SceneManager.LoadScene("Overworld");
				} else {
			        return art.Dequeue();
			    }
			    break;
            case "health": 
		    	if (health.Count == 0) {
					cleared["health"] = true;
					Time.Increment(5);
					SceneManager.LoadScene("Overworld");
				} else {
			        return health.Dequeue();
			    }
			    break;
            case "lecture": 
		    	if (lecture.Count == 0) {
					cleared["lecture"] = true;
					Time.Increment(5);
					SceneManager.LoadScene("Overworld");
				} else {
			        return lecture.Dequeue();
			    }
			    break;				
		}
		return null;
	}
}