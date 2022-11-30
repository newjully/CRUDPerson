using Microsoft.AspNetCore.Mvc;

using CRUDPerson.Models;
using CRUDPerson.Repository;

namespace CRUDPerson.Controllers
{
    public class PersonController : Controller
    {
        private readonly PersonRepository personRepository;

        public PersonController()
        {
            personRepository = new PersonRepository();
        }

        // ACTION INDEX
        // Anotação de uso do Verb HTTP Get
        [HttpGet]
        public IActionResult Index()
        {
            var list = personRepository.GetAll();

            // Retornando para View a lista de pessoas
            return View(list);
        }

        // ACTION CREATE
        // Anotação de uso do Verb HTTP Get
        [HttpGet]
        public IActionResult Create()
        {
            return View(new Person());
        }

        // Anotação de uso do Verb HTTP Post
        [HttpPost]
        public IActionResult Create(Person person)
        {
            // Se o ModelState não tem nenhum erro
            if (ModelState.IsValid)
            {
                personRepository.Create(person);

                // Gravação efetuada com sucesso.
                // Gravando mensagem de sucesso na TempData
                @TempData["message"] = "Pessoa cadastrada com sucesso!";

                return RedirectToAction("Index", "Person");

                // Encontrou um erro no preenchimento do campo descriçao
            }
            else
            {
                // retorna para tela do formulário
                return View(person);
            }
        }

        // ACTION UPDATE
        [HttpGet]
        public IActionResult Update(int Id)
        {
            var person = personRepository.GetOne(Id);

            // Retorna para a View o objeto modelo 
            // com as propriedades preenchidas com dados do banco de dados 
            return View(person);
        }

        [HttpPost]
        public IActionResult Update(Person person)
        {
            if (ModelState.IsValid)
            {
                personRepository.Update(person);

                @TempData["message"] = "Cadastro alterado com sucesso!";

                return RedirectToAction("Index", "Person");
            }
            else
            {
                return View(person);
            }
        }

        // ACTION READ
        [HttpGet]
        public IActionResult Read(int Id)
        {
            var person = personRepository.GetOne(Id);

            // Retorna para a View o objeto modelo 
            // com as propriedades preenchidas com dados do banco de dados 
            return View(person);
        }

        // ACTION DELETE
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            personRepository.Delete(Id);

            @TempData["message"] = "Pessoa removida com sucesso!";

            // Substituímos o return View()
            // pelo método de redirecionamento
            return RedirectToAction("Index", "Person");
        }
    }
}
