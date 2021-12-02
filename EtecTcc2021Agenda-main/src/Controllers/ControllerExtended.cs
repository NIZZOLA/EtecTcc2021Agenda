using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCC.Agenda.Controllers
{
    public class ControllerExtended : Controller
    {
        public void CriaViewBags(string metodo, string nomeController)
        {
            ViewBag.NomeController = nomeController;
            switch (metodo)
            {
                case "Index":
                    ViewBag.Acao = "Listagem";
                    break;
                case "Create":
                    ViewBag.Acao = "Inclusão";
                    break;
                case "Edit":
                    ViewBag.Acao = "Alteração";
                    break;
                case "Delete":
                    ViewBag.Acao = "Exclusão";
                    break;
                case "Details":
                    ViewBag.Acao = "Consulta";
                    break;
                default:
                    break;
            }
        }
    }
}
