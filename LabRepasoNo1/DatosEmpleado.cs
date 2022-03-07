using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabRepasoNo1
{
    internal class DatosEmpleado
    {
        public int id { get; set; }
        public string name { get; set; }
        public int sueldo { get; set; }
        public int h_work { get; set; }
        public string mont { get; set; }

        public float totalSueldo { get; set; }
        public DatosEmpleado(int v1, string v2, int v3)
        {
            this.id = v1;
            this.name = v2;
            this.sueldo = v3;
        }
    }
}
