using App.Repository;
using Domain.Interfaces;
using Persistence;

namespace App.UnitOfWork;
public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly IncidenciasContext context;
    private CountryRepository _countries;
    private CityRepository _cities;
    private ClassroomRepository _classrooms;
    private DepartamentRepository _departaments;
    private GenderRepository _genders;
    private PersonRepository _persons;
    private PersonTypeRepository _personTypes;
    private SubjectRepository _subjects;

    public UnitOfWork(IncidenciasContext _context)
    {
        context = _context;
    }
    public ICountryRepository Countries
    {
        get
        {
            if (_countries == null)
            {
                _countries = new CountryRepository(context);
            }
            return _countries;
        }
    }
    public ICityRepository Cities
    {
        get
        {
            if (_cities == null)
            {
                _cities = new CityRepository(context);
            }
            return _cities;
        }
    }
    public IClassroomRepository Classrooms
    {
        get
        {
            if (_classrooms == null)
            {
                _classrooms = new ClassroomRepository(context);
            }
            return _classrooms;
        }
    }
    public IDepartamentRepository Departaments
    {
        get
        {
            if (_departaments == null)
            {
                _departaments = new DepartamentRepository(context);
            }
            return _departaments;
        }
    }
    public IGenderRepository Genders
    {
        get
        {
            if (_genders == null)
            {
                _genders = new GenderRepository(context);
            }
            return _genders;
        }
    }
    public IPersonRepository Persons
    {
        get
        {
            if (_persons == null)
            {
                _persons = new PersonRepository(context);
            }
            return _persons;
        }
    }
    public IPersonTypeRepository PersonTypes
    {
        get
        {
            if (_personTypes == null)
            {
                _personTypes = new PersonTypeRepository(context);
            }
            return _personTypes;
        }
    }
    public ISubjectRepository Subjects
    {
        get
        {
            if (_subjects == null)
            {
                _subjects = new SubjectRepository(context);
            }
            return _subjects;
        }
    }

    public async Task<int> SaveAsync()
    {
        return await context.SaveChangesAsync();
    }
    public void Dispose()
    {
        context.Dispose();
    }
}