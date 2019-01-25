public class Exam : Item {
	
	public Exam () {
		name = "Exam"; description = "Whoever writes their name on this exam will feel Serene"; price = 11;
	}
	
	public override TimedMethod[] Use () {
		Party.AddItem(this);
		return new TimedMethod[] {new TimedMethod(60, "Log", new object[] {"No time for this"})};
	}
	
	public override void UseOutOfCombat (int index) {
		Party.members[index].SetQuirk(new Serene(Party.members[index]));
	}
	
}