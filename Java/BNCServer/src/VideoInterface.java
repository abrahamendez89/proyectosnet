
public class VideoInterface {

	static {
		System.loadLibrary("NumberList");
	}

	VideoInterface()  {
            initCppSide();
        }

	public native void addNumber(int n);

	public native int size();

	public native int getNumber(int i);

	private native void initCppSide();

	private int numberListPtr_;
	// NumberList*

}
