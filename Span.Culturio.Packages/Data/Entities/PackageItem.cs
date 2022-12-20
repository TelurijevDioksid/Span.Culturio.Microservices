using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Span.Culturio.Packages.Data.Entities
{
    public class PackageItem
    {
        public int Id { get; set; }
        public int CultureObjectId { get; set; }
        public int PackageId { get; set; }
        public int VisitsAvailable { get; set; }
    }

    public class PackageItemConfiguration : IEntityTypeConfiguration<PackageItem>
    {
        public void Configure(EntityTypeBuilder<PackageItem> builder)
        {
            builder.ToTable("PackageItems");
            builder.HasKey(x => x.Id);
            //builder.HasOne(x => x.CultureObject).WithMany(x => x.PackageItems).HasForeignKey(x => x.CultureObjectId);
            //builder.HasOne(x => x.Package).WithMany(x => x.PackageItems).HasForeignKey(x => x.PackageId);
            builder.Property(x => x.VisitsAvailable).IsRequired();
        }
    }
}