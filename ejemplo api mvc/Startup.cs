namespace ejemplo_api_mvc
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Otras configuraciones...

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                // Agrega tu ruta personalizada aquí
                endpoints.MapControllerRoute(
                    name: "country",
                    pattern: "Country/Index", // La URL que deseas asignar
                    defaults: new { controller = "Country", action = "Index" }); // Controlador y acción correspondientes
            });
        }

    }
}
