using System;
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
    public class FuncionariosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FuncionariosController(ApplicationDbContext context){
            this._context = context;
        }

        public async Task<IActionResult> Index(){
            return View(await _context.Funcionarios.ToListAsync());
        }

        public IActionResult Create(){
            ViewBag.empresa = new SelectList(_context.Empresas, "Id", "NomeFantasia");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Funcionario funcionario){
            if (ModelState.IsValid){
                _context.Add(funcionario);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
           
            return View(funcionario);
        }

        public async Task<IActionResult> Editar(int? id){
            if (id == null){
                return NotFound();
            }

            var funcionario = await _context.Funcionarios.Include("Endereco").Include("Empresa").FirstOrDefaultAsync(x => x.Id == id);

            if(funcionario == null){
                return NotFound();
            }
            ViewBag.empresa = new SelectList(_context.Empresas, "Id", "NomeFantasia");

            return View(funcionario);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Funcionario funcionario){
            if (ModelState.IsValid){
                _context.Update(funcionario);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(funcionario);
        }

        public async Task<IActionResult> Detalhe(int? id){
            if(id == null){
               return NotFound();
            }

            var funcionario = await _context.Funcionarios.Include("Empresa").Include("Endereco").FirstOrDefaultAsync(x => x.Id == id);

            if(funcionario == null){
                return NotFound();
            }

            return View(funcionario);
        }

        public async Task<IActionResult> Deletar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionario = await _context.Funcionarios.Include("Endereco").Include("Empresa").FirstOrDefaultAsync(m => m.Id == id);

            if (funcionario == null)
            {
                return NotFound();
            }

            return View(funcionario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Deletar(int id)
        {
            var funcionario = await _context.Funcionarios.FindAsync(id);
            _context.Funcionarios.Remove(funcionario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}