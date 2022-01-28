namespace DSAProblems.LLD.LockerManagement.Model
{
    public class Contact
    {
        readonly private string _phone;
        readonly private string _email;
        public Contact(string phone, string email)
        {
            _phone = phone;
            _email = email;
        }

        public string Phone => _phone;

        public string Email => _email;
    }
}
