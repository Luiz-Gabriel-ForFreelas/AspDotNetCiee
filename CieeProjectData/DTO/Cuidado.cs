using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CieeProjectData.DTO
{
    public class Cuidado
    {
        public int id_cuidado { get; set; }
        public string descricao_cuidado { get; set; }
        public string frequencia_cuidado { get; set; }
        public int id_animal_cuidado { get; set; }

    
    }
}
