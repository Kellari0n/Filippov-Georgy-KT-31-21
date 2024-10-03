using Filippov_Georgy_KT_31_21.Entities;

namespace Filippov_Georgy_KT_31_21.Tests {
    public class TeacherUnitTests {
        [Fact]
        public void IsValidTeacherEmail_True() {
            var testTeacher = new Teacher() {
                Email = "email@email.em"
            };

            var result = testTeacher.IsEmailValid();

            Assert.True(result);
        }

        [Fact]
        public void IsValidTeacherEmail_False() {
            var testTeacher = new Teacher() {
                Email = "emailaemailcom"
            };

            var result = testTeacher.IsEmailValid();

            Assert.False(result);
        }

        [Fact]
        public void IsValidTeacherPhone_89008887766_True() {
            var testTeacher = new Teacher() {
                Phone = "89008887766"
            };
            
            var result = testTeacher.IsPhoneValid();

            Assert.True(result);
        }
    }
}