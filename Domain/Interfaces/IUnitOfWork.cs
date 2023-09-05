using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUnitOfWork
    {
        ICityRepository Cities { get; }
        IClassroomRepository Classrooms { get; }
        ICountryRepository Countries { get; }
        IDepartamentRepository Departaments { get; }
        IGenderRepository Genders { get; }
        IPersonRepository Persons { get; }
        IPersonTypeRepository PersonTypes { get; }
        ISubjectRepository Subjects { get; }
        //ITrainerClassroomRepository TrainerClassrooms { get; }

        Task<int> SaveAsync();
    }
}