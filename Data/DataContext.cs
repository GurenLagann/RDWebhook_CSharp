using Microsoft.EntityFrameworkCore;
using SugarApi.Models;

namespace SugarApi.Data {
  public class DataContext : DbContext {
    public DataContext(DbContextOptions<DataContext> options)
      :base(options)
    {   
    }

    public DbSet<Sugar> Sugar {get; set;}
  }
    
}