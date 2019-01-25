public class Antibiotics : Item {
	
	public Antibiotics () {name = "Antibiotics"; description = "Cures poison and makes you immune for the rest of the fight"; price = 3;}
	
	public override TimedMethod[] Use () {
		Party.GetPlayer().status.poisoned = 0;
		Party.GetPlayer().status.poisonImmune = true;
		return new TimedMethod[0];
	}
	
	public override void UseOutOfCombat(int i) {
		Party.GetCharacter(i).status.poisonImmune = true;
	}
}