using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using DapperExer3.Models;

namespace DapperExer3.Models
{
    internal class Department
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Chair { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
