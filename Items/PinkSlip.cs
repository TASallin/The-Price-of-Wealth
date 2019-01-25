public class PinkSlip : Item {
	
	public PinkSlip() {name = "Pink Slip"; description = "If the enemy is a non-boss, they will flee"; price = 2;}
	
	public override TimedMethod[] Use () {
		if (Party.GetEnemy().GetChampion()) {
			return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {Party.GetEnemy().ToString() + " is not scared"})};
		}
		if (Party.enemyCount == 1) {
			return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {Party.GetEnemy().ToString() + " has fled"}),
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
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {fled.ToString() + " has fled"}),
			 new TimedMethod(0, "EnemySwitch", new object[] {Party.enemySlot, former})};
	}
	
}