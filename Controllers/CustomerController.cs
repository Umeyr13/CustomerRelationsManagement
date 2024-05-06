using CustomerRelationsManagement.Models;
using CustomerRelationsManagementDomain.Entities;
using CustomerRelationsManagementPersistence.Services;
using CustomerRelationsMangementApplication.DTOs;
using CustomerRelationsMangementApplication.IServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CustomerRelationsManagement.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly ISuggestionService _suggestionService;
        private readonly UserManager<AppUser> _userManager;
        public CustomerController(ICustomerService customerService, ISuggestionService suggestionService, UserManager<AppUser> userManager)
        {
            _customerService = customerService;
            _suggestionService = suggestionService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {            
            
            var allCustomers = await _customerService.GetAllCustomersAsync();

            return View(new EmployeeModel { allCustomers = allCustomers.ToList()});
        }
        [HttpGet]
        public IActionResult AddCustomer( )
        {
           
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomer(CreateCustomer customer)
        {
            await _customerService.CreateCustomerAsync(customer);
            ViewBag.SuccessMessage = "Kayıt Başarılı";
            ModelState.Clear();
            return View("AddCustomer");
        }

        [HttpGet]
        [Route("Customer/EditCustomer/{id}")]
        public async Task<IActionResult> EditCustomer(int Id)
        {
            var result = await _customerService.GetCustomerByIdAsync(Id);
            return View("EditCustomer",result);
        }
        [HttpPost]
        //[Route("Customer/EditCustomer/{id}")]
        public  async Task<IActionResult> EditCustomer(Customer customer)
        {
           var result = await _customerService.UpdateCustomer(customer);

            return RedirectToAction("Index","Customer");
        }

        [HttpGet]
        public async Task<IActionResult> MyCustomer()
        {
            var MyCustomers = await _customerService.MyCustomers(User);

                return View("MyCustomer", MyCustomers);
        }


    }
}
