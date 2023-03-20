namespace ProjektPW
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string GetFullName()
        {
            return FirstName + " " + LastName;
        }

        public void changeFirstName(string name)
        {
            FirstName = name;
        }

        public void changeLastName(string name)
        {
            LastName = name;
        }
    }
}
