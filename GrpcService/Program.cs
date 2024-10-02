using Grpc.AspNetCore.Web;
using GrpcService.Services; // ����������� ������������ ���� ������ �������

namespace GrpcService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddGrpc();

            var app = builder.Build();
            // �������� ��������� gRPC-Web
            app.UseGrpcWeb(new GrpcWebOptions { DefaultEnabled = true });
            // Configure the HTTP request pipeline.
            app.MapGrpcService<GreeterService>().EnableGrpcWeb(); // ����������� EnableGrpcWeb() ��� ���������� gRPC-Web �� ������ ����������� �������
            app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

            app.Run();
        }
    }
}