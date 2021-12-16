using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace facturator_api.Models
{
    public class Bill
    {
        int Id { get; set; }
        DateTime Date { get; set; }
        float Total { get; set; }
        Boolean IsValid { get; set; }

        public Bill(int id, DateTime date, float total, bool isValid)
        {
            Id = id;
            Date = date;
            Total = total;
            IsValid = isValid;
        }
    }
}
