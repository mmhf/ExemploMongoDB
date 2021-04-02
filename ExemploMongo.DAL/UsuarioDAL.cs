using ExemploMongoDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExemploMongoDB.DAL
{
    public class UsuarioDAL : IUsuarioDados
    {
        private readonly IDbHelper _dbHelper;

        public UsuarioDAL(IDbHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public void Alterar(Usuario usuario)
        {
            _dbHelper.UpdateCollection(usuario, usuario.Id);
        }

        public void Excluir(string id)
        {
            _dbHelper.DeleteCollection<Usuario>("Usuario", id);
        }

        public void Incluir(Usuario usuario)
        {
            _dbHelper.Incluir(usuario);
        }

        public IList<Usuario> ObterTodos() => _dbHelper.ObterCollection<Usuario>("Usuario");

        public Usuario ObterUsuario(string id)
        {
            return _dbHelper.ObterDocument<Usuario>("Usuario").Where(x => x.Id.Equals(id)).FirstOrDefault();
        }
    }
}
