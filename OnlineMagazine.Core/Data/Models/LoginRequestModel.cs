namespace OnlineMagazine.Data.Models
{
    public class LoginRequestModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
    public class LoginResponseModel
    {
        public string Token { get; set; }
        public string Email { get; set; }
    }
}
