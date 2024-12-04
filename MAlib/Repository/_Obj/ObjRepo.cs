using MAlib.Entity.Models._Obj;
using MAServer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAlib.Repository._Obj
{
    public class ObjRepo
    {
        MAContext _db;
        public ObjRepo(MAContext db)
        {
            _db = db;
        }
        public Task<List<ObjEsp>> GetObjEsp()
        {
            return Task.FromResult(new List<ObjEsp>
            {
                new ObjEsp { Name="A", ObjGeralId=1 },
                new ObjEsp { Name="B", ObjGeralId=1 }
            });
        }
        public Task<List<ObjGeral>> GetObjGeral()
        {
            return Task.FromResult(new List<ObjGeral>
            {
                     new ObjGeral { Name="A1", Id=1 }
             });
        }
    }
}
