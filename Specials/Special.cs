using UnityEngine;

public class Special {
	
	protected string name;
	protected string description;
	protected int baseCost;
	public int modifier;
	public bool usableOut = false;
	public bool selects;
	
	public Special() {
	}
	
	public string GetName() {return name;}
	public void SetModifier(int mod) {modifier = mod;}
	public int GetCost() {return baseCost + modifier;}
	public override string ToString() {return description + ", Cost: " + GetCost().ToString();}
	public virtual TimedMethod[] Use() {return new TimedMethod[0];}
	public virtual TimedMethod[] UseSupport(int i) {return new TimedMethod[0];}
	public virtual TimedMethod[] UseSelects(int i) {return new TimedMethod[0];}
	public virtual void UseOutOfCombat() {}
	}