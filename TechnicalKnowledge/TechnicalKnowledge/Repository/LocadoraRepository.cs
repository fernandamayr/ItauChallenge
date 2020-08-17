using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Web;
using TechnicalKnowledge.Models;

namespace TechnicalKnowledge.Repository
{
    public class LocadoraRepository
    {
        TechnicalKnowledgeDBEntities db = new TechnicalKnowledgeDBEntities();

        public void CadastraClientes(TechnicalKnowledge.Models.Clientes clientes) 
        {
            try
            {
                Clientes cli = new Clientes()
                {
                    nome_cliente = clientes.nome_cliente,
                    data_nascimento = clientes.data_nascimento,
                };
                db.Clientes.Add(cli);
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void AlugarFilme(TechnicalKnowledge.Models.Locacao locacao)
        {
            try
            {
                Locacao loc = new Locacao()
                {
                    data_locacao = locacao.data_locacao,

                    id_filme = locacao.id_filme,
                    estimativa_devolucao = locacao.estimativa_devolucao,
                    id_cliente = locacao.id_cliente,
                    devolucao = locacao.devolucao,
                    observacao = locacao.observacao,
                };
                db.Locacao.Add(loc);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Disponibilidade(string nome_filme)
        {
            try
            {
                var result = (TechnicalKnowledge.Models.Locacao)(from c in db.Filme
                              join t in db.Locacao
                              on c.id_filme equals t.id_filme
                              where c.nome_filme == nome_filme
                              select new TechnicalKnowledge.Models.Locacao { id_cliente = (int)t.id_cliente, id_filme = c.id_filme, devolucao = t.devolucao }
                          ).FirstOrDefault();

                if (result != null)
                {
                    if (result.devolucao == null)
                    {
                        throw new System.ArgumentException("O Filme não está disponível", "Retry");
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TechnicalKnowledge.Models.Locacao> Listagem()
        {
            try
            {
                IQueryable listagem = db.Locacao.OrderBy(a => a.devolucao);

                List<TechnicalKnowledge.Models.Locacao> result = new List<Models.Locacao>();

                foreach (Locacao item in listagem)
                {
                    var novoItem = new Models.Locacao();
                    novoItem.id_cliente = (int)item.id_cliente;
                    novoItem.id_filme = (int)item.id_filme;
                    novoItem.data_locacao = item.data_locacao;
                    novoItem.devolucao = item.devolucao;
                    novoItem.observacao = item.observacao;
                    result.Add(novoItem);
                }
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void DevolverFilme(TechnicalKnowledge.Models.Locacao locacao)
        {
            try
            {
                var resultBackLocacao = db.Locacao.SingleOrDefault(b => b.id_cliente == locacao.id_cliente && b.id_filme == locacao.id_filme && !b.devolucao.HasValue);

                if(resultBackLocacao == null)
                {
                    throw new System.ArgumentException("Não encontrado Locação estipulada!", "Retry");
                }

                int result = DateTime.Compare((DateTime)resultBackLocacao.estimativa_devolucao, DateTime.Now);

                if (result < 0)
                    locacao.observacao = "Sem Atraso";
                else if (result == 0)
                    locacao.observacao = "Sem Atraso";
                else
                    locacao.observacao = "Cobrar Multa";

                if (resultBackLocacao != null)
                {
                    resultBackLocacao.devolucao = locacao.devolucao;
                    resultBackLocacao.observacao = locacao.observacao;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Models.Locacao BuscarLocacao(TechnicalKnowledge.Models.Clientes clientes)
        {
            try
            {
                var result = (from c in db.Clientes
                              join t in db.Locacao
                              on c.id_cliente equals t.id_cliente
                              where c.nome_cliente == clientes.nome_cliente
                              select new TechnicalKnowledge.Models.Locacao
                              {
                                  id_cliente = (int)t.id_cliente,
                                  id_filme = (int)t.id_filme,
                                  data_locacao = t.data_locacao,
                                  devolucao = t.devolucao,
                                  id_locacao = t.id_locacao
                              }
                          );
                return (Models.Locacao)result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Models.Clientes BuscarClientes(string nome_cliente) {
            try
            {
                var result = (from c in db.Clientes
                                        where c.nome_cliente == nome_cliente
                                        select new Models.Clientes() { id_cliente = c.id_cliente }).FirstOrDefault();

                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public Models.Filme BuscarFilmes(string nome_filme)
        {
            try
            {
                var result = (from c in db.Filme
                             where c.nome_filme == nome_filme
                             select new Models.Filme() { id_filme = c.id_filme }).FirstOrDefault();

                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
