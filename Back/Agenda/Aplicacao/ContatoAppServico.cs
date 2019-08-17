using System.Collections.Generic;
using System.Linq;
using Aplicacao.Interfaces;
using Dominio.Entidades;
using Dominio.Interfaces.Servicos;

namespace Aplicacao
{
    public class ContatoAppServico : AppServicoBase<Contato>, IContatoAppServico
    {
        private readonly IContatoServico _contatoServico;
        private readonly ITelefoneAppServico _telefoneAppServico;
        private readonly IEmailAppServico _emailAppServico;

        public ContatoAppServico(IContatoServico contatoServico, ITelefoneAppServico telefoneAppServico, IEmailAppServico emailAppServico)
            :base(contatoServico)
        {
            _contatoServico = contatoServico;
            _telefoneAppServico = telefoneAppServico;
            _emailAppServico = emailAppServico;
        }

        public void AtualizarContato(Contato contato)
        {
            Contato contatoAnterior = _contatoServico.ObterPorId(contato.ContatoId);
            contatoAnterior.Emails = _emailAppServico.ObterTudo().Where(e => e.ContatoId == contatoAnterior.ContatoId);
            contatoAnterior.Telefones = _telefoneAppServico.ObterTudo().Where(t => t.ContatoId == contatoAnterior.ContatoId);

            foreach(var email in contato.Emails)
            {
                if(email.EmailId == 0)
                {
                    email.Ativo = true;
                    email.ContatoId = contato.ContatoId;
                    _emailAppServico.Adicionar(email);
                }
                else
                {
                    var emailAtualizar = _emailAppServico.ObterPorId(email.EmailId);
                    emailAtualizar.Ativo = email.Ativo;
                    emailAtualizar.EmailContato = email.EmailContato;
                    _emailAppServico.Atualizar(emailAtualizar);
                }
            }

            foreach (var telefone in contato.Telefones)
            {
                if (telefone.TelefoneId == 0)
                {
                    telefone.Ativo = true;
                    telefone.ContatoId = contato.ContatoId;
                    _telefoneAppServico.Adicionar(telefone);
                }
                else
                {
                    var telefoneAtualizar = _telefoneAppServico.ObterPorId(telefone.TelefoneId);
                    telefoneAtualizar.Ativo = telefone.Ativo;
                    telefoneAtualizar.TelefoneContato = telefone.TelefoneContato;
                    _telefoneAppServico.Atualizar(telefoneAtualizar);
                }
            }

            contatoAnterior.Nome = contato.Nome;
            _contatoServico.Atualizar(contatoAnterior);
        }

        public void CadastrarContato(Contato contato)
        {
            contato.Ativo = true;

            _contatoServico.Adicionar(contato);

            foreach (var email in contato.Emails)
            {
                email.Ativo = true;
                email.ContatoId = contato.ContatoId;
                _emailAppServico.Adicionar(email);
            }

            foreach (var telefone in contato.Telefones)
            {
                telefone.Ativo = true;
                telefone.ContatoId = contato.ContatoId;
                _telefoneAppServico.Adicionar(telefone);
            }
        }

        public void ExcluirContato(int idContato)
        {
            Contato contato = _contatoServico.ObterPorId(idContato);
            contato.Emails = _emailAppServico.ObterTudo().Where(e => e.ContatoId == idContato);
            contato.Telefones = _telefoneAppServico.ObterTudo().Where(t => t.ContatoId == idContato);

            foreach (var email in contato.Emails)
            {
                email.Ativo = false;
                _emailAppServico.Atualizar(email);
            }

            foreach (var telefone in contato.Telefones)
            {
                telefone.Ativo = false;
                _telefoneAppServico.Atualizar(telefone);
            }

            contato.Ativo = false;
            _contatoServico.Atualizar(contato);
        }

        public Contato ObterContato(int idContato)
        {
            Contato contato = _contatoServico.ObterPorId(idContato);
            contato.Telefones = _telefoneAppServico.ObterTudo().Where(t => t.Ativo && t.ContatoId == idContato);
            contato.Emails = _emailAppServico.ObterTudo().Where(e => e.Ativo && e.ContatoId == idContato);

            return contato;
        }
    }
}
