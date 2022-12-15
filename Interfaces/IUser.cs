using System;
namespace App.Interfaces
{


    public interface ICreateTime
    {

        public DateTime CreatedAt { get; set; }
    }


    public interface IUpdateTime
    {

        public DateTime? UpdatedAt { get; set; }

    }


    public interface IUserDataTime : ICreateTime, IUpdateTime
    {

    }



    public interface IUserAvatar
    {
        public string? UserAvatar { get; set; }
    }
}

