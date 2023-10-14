using LibraryApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Repository.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            //throw new NotImplementedException();
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x=>x.Name).IsRequired().HasMaxLength(50);

            builder.Property(x => x.Author).IsRequired().HasMaxLength(50);

            builder.Property(x => x.FilePath).IsRequired().HasMaxLength(256);

            builder.Property(x => x.IsInLibrary).IsRequired();
        }
    }
}
