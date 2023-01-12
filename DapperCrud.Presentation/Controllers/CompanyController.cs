using DapperCrud.Business.Service.Discrete;
using DapperCrud.Data.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DapperCrud.Presentation.Controllers
{
    public class CompanyController : Controller
    {
        private readonly IService<Company> _service;
        public CompanyController(IService<Company> service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _service.Get());
        }
    }
}
