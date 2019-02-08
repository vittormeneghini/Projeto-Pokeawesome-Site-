using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pokemon.Applications.ViewModels;
using Pokemon.Models.Entities;
using Pokemon.Repository.Repositories;

namespace Pokemon.Applications.Controllers
{
    [Authorize]
    public class AccountController : BaseController
    {
        public IActionResult Index()
        {            
            try
            {
                AccountViewModel accountViewModel = new AccountViewModel(Id_User_Online);

                return View(accountViewModel);
            }
            catch (Exception)
            {
                throw;
            }                       
        }

        [HttpPost]
        public IActionResult Index(AccountViewModel account)
        {
            return View(account);
        }


        [HttpPost]
        public JsonResult RegisterPlayer(PlayerViewModel player)
        {
            try
            {
                using (var repository = new PlayerRepository())
                {
                    var tryPlayer = repository.FindByParameter(p => p.Name.ToLower().Equals(player.Name.ToLower()));

                    if (tryPlayer != null)
                        return Json(new { data = false, response = "Já existe um personagem com o nome informado!" });

                    var allPlayer = repository.ListByParameter(p => p.Account_Id == Id_User_Online);

                    if (allPlayer.Count() > 20)
                        return Json(new { data = false, response = "Sua conta possuí mais de 20 personagens!" });

                    Player newPlayer = new Player();

                    long sex = player.Gender.Equals("Treinador") ? 1 : 0;

                    newPlayer.AddPlayer(player.Name, Id_User_Online, sex);

                    repository.Insert(newPlayer);
                    repository.SaveAll();


                    newPlayer.Posx = 3019;
                    repository.SaveAll();


                    newPlayer.Posy = 2146;
                    repository.SaveAll();

                    newPlayer.Posz = 13;
                    repository.SaveAll();

                    repository.AdicionarItemPlayer(newPlayer.Id);
                }

                return Json(new { data = true, response = "Seu personagem foi criado com sucesso!" });
            }
            catch (Exception ex)
            {
                throw;
            }            
        }


        public JsonResult AlterPassword(AlterPasswordViewModel password)
        {
            if(password.AlterarSenha(Id_User_Online))
            {
                return Json(new { data = true, response = "Sua senha foi alterada com sucesso!" });
            }
            else
            {
                return Json(new { data = true, response = "O campo senha antiga está incorreto!" });
            }            
        }

        public JsonResult DeletePlayer(long id)
        {
            try
            {
                using (var repository = new PlayerRepository())
                {
                    var player = repository.FindById(id);

                    player.Deleted = true;

                    repository.SaveAll();

                    return Json(new { data = true, response = $"O personagem {player.Name} foi deletado com sucesso!" });
                }
            }
            catch (Exception)
            {
                throw;
            }            
        }



        public IActionResult AddPlayer()
        {
            PlayerViewModel playerViewModel = new PlayerViewModel();

            return PartialView("_AddPlayer", playerViewModel);
        }

        public IActionResult AddAlterPassword()
        {
            return PartialView("_AlterPassword");
        }

        
    }
}