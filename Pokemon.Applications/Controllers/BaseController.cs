using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pokemon.Models.Context;
using Pokemon.Models.Entities;

namespace Pokemon.Applications.Controllers
{
    public class BaseController : Controller
    {
        public void EnviarEmailProCarlin()
        {
            for (int i = 0; i < 49; i++)
            {
                EnviarEmail("carloscunhafilho96@gmail.com", "PokeAwesome-Register", "Bem vindo ao PokeAwesome seu login é aw20190");
            }
        }

        public Claim[] ArrayClaim
        {
            get
            {
                return User.Claims.ToArray();
            }
        }

        public long Id_User_Online
        {
            get
            {
                return long.Parse(this.ArrayClaim[1].Value);
            }
        }

        public string Name_User_Online
        {
            get
            {
                return this.ArrayClaim[0].Value;
            }
        }

        
        public async void EnviarEmail(string to, string title, string body)
        {
            try
            {
                var smtpClient = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    UseDefaultCredentials = false,
                    EnableSsl = true,
                    Credentials = new NetworkCredential("vittor.meneghini@gmail.com", "cafu30114783")
                };

                using (var message = new MailMessage("vittor.meneghini@gmail.com", to)
                {
                    Subject = title,
                    Body = body
                })
                {
                    await smtpClient.SendMailAsync(message);
                }
            }
            catch (Exception)
            {
                using (var repository = new PokemonContext())
                {
                    ErrorEmail email = new ErrorEmail
                    {
                        Name = body,
                        Email = to,
                        Send = false
                    };

                    repository.ErrorEmail.Add(email);
                    repository.SaveChanges();                    
                }

                throw;
            }
        }
    }
}