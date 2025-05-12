using System.ComponentModel.DataAnnotations;

namespace CieeProjectWebApp.Models
{
    public class AnimalViewModel
    {
        [System.ComponentModel.DataAnnotations.Display(Name = "Id")]
        public int id_animal { get; set; }

        [System.ComponentModel.DataAnnotations.Display(Name = "Nome")]
        [Required(ErrorMessage = "O valor nao pode estar em branco")]
        [DataType(DataType.Text, ErrorMessage = "O campo valor está vazio")]
        public string nome_animal { get; set; }

        [System.ComponentModel.DataAnnotations.Display(Name = "Descrição")]
        [Required(ErrorMessage = "O valor não pode estar em branco")]
        [DataType(DataType.Text, ErrorMessage = "O campo descrição está vazio")]
        public string descricao_animal { get; set; }

        [System.ComponentModel.DataAnnotations.Display(Name = "Espécie")]
        [Required(ErrorMessage = "O valor nao pode estar em branco")]
        [DataType(DataType.Text, ErrorMessage = "O campo espécie está vazio")]
        public string especie_animal { get; set; }

        [System.ComponentModel.DataAnnotations.Display(Name = "Habitat")]
        [Required(ErrorMessage = "O valor nao pode estar em branco")]
        [DataType(DataType.Text, ErrorMessage = "O campo habitat está vazio")]
        public string habitat_animal { get; set; }

        [System.ComponentModel.DataAnnotations.Display(Name = "País de origem")]
        [Required(ErrorMessage ="O valor nao pode estar em branco")]
        [DataType(DataType.Text, ErrorMessage = "O campo país de origem está vazio")]
        public string pais_origem_animal { get; set; }

        public AnimalViewModel()
        {
            id_animal = 0;
        }
    }
}
