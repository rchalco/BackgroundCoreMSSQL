
//using Business.Main.DataMapping;
//using Business.Main.ModuloSample;
using Business.Main.DataMapping;
using Business.Main.Modules;
using Domain.Main.Wraper;
using NUnit.Framework;

namespace NUnitBusinessMain
{
    public class PersonManagerMySQLTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void InsertUserTest()
        {
            UsuarioManager usuarioManager = new UsuarioManager();
            User user = new User { IdUser = 0, Nick = "Ruben4444", Password = "132" };
            var resul = usuarioManager.SaveUser(user);
            Assert.AreEqual(resul.State, ResponseType.Success);
        }


        [Test]
        public void ModifyUserTest()
        {
            UsuarioManager usuarioManager = new UsuarioManager();
            User user = new User { IdUser = 1, Nick = "Ruben2", Password = "4444" };
            var resul = usuarioManager.SaveUser(user);
            Assert.AreEqual(resul.State, ResponseType.Success);
        }

        [Test]
        public void BuscarSimpleUser()
        {
            string user = "ruben";
            UsuarioManager usuarioManager = new UsuarioManager();
            var resul = usuarioManager.BuscarUsuario(user);
            Assert.AreEqual(resul.State, ResponseType.Success);
        }

        [Test]
        public void BuscarSimpleUserSP()
        {
            string user = "ruben";
            UsuarioManager usuarioManager = new UsuarioManager();
            var resul = usuarioManager.BuscarUsuario(user);
            Assert.AreEqual(resul.State, ResponseType.Success);
        }


        [Test]
        public void ModificarUserBySP()
        {
            string user = "JoJOJOrge falco";
            UsuarioManager usuarioManager = new UsuarioManager();
            var resul = usuarioManager.ModificarNick(1, user);
            Assert.AreEqual(resul.State, ResponseType.Success);
        }
    }
}