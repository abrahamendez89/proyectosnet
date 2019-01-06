package com.coppel.rest;

import javax.ws.rs.GET;
import javax.ws.rs.Path;

@Path("/prueba")
public class PruebaResource {
	
	@Path("/hola")
	@GET
	public String hola() {
		return "hola !";
	}

}
