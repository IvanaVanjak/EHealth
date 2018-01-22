using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EHealth.ViewModels
{
    public class DiseaseGroupViewModel
    {
        public int Id { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
        public string Name { get; set; }
        public bool IsCheked { get; set; }
    }
}
