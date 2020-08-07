using System;
using System.Collections.Generic;
using System.Text;

namespace ExemploMongoDB.Models
{
    public interface IUsuarioDados
    {
        void Incluir(Usuario usuario);
        void Alterar(Usuario usuario);
        void Excluir(string id);
        IList<Usuario> ObterTodos();
        Usuario ObterUsuario(string id);

    }
}
