using ExemploMongoDB.DAL;
using ExemploMongoDB.Models;
using System;
using System.Collections.Generic;

namespace ExemploMongoDB.BLL
{
    public class UsuarioBLL : IUsuarioDados
    {
        private UsuarioDAL dal;
        public UsuarioBLL(UsuarioDAL dalInstance)
        {
            this.dal = dalInstance;
        }

        public void Alterar(Usuario usuario)
        {
            this.dal.Alterar(usuario);
        }      

        public void Excluir(string id)
        {
            this.dal.Excluir(id);
        }

        public void Incluir(Usuario usuario)
        {
            this.dal.Incluir(usuario);
        }

        public IList<Usuario> ObterTodos()
        {
            return this.dal.ObterTodos();
        }

        public Usuario ObterUsuario(string id)
        {
            return this.dal.ObterUsuario(id);
        }
    }
}
