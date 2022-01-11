using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace facturator_api.Controllers.Bodys
{
    public class BillBody
    {
        public int Id { get; set; }
        public bool IsPayed { get; set; }
        public int ClientId { get; set; }
        public int Vendorid { get; set; }
        public List<int> ArticlesIds { get; set; }
    }
}
