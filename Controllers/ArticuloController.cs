using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiCRUD.Context;
using ApiCRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;

namespace ApiCRUD.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArticuloController : ControllerBase
    {
        private readonly DbArticuloContext _context;
        private readonly ILogger<DbArticuloContext> _logger;
        public ArticuloController(DbArticuloContext context, ILogger<DbArticuloContext> logger)
        {
            this._context = context;
            this._logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult> ObtenerArticulos()
        {
            try
            {
                var articulos = await _context.Articulos.ToListAsync();
                return Ok(articulos);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}", Name = "ObtenerArticulo")]
        public async Task<ActionResult> ObtenerArticulo(int id)
        {
            try
            {
                var articulo = await _context.Articulos.Where(x => x.id == id).FirstOrDefaultAsync<Articulo>();
                if (articulo == null)
                {
                    return BadRequest("El articulo a buscar no existe");
                }
                return Ok(articulo);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> registrarArticulo([FromBody] Articulo articulo)
        {
            try
            {
                var addArticulo = await _context.Articulos.AddAsync(articulo);
                var saveChanges = await _context.SaveChangesAsync();
                return CreatedAtRoute("ObtenerArticulo", new { id = articulo.id }, articulo);

            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> actualizarArticulo(int id, [FromBody] Articulo articulo)
        {
            try
            {
                if (id != articulo.id)
                {
                    return BadRequest("El identificador no coincide");
                }

                _context.Articulos.Update(articulo);
                await _context.SaveChangesAsync();
                return CreatedAtRoute("ObtenerArticulo", new { id = articulo.id }, articulo);

            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> eliminarArticulo(int id)
        {
            try
            {

                var articulo = await _context.Articulos.FirstOrDefaultAsync(x => x.id == id);
                if (articulo == null)
                {
                    return BadRequest("El articulo a eliminar no existe");
                }
                _context.Articulos.Remove(articulo);
                await _context.SaveChangesAsync();
                return Ok(articulo);

            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}