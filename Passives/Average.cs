public class Average : Quirk {
	
	public Average (Character c) {self = c; name = "Average"; description = "Attack and defense never change";}
	
	public override TimedMethod[] Check (bool player) {
		Status.NullifyAttack(self); Status.NullifyDefense(self);
		return new TimedMethod[0];
	}
	
	public override TimedMethod[] CheckLead (bool player) {return Check(player);}
}