public class WikiHPedia : Passive {
    
    public WikiHPedia (Character c) {
		self = c; name = "Wiki-HP-dia"; description = "Your team can see enemy HP";
	}

    public override TimedMethod[] Check (bool player) {
        if (player) {
		    StatusBarE.informed = true;
		}
		return new TimedMethod[0];
    }
	
	public override TimedMethod[] CheckLead(bool player) {
		return Check(player);
	}

    public override TimedMethod[] Deactivate (bool player) {
        if (player) {
		    StatusBarE.informed = false;
		}
		return new TimedMethod[0];
    }	
}