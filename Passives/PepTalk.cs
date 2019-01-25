public class PepTalk : Passive {
    
	static int countP = 0;
	static int countE = 0;
	
	public PepTalk(Character c) {
		self = c; name = "Pep Talk"; description = "If your lead has no charge, add 1 to charge";
	}

    public override TimedMethod[] Check (bool player) {
		Character lead;
		int count;
		if (player) {
		    lead = Party.GetPlayer();
			count = countP;
	    } else {
			lead = Party.GetEnemy();
			count = countE;
		}
        if (lead.GetCharge() < count) {
			lead.SetCharge(lead.GetCharge() + 1);
			return new TimedMethod[] {new TimedMethod("GetPlayer"), new TimedMethod("GetEnemy"), new TimedMethod(60, "Log", new object[] {
				lead.ToString() + " was inspired"})}; 
		}
		return new TimedMethod[0];
    }
	
	public override TimedMethod[] CheckLead(bool player) {
		return Check(player);
	}
	
	public override TimedMethod[] Initialize(bool player) {
		Character[] team;
		if (player) {
			team = Party.members;
		} else {
			team = Party.enemies;
		}
		int tempCount = 0;
		foreach (Character c in team) {
			if (c != null && c.GetPassive().GetType() == typeof(PepTalk)) {
				tempCount++;
			}
		}
		if (player) {
			countP = tempCount;
		} else {
			countE = tempCount;
		}
		return new TimedMethod[0];
	}
	
	public override TimedMethod[] Deactivate(bool player) {
		if (player) {
		    countP--;
		} else {
			countE--;
		}
		return new TimedMethod[0];
	}
}