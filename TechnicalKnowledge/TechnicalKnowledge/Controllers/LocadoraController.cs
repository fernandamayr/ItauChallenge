using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Http.Controllers;
using TechnicalKnowledge.Business;
using TechnicalKnowledge.Models;

namespace TechnicalKnowledge.Controllers
{
    [RoutePrefix("api/locadora")]
    public class LocadoraController : ApiController
    {
        [Route("lista")]
        public List<TechnicalKnowledge.Models.Locacao> Get()
        {
            LocadoraBusiness locadoraBusiness = new LocadoraBusiness();
            return locadoraBusiness.Listagem();
        }

        [Route("cadastrarlocador")]
        public Models.Clientes CadastrarLocador([FromBody] TechnicalKnowledge.Models.Clientes clientes)
        {
            LocadoraBusiness locadoraBusiness = new LocadoraBusiness();
            return locadoraBusiness.CadastrarLocador(clientes);
        }

        [Route("locarfilme")]
        public Models.Locacao LocarFilme([FromBody] TechnicalKnowledge.Models.Locacao locacao)
        {
            LocadoraBusiness locadoraBusiness = new LocadoraBusiness();
            return locadoraBusiness.LocarFilme(locacao.nome_cliente, locacao.nome_filme, locacao.observacao);
        }

        [Route("devolverfilme")]
        public Models.Locacao DevolverFilme([FromBody] TechnicalKnowledge.Models.Locacao locacao)
        {
            LocadoraBusiness locadoraBusiness = new LocadoraBusiness();
            return locadoraBusiness.DevolverFilme(locacao.nome_cliente, locacao.nome_filme, locacao.observacao);
        }

        public void Delete(int v)
        {
            throw new NotImplementedException();
        }

        public void Put(int v1, string v2)
        {
            throw new NotImplementedException();
        }

        public void Post(string v)
        {
            throw new NotImplementedException();
        }
    }
}
