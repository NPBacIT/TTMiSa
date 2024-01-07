using MISA.WebFresher072023.Demo.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher072023.Demo.Application
{
    public class EmployeeUpdateDto
    {

        [MaxLength(20, ErrorMessage = "Mã nhân viên không được vượt quá 20 ký tự!")]
        public string EmployeeCode { get; set; }

        public Guid DepartmentId { get; set; }

        [MaxLength(255, ErrorMessage = "Tên nhân viên không được vượt quá 255 ký tự!")]
        public string FullName { get; set; }
        public GenderEnum Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Email { get; set; }
        public string? IdentityNumber { get; set; }
        public DateTime? IdentityDate { get; set; }
        public string? IdentityPlace { get; set; }
        public string? PositionId { get; set; }
        public string? PositionName { get; set; }

        public string? Address { get; set; }

        public string? PhoneNumber { get; set; }
        public string? TelephoneNumber { get; set; }

        public string? BankAccount { get; set; }

        public string? BankName { get; set; }

        public string? BankBranchName { get; set; }


        public string GenderName
        {
            get
            {

                switch (Gender)
                {

                    case GenderEnum.Male:
                        return "Nam";
                    case GenderEnum.Female:
                        return "Nữ";
                    default:
                        return "Khác";
                }

            }
        }
    }
}
