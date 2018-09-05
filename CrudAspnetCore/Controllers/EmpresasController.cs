using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudAspnetCore.Data;
using CrudAspnetCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CrudAspnetCore.Controllers
{
    public class EmpresasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmpresasController(ApplicationDbContext context){
            this._context = context;
        }
        public async Task<IActionResult> Index(){
            return View(await _context.Empresas.ToListAsync());
        }

        public IActionResult Create(){
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Empresa empresas){

            if (ModelState.IsValid){
                _context.Add(empresas);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(empresas);
        }

        public async Task<IActionResult> Detalhe(int? id){
            if(id == null){
                return NotFound();
            }

            var empresa = await _context.Empresas.Include("Endereco").FirstOrDefaultAsync(m => m.Id == id);

            if (empresa == null){
                return NotFound();
            }

            return View(empresa);
        }

        public async Task<IActionResult> Editar(int? id){
            if(id == null){
                return NotFound();
            }

            var empresa = await _context.Empresas.Include("Endereco").FirstOrDefaultAsync(m => m.Id == id);

            if (empresa == null){
                return NotFound();
            }

            return View(empresa);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(Empresa empresa)
        {
            if (ModelState.IsValid)
            {
                _context.Update(empresa);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(empresa);
        }

        public async Task<IActionResult> Deletar(int? id)
        {
            if (id == null){
                return NotFound();
            }

            var empresa = await _context.Empresas.Include("Endereco").FirstOrDefaultAsync(m => m.Id == id);

            if (empresa == null){
                return NotFound();
            }

            return View(empresa);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Deletar(int id)
        {
            var empresa = await _context.Empresas.FindAsync(id);
            _context.Empresas.Remove(empresa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

       /*
        public ActionResult GetEmpresa(string q)
        {
            var empresa = new SelectList(_context.Empresas, "Id", "NomeFantasia");

            if (!(string.IsNullOrEmpty(q) || string.IsNullOrWhiteSpace(q)))
            {
                empresa = empresa.Where(x => x.NomeFantasia.ToLower().StartsWith(q.ToLower())).ToList();
            }

            return Json(new { items = empresa }, JsonRequestBehavior.AllowGet);
    
        }*/
    }
}