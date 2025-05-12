using CieeProjectData.DAO;
using CieeProjectData.DTO;
using CieeProjectWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CieeProjectWebApp.Controllers
{
    public class CuidadoController : Controller
    {
        CuidadoDao cuidadoDao;
        Cuidado cuidadoDto;

        [HttpGet]
        public IActionResult Cuidado(int? id_animal_cuidado)
        {
            var cuidadoVM = new CuidadoViewModel();

            if (id_animal_cuidado.HasValue)
            {
                cuidadoVM.id_animal_cuidado = id_animal_cuidado.Value;
                return View(cuidadoVM);
            }

            return View();
        }

        [HttpPost]
        public IActionResult Cuidado(CuidadoViewModel cuidadoVM)
        {
            cuidadoDao = new CuidadoDao();
            cuidadoDto = new Cuidado();

            cuidadoDto.id_cuidado = cuidadoVM.id_cuidado;
            cuidadoDto.descricao_cuidado = cuidadoVM.descricao_cuidado;
            cuidadoDto.frequencia_cuidado = cuidadoVM.frequencia_cuidado;
            cuidadoDto.id_animal_cuidado = cuidadoVM.id_animal_cuidado;

            cuidadoDao.IncludeCuidado(cuidadoDto);
            return RedirectToAction("ListCuidado", "Cuidado");
        }

        [HttpGet]
        public IActionResult ListCuidado()
        {
            cuidadoDao = new CuidadoDao();
            cuidadoDto = new Cuidado();

            List<CuidadoViewModel> listCuidado = new List<CuidadoViewModel>();
            List<Cuidado> listCuidadoDto = new List<Cuidado>();

            listCuidadoDto = cuidadoDao.ListCuidado();

            foreach (Cuidado cuidado in listCuidadoDto)
            {
                CuidadoViewModel cuidadoVM = new CuidadoViewModel();
                cuidadoVM.id_cuidado = cuidado.id_cuidado;
                cuidadoVM.descricao_cuidado = cuidado.descricao_cuidado;
                cuidadoVM.frequencia_cuidado = cuidado.frequencia_cuidado;
                cuidadoVM.id_animal_cuidado = cuidado.id_animal_cuidado;

                listCuidado.Add(cuidadoVM);
            }

            return View(listCuidado);
        }

        [HttpGet]
        public IActionResult ListAnimalCuidado(int id_animal_cuidado)
        {
            cuidadoDao = new CuidadoDao();
            cuidadoDto = new Cuidado();

            List<CuidadoViewModel> listCuidado = new List<CuidadoViewModel>();
            List<Cuidado> listCuidadoDto = new List<Cuidado>();

            listCuidadoDto = cuidadoDao.ListAnimalCuidado(id_animal_cuidado);

            foreach (Cuidado cuidado in listCuidadoDto)
            {
                CuidadoViewModel cuidadoVM = new CuidadoViewModel();
                cuidadoVM.id_cuidado = cuidado.id_cuidado;
                cuidadoVM.descricao_cuidado = cuidado.descricao_cuidado;
                cuidadoVM.frequencia_cuidado = cuidado.frequencia_cuidado;
                cuidadoVM.id_animal_cuidado = cuidado.id_animal_cuidado;

                listCuidado.Add(cuidadoVM);
            }

            return View(listCuidado);
        }

        [HttpGet]
        public IActionResult EditCuidado(int id_cuidado)
        {
            cuidadoDao = new CuidadoDao();
            cuidadoDto = new Cuidado();

            cuidadoDto = cuidadoDao.GetCuidado(id_cuidado);

            CuidadoViewModel cuidadoVM = new CuidadoViewModel();
            cuidadoVM.id_cuidado = cuidadoDto.id_cuidado;
            cuidadoVM.descricao_cuidado = cuidadoDto.descricao_cuidado;
            cuidadoVM.frequencia_cuidado = cuidadoDto.frequencia_cuidado;
            cuidadoVM.id_animal_cuidado = cuidadoDto.id_animal_cuidado;

            return View(cuidadoVM);
        }

        public IActionResult EditCuidado(CuidadoViewModel cuidadoVM)
        {
            cuidadoDao = new CuidadoDao();
            cuidadoDto = new Cuidado();

            cuidadoDto.id_cuidado = cuidadoVM.id_cuidado;
            cuidadoDto.descricao_cuidado = cuidadoVM.descricao_cuidado;
            cuidadoDto.frequencia_cuidado = cuidadoVM.frequencia_cuidado;
            cuidadoDto.id_animal_cuidado = cuidadoVM.id_animal_cuidado;

            cuidadoDao.AlterCuidado(cuidadoDto);

            return RedirectToAction("ListAnimalCuidado", "Cuidado", new { id_animal_cuidado = cuidadoVM.id_animal_cuidado });
        }

        public IActionResult DeleteCuidado(int id_cuidado)
        {
            cuidadoDao = new CuidadoDao();
            cuidadoDao.DeleteCuidado(id_cuidado);
            return RedirectToAction("ListCuidado", "Cuidado");
        }
    }
}
