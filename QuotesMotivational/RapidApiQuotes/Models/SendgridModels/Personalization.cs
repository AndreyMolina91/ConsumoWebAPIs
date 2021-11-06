using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RapidApiQuotes.Models.SendgridModels
{
    public class Personalization
    {
        public IList<To> to { get; set; }
        public string subject { get; set; }
    }
}
