using System.Net;
using System.Net.Mail;
using Test_Santiagorestrepoarismendy.Models;

namespace Test_Santiagorestrepoarismendy.Services
{
    public class EmailService
    {
        private readonly string _from = "tu_correo@gmail.com";
        private readonly string _password = "tu_contraseña_o_token";

        public bool SendAppointmentConfirmation(Patient patient, Appointment appointment)
        {
            try
            {
                var mail = new MailMessage();
                mail.From = new MailAddress(_from);
                mail.To.Add(patient.Email);
                mail.Subject = "Appointment Confirmation";
                mail.Body = $@"
Hello {patient.Name},

Your appointment has been scheduled successfully.

🗓 Date: {appointment.Date.ToShortDateString()}
🕐 Time: {appointment.Hour}
👨‍⚕️ Doctor: {appointment.Doctor?.Name} {appointment.Doctor?.LastName}
📍 Status: {appointment.State}

Thank you for choosing our clinic.";

                var smtp = new SmtpClient("smtp.gmail.com", 587)
                {
                    Credentials = new NetworkCredential(_from, _password),
                    EnableSsl = true
                };

                smtp.Send(mail);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}