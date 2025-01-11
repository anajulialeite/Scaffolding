using MODEL_FIRST.Models;

namespace MODEL_FIRST.Models
{
    public class Users
    {
        public int ID { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public Role Roles { get; set; }

        public enum  Role{
            Admin,
            Users
        };

        //Um tratamento de muitos para muitos, um usuário pode fazer vários pedidos
        public List<Orders> Orders { get; set; } = new List<Orders>();
    }
}
