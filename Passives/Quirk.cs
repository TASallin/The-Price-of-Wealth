public class Quirk : Passive {
	
	public static System.Random rng = new System.Random();
	
	public static Quirk GetQuirk(Character c) {
		int num = rng.Next(12);
		if (num == 0) {
		    return new Temperamental(c);
		} else if (num == 1) {
			return new SleepDeprived(c);
		} else if (num == 2) {
			return new Berserk(c);
		} else if (num == 3) {
			return new Vengeful(c);
		} else if (num == 4) {
			return new Ill(c);
		} else if (num == 5) {
			return new Average(c);
		} else if (num == 6) {
			return new Bandwagon(c);
		} else if (num == 7) {
			return new Procrastinator(c);
		} else if (num == 8) {
			return new Vaccinated(c);
		} else if (num == 9) {
			return new Ninja(c);
		} else if (num == 10) {
			return new Paranoid(c);
		} else {
			return new Overconfident(c);
		}
	}
}