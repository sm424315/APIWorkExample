using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TharstenAPI.Models.Data
{
    public class Currency
    {
        public int? Id { get; set; }
        public string Abbreviation { get; set; }
        public string Symbol { get; set; }
        public string Description { get; set; }
        public decimal? RateToBase { get; set; }
        public int? CurrencyDP { get; set; }
        public int? DocumentDP { get; set; }
        public int? AccCurrencyId { get; set; }
        public string ISOCode { get; set; }
    }
}
