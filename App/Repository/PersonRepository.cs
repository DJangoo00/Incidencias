using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Domain;
using Domain.Interfaces;
using Domain.Entities;
using Persistence;

namespace App.Repository;
public class PersonRepository : GenericRepository<Person>, IPersonRepository
{
    public PersonRepository(IncidenciasContext context) : base(context) { }
}