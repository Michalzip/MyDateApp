using System;
namespace App.Interfaces
{


    public interface ILogin
    {
        public string? Email { get; set; }
        public string? Password { get; set; }

    }

    public interface  IRegister
    {
        public string? Email { get; set; }
        public string? Name { get; set; }
        public string? Password
        {
            get; set;
        }
    }
    public interface IUser : IRegister, ILogin
    {



    }

}

