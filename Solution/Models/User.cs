using FluentNHibernate.Mapping;
using System.Text.Json.Serialization;

namespace Solution.Models
{
    public class User
    {
        public virtual int Id { get; set; }
        public virtual string? Email { get; set; }
        public virtual string? Password { get; set; }

        public virtual bool? IsUpdated { get; set; }
        public virtual Employee? Employee { get; set; }
            
    }

    public class UserMapping : ClassMap<User>
    {
        public UserMapping()
        {
            Id(x => x.Id)
                .GeneratedBy.Native()
                .Column("Id");
            Map(x => x.Email)
                .Column("email");
            Map(x => x.Password)
                .Column("password");
            Map(x => x.IsUpdated)
                .Column("is_updated");
            References(x => x.Employee);
            Table("Users");
        }
    }
}

