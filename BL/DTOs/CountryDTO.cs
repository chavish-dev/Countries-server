using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTOs
{
    public class CountryDTO
    {
        public string Name { get; set; }
        public string Flag { get; set; }
        public string Capital { get; set; }
        public string Region { get; set; }
        public List<CurrencyDTO> Currencies { get; set; }

    }

    public class CurrencyDTO
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
    }
}
