using System.ComponentModel.DataAnnotations;

namespace CieeProjectWebApp.Models
{
    public class CuidadoViewModel
    {
        [System.ComponentModel.DataAnnotations.Display(Name = "Id")]
        public int id_cuidado { get; set; }

        [System.ComponentModel.DataAnnotations.Display(Name = "Descrição")]
        [Required(ErrorMessage = "O valor nao pode estar em branco")]
        [DataType(DataType.Text, ErrorMessage = "O campo descrição está vazio")]
        public string descricao_cuidado { get; set; }

        [System.ComponentModel.DataAnnotations.Display(Name = "Frequência")]
        [Required(ErrorMessage = "O valor nao pode estar em branco")]
        [DataType(DataType.Text, ErrorMessage = "O campo frequência está vazio")]
        public string frequencia_cuidado { get; set; }

        [System.ComponentModel.DataAnnotations.Display(Name = "Id animal")]
        [Required(ErrorMessage = "O valor nao pode estar em branco")]
        [DataType(DataType.Text, ErrorMessage = "O campo id animal está vazio")]
        public int id_animal_cuidado { get; set; }

        public CuidadoViewModel()
        {
            id_cuidado = 0;
        }
    }
}
