public class FootballPlayerQ : FootballPlayer {
	
    public FootballPlayerQ() {}
	
	public override TimedMethod[] AI () {
		TimedMethod[] moves;
		if (health < maxHP / 2) {
			return Switch();
		} else {
			moves = new TimedMethod[] {new TimedMethod(0, "Audio", new object[] {"Skill2"}),
			    new TimedMethod(60, "Log", new object[] {"The " + ToString() + " is rallying. Team power has increased"})};
			foreach (Character current in Party.enemies) {
				if (current != null && current.GetAlive()) {
					current.GainPower(1);
				}
			}
		}
    	return moves;
	}
	
	
	public TimedMethod[] Switch () {
		int former = Party.enemySlot;
		for (int i = 0; i < 4; i++) {
			if (Party.enemies[Party.enemySlot + i % 4] != null && Party.enemies[Party.enemySlot + i % 4].GetAlive()) {
				Party.enemySlot = (Party.enemySlot + i % 4) + 1;
				return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {ToString() + " switched out"}),
    				new TimedMethod(0, "EnemySwitch", new object[] {Party.enemySlot, former})};
			}
		}
		return new TimedMethod[0];
	}
	
}