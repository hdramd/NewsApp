using Zamin.Core.Contracts.ApplicationServices.Commands;

namespace NewsApp.Core.Contracts.Categories.Commands.UpdateCategory
{
	public class UpdateCategoryCommand : ICommand<long>
	{
		public long Id { get; set; }
		public string Name { get; set; }
	}
}
