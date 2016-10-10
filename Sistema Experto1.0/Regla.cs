using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Experto1._0
{
    public class Regla
    {
        //Constructor
        public Regla(int IdReglax, string ReglaX, string NegadosX, string Conclusionx, string Negadox)
        {
            this.IdRegla = IdReglax;
            this.Reglax = ReglaX;
            this.Negados = NegadosX;
            this.Conclusion = Conclusionx;
            this.Negado = Negadox;

        }

        public int IdRegla { get; set; }
        public string Reglax { get; set; }
        public string Negados { get; set; }
        public string Conclusion { get; set; }
        public string Negado { get; set; }


    }

}
