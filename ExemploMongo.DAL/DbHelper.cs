using ExemploMongoDB.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ExemploMongoDB.DAL
{
    public static class DbHelper
    {

        public static string ConexaoMongoDB
        {
            get
            {
                return @"mongodb://mongo";
            }
        }
        public static string DatabaseMongoDB
        {
            get
            {
                return "ExemploMongoDB";
            }
        }
        private static MongoClient MongoClient
        {
            get
            {
                return new MongoClient(ConexaoMongoDB);
            }
        }

        private static IMongoDatabase MongoDatabase
        {
            get
            {
                return MongoClient.GetDatabase(DatabaseMongoDB);
            }
        }
        public static void Incluir<T>(T ObjetoDal)
        {
            var collection = MongoDatabase.GetCollection<T>(ObjetoDal.GetType().Name.ToString());
            collection.InsertOne(ObjetoDal);
        }

        public static IList<T> ObterCollection<T>(string NomeObjeto)
        {
            var collection = MongoDatabase.GetCollection<T>(NomeObjeto).AsQueryable<T>().ToList();
            return collection;
        }
        public static IList<T> ObterDocument<T>(string NomeObjeto)
        {
            var collection = MongoDatabase.GetCollection<T>(NomeObjeto).AsQueryable<T>().ToList();
            return collection;
        }
        public static T ObterDocument<T>(string NomeObjeto, string _id)
        {
            var filter = Builders<T>.Filter.Eq("_id", _id);
            return MongoDatabase.GetCollection<T>(NomeObjeto).Find(filter).FirstOrDefault();
        }

        public static void UpdateCollection<T>(T ObjetoDal, string id)
        {
            var collection = MongoDatabase.GetCollection<T>(ObjetoDal.GetType().Name.ToString());
            var filter = Builders<T>.Filter.Eq("_id", id);
            collection.ReplaceOne(filter, ObjetoDal);
        }
        public static void DeleteCollection<T>(string NomeObjeto, string id)
        {
            var collection = MongoDatabase.GetCollection<T>(NomeObjeto);
            var filter = Builders<T>.Filter.Eq("_id", id);
            collection.DeleteOne(filter);
        }

        static BsonDocument CriaBsonDocument(object ObjetoDal)
        {
            var bsonDocument = new BsonDocument();
            var type = ObjetoDal.GetType();
            var props = type.GetProperties();
            foreach (var prop in props)
            {
                bsonDocument.Add(prop.Name, prop.GetValue(ObjetoDal).ToString());
            }
            return bsonDocument;
        }


    }
}
