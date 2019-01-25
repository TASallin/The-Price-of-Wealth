using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Party {
	public static Character[] members = new Character[4];
	public static Character[] enemies = new Character[4];
	static Item[] items = new Item[10];
	public static int playerSlot = 1;
	public static int enemySlot = 1;
	static int sp = 10;
	static Item[] spoils = new Item[10];
	static int spoilIndex = 0;
	public static int playerCount;
	public static int enemyCount;
	public static Character fullRecruit;
	public static Character latestRecruit;
	public static string area;
	public static int turn;
	public static int usedItems;
	public static bool autoRecruit;
	
	public static int Main() {
	items[0] = new Pizza();
	return 0;
	}
	
	public static Character GetCharacter(int index) {return members[index];}
	public static Character GetPlayer() {return members[playerSlot - 1];}
	public static void SetPlayer(Character c) {members[playerSlot - 1] = c;}
	public static void SetEnemy(Character c) {enemies[enemySlot - 1] = c;}
	public static Character GetEnemy() {return enemies[enemySlot - 1];}
	public static Character GetEnemy(int index) {return enemies[index];}
	public static Item GetLootAt(int index) {return spoils[index];}
	public static Item GetItem(int index) {return items[index];}
	public static void UseItem(int index) {items[index] = null;}
	public static void SetItems(Item[] newItems) {items = newItems;}
	public static int GetActive() {return playerSlot;}
	public static int GetEnemyActive() {return enemySlot;}
	public static int GetSP() {return sp;}
	public static void UseSP(int amount) {sp = System.Math.Max(sp - amount, 0); sp = System.Math.Min(sp, 40);}
	public static Item[] GetItems () {return items;}
	public static Item[] GetLoot () {return spoils;}
	public static void ClearLoot () {spoils = new Item[10]; spoilIndex = 0;}
	public static void AddLoot (Item loot) {
		if (spoilIndex < 10) {
		    spoils[spoilIndex] = loot; spoilIndex++;
		}
	}
	public static void AddItem (Item item) {
		for (int i = 0; i < 10; i++) {
			if (items[i] == null) {
				items[i] = item;
				break;
			}
		}
	}
	
	public static bool BagContains (Item type) {
	    for (int i = 0; i < 10; i++) {
			if (items[i] != null && items[i].GetType().Equals(type.GetType())) {
				return true;
			}
		}
		return false;
	}
	
	public static TimedMethod[] StealItem () {
		if (BagContains(new Briefcase())) {return new TimedMethod[] {new TimedMethod(60, "Log", new object[]{"A briefcase prevents theft"})};}
		List<int> indexes = new List<int>();
		for (int i = 0; i < 10; i++) {
			if (items[i] != null) {indexes.Add(i);}
		}
		if (indexes.Count > 0) {
		    System.Random rng = new System.Random();
		    int index = rng.Next(indexes.Count);
			Item stolen = items[indexes[index]];
			Item[] newDrops = new Item[GetEnemy().drops.Length + 1];
			GetEnemy().drops.CopyTo(newDrops, 0);
			newDrops[GetEnemy().drops.Length] = stolen;
			GetEnemy().drops = newDrops;
			//AddLoot(stolen);
			items[indexes[index]] = null;
			return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {stolen.GetName() + " was stolen"})};
		}
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {"Nothing was stolen"})};
	}
	
	public static void Switch(int index, bool player) {
		if (player) {
			if (Status.firewall) {
				GetPlayer().Damage(10);
				members[index - 1].Damage(System.Math.Min(10, members[index - 1].GetHealth() - 1));
			}
			playerSlot = index;
		} else {
			if (Status.firewall) {
				GetEnemy().Damage(10);
				enemies[index - 1].Damage(System.Math.Min(10, enemies[index - 1].GetHealth() - 1));
			}
			enemySlot = index;
		}
	}
	
	public static void Clear() {
	    members = new Character[4];
	    enemies = new Character[4];
	    items = new Item[10];
	    playerSlot = 1;
	    enemySlot = 1;
		playerCount = 0;
		enemyCount = 0;
	    sp = 10;
	    spoils = new Item[10];
		turn = 0;
	}
	
	public static void AddPlayer(Character c) {
		bool added = false;
		for (int i = 0; i < 4; i++) {
			if (members[i] == null || !members[i].GetAlive()) {
				c.SetPlayer(true);
				members[i] = c;
				added = true;
				playerCount++;
				c.OnRecruit();
				latestRecruit = c;
				break;
			}
		}
		if (!added) {
			fullRecruit = c;
		}
	}
	
	public static void AddEnemy(Character c) {
		for (int i = 0; i < 4; i++) {
			if (enemies[i] == null || !enemies[i].GetAlive()) {
				enemies[i] = c;
				enemyCount++;
				if (turn > 0) {
					c.GetPassive().Initialize(false);
					c.GetQuirk().Initialize(false);
				}
				break;
			}
		}
	}
	
	public static void EnqueuePassives(Queue<TimedMethod> queue, TimedMethod[] toQueue) {
		foreach (TimedMethod t in toQueue) {
			queue.Enqueue(t);
		}
	}
	
	public static Queue<TimedMethod> CheckPassives () {
		turn++;
		Character current;
		TimedMethod[] toQueue1;
		TimedMethod[] toQueue2;
		Queue<TimedMethod> moves = new Queue<TimedMethod>();
		for (int index = 0; index < 4; index++) {
			current = members[index];
			if (current != null && current.GetAlive()) {
			    if (index + 1 == playerSlot) {
			        toQueue1 = current.GetPassive().CheckLead(true);
				    toQueue2 = current.GetQuirk().CheckLead(true);
			    } else {
			        toQueue1 = current.GetPassive().Check(true);
			        toQueue2 = current.GetQuirk().Check(true);
			    }
			    EnqueuePassives(moves, toQueue1);
			    EnqueuePassives(moves, toQueue2);
		    }
		}
		for (int index = 0; index < 4; index++) {
			current = enemies[index];
			if (current != null && current.GetAlive()) {
			    if (index + 1 == enemySlot) {
			        toQueue1 = current.GetPassive().CheckLead(false);
				    toQueue2 = current.GetQuirk().CheckLead(false);
			    } else {
			        toQueue1 = current.GetPassive().Check(false);
			        toQueue2 = current.GetQuirk().Check(false);
			    }
			    EnqueuePassives(moves, toQueue1);
			    EnqueuePassives(moves, toQueue2);
			}
		}
		usedItems = 0;
		return moves;
	}
	
	public static Queue<TimedMethod> InitializePassives () {
		turn = 0;
		TimedMethod[] toQueue; 
		Queue<TimedMethod> moves = new Queue<TimedMethod>();
		foreach (Character current in members) {
			if (current != null) {
			    toQueue = current.GetPassive().Initialize(true);
			    EnqueuePassives(moves, toQueue);
			    toQueue = current.GetQuirk().Initialize(true);
			    EnqueuePassives(moves, toQueue);
			}
		}
		foreach (Character current in enemies) {
			if (current != null) {
			    toQueue = current.GetPassive().Initialize(false);
			    EnqueuePassives(moves, toQueue);
			    toQueue = current.GetQuirk().Initialize(false);
			    EnqueuePassives(moves, toQueue);
			}
		}
		return moves;
	}
	
	public static TimedMethod[] CheckDeath() {
		for (int i = 0; i < 4; i++) {
			if (i != playerSlot - 1 && members[i] != null && members[i].GetHealth() <= 0 && members[i].GetAlive()) {
				members[i].SetAlive(false);
				playerCount--;
				members[i].GetPassive().Deactivate(true);
			}
			if (i != enemySlot - 1 && enemies[i] != null && enemies[i].GetHealth() <= 0 && enemies[i].GetAlive()) {
				enemies[i].SetAlive(false);
				enemyCount--;
				enemies[i].GetPassive().Deactivate(false);
				Spoils(enemies[i]);
			}
		}
		
		if (GetPlayer().GetHealth() <= 0) {
			Character dead = GetPlayer();
			dead.SetAlive(false);
			playerCount--;
			dead.GetPassive().Deactivate(true);
			if (dead.GetChampion()) {
				return new TimedMethod[] {new TimedMethod(60, "Lose")};
			} else {
				//members[playerSlot - 1] = null;
				//members[playerSlot - 1].SetAlive(false);
				Switch(1, true);
				return new TimedMethod[] {new TimedMethod(60, "PartyDeath", new object[] {dead})};
			}
		} else if (GetEnemy().GetHealth() <= 0) {
			Character dead = GetEnemy();
			dead.SetAlive(false);
			enemyCount--;
			dead.GetPassive().Deactivate(false);
			Spoils(dead);
			int prev = enemySlot;
			if (dead.GetChampion()) {
				return new TimedMethod[] {new TimedMethod(60, "Win")};
		    } else {
				//enemies[enemySlot - 1] = null;
				//enemies[enemySlot - 1].SetAlive(false);
				int newSlot = 0;
				for (int i = 0; i < 4; i++) {
				    if (newSlot == 0 && enemies[i] != null && enemies[i].GetAlive()) {
						newSlot = i + 1;
					} else if (enemies[i] != null && enemies[i].GetChampion() && enemies[i].GetAlive()) {
						newSlot = i + 1;
					}
				}
				if (newSlot == 0) {
					return new TimedMethod[] {new TimedMethod(0, "ToggleMenu", new object[] {false}),
					new TimedMethod(60, "EnemyDeath", new object[] {dead}), new TimedMethod(30, "Win")};
				} else {
					Switch(newSlot, false);
				    return new TimedMethod[] {new TimedMethod(0, "EnemySwitch", new object[] {prev, enemySlot}),
    					new TimedMethod(60, "EnemyDeath", new object[] {dead})};
			    }
			}
		} else {
			return new TimedMethod[0];
		}
	}
	
	public static void Spoils(Character looted) {
		Item[] loot = looted.Loot();
		foreach (Item piece in loot) {
			if (piece != null && spoilIndex < 10) {
			    spoils[spoilIndex] = piece;
			    spoilIndex++;
			}
		}
	}
	
	public static void PostBattle() {
	    enemies = new Character[4];
	    enemyCount = 0;
		enemySlot = 1;
        spoils = new Item[10];
		spoilIndex = 0;
		autoRecruit = false;
		turn = 0;
		latestRecruit = null;
	    for (int index = 0; index < 4; index++) {
	        if (members[index] != null) {
				if (!members[index].GetAlive()) {
					members[index] = null;
				} else {
				    members[index].PostBattle();
				}
			}
   	    } 
	}
}