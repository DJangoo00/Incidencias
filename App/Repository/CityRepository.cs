using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Domain;
using Domain.Interfaces;
using Domain.Entities;
using Persistence;

namespace App.Repository;
public class CityRepository : GenericRepository<City>, ICityRepository
{
    public CityRepository(IncidenciasContext context) : base(context)
    {
    }
}
