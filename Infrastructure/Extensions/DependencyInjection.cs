using Core.Interfaces;
using Core.UseCases;
using Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Repositorios
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IProductoRepository, ProductoRepository>();
            services.AddScoped<IFacturaRepository, FacturaRepository>();
            services.AddScoped<IProveedorRepository, ProveedorRepository>();

            // Casos de uso
            services.AddScoped<CrearProveedorUseCase>();
            services.AddScoped<CrearClienteUseCase>();
            services.AddScoped<CrearProductoUseCase>();
            services.AddScoped<EditarClienteUseCase>();
            services.AddScoped<EliminarClienteUseCase>();
            services.AddScoped<ObtenerClientesUseCase>();
            services.AddScoped<ObtenerProductosUseCase>();
            services.AddScoped<ObtenerProductoActivossUseCase>();
            services.AddScoped<ObtenerFacturasUseCase>();
            services.AddScoped<ObtenerProveedoresUseCase>();
            services.AddScoped<ObtenerProveedoresActivosUseCase>();
            services.AddScoped<InsertarLoteUseCase>();
            services.AddScoped<ObtenerLoteProductosUseCase>();

            return services;
        }
    }
}