using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blue.Api.ViewModels
{
    public class ContatoForPatch
    {
        public Guid Id  { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Fone { get; set; }
    }
}
