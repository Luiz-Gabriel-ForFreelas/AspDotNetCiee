using CieeProjectData.DAO;
using CieeProjectData.DTO;
using CieeProjectWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CieeProjectWebApp.Controllers
{
    public class AnimalController : Controller
    {
        AnimalDao animalDao;
        Animal animalDto;

        [HttpGet]
        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(AnimalViewModel animalVM)
        {
            animalDao = new AnimalDao();
            animalDto = new Animal();

            animalDto.id_animal = animalVM.id_animal;
            animalDto.nome_animal = animalVM.nome_animal;
            animalDto.descricao_animal = animalVM.descricao_animal;
            animalDto.especie_animal = animalVM.especie_animal;
            animalDto.habitat_animal = animalVM.habitat_animal;
            animalDto.pais_origem_animal = animalVM.pais_origem_animal;

            animalDao.IncludeAnimal(animalDto);

            return RedirectToAction("ListAnimal", "Animal");
        }

        [HttpGet]
        public IActionResult ListAnimal()
        {
            animalDao = new AnimalDao();
            animalDto = new Animal();

            List<AnimalViewModel> listAnimal = new List<AnimalViewModel>();
            List<Animal> listAnimalDto = new List<Animal>();

            listAnimalDto = animalDao.ListAnimal();

            foreach (Animal animal in listAnimalDto)
            {
                AnimalViewModel animalVM = new AnimalViewModel();
                animalVM.id_animal = animal.id_animal;
                animalVM.nome_animal = animal.nome_animal;
                animalVM.descricao_animal = animal.descricao_animal;
                animalVM.especie_animal = animal.especie_animal;
                animalVM.habitat_animal = animal.habitat_animal;
                animalVM.pais_origem_animal = animal.pais_origem_animal;

                listAnimal.Add(animalVM);
            }

            return View(listAnimal);
        }

        [HttpGet]
        public IActionResult EditAnimal(int id_animal)
        {
            animalDao = new AnimalDao();
            animalDto = new Animal();

            animalDto = animalDao.GetAnimal(id_animal);

            AnimalViewModel animalVM = new AnimalViewModel();
            animalVM.id_animal = animalDto.id_animal;
            animalVM.nome_animal = animalDto.nome_animal;
            animalVM.descricao_animal = animalDto.descricao_animal;
            animalVM.especie_animal = animalDto.especie_animal;
            animalVM.habitat_animal = animalDto.habitat_animal;
            animalVM.pais_origem_animal = animalDto.pais_origem_animal;

            return View(animalVM);
        }

        public IActionResult EditAnimal(AnimalViewModel animalVM)
        {
            animalDao = new AnimalDao();
            animalDto = new Animal();

            animalDto.id_animal = animalVM.id_animal;
            animalDto.nome_animal = animalVM.nome_animal;
            animalDto.descricao_animal = animalVM.descricao_animal;
            animalDto.especie_animal = animalVM.especie_animal;
            animalDto.habitat_animal = animalVM.habitat_animal;
            animalDto.pais_origem_animal = animalVM.pais_origem_animal;

            animalDao.AlterAnimal(animalDto);

            return RedirectToAction("ListAnimal", "Animal");
        }

        public IActionResult DeleteAnimal(int id_animal)
        {
            animalDao = new AnimalDao();
            animalDao.DeleteAnimal(id_animal);
            return RedirectToAction("ListAnimal", "Animal");
        }
    }
}
