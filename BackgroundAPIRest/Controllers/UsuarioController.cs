using Business.Main.DataMapping;
using Business.Main.Modules;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using domain = Domain.Main.Wraper;

namespace BackgroundAPIRest.Controllers
{
    [Route("api/Usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpGet]
        public string Index()
        {
            return "Servicio de usuarios disponible";
        }

        [HttpPost("InsertUserTest")]
        public domain.Response InsertUserTest(User user)
        {
            UsuarioManager usuarioManager = new UsuarioManager();
            return usuarioManager.SaveUser(user);
        }

        [HttpPost("ModifyUserTest")]
        public domain.Response ModifyUserTest(User user)
        {
            UsuarioManager usuarioManager = new UsuarioManager();
            return usuarioManager.SaveUser(user);
        }

        public class ReqBuscarSimpleUser
        {
            public string user { get; set; }
        }

        [HttpPost("BuscarSimpleUser")]
        public domain.ResponseQuery<User> BuscarSimpleUser(ReqBuscarSimpleUser reqBuscarSimpleUser)
        {
            UsuarioManager usuarioManager = new UsuarioManager();
            return usuarioManager.BuscarUsuario(reqBuscarSimpleUser.user);
        }

        [HttpPost("BuscarSimpleUserSP")]
        public domain.ResponseQuery<User> BuscarSimpleUserSP(ReqBuscarSimpleUser reqBuscarSimpleUser)
        {
            UsuarioManager usuarioManager = new UsuarioManager();
            return usuarioManager.BuscarUsuario(reqBuscarSimpleUser.user);
        }

        [HttpPost("ModificarUserBySP")]
        public domain.Response ModificarUserBySP(ReqBuscarSimpleUser reqBuscarSimpleUser)
        {
            UsuarioManager usuarioManager = new UsuarioManager();
            return usuarioManager.ModificarNick(1, reqBuscarSimpleUser.user);
        }

    }
}
