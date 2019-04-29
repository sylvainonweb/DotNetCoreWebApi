using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetCoreWebApiTests.Shared
{
    [Table("Customer")]
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public int CustomerTypeId { get; set; }
    }
}
