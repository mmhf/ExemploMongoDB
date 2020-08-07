using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExemploMongoDB.DAL.NetStandart
{
    public static class DbHelper
    {

        public static void Incluir(object ObjetoDal)
        {
            var client = new MongoClient(@"mongodb://mongo");
            var x = client.ListDatabaseNames();
            var database = client.GetDatabase("ExemploMongoDB");
            var collection = database.GetCollection<BsonDocument>("Usuario");
            //database.CreateCollection("Usuario");
            if (collection == null)
            {
                database.CreateCollection("Usuario");
            }
            else
            {
                collection.InsertOne(CriaBsonDocument(ObjetoDal));
            }
        }

        public static IMongoCollection<BsonDocument> ObterUsuarios()
        {
            var client = new MongoClient(@"mongodb://localhost:27017");
            var database = client.GetDatabase("ExemploMongoDB");
            var usuarios = database.GetCollection<BsonDocument>("Usuario");
            return usuarios;
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

        public static string conexao
        {
            get
            {
                return @"mongodb://localhost:27017";
            }
        }
    }
}

/*
 "ConnectionString": "mongodb://localhost:27017",
  "Database": "LocationsDb",
*/
