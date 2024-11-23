using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using WebApi.Mapping;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
//    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
//// AddDbContext: DbContext sınıfını, ASP.NET Core uygulamasının hizmet sağlayıcısına (service provider) kaydeder.
//builder.Services.AddDbContext<SignalRDbContext>(options =>
//    options.UseSqlServer(connectionString, b => b.MigrationsAssembly("WebApi")));

builder.Services.AddAutoMapper(typeof(AboutMapping));
builder.Services.AddAutoMapper(typeof(BookingMapping));
builder.Services.AddAutoMapper(typeof(CategoryMapping));
builder.Services.AddAutoMapper(typeof(ProductMapping));
builder.Services.AddAutoMapper(typeof(ContactMapping));


builder.Services.AddDbContext<SignalRDbContext>();

builder.Services.AddScoped<IAboutService, AboutManager>();
builder.Services.AddScoped<IAboutDal, EfAboutDal>();

builder.Services.AddScoped<IBookingService, BookingManager>();
builder.Services.AddScoped<IBookingDal, EfBookingDal>();

builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<ICategoryDal, EfCategoryDal>();

builder.Services.AddScoped<IProductService, ProductManager>();
builder.Services.AddScoped<IProductDal, EfProductDal>();

builder.Services.AddScoped<IContactService, ContactManager>();
builder.Services.AddScoped<IContactDal, EfContactDal>();


//builder.Services.AddScoped<IContactService, ContactManager>();
//builder.Services.AddScoped<IContactDal, EfContactDal>();

//builder.Services.AddScoped<IDiscountService, DiscountManager>();
//builder.Services.AddScoped<IDiscountDal, EfDiscountDal>();

//builder.Services.AddScoped<IFeatureService, FeatureManager>();
//builder.Services.AddScoped<IFeatureDal, EfFeatureDal>();

//builder.Services.AddScoped<ISocialMediaService, SocialMediaManager>();
//builder.Services.AddScoped<ISocialMediaDal, EfSocialMediaDal>();

//builder.Services.AddScoped<ITestimonialService, TestimonialManager>();
//builder.Services.AddScoped<ITestimonialDal, EfTestimonialDal>();







// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
