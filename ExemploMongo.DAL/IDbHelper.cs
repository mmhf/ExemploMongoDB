using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ExemploMongoDB.DAL
{
    public interface IDbHelper
    {
        void Incluir<T>(T ObjetoDal);
        IList<T> ObterCollection<T>(string NomeObjeto);
        IList<T> ObterDocument<T>(string NomeObjeto);
        T ObterDocument<T>(string NomeObjeto, string _id);
        T Single<T>(Expression<Func<T, bool>> expression) where T : class, new();
        IQueryable<T> All<T>() where T : class, new();
        IQueryable<T> Where<T>(Expression<Func<T, bool>> expression) where T : class, new();
        void UpdateCollection<T>(T ObjetoDal, string id);
        void DeleteCollection<T>(string NomeObjeto, string id);
    }
}
