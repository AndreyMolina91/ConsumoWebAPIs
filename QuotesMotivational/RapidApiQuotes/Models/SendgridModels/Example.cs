using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RapidApiQuotes.Models.SendgridModels
{
    public class Example
    {
        public IList<Personalization> personalizations { get; set; }
        public From from { get; set; }
        public IList<Content> content { get; set; }
    }
}
