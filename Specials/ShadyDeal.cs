public class ShadyDeal : Special {
	
	public ShadyDeal() {name = "Shady Deal"; description = "If the enemy is recruitable, they will leave the fight"; baseCost = 9; modifier = 0;}
	
	public override TimedMethod[] UseSupport (int j) {
		if (Party.GetEnemy().GetChampion() || !Party.GetEnemy().GetRecruitable()) {
			return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {Party.GetEnemy().ToString() + " can't be reasoned with"})};
		}
		if (Party.enemyCount == 1) {
			return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {Party.GetEnemy().ToString() + " stopped fighting"}),
			 new TimedMethod("Win")};
		}
		Character fled = Party.GetEnemy();
		int former = Party.enemySlot;
		Party.enemies[Party.enemySlot - 1] = null;
		Party.enemyCount --;
		for (int i = 0; i < 4; i++) {
			if (Party.enemies[i] != null && Party.enemies[i].GetAlive()) {
				Party.enemySlot = i + 1;
				break;
			}
		}
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {fled.ToString() + " stopped fighting"}),
			 new TimedMethod(0, "EnemySwitch", new object[] {Party.enemySlot, former})};
	}
	
}