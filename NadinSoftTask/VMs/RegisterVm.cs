namespace NadinSoftTask.VMs
{
    public class RegisterVm
    {
        public string Email {  get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
        public string Phonenumber { get; set; }
        public bool IsCustomer { get; set; }
        public bool IsManufacturer { get; set; }
        public bool isAdmin { get; set; }
    }
}
