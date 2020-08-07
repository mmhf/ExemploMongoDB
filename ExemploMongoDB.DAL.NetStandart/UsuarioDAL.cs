
using ExemploMongoDB.Model.NetStandart;
using System;
using System.Collections.Generic;

namespace ExemploMongoDB.DAL.NetStandart
{
    public class UsuarioDAL : IUsuarioDados
    {
        public void Alterar(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public void Incluir(Usuario usuario)
        {
            DbHelper.Incluir(usuario);
        }

        public List<Usuario> ObterTodos()
        {
            throw new NotImplementedException();
        }
    }
}
