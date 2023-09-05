using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Domain;
using Domain.Interfaces;
using Domain.Entities;
using Persistence;
using Microsoft.EntityFrameworkCore;

namespace App.Repository;
public class CountryRepository : GenericRepository<Country>, ICountryRepository
{
    protected readonly IncidenciasContext _context;
    public CountryRepository(IncidenciasContext context) : base(context)
    {
        _context = context;
    }
    public override async Task<(int totalRegistros, IEnumerable<Country> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.Countries as IQueryable<Country>;
        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.Name.ToLower().Contains(search));
        };
        query = query.OrderBy(p => p.Id);
        var totalRegistros = await query.CountAsync();
        var registros = await query
            .Include(u => u.Departaments)
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        return (totalRegistros, registros);
    }

    public override async Task<Country> GetByIdAsync(int id)
    {
        return await _context.Countries
        .Include(p => p.Departaments)
        .FirstOrDefaultAsync(p => p.Id == id);
    }
}