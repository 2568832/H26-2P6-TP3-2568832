using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Interfaces
{
    using System;

    namespace Models.Interfaces
    {
        public interface IReponseAvecIndice
        {
            string Indice { get; set; }
            bool IndiceUtilise { get; set; }
            double PenaliteIndice { get; set; }

            void UtiliserIndice();
        }
    }
}
