public class Smartphone : Item {
	public Smartphone() {name = "Smartphone"; description = "In a crisis like this, a charged phone will"
	    + " win over anyone that doesn't have glowing eyes"; price = 2;}
	
	public override TimedMethod[] Use() {
		string message;
		TimedMethod move;
		if (!Party.GetEnemy().GetRecruitable()) {
			message = "You chucked the smartphone at the one with glowing eyes";
			move = new TimedMethod(30, "StagnantAttack", new object[] {true, 1, 1, Party.GetPlayer().GetAccuracy(), true, true, false});
		} else if (Party.enemyCount > 1) {
		    message = "Alas, party bonds were stronger than the smartphone. So you threw it at them";
		    move = new TimedMethod(30, "StagnantAttack", new object[] {true, 1, 1, Party.GetPlayer().GetAccuracy(), true, true, false});
		} else {
			message = Party.GetEnemy().ToString() + " was easily convinced by the gift";
			move = new TimedMethod(30, "RecruitSuccess");
		}
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {message}), move};
	}
}