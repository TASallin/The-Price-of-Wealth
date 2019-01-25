public class Breakthrough : Special {
	
	public Breakthrough() {name = "Breakthrough"; description = "Attack and force the enemy to switch"; baseCost = 3; modifier = 0;}
	
	public override TimedMethod[] Use() {
		if (Party.enemyCount == 1 || !Attacks.EvasionCheck(Party.GetEnemy(), Party.GetPlayer().GetAccuracy())) {
			return new TimedMethod[] {new TimedMethod(0, "StagnantAttack", new object[] {
		    	true, Party.GetPlayer().GetStrength(), Party.GetPlayer().GetStrength() + 4, Party.GetPlayer().GetAccuracy(), true, true, false})};
		}
		int[] pool = new int[Party.enemyCount - 1];
		int index = 0;
		for (int i = 0; i < 4; i++) {
			if (i != Party.enemySlot - 1 && Party.enemies[i] != null && Party.enemies[i].GetAlive()) {
				pool[index] = i;
				index++;
			}
		}
		System.Random rng = new System.Random();
		int former = Party.enemySlot;
		Party.enemySlot = pool[rng.Next(Party.enemyCount - 1)] + 1;
		return new TimedMethod[] {new TimedMethod(0, "AttackAny", new object[] {Party.GetPlayer(), Party.enemies[former - 1],
    		Party.GetPlayer().GetStrength(), Party.GetPlayer().GetStrength() + 4, Party.GetPlayer().GetAccuracy(), true, true, false}),
			new TimedMethod(0, "EnemySwitch", new object[] {Party.enemySlot, former}),
			new TimedMethod(60, "Log", new object[] {Party.GetEnemy().ToString() + " was sent out"})};
	}
}