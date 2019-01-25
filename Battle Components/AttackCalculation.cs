using System.Collections;
using System.Collections.Generic;

public static class AttackCalculation {

	public static LinkedList<TimedMessage> Attack (Character attacker, Character target, string type) {
		LinkedList<TimedMessage> messages = new LinkedList<TimedMessage>();
		switch (type) {
			case "attack":
			    if (attacker.GetAccuracy() < target.GetEvasion()) {
					target.SetEvasion(target.GetEvasion() - attacker.GetAccuracy());
					attacker.SetCharge(0);
				} else {
					int damage = attacker.GetStrength() + attacker.GetPower() + attacker.GetCharge()
					    - target.GetDefense();
					if (damage < 0) {
						damage = 0;
					}
					attacker.SetCharge(0);
					target.SetEvasion(target.GetEvasion() + target.GetDexterity());
					target.SetHealth(target.GetHealth() - damage);
				}
				break;
		}
		return messages;
	}
}
