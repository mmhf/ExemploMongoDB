using ExemploMongoDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExemploMongoDB.DAL
{
    public class UsuarioDAL : IUsuarioDados
    {
        public void Alterar(Usuario usuario)
        {
            DbHelper.UpdateCollection<Usuario>(usuario, usuario.Id);
        }

        public void Excluir(string id)
        {
            DbHelper.DeleteCollection<Usuario>("Usuario", id);
        }

        public void Incluir(Usuario usuario)
        {
            DbHelper.Incluir(usuario);
        }

        public IList<Usuario> ObterTodos() => DbHelper.ObterCollection<Usuario>("Usuario");

        public Usuario ObterUsuario(string id)
        {
            return DbHelper.ObterDocument<Usuario>("Usuario").Where(x => x.Id.Equals(id)).FirstOrDefault();
        }
    }
}
