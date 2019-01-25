public class Charge : Special {
	
	public Charge () {name = "Charge"; description = "Attack the front 2 enemies"; baseCost = 3; modifier = 0;}
	
	public override TimedMethod[] Use () {
		if (Attacks.EvasionCheck(Party.GetEnemy(), Party.GetPlayer().GetAccuracy()) && Party.enemyCount > 1) {
			Character second = Party.enemies[0];
			for (int i = 1; i < 4; i++) {
				if (Party.enemies[i] != null && Party.enemies[i].GetAlive()) {
					second = Party.enemies[i];
					break;
				}
			}
		    return new TimedMethod[] {new TimedMethod(60, "StagnantAttack", new object[] {
		        true, Party.GetPlayer().GetStrength(), Party.GetPlayer().GetStrength() + 5, Party.GetPlayer().GetAccuracy(), true, false, false}),
			    new TimedMethod(60, "AttackAny", new object[] {Party.GetPlayer(), second, Party.GetPlayer().GetStrength() / 2,
			    (Party.GetPlayer().GetStrength() + 5)/2, Party.GetPlayer().GetAccuracy(), true, true, false})};
		} else {
			return new TimedMethod[] {new TimedMethod(60, "StagnantAttack", new object[] {
		        true, Party.GetPlayer().GetStrength(), Party.GetPlayer().GetStrength() + 5, Party.GetPlayer().GetAccuracy(), true, false, false})};
		}
	}
}