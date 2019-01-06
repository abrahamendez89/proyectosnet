import static spark.Spark.before;
import static spark.Spark.get;
import static spark.Spark.options;
import static spark.Spark.port;
import static spark.Spark.post;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;

public class HelloWorld {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		port(4000); // Spark will run on port 8080
		//configuracion de cors
		options("/*",
		        (request, response) -> {

		            String accessControlRequestHeaders = request
		                    .headers("Access-Control-Request-Headers");
		            if (accessControlRequestHeaders != null) {
		                response.header("Access-Control-Allow-Headers",
		                        accessControlRequestHeaders);
		            }

		            String accessControlRequestMethod = request
		                    .headers("Access-Control-Request-Method");
		            if (accessControlRequestMethod != null) {
		                response.header("Access-Control-Allow-Methods",
		                        accessControlRequestMethod);
		            }

		            return "OK";
		        });

		before((request, response) -> response.header("Access-Control-Allow-Origin", "*"));
		
		
		//apis
		
		get("/hello", (req, res) -> {
			System.out.println("Hola mundo!");	
			res.type("application/json");
		    return "{\"message\":\"Custom 500 handling\"}";
		});
		
		get("/hello/:name", (req, res) -> {
			res.type("application/json");
		    return "{\"hello\":\""+req.params(":name")+"\"}";
		});
		
		post("/login", (req, res) -> {
	       
			System.out.println(req.body());
			String yourObjectStr = req.body();
			   
		     //Convert the JSON string to a POJO obj
		     Gson gson = new GsonBuilder().create();
		     Paquete pojoObj = gson.fromJson(yourObjectStr , Paquete.class);

			System.out.println(pojoObj.getParam1());
			
			ResponsePaquete rp = new ResponsePaquete();
			rp.setRespuesta(pojoObj.getParam1());
			rp.setResultado(200);
			
			
			
	        return gson.toJson(rp);
	    });
		
	}
	
	

}

class Paquete{
	private String param1;

	public String getParam1() {
		return param1;
	}

	public void setParam1(String param1) {
		this.param1 = param1;
	}

}
class ResponsePaquete{
	private String Respuesta;
	private int Resultado;
	public ResponsePaquete() {}
	public String getRespuesta() {
		return Respuesta;
	}
	public void setRespuesta(String respuesta) {
		Respuesta = respuesta;
	}
	public int getResultado() {
		return Resultado;
	}
	public void setResultado(int resultado) {
		Resultado = resultado;
	}
}
