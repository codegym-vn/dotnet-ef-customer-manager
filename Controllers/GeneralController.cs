using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MvcCustomerManager.Services;
using MvcCustomerManager.Models;

namespace MvcCustomerManager.Controllers
{
    public abstract class GeneralController<TEntity, TService> : Controller
        where TEntity : class
        where TService : IGeneralService<TEntity>
    {
        private readonly TService service;

        public GeneralController(TService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TEntity>>> Index()
        {
            return View(await service.GetAll());
        }

        [HttpGet]
        public virtual async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult<TEntity>> Create(TEntity t)
        {
            if (ModelState.IsValid)
            {
                await service.Add(t);
                return RedirectToAction(nameof(Create));
            }
            return View(t);
        }

        [HttpGet]
        public async Task<ActionResult<TEntity>> Edit(int id)
        {
            var t = await service.Get(id);
            if (t == null)
            {
                return NotFound();
            }
            return View(t);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(int id, TEntity t)
        {
            await service.Update(t);
            return View(t);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var t = await service.Get(id);
            if (t == null)
            {
                return NotFound();
            }

            return View(t);
        }

        [HttpPost]
        public async Task<ActionResult<TEntity>> DeleteConfirm(int id)
        {
            var t = await service.Delete(id);
            if (t == null)
            {
                return NotFound();
            }
            return RedirectToAction(nameof(Index));
        }

    }
}