using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MyApp.Domain;
using MyApp.Domain.Items;

namespace MyApp.Application.Items.Commands
{
    public class CreateItemCommandHandler : IRequestHandler<CreateItemCommand, long>
    {
        private readonly IItemsRepository _itemsRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateItemCommandHandler(IItemsRepository itemsRepository, IUnitOfWork unitOfWork)
        {
            _itemsRepository = itemsRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<long> Handle(CreateItemCommand request, CancellationToken cancellationToken)
        {
            var item = new Item
            {
                Name = request.Name,
                Qtd = request.Qtd
            };

            _itemsRepository.Insert(item);
            _unitOfWork.Commit();

            return Task.FromResult(item.Id);

        }
    }
}