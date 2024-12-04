using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAlib.Services
{
    public class APIResponseError
    {
        public short ERROR_CODE { get; set; } = 0;
        public string? ERROR_MESSAGE { get; set; } = "";
    }
}
