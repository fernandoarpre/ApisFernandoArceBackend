using Business.Customer;
using Business.Email;
using Business.Home;
using Business.Login;
using Business.Sales;
using Business.Users;
using Data.Repository.Customer;
using Data.Repository.Home;
using Data.Repository.Login;
using Data.Repository.Sales;
using Data.Repository.Users;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiVentas.Providers
{
    public static class DependencyInjections
    {
		public static void Register(IServiceCollection service)
		{
			//Business Class.!
			service.AddScoped<ILoginBusiness, LoginBusiness>();
			service.AddScoped<ICustomerBusiness, CustomerBusiness>();
			service.AddScoped<ISalesBusiness, SalesBusiness>();
			service.AddScoped<IUsersBusiness, UsersBusiness>();
			service.AddScoped<IEmailService, EmailService>();
			service.AddScoped<IHomeBusiness, HomeBusiness>();

			//Data Repository Class.!
			service.AddScoped<ILoginRepository, LoginRepository>();
			service.AddScoped<ICustomerRepository, CustomerRepository>();
			service.AddScoped<ISalesRepository, SalesRepository>();
			service.AddScoped<IUsersRepository, UsersRepository>();
			service.AddScoped<IHomeRepository, HomeRepository>();
		}
	}
}
