using P013AspNetMVCEgitim.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<UyeContext>();    //bu sat�r� sanal veri taban� kullanabilmek i�in ekledik

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection(); //uygulama http isteklerini https ile g�venli ba�lant�ya y�nlendirmeyi desteklesin
app.UseStaticFiles(); //uygulama statik dosyalar�(wwwroot klas�r�ndekiler) desteklesin

app.UseRouting(); //uygulama routing ile y�nlendirmeyi kullans�n

app.UseAuthentication(); //uygulam kullan�c� giri� sistemini aktif etsin
app.UseAuthorization(); //uygulama kullan�c� yetkilendime(admin, user) sistemini aktif etsin

app.MapControllerRoute( //uygulaman�n kullanaca�� routing y�nlendirme ayar�
    name: "default", //route ad�
    pattern: "{controller=Home}/{action=Index}/{id?}"); // e�er adres �ubu�undan uygulama bir controller ad� ve action ad� g�nderilmezse varsay�lan olarak Home controlleri ve i�indeki index isimli action� �al��t�rs�n. Id de�eri ise ? i�areti ile parametrik yani iste�e ba�l� belirtilmi�

app.Run(); //uygulamay� yukar�daki ayarlar� kullanarak �al��t�r
