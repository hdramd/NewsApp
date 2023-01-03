using Zamin.Core.Contracts.ApplicationServices.Commands;

namespace NewsApp.Core.Contracts.Images.Commands.CreateImage
{
	public class CreateImageCommand : ICommand<Guid>
	{
		public string Path { get; set; }
	}
}
