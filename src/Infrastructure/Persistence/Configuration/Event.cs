using Finbuckle.MultiTenant.EntityFrameworkCore;
using EventManagment.Domain.Catalog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EventManagment.Domain.Events;

namespace EventManagment.Infrastructure.Persistence.Configuration;

public class EventConfig : IEntityTypeConfiguration<Event>
{
    public void Configure(EntityTypeBuilder<Event> builder)
    {
        builder.IsMultiTenant();

        builder
            .Property(b => b.EventName)
                .HasMaxLength(50)
                .IsRequired();

        builder.HasIndex(b => b.EventName).IsUnique();
    }
}

public class EventSettingsConfig : IEntityTypeConfiguration<EventSettings>
{
    public void Configure(EntityTypeBuilder<EventSettings> builder)
    {
        builder.IsMultiTenant();
    }
}

public class CommentResponseConfig : IEntityTypeConfiguration<CommentResponse>
{
    public void Configure(EntityTypeBuilder<CommentResponse> builder)
    {
        builder.IsMultiTenant();
    }
}


public class CommentConfig : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.IsMultiTenant();
    }
}

public class ParticipantConfig : IEntityTypeConfiguration<Participant>
{
    public void Configure(EntityTypeBuilder<Participant> builder)
    {
        builder.IsMultiTenant();
    }
}