using ApiConciertosAWSExamen.Models;
using ApiConciertosAWSExamen.Data;
using ApiConciertosAWSExamen.Models;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using static System.Net.Mime.MediaTypeNames;


#region PROCEDURES
//DELIMITER $$
//DROP PROCEDURE IF EXISTS update_personaje$$
//CREATE PROCEDURE update_personaje(IN nombre VARCHAR(255), IN imagen VARCHAR(255), IN idpers INT)
//BEGIN

//update PERSONAJES
//	SET PERSONAJE=nombre, IMAGEN = imagen
//	WHERE IDPERSONAJE = idpers;
//END
//$$
#endregion
namespace ApiConciertosAWSExamen.Repositories
{
    public class ConciertosRepository
    {
        private ConciertosContext context;

        public ConciertosRepository(ConciertosContext context)
        {
            this.context = context;
        }


        public async Task<int> GetMaxIdEvento()
        {
            if (this.context.Eventos.Count() == 0)
            {
                return 1;
            }
            else
            {
                return await this.context.Eventos.MaxAsync(x => x.IdEvento) + 1;
            }
        }

        public async Task<int> GetMaxIdCategoria()
        {
            if (this.context.Categorias.Count() == 0)
            {
                return 1;
            }
            else
            {
                return await this.context.Categorias.MaxAsync(x => x.IdCategoria) + 1;
            }
        }

        public async Task<List<Evento>> GetEventosAsync()
        {
            List<Evento> eventos = await this.context.Eventos.ToListAsync();
            return eventos;
        }

        public async Task<List<Categoria>> GetCategoriasAsync()
        {
            List<Categoria> categorias = await this.context.Categorias.ToListAsync();
            return categorias;
        }

        public async Task<List<Evento>> GetEventosByCategoryAsync(int idcategoria)
        {
            List<Evento> eventosfiltered = await this.context.Eventos.Where(x => x.IdCategoria == idcategoria).ToListAsync();

            return eventosfiltered;
        }
    }
}
