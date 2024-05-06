using CustomerRelationsManagementDomain.Entities;

namespace CustomerRelationsManagement.Models
{
	public class EmployeeModel
	{
        public string EmployeName { get; set; }
        public List<Suggestion> suggestions { get; set; }
        public List<Customer> allCustomers { get; set; }
        public List<Customer> SuggestionCustomers { get; set; }
    }
}
