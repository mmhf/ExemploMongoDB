using System;
using System.Collections.Generic;
using System.Text;

namespace ExemploMongoDB.Model.NetStandart
{
    public interface IUsuarioDados
    {
        void Incluir(Usuario usuario);
        void Alterar(Usuario usuario);
        List<Usuario> ObterTodos();
    }
}
