using CQRSWithMediatR.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CQRSWithMediatR.Infra.Context;

public class AppDbContext : DbContext
{
	public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)	{ }

	protected override void OnModelCreating(ModelBuilder mb)
	{
		mb.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
	}

	public DbSet<Member> Members { get; set; }
}
