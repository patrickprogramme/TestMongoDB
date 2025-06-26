using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestMongoDB
{
    public partial class FormChocolatin : Form
    {
        private MongoClient client = new MongoClient("mongodb://127.0.0.1:27017");
        private IMongoDatabase db;
        private IMongoCollection<Produit> collection;
        private List<Produit> lesProduits = new List<Produit>();

        public FormChocolatin()
        {
            InitializeComponent();
        }

        private void FormChocolatin_Load(object sender, EventArgs e)
        {
            db = client.GetDatabase("chocolatein");
            collection = db.GetCollection<Produit>("produits");
            remplirListbox();
        }
        public void remplirListbox()
        {
            lesProduits = collection.AsQueryable().ToList<Produit>();
            listBoxProduits.Items.Clear();
            foreach (var produit in lesProduits)
            {
                listBoxProduits.Items.Add(produit);
            }
        }

        private void buttonAjouter_Click(object sender, EventArgs e)
        {
            Produit produit = new Produit("rocher_gourmand", "Rocher gourmand", "Rocher en chocolat avec éclats de caramel", "boite de 4", "", "chocolats", 0);
            collection.InsertOne(produit);
            remplirListbox();
        }

        private void buttonSupprimer_Click(object sender, EventArgs e)
        {
            collection.DeleteMany(p => p.id == "rocher_gourmand");
            remplirListbox();
        }

        private void buttonModifier_Click(object sender, EventArgs e)
        {
            //"Mets la propriété gamme à "produits_de_saison"
            UpdateDefinition<Produit> update = Builders<Produit>.Update.Set(p => p.gamme, "produits_de_saison");
            //Met à jour en masse tous les produits rares pour les passer dans la gamme "produits de saison"
            collection.UpdateMany(p => p.gamme == "produits_rares", update);
            remplirListbox();
        }
    }
}
