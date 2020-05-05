using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MvcCustomerManager.Repositories;
using MvcCustomerManager.Models;

namespace MvcCustomerManager.Controllers
{
    public abstract class GeneralController<TEntity, TRepository> : Controller
        where TEntity : class
        where TRepository : IGeneralRepository<TEntity>
    {
        private readonly TRepository repository;

        public GeneralController(TRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TEntity>>> Index()
        {
            return View(await repository.GetAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult<TEntity>> Create(TEntity t)
        {
            if (ModelState.IsValid)
            {
                await repository.Add(t);
                return RedirectToAction(nameof(Create));
            }
            return View(t);
        }

        [HttpGet]
        public async Task<ActionResult<TEntity>> Edit(int id)
        {
            var t = await repository.Get(id);
            if (t == null)
            {
                return NotFound();
            }
            return View(t);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(int id, TEntity t)
        {
            await repository.Update(t);
            return View(t);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var t = await repository.Get(id);
            if (t == null)
            {
                return NotFound();
            }

            return View(t);
        }

        [HttpPost]
        public async Task<ActionResult<TEntity>> DeleteConfirm(int id)
        {
            var t = await repository.Delete(id);
            if (t == null)
            {
                return NotFound();
            }
            return RedirectToAction(nameof(Index));
        }

    }
}