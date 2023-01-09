using Zamin.Core.Contracts.ApplicationServices.Commands;

namespace NewsApp.Core.Contracts.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommand : ICommand<long>
    {
        public string Name { get; set; }
    }
}
