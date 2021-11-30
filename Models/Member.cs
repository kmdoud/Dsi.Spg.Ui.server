using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsi.Spg.Ui.Data.Models
{
    public class Member
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Tag { get; set; }
        public string? Discord { get; set; }
        public string? Email { get; set; }
        public List<Platform>? Platforms { get; set; }
    }
}
