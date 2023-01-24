using react_red.Model;

namespace react_red.interfaces{

public partial class ILogin {
    public string Email { get; set;} = null!;
    public string Password {get; set;} = null!;
}

public interface IUser{
    User? Login(ILogin login);

    void Register (User user);

    bool MakeAdmin(Guid id);

    User? UpdateUser(User user);

    User? GetUser(Guid id);


    bool emailExists(string email);

    bool isEmail(string email);
    bool isStrongPassword(string password);

}
}