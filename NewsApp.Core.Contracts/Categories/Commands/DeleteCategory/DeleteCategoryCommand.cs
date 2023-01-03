using Zamin.Core.Contracts.ApplicationServices.Commands;

namespace NewsApp.Core.Contracts.Categories.Commands.DeleteCategory
{
	public class DeleteCategoryCommand : ICommand
	{
		public long Id { get; set; }
	}
}
