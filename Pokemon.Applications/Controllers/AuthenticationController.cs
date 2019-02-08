using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Pokemon.Applications.ViewModels;
using Pokemon.Models.Entities;
using Pokemon.Repository.Repositories;

namespace Pokemon.Applications.Controllers
{
    public class AuthenticationController : BaseController
    {
        [HttpGet]
        public IActionResult Login()
        {
            if(User.Identity.IsAuthenticated)
            {
                return Redirect("/Home");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            try
            {
                if (model.Password == null || model.Name == null)
                {
                    if (model.Password == null)
                        ModelState.AddModelError("Password", "Necessário Informar uma Senha");

                    if (model.Name == null)
                        ModelState.AddModelError("Name", "Necessário informar um Usúario");

                    return View(model);
                }

                SHA1 sha = new SHA1CryptoServiceProvider();

                byte[] temp = sha.ComputeHash(Encoding.UTF8.GetBytes(model.Password));

                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < temp.Length; i++)
                {
                    sb.Append(temp[i].ToString("x2"));
                }

                string hash = sb.ToString();

                Account account = new AccountRepository().FindAccount(model.Name, hash);

                if (account != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, account.NickName),
                        new Claim(ClaimTypes.Hash, $"{account.Id}"),
                    };

                    var userIdentity = new ClaimsIdentity(claims, "login");

                    ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);

                    await HttpContext.SignInAsync(principal);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("Password", "Usúario não encontrado!");
                    return View(model);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public IActionResult Register()
        {
            if (User.Identity.IsAuthenticated)
            {
                return Redirect("/Home");
            }

            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterAccountViewModel register)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (!register.TermCondition)
                    {
                        ModelState.AddModelError("TermCondition", "Necessário concordar com os termos.");
                        return View(register);
                    }

                    if (register.Password != register.ConfirmPassword)
                    {
                        ModelState.AddModelError("Password", "Os campos de senha e confirmação de senha não conferem.");
                        return View(register);
                    }

                    using (var accountRepository = new AccountRepository())
                    {                        
                        Account existAccount = accountRepository.FindByParameter(p => p.NickName == register.NickName || p.Email == register.Email);

                        if(existAccount != null)
                        {
                            if(existAccount.Email == register.Email)
                                ModelState.AddModelError("Email", "Já possuí um usúario cadastrado com o mesmo e-mail");

                            if (existAccount.NickName == register.NickName)
                                ModelState.AddModelError("NickName", "Já possuí um usúario cadastrado com o mesmo apelido");

                            return View(register);
                        }

                                                
                        //Creating new account
                        Account account = new Account();

                        SHA1 sha = new SHA1CryptoServiceProvider();

                        byte[] temp = sha.ComputeHash(Encoding.UTF8.GetBytes(register.Password));

                        StringBuilder sb = new StringBuilder();

                        for (int i = 0; i < temp.Length; i++)
                        {
                            sb.Append(temp[i].ToString("x2"));
                        }

                        string hash = sb.ToString();

                        account.AddAccount(hash, register.Email, register.NickName);

                        accountRepository.Insert(account);

                        accountRepository.SaveAll();

                        //Generate new name automatic
                        account.Name = GenerateName(account.Id);

                        accountRepository.Update(account);

                        accountRepository.SaveAll();

                        EnviarEmail(account.Email, "Pokeawesome - Register", $"Obrigado por se cadastrar, seu login é {account.Name}");

                        ViewBag.Success = true;
                        ViewBag.Account = account.Name;
                        

                        return View(new RegisterAccountViewModel());
                    }                    
                }

                return View(register);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            if (User.Identity.IsAuthenticated)
            {
                await HttpContext.SignOutAsync();
            }

            return Redirect("/Home");
        }

        public string GenerateName(long lastId)
        {
            long number = 2019 * lastId;

            return $"aw{number}";
        }

    }
}