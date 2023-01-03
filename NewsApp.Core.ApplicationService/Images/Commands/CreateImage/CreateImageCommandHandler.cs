using Zamin.Core.ApplicationServices.Commands;
using Zamin.Core.Contracts.ApplicationServices.Commands;
using Zamin.Utilities;
using NewsApp.Core.Contracts.Images.Commands;
using NewsApp.Core.Domain.Images.Entities;
using NewsApp.Core.Contracts.Images.Commands.CreateImage;

namespace NewsApp.Core.ApplicationService.Images.Commands.CreateImage
{
	public class CreateImageCommandHandler : CommandHandler<CreateImageCommand, Guid>
	{
		private readonly IImageCommandRepository _imageCommandRepository;
		public CreateImageCommandHandler(ZaminServices zaminServices,
			IImageCommandRepository imageCommandRepository) : base(zaminServices)
		{
			_imageCommandRepository = imageCommandRepository;
		}

		public override async Task<CommandResult<Guid>> Handle(CreateImageCommand command)
		{
			var image = Image.Create(command.Path);
			await _imageCommandRepository.InsertAsync(image);
			await _imageCommandRepository.CommitAsync();
			return Ok(image.BusinessId.Value);
		}
	}
}
