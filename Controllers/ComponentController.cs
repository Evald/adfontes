using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Adfontes.Models;
using Adfontes.Models.ViewModels;
using Adfontes.Models.Repositories;

namespace Adfontes.Controllers
{
    [Route("api/[controller]")]
    public class ComponentController : Controller
    {
        private ComponentRepository _repo;

        public ComponentController(ComponentRepository repo){
            this._repo = repo;
        }

        // GET: /api/Component/
        // the id represents the id of the parent note
        [HttpGet("Parent/{parentId}")]
        public async Task<IEnumerable<Component>> Components(int parentId)
        {
            var Components = await _repo.GetAllByParentId(parentId);
            return Components;
        }

        // GET: /api/Component/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetComponentById(int id){
            var Component = await _repo.GetById(id);
            if (Component == null)
            {
                //Produces 404 not found response.
                return NotFound();
            }
            return Json(Component);
        }

        // POST: /api/Component
        [HttpPost]
        public async Task<IActionResult> CreateComponent([FromBody]Component component)
        {
            var Component = await _repo.Add(component);
            if (Component == null)
            {
                //Produces 404 not found response.
                return NotFound();
            }
            return Json(Component);
        }

        // PUT: /api/Component
        [HttpPatch]
        public async Task<IActionResult> UpdateComponent([FromBody]Component component)
        {
            var Component = await _repo.Edit(component);
            if (Component == null)
            {   
                //Produces 404 not found response.
                return NotFound();
            }
            return Json(Component);
            
        }

        // DELETE: /api/Component/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveComponent(int id)
        {             
            var Component = await _repo.Remove(id);
            if (Component == null)
            {
                //Produces 404 not found response.
                return NotFound();
            }
            return Json(Component);
            
        }
    }
}
