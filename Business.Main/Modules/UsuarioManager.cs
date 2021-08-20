using Business.Main.Base;
using Business.Main.DataMapping;
using CoreAccesLayer.Wraper;
using Domain.Main.Wraper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Main.Modules
{
    public class UsuarioManager : BaseManager
    {
        public Response SaveUser(User user)
        {
            Response response = new Response { State = ResponseType.Success, Message = "Usuario guardado correctamente" };
            try
            {
                Entity<User> entity = new Entity<User> { EntityDB = user };
                entity.stateEntity = user.IdUser > 0 ? StateEntity.modify : StateEntity.add;
                repository.SaveObject<User>(entity);
                repository.Commit();
            }
            catch (Exception ex)
            {
                ProcessError(ex, response);
            }
            return response;
        }

        public ResponseQuery<User> BuscarUsuario(string nameUser)
        {
            ResponseQuery<User> response = new ResponseQuery<User> { State = ResponseType.Success, Message = "Consulta ejecutada correctamente" };
            try
            {
                response.ListEntities = repository.SimpleSelect<User>(x => x.Nick.StartsWith(nameUser));
            }
            catch (Exception ex)
            {
                ProcessError(ex, response);
            }
            return response;
        }

        public ResponseQuery<User> BuscarUsuarioBySP(string nameUser)
        {
            ResponseQuery<User> response = new ResponseQuery<User> { State = ResponseType.Success, Message = "Consulta ejecutada correctamente" };
            try
            {
                response.ListEntities = repository.GetDataByProcedure<User>("GetUserSearch", nameUser);
            }
            catch (Exception ex)
            {
                ProcessError(ex, response);
            }
            return response;
        }

        public Response ModificarNick(int id, string nameUser)
        {
            Response response = new Response { State = ResponseType.Success, Message = "Consulta ejecutada correctamente" };
            try
            {
                repository.CallProcedure("udpdateNick", id, nameUser);
                repository.Commit();
            }
            catch (Exception ex)
            {
                ProcessError(ex, response);
            }
            return response;
        }
    }
}
