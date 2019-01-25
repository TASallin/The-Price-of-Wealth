public class TimedMethod {
    
    public int delay;
    public string method;
    public object[] args;

    public TimedMethod(int delay, string method, object[] args) {
        this.delay = delay; this.method = method; this.args = args;
    }	
	
	public TimedMethod(int delay, string method) {
		this.delay = delay; this.method = method; this.args = null;
	}
	
	public TimedMethod(string method) {
		this.delay = 0; this.method = method; this.args = null;
	}
}