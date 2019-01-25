public class Defibrilator : Item {
	
	public Defibrilator() {name = "Defibrilator"; description = "Revives a party member with 1 hp."; selects = true; price = 3;}
	
	public override TimedMethod[] UseSelected(int index) {
	    if (!Party.members[index].GetAlive()) {
		    Party.playerCount++;
	        Party.members[index].SetAlive(true);
		}
		Party.members[index].Heal(1);
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {Party.members[index].ToString() + " was revived"})};
	}
}