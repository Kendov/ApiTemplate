using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MyApp.Domain;
using MyApp.Domain.Publishers;

namespace MyApp.Application.Publishers.Commands.CreatePublisher
{
    public class CreatePublisherCommandHandler : IRequestHandler<CreatePublisherCommand, long>
    {
        private readonly IPublishersRepository _publishersRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreatePublisherCommandHandler(IPublishersRepository publishersRepository, IUnitOfWork unitOfWork)
        {
            _publishersRepository = publishersRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<long> Handle(CreatePublisherCommand request, CancellationToken cancellationToken)
        {

            var publisher = new Publisher
            {
                Name = request.Name,
                Description = request.Description
            };

            _publishersRepository.Insert(publisher);

            await _unitOfWork.CommitAsync();

            return publisher.Id;
        }
    }
}