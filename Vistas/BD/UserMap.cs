using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using Vistas.Models;

namespace Vistas.BD
{
    public class UserMap : EntityTypeConfiguration<User>{
        public UserMap(){
            ToTable("User");
            HasKey(o => o.Id);
        }
    }
}