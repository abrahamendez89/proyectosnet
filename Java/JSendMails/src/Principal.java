import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.text.SimpleDateFormat;
import java.util.Date;

public class Principal {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		System.out.println(getFechaCompletaString()+": Inicializando configuracion de correo");
		Mail jm = new Mail();
		jm.InicializaValores("plataformacorcega@gmail.com", "Qwer1234!", "Plataforma Stanza Corcega");
		System.out.println(getFechaCompletaString()+": Conectando con base de datos");
		MysqlConnect mysqlConnect = new MysqlConnect();

		try {
			while (true) {

				Thread.sleep(5000L);

				Connection conn = mysqlConnect.connect();

				PreparedStatement statement = conn
						.prepareStatement("SELECT * FROM plat_corcega.mail_correos where seEnvio = 0");
				System.out.println(getFechaCompletaString()+": Consultando correos pendientes por enviar...");
				ResultSet rs = statement.executeQuery();

				if (!rs.last()) {
					System.out.println(getFechaCompletaString()+": Sin correos para enviar.");
					continue;
				}
				System.out.println(getFechaCompletaString()+": Hay correos para enviar.");
				
				rs.beforeFirst();

				System.out.println(getFechaCompletaString()+": Creando sesion de gmail...");
				jm.CrearSesion();
				System.out.println(getFechaCompletaString()+": Sesión de Gmail creada.");
				while (rs.next()) {
					System.out.println(getFechaCompletaString()+": Enviando correo...");
					if (jm.EnviarMensaje(rs.getString("email_destino"), rs.getString("titulo_correo"),
							rs.getString("contenido_correo"))) {
						System.out.println(getFechaCompletaString()+": Correo enviado exitosamente.");
						System.out.println(getFechaCompletaString()+": Actualizando estado de correo en base de datos...");

						

						PreparedStatement updCorreo = conn
								.prepareStatement("update mail_correos set seEnvio = 1, fecha_enviado = '" + getFechaCompletaString()
										+ "' where id_correo = " + rs.getInt("id_correo"));
						if (updCorreo.executeUpdate() == 1) {
							System.out.println(getFechaCompletaString()+": Correo actualizado correctamente.");
						}

					}
				}
			}
		} catch (SQLException e) {
			e.printStackTrace();
		} catch (InterruptedException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		} finally {
			mysqlConnect.disconnect();
		}

	}
	
	public static String getFechaCompletaString() {
		SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
		Date now = new Date();
		String strDate = sdf.format(now);
		return strDate;
	}

}
