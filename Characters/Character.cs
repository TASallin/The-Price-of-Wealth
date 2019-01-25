using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character {
	protected int health;
	protected int maxHP;
	protected int strength;
	protected int power;
	protected int charge;
	protected int defense;
	protected int guard;
	protected int baseAccuracy;
	protected int accuracy;
	protected int dexterity;
	protected int evasion;
	protected string name;
	public string type;
	protected Passive passive;
	protected Passive quirk;
	protected Special special;
	protected Special special2;
	protected bool player;
	protected bool champion;
	protected bool recruitable;
	public Status status;
	protected bool alive;
	public Item[] drops;
	
	public Character(int health, int maxHP, int strength, int accuracy,
	int dexterity, string name, Quirk quirk, bool player, bool champion,
	bool recruitable) {
		this.health = health; this.maxHP = maxHP; this.strength = strength; 
		power = 0; charge = 0; defense = 0; guard = 0; baseAccuracy = accuracy; this.accuracy = accuracy;
		this.dexterity = dexterity; evasion = 0; this.name = name;
		this.quirk = quirk; this.special = new Rally(); this.player = player; 
		this.champion = champion; this.recruitable = recruitable;
	}
	
	public Character(Quirk quirkR) {}
	public Character () {alive = true; status = new Status(this); name = Names.Get();}
	
	public void SetHealth (int health) {if (health < this.health) {status.Awake();} this.health = health; if (health <= 0) {alive = false;}}
	public int GetHealth () {return health;}
	public void SetMaxHP (int maxHP) {this.maxHP = maxHP;}
	public int GetMaxHP () {return maxHP;}
	public void SetStrength (int strength) {this.strength = strength;}
	public int GetStrength () {return strength;}
	public void SetPower(int power) {this.power = power;}
	public int GetPower() {return power + status.CoffeeEffect();}
    public void SetCharge(int charge) {this.charge = charge;}
	public int GetCharge() {return charge;}
	public void SetDefense(int defense) {this.defense = defense;}
	public int GetDefense() {return defense;}
	public void SetGuard(int guard) {this.guard = guard;}
	public int GetGuard() {return guard;}
	public void SetBaseAccuracy (int baseAccuracy) {this.baseAccuracy = baseAccuracy;}
	public int GetBaseAccuracy () {return baseAccuracy;}
	public void SetAccuracy (int accuracy) {this.accuracy = accuracy;}
	public int GetAccuracy () {return accuracy - status.blinded;}
	public void SetDexterity (int dexterity) {this.dexterity = dexterity;}
	public int GetDexterity () {return dexterity;}
	public void SetEvasion (int evasion) {this.evasion = evasion;}
	public int GetEvasion () {return evasion;}
	public void SetName (string name) {this.name = name;}
	public string GetName () {return name;}
	public void SetPassive(Passive passive) {this.passive = passive;}
	public Passive GetPassive() {return passive;}
	public void SetQuirk (Passive quirk) {this.quirk = quirk;}
	public Passive GetQuirk () {return quirk;}
	public void SetSpecial(Special special) {this.special = special;}
	public Special GetSpecial () {return special;}
	public void SetSupportSpecial(Special special2) {this.special2 = special2;}
	public Special GetSupportSpecial () {return special2;}
	public void SetPlayer (bool player) {this.player = player;}
	public bool GetPlayer () {return player;}
	public void SetChampion (bool champion) {this.champion = champion;}
	public bool GetChampion () {return champion;}
	public void SetRecruitable (bool recruitable) {this.recruitable = recruitable;}
	public bool GetRecruitable () {return recruitable;}
	public void SetAlive (bool alive) {this.alive = alive;}
	public bool GetAlive () {return alive;}
	public bool GetAsleep () {return status.asleep > 0;}
	public bool GetPoisoned () {return status.poisoned > 0;}
	public bool GetStunned () {return status.stunned > 0;}
	public bool GetBlinded () {return status.blinded > 0;}
	public bool GetGooped () {return status.gooped;}
	public bool GetPassing () {return status.passing;}
	public bool GetApathy () {return status.apathetic > 0;}
	
	public virtual TimedMethod[] BasicAttack() {
		if (Party.BagContains(new Metronome())) {
			return Attacks.Attack(this, Party.GetEnemy(), strength + 2, strength + 2, GetAccuracy(), true, true, false);
		}
		return Attacks.Attack(this, Party.GetEnemy());
	}
	
	public void Heal (int amount) {
		if (alive) {health = System.Math.Min(health + amount, maxHP);}
	}
	
	public virtual void Damage (int amount) {
		health = System.Math.Max(health - amount, 0); status.Awake();
	}
	
	public void GainStrength (int amount) {strength += amount;}
	public void GainPower (int amount) {power += amount;}
	public void GainCharge (int amount) {charge += amount;}
	public void GainDefense(int amount) {defense += amount;}
	public void GainGuard(int amount) {guard += amount;}
	public void GainEvasion(int amount) {evasion = System.Math.Max(0, evasion + amount);}
	public void GainDexterity (int amount) {dexterity += amount;}
	public void GainMaxHP (int amount) {maxHP += amount; health = System.Math.Min(health, maxHP);}
	public void GainAccuracy (int amount) {accuracy += amount;}
	
	public void DexCheck () {if (!GetAsleep() && !GetStunned() && !GetGooped()) {evasion += dexterity;}}
	
	public override string ToString() {
		if (player) {
		    return name;
		} else {
		    return "Enemy " + type;
		}
	}
	
	public virtual void OnRecruit() {}
	
	public string StatusText() {
		if (alive) {
		return name + "(" + quirk.GetName() + " " + type + ")  - HP: " + health.ToString() + "/" + maxHP.ToString() + " SP: " + Party.GetSP()
		    + "\nStrength: " + strength.ToString() + " Power: " + power.ToString() + " Charge: " + charge.ToString()
			+ " Defense: " + defense.ToString() + " Guard: " + guard.ToString() + "\nAccuracy: " + accuracy.ToString()
			+ " Evasion: " + evasion.ToString() + " Dexterity: " + dexterity.ToString() + "\nPrimary Special: " 
			+ special.GetName() + " - " + special.ToString() + "\nSupport Special: " 
			+ special2.GetName() + " - " + special2.ToString() + "\nPassive: " + passive.GetName() + " - " 
			+ passive.GetDescription() + "\nTrait: " + quirk.GetName() + " - " + quirk.GetDescription() + "\n" + status.DescriptorText();
		} else {
			return quirk.GetName() + " " + name + ". This character is at 0 hp "; 
		}
	}
	
	public string StatusE() {
		if (alive) {
		return ToString() + " - Power: " + power.ToString() + " Charge: " + charge.ToString()
			+ " Defense: " + defense.ToString() + " Guard: " + guard.ToString() + "\nAccuracy: " 
			+ accuracy.ToString() + " Evasion: " + evasion.ToString() + " Dexterity: " + dexterity.ToString()
			+ "\nTrait: " + quirk.GetName() + " - " + quirk.GetDescription() + "\n" + status.DescriptorText();
		} else {
			return quirk.GetName() + " " + name + ". This character is at 0 hp ";
		}
	}
	
	public virtual string SpecificBarText () {
		return "";
	}
	
	public virtual TimedMethod[] AI () {
		return new TimedMethod[0];
	}
	
	public virtual TimedMethod[] EnemyTurn () {
		//TimedMethod[] extra = status.Check(this);
		if (GetAsleep() || GetStunned() || GetPassing()) {
			status.passing = false;
			return new TimedMethod[0];
		} else { 
		    return AI();
		}
	}
	
	public virtual Item[] Loot () {
	    return new Item[0];	
	}
	
	public virtual void CreateDrops() {
		drops = new Item[0];
	}
	
	public virtual void PostBattle() {
		power = 0; charge = 0; defense = 0; guard = 0; evasion = 0; accuracy = baseAccuracy; status.PostBattle();
	}
	
	public virtual string[] CSDescription() {
		return new string[0];
	}
}
