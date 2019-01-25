public class Passive {
    
	protected string description;
	protected string name;
	protected Character self;
	
	public Passive(Character c) {self = c;}
	public Passive(){}
	
	public virtual TimedMethod[] Check (bool player) {
		return new TimedMethod[0];
	}
	
	public virtual TimedMethod[] CheckLead (bool player) {
	    return new TimedMethod[0];	
	}
	
	public virtual TimedMethod[] Use (bool player) {
		return new TimedMethod[0];
	}
	
	public virtual TimedMethod[] Initialize (bool player) {
		return new TimedMethod[0];
	}
	
	public virtual TimedMethod[] Deactivate (bool player) {
		return new TimedMethod[0];
	}
	
	public string GetName() {return name;}
	public string GetDescription() {return description;}
	public Passive Clone () {return (Passive)this.MemberwiseClone();}
	
}