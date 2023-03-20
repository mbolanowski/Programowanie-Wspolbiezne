namespace ProjektPW.ProjectTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void changeFirstNameTest()
        {
            Student student = new Student();
            student.FirstName = "Test";
            student.LastName = "Testing";
            Assert.AreEqual(student.FirstName, "Test");

            student.changeFirstName("Test2");
            Assert.AreEqual(student.FirstName, "Test2");
        }

        [TestMethod]
        public void changeLastNameTest()
        {
            Student student = new Student();
            student.FirstName = "Test";
            student.LastName = "Testing";
            Assert.AreEqual(student.LastName, "Testing");

            student.changeLastName("Testing2");
            Assert.AreEqual(student.LastName, "Testing2");
        }
    }
}