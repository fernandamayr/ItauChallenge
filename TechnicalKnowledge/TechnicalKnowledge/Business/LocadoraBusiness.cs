using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechnicalKnowledge.Models;
using TechnicalKnowledge.Repository;

namespace TechnicalKnowledge.Business
{
    public class LocadoraBusiness
    {
        public Models.Clientes CadastrarLocador(Models.Clientes clientes)
        {
            Models.Clientes returnObject = new Models.Clientes();
            try
            {
                LocadoraRepository locadoraRepository = new LocadoraRepository();
                locadoraRepository.CadastraClientes(clientes);
                returnObject.status = "Sucesso!";
                return returnObject;
            }
            catch (Exception ex)
            {
                returnObject.erro = new Erro() { descricaoErro = ex.Message.ToString(), codErro = ex.HResult };
                return returnObject;
            }
        }

        public Models.Locacao LocarFilme(string nome_cliente, string nome_filme, string observacao)
        {
            Models.Locacao returnObject = new Models.Locacao();
            try
            {
                LocadoraRepository locadoraRepository = new LocadoraRepository();

                var filmes = locadoraRepository.BuscarFilmes(nome_filme);
                if (filmes == null)
                {
                    returnObject.erro = new Erro() { descricaoErro = "Filme não localizado! Por favor, tente novamente" };
                    return returnObject;
                }
                var clientes = locadoraRepository.BuscarClientes(nome_cliente);
                if (clientes == null)
                {
                    returnObject.erro = new Erro() { descricaoErro = "Cliente não localizado! Por favor, tente novamente" };
                    return returnObject;
                }

                locadoraRepository.Disponibilidade(nome_filme);

                locadoraRepository.AlugarFilme(new Models.Locacao()
                {
                    id_cliente = clientes.id_cliente,
                    id_filme = filmes.id_filme,
                    data_locacao = DateTime.Now,
                    estimativa_devolucao = (DateTime.Now.AddDays(3)),
                    observacao = observacao,
                });
            }
            catch (Exception ex)
            {
                returnObject.erro = new Erro() { descricaoErro = ex.Message.ToString(), codErro = ex.HResult };
                return returnObject;
            }
            returnObject.status = "Sucesso!";
            return returnObject;
        }

        public Models.Locacao DevolverFilme(string nome_cliente, string nome_filme, string observacao)
        {
            LocadoraRepository locadoraRepository = new LocadoraRepository();
            Models.Locacao returnObject = new Models.Locacao();
            try
            {
                var filmes = locadoraRepository.BuscarFilmes(nome_filme);
                if (filmes == null)
                {
                    returnObject.erro = new Erro() { descricaoErro = "Filme não localizado! Por favor, tente novamente" };
                    return returnObject;
                }
                var clientes = locadoraRepository.BuscarClientes(nome_cliente);
                if (clientes == null)
                {
                    returnObject.erro = new Erro() { descricaoErro = "Cliente não localizado! Por favor, tente novamente" };
                    return returnObject;
                }
                
                locadoraRepository.DevolverFilme(new Models.Locacao() { id_cliente = clientes.id_cliente, id_filme = filmes.id_filme, devolucao = DateTime.Now, 
                    observacao = observacao });
            }
            catch (Exception ex)
            {
                returnObject.erro = new Erro() { descricaoErro = ex.Message.ToString(), codErro = ex.HResult };
                return returnObject;
            }
            returnObject.status = "Sucesso!";
            return returnObject;
        }

        public List<TechnicalKnowledge.Models.Locacao> Listagem()
        {
            List<TechnicalKnowledge.Models.Locacao> returnObject = new List<Models.Locacao>();
            try
            {
                LocadoraRepository locadoraRepository = new LocadoraRepository();
                return locadoraRepository.Listagem();
            }
            catch (Exception ex)
            {
                returnObject.Add(new Models.Locacao() { erro = new Erro() { descricaoErro = ex.Message.ToString(), codErro = ex.HResult }});
                return returnObject;
            }
        }
    }
}
