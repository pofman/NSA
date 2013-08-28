using System;
using NSA.Support.Domain;

namespace NSA.Domain
{
    public class Client : Entity<Client>
    {
        public virtual string Name { get; protected set; }
        public virtual DateTime BirthDate { get; protected set; }

        protected Client() { }

        public Client(string name, DateTime birthDate)
        {
            Name = name;
            BirthDate = birthDate;
        }
    }
}