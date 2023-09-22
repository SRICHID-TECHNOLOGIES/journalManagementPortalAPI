namespace Application.Security
{
    public class LoginUserModel
    {
        public string Userid { get; set; }
       
        public string UserRole { get; set; }
        public string Password { get; set; }
        public int OperatorUid { get; set; }
        public string Email { get; set; }
    }
}
