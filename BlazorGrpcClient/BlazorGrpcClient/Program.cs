using BlazorGrpcClient.Components;
using Grpc.Net.Client;
using Grpc.Net.Client.Web;
using BlazorGrpcClient;
using System.Threading.Channels;
namespace BlazorGrpcClient
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents()
                .AddInteractiveWebAssemblyComponents();
            builder.Services.AddHttpClient();

            builder.Services.AddScoped(services =>
            {
                var httpClientHandler = new GrpcWebHandler(GrpcWebMode.GrpcWebText, new HttpClientHandler());
                var grpcChannel = GrpcChannel.ForAddress("http://localhost:5000/", new GrpcChannelOptions { HttpHandler = httpClientHandler });
                return new Greeter.GreeterClient(grpcChannel); // Убедитесь, что GreeterClient правильно сгенерирован
                
            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode()
                .AddInteractiveWebAssemblyRenderMode()
                .AddAdditionalAssemblies(typeof(Client._Imports).Assembly);

            app.Run();
        }
    }
}
