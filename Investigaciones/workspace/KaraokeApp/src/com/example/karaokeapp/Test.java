package com.example.karaokeapp;

import java.io.BufferedWriter;
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.io.OutputStreamWriter;
import java.io.PrintWriter;
import java.net.InetAddress;
import java.net.Socket;
import java.net.UnknownHostException;
import java.nio.ByteBuffer;

import android.os.Bundle;
import android.app.Activity;
import android.app.Application.ActivityLifecycleCallbacks;
import android.content.Context;
import android.content.pm.PackageManager;
import android.graphics.Bitmap;
import android.graphics.Bitmap.Config;
import android.graphics.Canvas;
import android.hardware.Camera;
import android.hardware.Camera.CameraInfo;
import android.hardware.Camera.ShutterCallback;
import android.util.Base64;
import android.util.DisplayMetrics;
import android.util.Log;
import android.view.Menu;
import android.view.View;
import android.widget.EditText;
import android.widget.TableLayout;
import android.widget.TableRow;
import android.widget.TextView;
import android.widget.Toast;

public class Test extends Activity {
	private Socket socket;
	private int TamSocket = 5242880;
	private String ipActual;
	private Activity mActivity;
	private TextView txt;
	
//	private Camera mCamera;
//    private CameraPreview mCameraPreview;
	
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_test);
        //camara
        
//        mCamera = getCameraInstance();
//        mCameraPreview = new CameraPreview(this, mCamera);
//        FrameLayout preview = (FrameLayout) findViewById(R.id.camera_preview);
//        preview.addView(mCameraPreview);
        
        //
        String ipTemp = Utils.getIPAddress(true);
        int puntos = 0;
        ipActual = "";
        for(int i = 0; i < ipTemp.length(); i++)
        {
        	if(ipTemp.charAt(i) == '.')
        		puntos++;
        	ipActual += ipTemp.charAt(i);
        	if(puntos == 3)
        		break;
        }
        txt = (TextView) findViewById(R.id.mensaje);
        
        mActivity= this;
        
        DisplayMetrics metrics = this.getResources().getDisplayMetrics();
        int height = metrics.heightPixels / 4; // quarter of screen height
        TableRow row1 = (TableRow) findViewById(R.id.tableRow1);
        row1.setLayoutParams(new TableRow.LayoutParams(TableRow.LayoutParams.WRAP_CONTENT, 100));
        TableRow row2 = (TableRow) findViewById(R.id.tableRow2);
        row2.setLayoutParams(new TableRow.LayoutParams(TableRow.LayoutParams.MATCH_PARENT, 80));
        TableRow row3 = (TableRow) findViewById(R.id.tableRow3);
        row3.setLayoutParams(new TableRow.LayoutParams(TableRow.LayoutParams.MATCH_PARENT, 80));
        
        
        new Thread(new BuscarServer()).start();

    }
    
    private Boolean encontrado = false;
    private String ipEcontrada = "";
    private String ipTemporal = "";
    class IntentarConectar implements Runnable 
    {
        @Override
        public void run() 
        {
	        String ip = (String)ipTemporal;
	        try
	        {
	        	InetAddress serverAddr = InetAddress.getByName(ip);
	            Socket socket = new Socket(serverAddr, 8889);
	            encontrado = true;
	            ipEcontrada = ip;
	        }
	        catch(Exception ex) 
	        { 
	        }
        }
    }
    class BuscarServer implements Runnable
    {
    	@Override
        public void run() 
    	{
    		Mensaje("Buscando...");
	        for (int i = 0; i <= 255; i++)
	        {
	        	ipTemporal = ipActual + i;
	        	Mensaje(ipTemporal);
	        	Thread intento = new Thread(new IntentarConectar());
	            try {
		            intento.start();
		            Thread.sleep(200);
				} catch (Exception e) {
					
				}
	            if (encontrado)
	            {
	                if(intento.isAlive())
	                    intento.interrupt();
	                try {
	                	ipTemporal = ipActual + (i);
    	                InetAddress serverAddr = InetAddress.getByName(ipEcontrada);
    	                socket = new Socket(serverAddr, 8888);
    	            } catch (Exception ex)
    	            {
    	            	Mensaje(ex.getMessage());
    	            }
	                Mensaje("Conexión exitosa!!");
	                return;
	            }
	                
	        }
	        Mensaje("No se encontró!!");
    	}
    }
    private String textT = "";
    public void Mensaje(String texto)
    {
    	textT = texto;
    	    mActivity.runOnUiThread(new Runnable() {
    	        public void run() {
    	            txt.setText(textT);
    	        }
    	    });
    }
    public Bitmap screenShot(View view) {
        Bitmap bitmap = Bitmap.createBitmap(view.getWidth(),
                view.getHeight(), Config.ARGB_8888);
        Canvas canvas = new Canvas(bitmap);
        view.draw(canvas);
        return bitmap;
    }
    Bitmap bitmap;
    byte[] byteArray = null;
    public void onClickCamera(View view) 
    {
    	
    	try
    	{
    	 		
    	mActivity.runOnUiThread(new Runnable() {
    		
	        public void run() {
	        	bitmap = screenShot(findViewById(R.id.layoutPrincipal));
	        	
//	        	try
//	        	{
//	        	Thread.sleep(300);
////	        	byteArray = PhotoHandler.BytesFoto;
//	        	}catch(Exception ex){}
	        	
	        }
	    });
    	  
    	ByteArrayOutputStream stream = new ByteArrayOutputStream();
        bitmap.compress(Bitmap.CompressFormat.PNG, 100, stream);
        byteArray = stream.toByteArray();
    	
        String encoded = Base64.encodeToString(byteArray, Base64.DEFAULT);
        
        socket.setReceiveBufferSize(TamSocket);
        socket.setSendBufferSize(TamSocket);
    	PrintWriter out = new PrintWriter(new BufferedWriter(new OutputStreamWriter(socket.getOutputStream())),true);
        out.println(encoded);
        
        Mensaje("exito foto");
    	}
    	catch(Exception ex)
    	{
    		Mensaje(ex.getMessage());
    	}
    }
    
    public void onClick(View view) {
    	        try {
    	        	String valor = "";
    	        	switch (view.getId()) {
    	            case  R.id.btn1: {
    	            	valor = "1";
    	                break;
    	            	}
    	            case  R.id.btn2: {
    	            	valor = "2";
    	                break;
    	            	}
    	            case  R.id.btn3: {
    	            	valor = "3";
    	                break;
    	            	}
    	            case  R.id.btn4: {
    	            	valor = "4";
    	                break;
    	            	}
    	            case  R.id.btn5: {
    	            	valor = "5";
    	                break;
    	            	}
    	            case  R.id.btn6: {
    	            	valor = "6";
    	                break;
    	            	}
    	            case  R.id.btn7: {
    	            	valor = "7";
    	                break;
    	            	}
    	            case  R.id.btn8: {
    	            	valor = "8";
    	                break;
    	            	}
    	            case  R.id.btn9: {
    	            	valor = "9";
    	                break;
    	            	}
    	        	}
    	        	socket.setReceiveBufferSize(TamSocket);
    	            socket.setSendBufferSize(TamSocket);
    	            PrintWriter out = new PrintWriter(new BufferedWriter(new OutputStreamWriter(socket.getOutputStream())),true);
    	            out.println(valor);
    	        } catch (Exception ex) {
    	        	Mensaje(ex.getMessage());
    	        }
    	    }
    
    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.test, menu);
        return true;
    }
    
}
