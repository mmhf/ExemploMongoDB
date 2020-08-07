﻿using System;

namespace ExemploMongoDB.Models
{
    public class Usuario
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime? DataCriacao { get; set; }        
        public DateTime? DataAtualizacao { get; set; }

    }
}
