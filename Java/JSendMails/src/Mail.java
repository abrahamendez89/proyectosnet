
import java.util.Date;
import java.util.Properties;

import javax.mail.Message;
import javax.mail.MessagingException;
import javax.mail.PasswordAuthentication;
import javax.mail.Session;
import javax.mail.Transport;
import javax.mail.internet.InternetAddress;
import javax.mail.internet.MimeMessage;

public class Mail {
	String username;
	String password;
	String nombrePublico;
	Properties props;
	Session session;
	String mensajeError;

	public void InicializaValores(String email, String password, String nombrePublico) {
		username = email;
		this.password = password;
		this.nombrePublico = nombrePublico;

		props = new Properties();
		props.put("mail.smtp.starttls.enable", "true");
		props.put("mail.smtp.auth", "true");
		props.put("mail.smtp.host", "smtp.gmail.com");
		props.put("mail.smtp.port", "587");
	}

	public void CrearSesion() {
		session = Session.getInstance(props, new javax.mail.Authenticator() {
			protected PasswordAuthentication getPasswordAuthentication() {
				return new PasswordAuthentication(username, password);
			}
		});
	}

	public Boolean EnviarMensaje(String para, String titulo, String contenido) {

		try {

			Message message = new MimeMessage(session);
			message.setFrom(new InternetAddress(this.username));
			message.setRecipients(Message.RecipientType.TO, InternetAddress.parse(para));
			message.setSubject(titulo);
			message.setContent(contenido, "text/html; charset=utf-8");
			message.setSentDate(new Date());
			Transport.send(message);
			return true;

		} catch (MessagingException e) {
			System.out.println(e.getMessage());
			this.mensajeError = e.getMessage();
			return false;
		}
	}
	
	public String getMensajeError() {
		String mensajeError = this.mensajeError;
		this.mensajeError = "";
		return mensajeError;
	}

}
