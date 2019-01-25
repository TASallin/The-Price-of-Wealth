public class Celery : Item {
	
	public Celery() {name = "Celery"; description = "Restores 5 hp. You gain 1 defense"; selects = true; price = 2;}
	
	public override TimedMethod[] UseSelected(int i) {
		Party.members[i].Heal(5);
		Party.members[i].SetDefense(Party.members[i].GetDefense() + 1);
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {Party.members[i].GetName() + " ate the celery. It was fibrous."})};
	}

    public override void UseOutOfCombat(int i) {
		UseSelected(i);
	}
}