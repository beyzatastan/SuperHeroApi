using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SuperHeroApi.Data;
using SuperHeroApi.Models;
using SuperHeroApi.Services;

var builder = WebApplication.CreateBuilder(args);
//Bu satır, uygulamanızın yapılandırma ve servis ekleme işlemleri için
//bir WebApplicationBuilder oluşturur.
//args, uygulamanın komut satırı argümanlarını içerir (örneğin, --urls gibi).

// Servisleri ekleyin
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ISuperHeroService, SuperHeroService>();
builder.Services.AddDbContext<DataContext>();
var app = builder.Build();

// Swagger'ı etkinleştir - Hem Development hem de Production ortamında
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "SuperHero API V1");
    c.RoutePrefix = string.Empty; // Swagger UI'ye root URL'den erişmek için
});

 // safari buna izin vermiyo app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
/*
 AddControllers(): MVC ve API denetleyicileri
 (controllers) için gerekli olan hizmetleri ekler.
 API denetleyicileri bu hizmetler aracılığıyla çalışır.

 AddEndpointsApiExplorer(): API uç noktalarını
 (endpoints) keşfetmek için gerekli olan hizmeti ekler.
 Swagger ve diğer araçlar bu bilgiyi kullanır.

 AddSwaggerGen(): Swagger belgeleri oluşturmak
  için gerekli olan hizmeti ekler.
  Bu, API'nizin otomatik olarak belgelenmesini sağlar.

  Bu satır, WebApplicationBuilder'dan bir WebApplication oluşturur.
   Artık uygulamanızın orta katman yazılımlarını ve yönlendirmelerini yapılandırabilirsiniz.

   c.SwaggerEndpoint("/swagger/v1/swagger.json", "SuperHero API V1"): Swagger JSON belgelerinin
   bulunduğu endpoint'i belirtir.
   c.RoutePrefix = string.Empty: Swagger UI'nin kök (root) URL'den erişilmesini sağlar.
   Örneğin, uygulamanız http://localhost:5000/ adresinde çalışıyorsa,
   Swagger UI de bu adres üzerinden erişilebilir.
 */