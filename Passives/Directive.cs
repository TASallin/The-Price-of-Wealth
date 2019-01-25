public class Directive : Passive {
	
	bool firstTurn;
	
	public Directive (Character c) {self = c; name = "Directive"; description = "At the start of the round, rotate through your party";}
	
	public override TimedMethod[] Initialize(bool player) {
		firstTurn = true;
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {self.ToString() + "'s team is rotating"})};
	}
	
	public override TimedMethod[] Check (bool player) {
		if (firstTurn) {
			firstTurn = false;
			return new TimedMethod[0];
		}
		Character[] team;
		int slot;
		if (player) {
			team = Party.members;
			slot = Party.playerSlot - 1;
		} else {
			team = Party.enemies;
			slot = Party.enemySlot - 1;
		}
		for (int i = 1; i < 4; i++) {
			if (team[(slot + i) % 4] != null && team[(slot + i) % 4].GetAlive()) {
				if (player) {
					return new TimedMethod[] {new TimedMethod(0, "SwitchTo", new object[] {(slot + i) % 4 + 1})};
				} else {
					Party.enemySlot = ((slot + i) % 4) + 1;
					return new TimedMethod[] {new TimedMethod(0, "EnemySwitch", new object[] {Party.enemySlot, slot + 1})};
				}
			}
		}
		return new TimedMethod[0];
	}
	
	public override TimedMethod[] CheckLead (bool player) {
		return Check(player);
	}
}