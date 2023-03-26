
using Microsoft.EntityFrameworkCore;

namespace P013AspNetMVCEgitim.Models
{
    //InMemoryDb Kullanabilmek için projeye sağ tık nuget package manager menüsünü aç
    //installed yüklü olanları gösterir browse den gerekli eklentiyi buluruz
    //orandan EntityFrameworkCore.desing ve EntityFrameworkCore.InMemory Paketlerini yüklüyoruz
    //controllera gidip UyeListesine add view diyip sonrasında razor view seçip gerekli alanları girip view ekliyoruz
    public class UyeContext :DbContext
    {
        public DbSet<Uye> Uyes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //EntityFrameworkCore veritabanı işlemleri için yapılandırma ayarlarını yapabildiğimiz metot
            optionsBuilder.UseInMemoryDatabase("InMemoryDb"); //bilgisayarımızın ram belleğini sanal veritabanı olarak kullanmasını sağlayan ayarı yaptık
            //bu ayardan sonra projemizin program.cs classına gidip bu UyeContext Sınıfını servis olarak ekliyoruz
            base.OnConfiguring(optionsBuilder);
        }
    }
}
