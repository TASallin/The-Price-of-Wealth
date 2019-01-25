public class TimedMessage {

	string message;
	int duration;
	
	public TimedMessage(string message, int duration) {
		this.message = message; this.duration = duration;
    }
	
	public string GetMessage() {return message;}
	public int GetDuration() {return duration;}
}