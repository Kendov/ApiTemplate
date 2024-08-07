using MediatR;

namespace MyApp.Application.Publishers.CreatePublisher
{
    public class CreatePublisherCommand : IRequest<long>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}