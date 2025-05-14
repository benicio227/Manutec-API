namespace Manutec.Application.Models.UserModel;
public class LoginViewModel
{
    public LoginViewModel(string token)
    {
        Token = token;
    }
    public string Token {  get; set; }
}
