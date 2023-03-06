namespace GerenciadorApartamentos.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Building>().HasData(
                new Building
                {
                    Id = 1,
                    Name = "Edificio 1",
                    Address = "Rua 1"
                },
                new Building
                {
                    Id = 2,
                    Name = "Edificio 2",
                    Address = "Rua 1"
                },
                new Building
                {
                    Id = 3,
                    Name = "Edificio 3",
                    Address = "Rua 2"
                });
            modelBuilder.Entity<Apartment>().HasData(
                new Apartment
                {
                    Id = 1,
                    Number = "101",
                    RentValue = 1000,
                    BuildingId = 1,
                    LandlordId = 1,
                },
                new Apartment
                {
                    Id = 2,
                    Number = "102",
                    RentValue = 1100,
                    BuildingId = 1,
                    LandlordId = 1,
                },
                new Apartment
                {
                    Id = 3,
                    Number = "103",
                    RentValue = 1200,
                    BuildingId = 2,
                    LandlordId = 1,
                });
            modelBuilder.Entity<Landlord>().HasData(
                new Landlord
                {
                    Id = 1,
                    Name = "Biopark",
                    Email = "comercial@biopark.gg"
                });
            modelBuilder.Entity<Tenant>().HasData(
                new Tenant
                {
                    Id = 1,
                    Name = "Joao",
                    CPF = "123456789",
                    Address = "minha rua, 322"
                });
        }
        public DbSet<Building> Buildings { get; set; }

        public DbSet<Apartment> Apartments { get; set; }

        public DbSet<Tenant> Tenants { get; set; }

        public DbSet<Landlord> Landlords { get; set; }

        public DbSet<Rental> Rentals { get; set; }
    }
}

