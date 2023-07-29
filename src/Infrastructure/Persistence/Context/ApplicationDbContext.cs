using Finbuckle.MultiTenant;
using EventManagment.Application.Common.Events;
using EventManagment.Application.Common.Interfaces;
using EventManagment.Domain.Catalog;
using EventManagment.Infrastructure.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using EventManagment.Domain.Events;

namespace EventManagment.Infrastructure.Persistence.Context;

public class ApplicationDbContext : BaseDbContext
{
    public ApplicationDbContext(ITenantInfo currentTenant, DbContextOptions options, ICurrentUser currentUser, ISerializerService serializer, IOptions<DatabaseSettings> dbSettings, IEventPublisher events)
        : base(currentTenant, options, currentUser, serializer, dbSettings, events)
    {
    }

    public DbSet<Product> Products => Set<Product>();
    public DbSet<Brand> Brands => Set<Brand>();
    public DbSet<Event> Events => Set<Event>();
    public DbSet<Comment> Comments => Set<Comment>();
    public DbSet<CommentResponse> CommentResponses => Set<CommentResponse>();
    public DbSet<Participant> Participants => Set<Participant>();
    public DbSet<EventSettings> EventSettings => Set<EventSettings>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.HasDefaultSchema(SchemaNames.Event);
    }
}