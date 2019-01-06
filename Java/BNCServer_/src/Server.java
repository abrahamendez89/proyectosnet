import java.awt.AWTException;
import java.awt.Robot;
import java.awt.Toolkit;
import java.awt.datatransfer.Clipboard;
import java.awt.datatransfer.StringSelection;
import java.awt.event.InputEvent;
import java.awt.event.KeyEvent;
import java.net.MalformedURLException;

import org.json.JSONException;
import org.json.JSONObject;

import io.socket.IOAcknowledge;
import io.socket.IOCallback;
import io.socket.SocketIO;
import io.socket.SocketIOException;

public class Server {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		try {
			// Rectangle screenRect = new
			// Rectangle(Toolkit.getDefaultToolkit().getScreenSize());
			// BufferedImage capture;
			/*
			 * for (int i = 0; i < 20; i++) { Rectangle screen = new
			 * Rectangle(Toolkit.getDefaultToolkit().getScreenSize()); BufferedImage
			 * screenCapture = new Robot().createScreenCapture(screen);
			 * 
			 * Image cursor = ImageIO.read(new File("cursor.png")); int x =
			 * MouseInfo.getPointerInfo().getLocation().x; int y =
			 * MouseInfo.getPointerInfo().getLocation().y;
			 * 
			 * Graphics2D graphics2D = screenCapture.createGraphics();
			 * graphics2D.drawImage(cursor, x, y, 16, 16, null); // cursor.gif is 16x16
			 * size. // ImageIO.write(screenCapture, "jpg", new File("c:/capture.gif"));
			 * 
			 * // capture = new Robot().createScreenCapture(screenRect);
			 * ImageIO.write(screenCapture, "jpg", new File("screen" + i + ".jpg"));
			 * Thread.sleep(300); }
			 */

			useRobot();

		} catch (Exception e) {
			e.printStackTrace();
		}
	}

	private static void useRobot() {
		// TODO Auto-generated method stub
		try {
			Robot robot = new Robot();
			// moving mouse

			robot.mouseMove(500, 300);
			Thread.sleep(200);
			robot.mouseMove(550, 250);
			Thread.sleep(200);
			robot.mouseMove(460, 200);
			Thread.sleep(200);
			robot.mouseMove(300, 400);
			Thread.sleep(200);
			robot.mouseMove(470, 280);
			robot.mousePress(InputEvent.BUTTON1_MASK);
			Thread.sleep(500);
			robot.mouseMove(500, 200);
			robot.mouseRelease(InputEvent.BUTTON1_MASK);
			Thread.sleep(500);
			// robot.mousePress(InputEvent.BUTTON1_MASK);
			// robot.mouseRelease(InputEvent.BUTTON1_MASK);

			// copiar al clipboard
			String text = "Hello World";
			StringSelection stringSelection = new StringSelection(text);
			Clipboard clipboard = Toolkit.getDefaultToolkit().getSystemClipboard();
			clipboard.setContents(stringSelection, stringSelection);

			// pegar
			robot.keyPress(KeyEvent.VK_CONTROL);
			robot.keyPress(KeyEvent.VK_V);
			robot.keyRelease(KeyEvent.VK_V);
			robot.keyRelease(KeyEvent.VK_CONTROL);

		} catch (AWTException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		} catch (Exception e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}

	private static void SocketIOTest() {
		SocketIO socket;
		try {
			socket = new SocketIO("http://127.0.0.1:3001/");

			socket.connect(new IOCallback() {
				@Override
				public void onMessage(JSONObject json, IOAcknowledge ack) {
					try {
						System.out.println("Server said:" + json.toString(2));
					} catch (JSONException e) {
						e.printStackTrace();
					}
				}

				@Override
				public void onMessage(String data, IOAcknowledge ack) {
					System.out.println("Server said: " + data);
				}

				@Override
				public void onError(SocketIOException socketIOException) {
					System.out.println("an Error occured");
					socketIOException.printStackTrace();
				}

				@Override
				public void onDisconnect() {
					System.out.println("Connection terminated.");
				}

				@Override
				public void onConnect() {
					System.out.println("Connection established");
				}

				@Override
				public void on(String event, IOAcknowledge ack, Object... args) {
					System.out.println("Server triggered event '" + event + "'");
				}
			});

			// This line is cached until the connection is establisched.
			socket.send("Hello Server!");
		} catch (Exception e1) {
			// TODO Auto-generated catch block
			e1.printStackTrace();
		}
	}

}
