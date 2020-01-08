using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ConsuTiWebApp.Models;

namespace ConsuTiWebApp.Controllers
{
    public class GadosController : Controller
    {
        GadosModel model = new GadosModel();
        // GET: Gados
        [AsyncTimeout(1000)]
        public async Task Index()
        {
            

            List = await model.GetGados();
           


            return View(model);
        }


        // GET: Contacts/Details/5
        public async Task Details(int id)
        {
            Gados c = await model.GetGadosByID(id);

            return View(c);
        }
    }

    
}