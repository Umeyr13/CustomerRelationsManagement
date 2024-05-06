using CustomerRelationsManagement.Models;
using CustomerRelationsManagementDomain.Entities;
using CustomerRelationsMangementApplication.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CustomerRelationsManagement.Controllers
{
	[Authorize]
	public class EmployeeController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ICustomerService _customerService;
        private readonly ISaleService _saleService;
        private readonly ISuggestionService _suggestionService;
        private readonly ITaskService _taskService;

		public EmployeeController(UserManager<AppUser> userManager, ICustomerService customerService, ISaleService saleService, ISuggestionService suggestionService, ITaskService taskService)
		{
			_userManager = userManager;
			_customerService = customerService;
			_saleService = saleService;
			_suggestionService = suggestionService;
			_taskService = taskService;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
        {
			
            var user2 = await _userManager.GetUserAsync(User) as Employee;
			var suggestions =await _suggestionService.GetAllSuggestionAsync(User);
			var customerIds = suggestions.Select(s => s.CustomerId).Distinct().ToList();
			
			var allCustomers = await _customerService.GetAllCustomersAsync();
			var sugestionCustomers = new List<Customer>();
			foreach (var customerId in customerIds)
			{
				var customer = await _customerService.GetCustomerByIdAsync(customerId);
				if (customer != null)
				{
					sugestionCustomers.Add(customer);
				}
			}

			var model = new EmployeeModel()
			{
				suggestions = suggestions,
				allCustomers = allCustomers.ToList(),
				EmployeName = user2.FullName,
				SuggestionCustomers = sugestionCustomers

			};

			return View("Index",model);

			//var customersFromSuggestions = customers.Where(c=>customerIds.Contains(c.Id));
			//var aa= customers.Where(c=> c.Suggestions.Any(s=>s.EmployeeId == user.Id));
	
        }
    }
}
