using System.ComponentModel.DataAnnotations.Schema;

namespace MODEL_FIRST.Models
{
    public class Orders
    {
        public int Id { get; set; }

        public DateTime TimeOrder { get; set; } = DateTime.Now;

        public double Price { get; set; }

        public Status status { get; set; }

        public enum Status
        {
            available,
            preparation,
            completed
        };

        public int  IdUsers   { get; set; }

        public Users User { get; set; } = new Users();
    }
}
