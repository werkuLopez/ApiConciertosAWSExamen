using ApiConciertosAWSExamen.Models;
using ApiConciertosAWSExamen.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiConciertosAWSExamen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConciertosController : ControllerBase
    {
        private ConciertosRepository repo;

        public ConciertosController(ConciertosRepository repo)
        {
            this.repo = repo;
        }


        [HttpGet]
        public async Task<ActionResult<List<Evento>>> Get()
        {
            return await this.repo.GetEventosAsync();
        }

        [HttpGet("{idcategoria}")]
        public async Task<ActionResult<List<Evento>>> Find(int idcategoria)
        {
            return await this.repo.GetEventosByCategoryAsync(idcategoria);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<List<Categoria>>> Categorias()
        {
            return await this.repo.GetCategoriasAsync();
        }
    }
}
