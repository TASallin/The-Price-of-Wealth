public class Vengeful : Quirk {
   
    int count;
    
    public Vengeful(Character c) {
        self = c; name = "Vengeful"; description = "Gains power when teammates are defeated";
    }

    public override TimedMethod[] Initialize (bool player) {
        count = 0;
		return new TimedMethod[0];
	}	
	
	public override TimedMethod[] Check (bool player) {
		int defeated = 0;
		Character[] team;
		bool used = false;
		if (player) {
			team = Party.members;
		} else {
			team = Party.enemies;
		}
		foreach (Character c in team) {
			if (c != null && !c.GetAlive()) {
				defeated++;
			}
		}
		while (defeated > count) {
			count++;
			self.SetPower(self.GetPower() + 2);
			used = true;
		}
		if (used) {
			return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {self.ToString() + " will have revenge"})};
		} else {
			return new TimedMethod[0];
		}
	}
	
	public override TimedMethod[] CheckLead (bool player) {return Check(player);}
}