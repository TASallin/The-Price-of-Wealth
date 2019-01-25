using System.Collections;
using System.Collections.Generic;

public class Item {
	protected string name;
	protected string description;
	public bool selects;
	public int price;
	
	public Item() {
		price = 2;
	}
	
	public virtual TimedMethod[] Use () {
		return new TimedMethod[0];
	}
	
	public string GetName () {
		return name;
	}
	
	public string GetDescription () {
	    return description;	
	}
	
	public virtual void UseOutOfCombat(int i){Party.AddItem(this);}
	
	public virtual TimedMethod[] UseSelected (int i) {return new TimedMethod[0];}
	
}