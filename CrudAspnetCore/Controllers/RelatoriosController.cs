using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudAspnetCore.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CrudAspnetCore.Controllers
{
    public class RelatoriosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RelatoriosController(ApplicationDbContext context)
        {
            this._context = context;
        }

        public IActionResult Index()
        {
            ViewBag.empresa = new SelectList(_context.Empresas, "Id", "NomeFantasia");

            ViewBag.funcionarios = null;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult>Index(int? id)
        {
            if(id == null){
                return NotFound();
            }

            var func = await _context.Funcionarios.Where(x => x.EmpresaId == id).ToListAsync();
            ViewBag.empresa = new SelectList(_context.Empresas, "Id", "NomeFantasia");

            ViewBag.funcionarios = func;

            return View();
        }
    }
}