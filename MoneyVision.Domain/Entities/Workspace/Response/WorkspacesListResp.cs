using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyVision.Domain.Entities.Workspace.Response
{
     public class WorkspacesListResp : GenericResp
     {
          public List<Workspace> Workspaces { get; set; }
     }
}
