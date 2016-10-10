using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Experto1._0
{
    class ReglaClonNum
    {
            public ReglaClonNum(int IdReglax, List<int> ReglaX, int Conclusionx)
            {
                this.IdRegla = IdReglax;
                this.Reglax = ReglaX;
                this.Conclusion = Conclusionx;
            }
            public int IdRegla { get; set; }
            public List<int> Reglax { get; set; }
            public int Conclusion { get; set; }
    }
}
