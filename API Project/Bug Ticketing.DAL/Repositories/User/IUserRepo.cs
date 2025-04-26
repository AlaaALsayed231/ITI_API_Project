using Bug_Ticketing.DAL.Context;
using Bug_Ticketing.DAL.Models;
using Bug_Ticketing.DAL.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bug_Ticketing.DAL
{
    public interface IUserRepo : IGenericRepo<User>
    {
        Task<User?> GetByEmailAsynic(string email);

      
    }
}
