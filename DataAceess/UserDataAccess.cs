    using System.Net.Mail;
using System.Text.RegularExpressions;
using react_red.interfaces;
using react_red.Model;

namespace react_red.DataAccess;
public class UserDataAccess : IUser
{
    private readonly BlogContext _;
    public UserDataAccess(BlogContext _)
    {
        this._=_;
    }

    public bool emailExists(string email)
    {
        User? _user = _.Users.FirstOrDefault(p=>p.Email==email);
        return _user != null; 
    }

    public User? GetUser(Guid id)
    {
        User? _user = _.Users.FirstOrDefault(p=>p.UsersId==id);
        return _user;
    }

    public bool isEmail(string email)
    {
        try { 
            MailAddress mailAddress = new(email);
            return true;
        }catch (Exception){
                return false;
            }
    }

    public bool isStrongPassword(string password)
    {
        return Regex.IsMatch(password,(@"^.* (?=.{ 8,})(?=.*[\d])(?=.*[\W]).*$"));
    }

    public User? Login(ILogin _login)
    {
        User? _user = _.Users.FirstOrDefault(p=>p.Email==_login.Email);
        if(_user!=null&&BCrypt.Net.BCrypt.Equals(_login.Password,_user.Password)) return _user;
        else return null;
    }

    public bool MakeAdmin(Guid id)
    {
        User? user = GetUser(id);
        if(user==null) return false;
        else {
            user.Role="admin";
            _.SaveChanges();
            return true;
        }
    }

    public void Register(User _user)
    {
        try{
            _user.Password = BCrypt.Net.BCrypt.HashPassword(_user.Password);
            _.Users.Add(_user);
            _.SaveChanges();
        }catch(Exception ex){
            Console.WriteLine(ex);
        }
    }

    public void DeleteUser(Guid id)
    {
        User? user = GetUser(id);
        if (user != null)
        {
            _.Users.Remove(user);
            _.SaveChanges();
        }
    }

    public User? UpdateUser(User _user)
    {
        User? user = _.Users.FirstOrDefault(p=>p.UsersId==_user.UsersId);
        if(user==null) return null ;
        else{
            user = _user;
            _.SaveChanges();
            return user;
        }
    }
}