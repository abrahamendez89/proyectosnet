package com.zucarmex.cuentasxcobrar.rest;

import java.util.HashSet;
import java.util.Set;

import javax.ws.rs.ApplicationPath;
import javax.ws.rs.core.Application;



@ApplicationPath("/rest")
public class RestApplicationActivator extends Application {
	
	private Set<Object> singletons = new HashSet<Object>();

	public RestApplicationActivator() {
		//singletons.add(new CoCuentasContablesResource());
		//singletons.add(new Prue)
	}
	
	@Override
	public Set<Object> getSingletons() {
		return singletons;
	}

}