using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DataModel;


namespace DataModelTest
{
    [TestFixture]
    class BrojiloTest
    {
        [Test]
        [TestCase(1,"Marko","Markovic","Danila Kisa",11,21000,"Novi Sad")]
        public void BrojiloKonsturktorDobriParametri(int iD, string imeKorisnika, string prezimeKorisnika, string ulica, int broj, int postanskiBroj, string grad)
        {
            Brojilo b = new Brojilo(iD, imeKorisnika, prezimeKorisnika, ulica, broj, postanskiBroj, grad);
            Assert.AreEqual(iD, b.ID);
            Assert.AreEqual(imeKorisnika,b.ImeKorisnika);
            Assert.AreEqual(prezimeKorisnika, b.PrezimeKorisnika);
            Assert.AreEqual(ulica, b.Ulica);
            Assert.AreEqual(broj, b.Broj);
            Assert.AreEqual(postanskiBroj,b.PostanskiBroj);
            Assert.AreEqual(grad, b.Grad);
        }

        [Test]
        [TestCase(1, "Marko", "Markovic", "Danila Kisa", 11, 38999, "Novi Sad")]
        [TestCase(100, "Dejan", "Dejanovic", "Kisacka", 15, 10001, "Novi Sad")]
        public void BrojiloKonsturktorGranicniParametri(int iD, string imeKorisnika, string prezimeKorisnika, string ulica, int broj, int postanskiBroj, string grad)
        {
            Brojilo b = new Brojilo(iD, imeKorisnika, prezimeKorisnika, ulica, broj, postanskiBroj, grad);
            Assert.AreEqual(iD, b.ID);
            Assert.AreEqual(imeKorisnika, b.ImeKorisnika);
            Assert.AreEqual(prezimeKorisnika, b.PrezimeKorisnika);
            Assert.AreEqual(ulica, b.Ulica);
            Assert.AreEqual(broj, b.Broj);
            Assert.AreEqual(postanskiBroj, b.PostanskiBroj);
            Assert.AreEqual(grad, b.Grad);
        }

        [Test]
        [TestCase(1, "", "Markovic", "Danila Kisa", 11, 21000, "Novi Sad")]     // Prazno ime
        [TestCase(1, "Marko", "", "Danila Kisa", 11, 21000, "Novi Sad")]        // Prazno prezime
        [TestCase(1, "Marko", "Markovic", "", 11, 21000, "Novi Sad")]           // Prazna ulica
        [TestCase(1, "Marko", "Markovic", "Danila Kisa", 11, 21000, "")]        // Prazan grad
        [TestCase(-1, "Marko", "Markovic", "Danila Kisa", 11, 21000, "Novi Sad")]   // Los ID
        [TestCase(1, "Marko", "Markovic", "Danila Kisa", -100, 21000, "Novi Sad")]  // Los broj ulice
        public void BrojiloKonsturktorLosiParametri(int iD, string imeKorisnika, string prezimeKorisnika, string ulica, int broj, int postanskiBroj, string grad)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Brojilo b = new Brojilo(iD, imeKorisnika, prezimeKorisnika, ulica, broj, postanskiBroj, grad);
            });
        }

        [Test]
        [TestCase(1, null, "Markovic", "Danila Kisa", 11, 21000, "Novi Sad")]       // Ime null
        [TestCase(1, "Marko", null, "Danila Kisa", 11, 21000, "Novi Sad")]          // Prezime null
        [TestCase(1, "Marko", "Markovic", null, 11, 21000, "Novi Sad")]             // Ulica null
        [TestCase(1, "Marko", "Markovic", "Danila Kisa", 11, 21000, null)]          // Grad null
        public void BrojiloKonsturktorLosiParametriNull(int iD, string imeKorisnika, string prezimeKorisnika, string ulica, int broj, int postanskiBroj, string grad)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Brojilo b = new Brojilo(iD, imeKorisnika, prezimeKorisnika, ulica, broj, postanskiBroj, grad);
            });
        }
        [Test]
        [TestCase(1, "Marko", "Markovic", "Danila Kisa", 11, 1, "Novi Sad")]        // Postanski broj van opsega
        [TestCase(1, "Marko", "Markovic", "Danila Kisa", 11, 4000000, "Novi Sad")]  // Postanski broj van opsega
        public void BrojiloKonsturktorLosiParametriRange(int iD, string imeKorisnika, string prezimeKorisnika, string ulica, int broj, int postanskiBroj, string grad)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Brojilo b = new Brojilo(iD, imeKorisnika, prezimeKorisnika, ulica, broj, postanskiBroj, grad);
            });
        }
    }
}
