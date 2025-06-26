using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMongoDB
{
    internal class Produit
    {
        public ObjectId Id { get; set; }
        public string id { get; set; }
        public string nom { get; set; }
        public string description { get; set; }
        public string packaging { get; set; }
        public string urlimg { get; set; }
        public string gamme { get; set; }
        public int stock { get; set; }

        public Produit(string id, string nom, string description, string packaging, string urlimg, string gamme, int stock)
        {
            this.id = id;
            this.nom = nom;
            this.description = description;
            this.packaging = packaging;
            this.urlimg = urlimg;
            this.gamme = gamme;
            this.stock = stock;
        }
        public override string ToString()
        {
            return $"{this.nom} ({this.packaging}) {this.gamme}";
        }
    }
}
