using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreWebApiTests.Data
{
    [Table("CustomerType")]
    public class CustomerType
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
    }
}
