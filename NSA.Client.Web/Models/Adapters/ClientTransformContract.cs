using System;
using System.Linq.Expressions;
using NSA.Support.Adapter;
using NailsFramework.IoC;

namespace NSA.Client.Web.Models.Adapters
{
    [Lemming]
    public class ClientTransformContract : EntityAdapter<Domain.Client, ClientDto>
    {
        public override ClientDto Transform(Domain.Client entity)
        {
            return new ClientDto
            {
                Name = entity.Name,
                BirthDate = entity.BirthDate
            };
        }

        public override Expression<Func<Domain.Client, ClientDto>> Transform()
        {
            return client => new ClientDto
            {
                Name = client.Name,
                BirthDate = client.BirthDate
            };
        }
    }   
}