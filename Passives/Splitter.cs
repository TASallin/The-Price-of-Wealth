public class Splitter : Passive {
	
	public bool split;
	
	public Splitter(Character c) {self = c; name = "Splitter"; description = "Splits when damaged"; split = false;}
	
	public override TimedMethod[] CheckLead(bool player) {
		if (split) {
			split = false;
			return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {"The slime has split"})};
		}
		return new TimedMethod[0];
	}

}