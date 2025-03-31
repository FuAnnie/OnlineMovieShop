using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class MovieDbContext: DbContext
{
    public MovieDbContext(DbContextOptions<MovieDbContext> options): base(options)
    {
        
    }

    public DbSet<Cast> Casts { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<MovieGenre> MovieGenres { get; set; }
    public DbSet<MovieCast> MovieCasts { get; set; }
    public DbSet<Trailer> Trailers { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Purchase> Purchases { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MovieGenre>()
            .HasKey(e => new { e.GenreId, e.MovieId });
        
        modelBuilder.Entity<MovieGenre>()
            .HasOne(e => e.Genre)
            .WithMany(e => e.MovieGenres)
            .HasForeignKey(e => e.GenreId);
        
        modelBuilder.Entity<MovieGenre>()
            .HasOne(e => e.Movie)
            .WithMany(e => e.MovieGenres)
            .HasForeignKey(e => e.MovieId);
        
        modelBuilder.Entity<MovieCast>()
            .HasKey(e => new { e.MovieId, e.Character, e.CastId });
        
        modelBuilder.Entity<MovieCast>()
            .HasOne(e => e.Movie)
            .WithMany(e => e.MovieCasts)
            .HasForeignKey(e => e.MovieId);
        
        modelBuilder.Entity<MovieCast>()
            .HasOne(e => e.Cast)
            .WithMany(e => e.MovieCasts)
            .HasForeignKey(e => e.CastId);
        
        modelBuilder.Entity<Trailer>()
            .HasKey(e => e.Id);
        
        modelBuilder.Entity<Trailer>()
            .HasOne(e => e.Movie)
            .WithMany(e => e.Trailers)
            .HasForeignKey(e => e.MovieId);
        
        modelBuilder.Entity<Favorite>()
            .HasKey(e => new { e.MovieId, e.UserId });
        
        modelBuilder.Entity<Favorite>()
            .HasOne(e => e.Movie)
            .WithMany(e => e.Favorites)
            .HasForeignKey(e => e.MovieId);
        
        modelBuilder.Entity<Favorite>()
            .HasOne(e => e.User)
            .WithMany(e => e.Favorites)
            .HasForeignKey(e => e.UserId);
        
        modelBuilder.Entity<Review>()
            .HasKey(e => new {e.MovieId, e.UserId});
        
        modelBuilder.Entity<Review>()
            .HasOne(e => e.Movie)
            .WithMany(e => e.Reviews)
            .HasForeignKey(e => e.MovieId);
        
        modelBuilder.Entity<Review>()
            .HasOne(e => e.User)
            .WithMany(e => e.Reviews)
            .HasForeignKey(e => e.UserId);
        
        modelBuilder.Entity<Purchase>()
            .HasKey(e => new {e.MovieId, e.UserId});
        
        modelBuilder.Entity<Purchase>()
            .HasOne(e => e.Movie)
            .WithMany(e => e.Purchases)
            .HasForeignKey(e => e.MovieId);
        
        modelBuilder.Entity<Purchase>()
            .HasOne(e => e.User)
            .WithMany(e => e.Purchases)
            .HasForeignKey(e => e.UserId);
        
        modelBuilder.Entity<UserRole>()
            .HasKey(e => new {e.RoleId, e.UserId});
        
        modelBuilder.Entity<UserRole>()
            .HasOne(e => e.Role)
            .WithMany(e => e.UserRoles)
            .HasForeignKey(e => e.RoleId);
        
        modelBuilder.Entity<UserRole>()
            .HasOne(e => e.User)
            .WithMany(e => e.UserRoles)
            .HasForeignKey(e => e.UserId);
    }
}