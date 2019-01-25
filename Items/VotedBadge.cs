public class VotedBadge : Item {
	
	public VotedBadge () {
	    name = "VotedBadge"; 
		description = "While in inventory, failing a recruit due to chance causes the enemy to spare you rather than keep fighting";
		price = 2;
    }
	
	public override TimedMethod[] Use () {
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {"The voted badge was discarded, never to be seen again :("})};
	}
	
	public override void UseOutOfCombat (int index) {}
}