using System.Collections.Generic;
using ExemploMongoDB.Models;

namespace ExemploMongoDB.DAL
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
