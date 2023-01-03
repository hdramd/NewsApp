using NewsApp.Core.Domain.News.Entities;
using Zamin.Core.Domain.Entities;

namespace NewsApp.Core.Domain.Images.Entities
{
    public class Image : AggregateRoot
    {
        #region Props
        public string Path { get; private set; }
        public virtual ICollection<NewsImageMapping> NewsImageMappings { get; private set; }
        #endregion

        #region Ctor
        private Image()
        {

        }

        public Image(string path)
        {
            Path = path;
        }
        #endregion

        #region Commands
        public static Image Create(string patch) => new(patch);

        #endregion
    }
}
