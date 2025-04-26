using Bug_Ticketing.BL.DTOS.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bug_Ticketing.BL.Managers.Users
{
    public interface IUserManger
    {
        Task <bool> RegisterAsync(UserRegisterDto userRegisterDto);
        Task<string> LogInAsync(UserLoginDto userLoginDto);
    }

  
}
