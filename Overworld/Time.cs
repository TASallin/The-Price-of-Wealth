public static class Time {
	
	public static int timeUnit;
	
	public static void Increment () {
		timeUnit++;
		if (timeUnit % 4 == 0) {
		    UpdateShops();
		}
	}
	
	public static void Increment(int amount) {
		while (amount > 0) {
			Increment();
			amount--;
		}
	}
	
	public static void UpdateShops () {}
}