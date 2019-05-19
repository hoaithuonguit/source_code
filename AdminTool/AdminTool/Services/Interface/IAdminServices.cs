using AdminTool.Models.DtoModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminTool.Services.Interface
{
   public interface IAdminServices
   {
        List<UserModel> GetListUser();

   }
}
