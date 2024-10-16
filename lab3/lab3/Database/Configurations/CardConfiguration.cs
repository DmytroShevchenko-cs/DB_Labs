namespace lab3.Database.Configurations;

using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class CardConfiguration : IEntityTypeConfiguration<Card>
{
    public void Configure(EntityTypeBuilder<Card> builder)
    {
        builder.HasKey(e => e.CardId);
        
        builder.Property(d => d.CardId)
            .ValueGeneratedOnAdd();
        
        builder.Property(e => e.CardCreationDate)
            .IsRequired();

        builder.Property(e => e.PolicyNumber)
            .IsRequired()
            .HasMaxLength(50);

        builder.HasOne(c => c.Patient)
            .WithOne(p => p.Card)
            .HasForeignKey<Card>(c => c.CardId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}