using Aplicacao.Interfaces;
using Dominio.Entidades;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ContatoController : ApiController
    {
        private readonly IContatoAppServico _contatoAppServico;
        
        public ContatoController(IContatoAppServico contatoAppServico)
        {
            _contatoAppServico = contatoAppServico;
        }

        public IHttpActionResult Post([FromBody]Contato contato)
        {
            try
            {
                _contatoAppServico.CadastrarContato(contato);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        public IHttpActionResult Get()
        {
            try
            {
                return Ok(_contatoAppServico.ObterTudo().Where(c => c.Ativo));
            }
            catch
            {
                return BadRequest();
            }
        }

        public IHttpActionResult Get(int idContato)
        {
            try
            {
                return Ok(_contatoAppServico.ObterContato(idContato));
            }
            catch
            {
                return BadRequest();
            }
        }

        public IHttpActionResult Put([FromBody]Contato contato)
        {
            try
            {
                _contatoAppServico.AtualizarContato(contato);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        public IHttpActionResult Delete(int idContato)
        {
            try
            {
                _contatoAppServico.ExcluirContato(idContato);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
