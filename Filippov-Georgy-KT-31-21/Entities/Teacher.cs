using System.Text.RegularExpressions;

namespace Filippov_Georgy_KT_31_21.Entities {
    public class Teacher : AEntity {
        public string SecondName { get; set; } = string.Empty;

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public DateTime Birthdate { get; set; }

        public DateTime EmploymentDate { get; set; }

        public string Email { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public int? DegreeId { get; set; }

        public Degree Degree { get; set; } = null!;

        public int PostId { get; set; }

        public Post Post { get; set; } = null!;

        public bool IsEmailValid() {
            return Regex.Match(Email, "(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|\"(?:[\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21\\x23-\\x5b\\x5d-\\x7f]|\\\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])*\")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\\[(?:(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9]))\\.){3}(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9])|[a-z0-9-]*[a-z0-9]:(?:[\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21-\\x5a\\x53-\\x7f]|\\\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])+)\\])").Success;
        }
        public bool IsPhoneValid() {
            return Regex.Match(Phone, "^((8|\\+7)[\\- ]?)?(\\(?\\d{3}\\)?[\\- ]?)?[\\d\\- ]{7,10}$").Success;
        }

        public bool IsEmploymentValid() {
            if (EmploymentDate > DateTime.Now) {
                return false;
            }
            if (EmploymentDate < Birthdate.AddYears(16)) {
                return false;
            }

            return true;
        }
    }
}
