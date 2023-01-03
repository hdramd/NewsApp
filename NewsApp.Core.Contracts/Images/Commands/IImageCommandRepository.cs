using NewsApp.Core.Domain.Images.Entities;
using Zamin.Core.Contracts.Data.Commands;

namespace NewsApp.Core.Contracts.Images.Commands
{
	public interface IImageCommandRepository : ICommandRepository<Image>
	{
	}
}
