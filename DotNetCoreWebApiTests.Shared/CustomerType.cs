using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetCoreWebApiTests.Shared
{
    [Table("CustomerType")]
    public class CustomerType
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
    }
}
