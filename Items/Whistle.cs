public class Whistle : Item {
	
	public Whistle () {name = "Whistle"; description = "Forces the enemy to switch. Repeatable"; price = 2;}
	
	public override TimedMethod[] Use () {
		if (Party.enemyCount == 1) {
			return new TimedMethod[] {new TimedMethod(60, "Log",new object[] {"No one to switch to"})};
		}
		Party.AddItem(this);
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
		return new TimedMethod[] {new TimedMethod(0, "EnemySwitch", new object[] {Party.enemySlot, former}), new TimedMethod(
		    60, "Log", new object[] {Party.GetEnemy().ToString() + " was sent out"})};
	}
}