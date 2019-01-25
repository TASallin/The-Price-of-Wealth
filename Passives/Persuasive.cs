public class Persuasive : Passive {
	
	public Persuasive (Character c) {self = c; name = "Persuasive"; description = "Your team has a 100% success rate on recruits";}
	
	public override TimedMethod[] Initialize(bool player) {
		Party.autoRecruit = true;
		return new TimedMethod[0];
	}
}