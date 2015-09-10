using OnlineNative.Domain.Model;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace OnlineNative.Repositories.EntityFramework.ModelConfigurations
{
    public class CategoryTypeConfiguration: EntityTypeConfiguration<Category>
    {
        public CategoryTypeConfiguration()
        {
            HasKey<Guid>(c => c.Id);
            Property(c => c.Id)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(25);
        }
    }
}
