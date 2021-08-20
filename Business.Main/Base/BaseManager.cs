//using Business.Main.DataMapping;
using Business.Main.DataMapping;
using CoreAccesLayer.Interface;
using Domain.Main.Wraper;
using PlumbingProps.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Main.Base
{
    public abstract class BaseManager
    {
        internal IRepository repository { get; set; } = null;
        public BaseManager()
        {
            //repository = FactoryDataInterfaz.CreateRepository<ibnorca_mokContext>("mysql");
            repository = FactoryDataInterfaz.CreateRepository<bdSampleContext>("sqlserver");
        }

        public string ProcessError(Exception ex)
        {
            ManagerException managerException = new ManagerException();
            return managerException.ProcessException(ex);
        }

        public string ProcessError(Exception ex, Response response)
        {
            repository?.Rollback();
            ManagerException managerException = new ManagerException();
            response.State = ResponseType.Error;
            response.Message = managerException.ProcessException(ex);
            return managerException.ProcessException(ex);
        }
    }

}
