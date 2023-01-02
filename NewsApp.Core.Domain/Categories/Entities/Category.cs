using NewsApp.Core.Domain.News.Entities;
using Zamin.Core.Domain.Entities;

namespace NewsApp.Core.Domain.Categories.Entities
{
    public class Category : AggregateRoot
    {
        #region Props
        public string Name { get; private set; }
        public virtual ICollection<NewsCategoryMapping> NewsCategoryMappings { get; private set; }
        #endregion

        #region Ctor
        private Category()
        {

        }

        public Category(string name)
        {
            Name = name;
        }
        #endregion

        #region Commands
        public static Category Create(string name) => new(name);
        #endregion
    }
}
