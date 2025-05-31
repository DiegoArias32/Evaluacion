using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Entity.Model.Base;
using System.Data;
using Dapper;
using System.Linq.Expressions;
using Entity.Model.Security;
using Entity.Model.DatesPerson;

namespace Entity.Context
{
    public class ApplicationDbContext : DbContext
    {
        protected readonly IConfiguration _configuration;
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        // DbSets de Security
        public DbSet<User> Users { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<RolUser> RolUsers { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Form> Forms { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<FormModule> FormModules { get; set; }
        public DbSet<RolFormPermission> RolFormPermissions { get; set; }

        // DbSets de DatesPerson
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Neighborhood> Neighborhoods { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Provider> Providers { get; set; }

protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    // Configuración de RolUser - FIXED to prevent cascade conflicts
    modelBuilder.Entity<RolUser>()
        .HasKey(ru => new { ru.UserId, ru.RolId });

    // Main user relationship - keep CASCADE
    modelBuilder.Entity<RolUser>()
        .HasOne(ru => ru.User)
        .WithMany(u => u.RolUsers)
        .HasForeignKey(ru => ru.UserId)
        .OnDelete(DeleteBehavior.Cascade);

    // AssignedBy user relationship - change to NO ACTION to prevent cascade conflict
    modelBuilder.Entity<RolUser>()
        .HasOne(ru => ru.AssignedByUser)  // Assuming you have this navigation property
        .WithMany()
        .HasForeignKey(ru => ru.AssignedByUserId)
        .OnDelete(DeleteBehavior.NoAction);

    modelBuilder.Entity<RolUser>()
        .HasOne(ru => ru.Rol)
        .WithMany(r => r.RolUsers)
        .HasForeignKey(ru => ru.RolId)
        .OnDelete(DeleteBehavior.Cascade);
            
            // Configuración de FormModule
            modelBuilder.Entity<FormModule>()
                .HasKey(fm => new { fm.FormId, fm.ModuleId });
            
            modelBuilder.Entity<FormModule>()
                .HasOne(fm => fm.Form)
                .WithMany(f => f.FormModules)
                .HasForeignKey(fm => fm.FormId);
            
            modelBuilder.Entity<FormModule>()
                .HasOne(fm => fm.Module)
                .WithMany(m => m.FormModules)
                .HasForeignKey(fm => fm.ModuleId);
            
            // Configuración de RolFormPermission
            modelBuilder.Entity<RolFormPermission>()
                .HasKey(rfp => new { rfp.RolId, rfp.FormId, rfp.PermissionId });
            
            modelBuilder.Entity<RolFormPermission>()
                .HasOne(rfp => rfp.Rol)
                .WithMany(r => r.RolFormPermissions)
                .HasForeignKey(rfp => rfp.RolId);
            
            modelBuilder.Entity<RolFormPermission>()
                .HasOne(rfp => rfp.Form)
                .WithMany(f => f.RolFormPermissions)
                .HasForeignKey(rfp => rfp.FormId);
            
            modelBuilder.Entity<RolFormPermission>()
                .HasOne(rfp => rfp.Permission)
                .WithMany(p => p.RolFormPermissions)
                .HasForeignKey(rfp => rfp.PermissionId);
            
            // Configuración de User-Person (1:1)
            modelBuilder.Entity<User>()
                .HasOne(u => u.Person)
                .WithOne(p => p.User)
                .HasForeignKey<User>(u => u.PersonId);
            
            // Configuración de Person-Address
            modelBuilder.Entity<Person>()
                .HasOne(p => p.Address)
                .WithMany(a => a.Persons)
                .HasForeignKey(p => p.AddressId);
            
            // Configuración de Provider-Person
            modelBuilder.Entity<Provider>()
                .HasOne(pr => pr.Person)
                .WithMany()
                .HasForeignKey(pr => pr.PersonId)
                .IsRequired(false);
            
            // Configuración de Provider-Address
            modelBuilder.Entity<Provider>()
                .HasOne(pr => pr.Address)
                .WithMany(a => a.Providers)
                .HasForeignKey(pr => pr.AddressId)
                .IsRequired(false);
            
            // Configuración de jerarquía geográfica
            modelBuilder.Entity<Department>()
                .HasOne(d => d.Country)
                .WithMany(c => c.Departments)
                .HasForeignKey(d => d.CountryId);
            
            modelBuilder.Entity<City>()
                .HasOne(c => c.Department)
                .WithMany(d => d.Cities)
                .HasForeignKey(c => c.DepartmentId);
            
            modelBuilder.Entity<Neighborhood>()
                .HasOne(n => n.City)
                .WithMany(c => c.Neighborhoods)
                .HasForeignKey(n => n.CityId);
            
            // Configuraciones de Address con jerarquía geográfica
            modelBuilder.Entity<Address>()
                .HasOne(a => a.Country)
                .WithMany(c => c.Addresses)
                .HasForeignKey(a => a.CountryId)
                .IsRequired(false);
            
            modelBuilder.Entity<Address>()
                .HasOne(a => a.Department)
                .WithMany(d => d.Addresses)
                .HasForeignKey(a => a.DepartmentId)
                .IsRequired(false);
            
            modelBuilder.Entity<Address>()
                .HasOne(a => a.City)
                .WithMany(c => c.Addresses)
                .HasForeignKey(a => a.CityId)
                .IsRequired(false);
            
            modelBuilder.Entity<Address>()
                .HasOne(a => a.Neighborhood)
                .WithMany(n => n.Addresses)
                .HasForeignKey(a => a.NeighborhoodId)
                .IsRequired(false);
            
            // Configuración de herencia TPH para Client y Employee
            modelBuilder.Entity<Client>()
                .HasBaseType<Person>();
            
            modelBuilder.Entity<Employee>()
                .HasBaseType<Person>();
                
            // Configuración para todas las entidades que heredan de BaseEntity (existente)
            foreach (var entityType in modelBuilder.Model.GetEntityTypes()
                .Where(t => t.ClrType.IsSubclassOf(typeof(BaseEntity))))
            {
                modelBuilder.Entity(entityType.ClrType)
                    .Property("CreatedAt")
                    .IsRequired();
                    
                modelBuilder.Entity(entityType.ClrType)
                    .Property("UpdatedAt")
                    .IsRequired(false);
                    
                modelBuilder.Entity(entityType.ClrType)
                    .Property("DeleteAt")
                    .IsRequired(false);
                    
                modelBuilder.Entity(entityType.ClrType)
                    .Property("Status")
                    .HasDefaultValue(true);
            }

            foreach (var entityType in modelBuilder.Model.GetEntityTypes()
            .Where(t =>
            typeof(BaseEntity).IsAssignableFrom(t.ClrType) &&
            t.BaseType == null)) // Solo entidades raíz
            {
                var parameter = Expression.Parameter(entityType.ClrType, "e");
                var property = Expression.Property(parameter, nameof(BaseEntity.Status));
                var condition = Expression.Equal(property, Expression.Constant(true));
                var lambda = Expression.Lambda(condition, parameter);

                modelBuilder.Entity(entityType.ClrType).HasQueryFilter(lambda);
            }

        }

        // Resto de tu código existente...
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<decimal>().HavePrecision(18, 2);
        }

        public override int SaveChanges()
        {
            EnsureAudit();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            EnsureAudit();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(string text, object? parameters = null, int? timeout = null, CommandType? type = null)
        {
           using var command = new DapperEFCoreCommand(this, text, parameters ?? new { }, timeout, type, CancellationToken.None);
           var connection = this.Database.GetDbConnection();
           return await connection.QueryAsync<T>(command.Definition);
        }

        public async Task<T?> QueryFirstOrDefaultAsync<T>(string text, object? parameters = null, int? timeout = null, CommandType? type = null)
        {
           using var command = new DapperEFCoreCommand(this, text, parameters ?? new { }, timeout, type, CancellationToken.None);
           var connection = this.Database.GetDbConnection();
           return await connection.QueryFirstOrDefaultAsync<T>(command.Definition);
        }        
        
        public IQueryable<T> GetActiveSet<T>() where T : class
        {
            var query = Set<T>().AsQueryable();
            var parameter = Expression.Parameter(typeof(T), "e");
            
            if (typeof(T).GetProperty("Status") != null)
            {
                try {
                    var property = Expression.Property(parameter, "Status");
                    var value = Expression.Constant(true);
                    var equal = Expression.Equal(property, value);
                    var lambda = Expression.Lambda<Func<T, bool>>(equal, parameter);
                    query = query.Where(lambda);
                }
                catch {
                    // Si hay algún error, devolvemos el query sin filtrar
                }
            }
            
            return query;
        }

        private static bool GetPropertyValue(object obj, string propertyName)
        {
            var property = obj.GetType().GetProperty(propertyName);
            if (property == null)
            {
                return false;
            }
            return property.GetValue(obj, null) is bool value ? value : false;
        }
        
        public IQueryable<T> GetPaged<T>(IQueryable<T> query, int page, int pageSize) where T : class
        {
            if (page <= 0) page = 1;
            if (pageSize <= 0) pageSize = 10;
            
            return query.Skip((page - 1) * pageSize).Take(pageSize);
        }
         
        public async Task<List<T>> ToListAsyncSafe<T>(IQueryable<T> query)
        {
            if (query == null)
                return new List<T>();
                
            return await EntityFrameworkQueryableExtensions.ToListAsync(query);
        }

        private void EnsureAudit()
        {
            ChangeTracker.DetectChanges();

            var entries = ChangeTracker.Entries()
                .Where(e => e.Entity is BaseEntity);

            var currentDateTime = DateTime.UtcNow;

            foreach (var entry in entries)
            {
                if (entry.Entity is BaseEntity entity)
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            entity.CreatedAt = currentDateTime;
                            entity.Status = true;
                            break;

                        case EntityState.Modified:
                            entity.UpdatedAt = currentDateTime;

                            // Detectar delete lógico: si Status fue cambiado a false
                            var statusProp = entry.Property("Status");
                            if (statusProp.IsModified && statusProp.CurrentValue is bool status && status == false)
                            {
                                entity.DeleteAt = currentDateTime;
                            }

                            break;

                        case EntityState.Deleted:
                            // Este es delete físico
                            entity.DeleteAt = currentDateTime;
                            entity.Status = false;
                            break;
                    }
                }
            }
        }

        public readonly struct DapperEFCoreCommand : IDisposable
        {
            public DapperEFCoreCommand(DbContext context, string text, object parameters, int? timeout, CommandType? type, CancellationToken ct)
            {
                var transaction = context.Database.CurrentTransaction?.GetDbTransaction();
                var commandType = type ?? CommandType.Text;
                var commandTimeout = timeout ?? context.Database.GetCommandTimeout() ?? 30;

                Definition = new CommandDefinition(
                    text,
                    parameters,
                    transaction,
                    commandTimeout,
                    commandType,
                    cancellationToken: ct
                );
            }

           public CommandDefinition Definition { get; }

           public void Dispose()
           {
           }
        }
    }
}