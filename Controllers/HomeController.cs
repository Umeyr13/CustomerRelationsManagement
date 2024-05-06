using CustomerRelationsManagement.Models;
using CustomerRelationsManagementDomain.Entities;
using CustomerRelationsMangementApplication.DTOs;
using CustomerRelationsMangementApplication.IRepository;
using CustomerRelationsMangementApplication.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CustomerRelationsManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmployeeService _employeeService;
        private readonly ISuggestionService _suggestionService;
        private ICustomerService _customerService;
        private readonly ISuggestionRepository _suggestionRepository;
        public HomeController(ILogger<HomeController> logger, IEmployeeService employeeService, ISuggestionService suggestionService, ICustomerService customerService, ISuggestionRepository suggestionRepository)
        {
            _logger = logger;
            _employeeService = employeeService;
            _suggestionService = suggestionService;
            _customerService = customerService;
            _suggestionRepository = suggestionRepository;
        }

        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}