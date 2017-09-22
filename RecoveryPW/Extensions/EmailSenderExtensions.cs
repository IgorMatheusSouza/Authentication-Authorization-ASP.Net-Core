using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using RecoveryPW.Services;

namespace RecoveryPW.Services
{
    public static class EmailSenderExtensions
    {
        public static Task SendEmailConfirmationAsync(this IEmailSender emailSender, string email, string link)
        {
            return emailSender.SendEmailAsync(email, "Comfirme seu E-mail para logar na ASC",
                $"Por favor confime seu e-mail clicando no link a seguir para permitir seu acesso no site ASC : <a href='{HtmlEncoder.Default.Encode(link)}'>Clique aqui.</a>" +
                $"<br/><br><img  src='http://ascsolutions.com.br/wp-content/themes/ascsolutions/imagens/global/logo.gif'><h2>Igor Matheus de Souza</h2><h3>Estagiário em engenharia de software</h3>");
        }
    }
}
