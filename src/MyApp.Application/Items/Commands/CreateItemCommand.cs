using MediatR;
using MyApp.Domain.Items;

namespace MyApp.Application.Items.Commands
{
    public class CreateItemCommand : IRequest<long>
    {
        public string Name { get; set; }
        public int Qtd { get; set; }
    }
}