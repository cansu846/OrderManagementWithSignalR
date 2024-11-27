using Entities.Concrete;
using Entities.Concrete.Pages;
using Entities.Pages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class SignalRDbContext : DbContext
    {
        //OnConfiguring yöntemi, bir DbContext örneği oluşturulurken
        //kullanılan veritabanı bağlantısı ve yapılandırmalarını belirlemek için kullanılır.
        //Bu yöntem, genellikle Dependency Injection kullanmadığınız durumlarda veya farklı Db ler ile çalışılacagı zaman,
        //yapılandırmayı doğrudan kod içinde tanımlamanız gerektiğinde devreye girer.

        /*
         DbContextOptions<EfDbContext>:

        EF Core'un, DbContext için veritabanı bağlantısı ve diğer yapılandırma bilgilerini içeren bir yapılandırma nesnesidir.
        Bu nesne, EF Core'un hangi veritabanı sağlayıcısını (SQL Server, SQLite vb.) ve bağlantı dizesini kullanacağını belirtir.
        options parametresi, EF Core tarafından AddDbContext çağrısı sırasında geçirilir.
        : base(options):

        Bu ifade, yapılandırma nesnesini EF Core'un DbContext taban sınıfına (base class) iletir.
        DbContext taban sınıfı, bu yapılandırmayı kullanarak veritabanı bağlantısını ve diğer ayarları oluşturur.

         */
        //public SignalRDbContext(DbContextOptions<SignalRDbContext> options)
        // : base(options)
        //{
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Eğer başka bir ayar yapılmamışsa, varsayılan ayarı uygula
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-3ADO5MC\SQLEXPRESS;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False", b => b.MigrationsAssembly("DataAccess"));
            }
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Feature> Features { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<OrderDetail> OrderDetails {get; set; }
		public DbSet<MoneyCase> MoneyCases { get; set; }
		public DbSet<MenuTable> MenuTables { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Basket> Baskets { get; set; }


    }
}
