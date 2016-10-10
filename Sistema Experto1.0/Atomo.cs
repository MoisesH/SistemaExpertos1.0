using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Experto1._0
{
    public class Atomo
    {
        //Constructor     
        public Atomo(int idX, string atomoX)
        {
            this.IdAtomo = idX;
            this.Atomox = atomoX;
        }
        //Propiedades
        public int IdAtomo { get; set; }
        public string Atomox { get; set; }
    }
}
