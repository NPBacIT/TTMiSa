using MISA.WebFresher072023.Demo.Application;
using MISA.WebFresher072023.Demo.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher072023.Demo.Application
{
    public interface IEmployeeService : IBaseService<EmployeeDto,EmployeeCretateDto,EmployeeUpdateDto>
    {
        

    }
}
