using Zee.Implementation.Repositories;
using Zee.Interface.Repositories;
using Zee.Interface.Services;
using Zee.Implementation.Service;
using Zee;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);


        // Add services to the container.
        builder.Services.AddControllersWithViews();


        builder.Services.AddDbContext<ZeeDbContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("ZeeConnection"));
        });
        builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(config =>
        {
            config.LoginPath = "/Zee/login";
            config.Cookie.Name = "Zee";
            config.LogoutPath = "/Zee/Logout";
        });
        builder.Services.AddDbContext<ZeeDbContext>();
    //     builder.Services.AddIdentity<User, IdentityRole>()
    // .AddEntityFrameworkStores<DbContext>()
    // .AddDefaultTokenProviders();


        builder.Services.AddAuthentication();
        builder.Services.AddSession();
        builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

        builder.Services.AddScoped<ICustomerService, CustomerService>();

        builder.Services.AddScoped<IUserRepository, UserRepository>();

        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddScoped<IAddressRepository, AddressRepository>();
        builder.Services.AddScoped<IAddressService, AddressService>();
        builder.Services.AddScoped<ISellerRepository, SellerRepository>();
        builder.Services.AddScoped<ISellerService, SellerService>();
        builder.Services.AddScoped<IDispatchRepository, DispatchRepository>();
        builder.Services.AddScoped<IDispatchService, DispatchService>();
        //  builder.Services.AddScoped<IOrderRepository, OrderRepository>();
        // builder.Services.AddScoped<IOrderService, OrderService>();

        builder.Services.AddScoped<ICartRepository, CartRepository>();
        builder.Services.AddScoped<ICartService, CartService>();
        builder.Services.AddScoped<ICartItemRepository, CartItemRepository>();
        builder.Services.AddScoped<ICartItemService, CartItemService>();
        builder.Services.AddScoped<IAdminRepository, AdminRepository>();
        builder.Services.AddScoped<IAdminService, AdminService>();
        builder.Services.AddScoped<IProductRepository, ProductRepository>();
        builder.Services.AddScoped<IProductService, ProductService>();
        builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
        builder.Services.AddScoped<IReviewService, ReviewService>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseSession();
        app.UseCookiePolicy();
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();

    }
}