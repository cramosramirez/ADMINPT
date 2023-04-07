using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMINPT.DL.Entidades
{
    public class OpcionBarra
    {
        public string ImageUrl { get; set; }
        public string IconID { get; set; }
        public string AlternateText { get; set; }
        public Boolean CausesValidation { get; set; }
        public string CommandName { get; set; }
        public string AtributoKey { get; set; }
        public string AtributoValue { get; set; }
    }
}
