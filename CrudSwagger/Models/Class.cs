using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CrudSwagger.Models
{
    public class Users
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int userId {get; set;}

        public int DocumentCi { get; set; }

        public String Name { get; set; }

        public String lastName { get; set; }

        public String email { get; set; }

        public String telephone { get; set; }

        public DateTime date_birth { get; set; }

    }
}
