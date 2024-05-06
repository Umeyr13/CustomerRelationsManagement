using CustomerRelationsManagementDomain.Entities;
using CustomerRelationsMangementApplication.IServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CustomerRelationsManagement.Controllers
{
    public class SuggestionController : Controller
    {
        private readonly ISuggestionService _suggestionService;
        private readonly UserManager<AppUser> _userManager;

        public SuggestionController(ISuggestionService suggestionService, UserManager<AppUser> userManager)
        {
            _suggestionService = suggestionService;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result =  await _suggestionService.GetAllSuggestionAsync(User);

            return View(result);
        }

        [HttpGet]
        [Route("Suggestion/AddSuggestion/{id}")]
        public async Task<IActionResult> AddSuggestion(int Id)
        {
            var employeeID = int.Parse(_userManager.GetUserId(User));
            Suggestion suggestion = new() {CustomerId = Id,EmployeeId =employeeID};
            var result = await _suggestionService.CreateSuggestion(suggestion);
            return View(result);
        }

        [HttpPost]
        [Route("Suggestion/AddSuggestion/{id}")]
        public IActionResult AddSuggestion(Suggestion suggestion)
        {
             
              _suggestionService.UpdateSuggestion(suggestion);
            return View(suggestion);
        }
    }
}
