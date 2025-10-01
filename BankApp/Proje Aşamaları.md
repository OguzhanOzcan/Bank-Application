# **Öncelik: Angular (ClientApp)**


UI tasarımı ve sayfa akışını netleştiririz.

Servisler ve HTTP endpoint ihtiyaçlarını daha net görürüz.

**Layout component’lerini oluştur ve test et**

* Navbar ve Footer component’leri.
* AppComponent içinde <app-navbar> ve <app-footer> ekle.
* Basit statik linkler ile yönlendirme testi yap.



**Feature module’leri oluştur**

* credit-calculator, credit-application, about module’lerini ve component’lerini hazırla.
* app-routing.module.ts ile route’ları bağla.
* Test: Linklere tıklandığında ilgili component açılıyor mu?



**Shared ve Core modüllerini oluştur**

* Shared: Kaydırılabilir kart (scroll-card) component’i.
* Core: credit.service.ts ve bank.service.ts.
* Test: Servisler injectable mı, component içinde kullanılabiliyor mu?



**Sayfa tasarımlarını yap**

* credit-calculator sayfasında input alanları ve “Hesapla” butonu.
* credit-application sayfasında form alanları ve “Başvur” butonu.
* Sağ taraftaki kaydırılabilir kartlar (bankalar ve popüler krediler).



**HTTP servislerini mock ile test et**

* Backend hazır değilken Angular içinde servisleri mock data ile çalıştır.
* Test: Kredi hesaplama ve kredi başvuru verileri component’e geliyor mu?



---------------------------------------------------------------------------------------------------------------------------------------------



# **Backend (ServerApp)**





**DbContext ve veri modellerini hazırla**

* CreditApplication, LoanProduct, PaymentPlanItem.
* Migration ekle (dotnet ef migrations add InitialCreate) ve veritabanını oluştur.



**Servis sınıflarını hazırla**

* CreditService: kredi hesaplama mantığını buraya koy.
* Test: Console veya Postman ile direkt servis çağır ve doğru sonuç dönüyor mu?



**Controller’ları oluştur**

* CreditController → kredi hesaplama ve başvuru endpoint’leri (POST /calculate, POST /apply).
* BankController → banka listesi ve popüler krediler endpoint’leri (GET /banks, GET /popular-loans).



**Minimal API yerine Controller kullanmak istersen**

* .NET 6+’da AddControllers() kullan ve MapControllers() ile route’ları aç.
* Test: Postman ile endpoint’ler çalışıyor mu?





Angular + .NET Entegrasyonu



**Angular servislerinde HTTPClient ile backend endpoint’lerine bağlan.**

* Örnek: credit.service.ts → GET /banks, POST /calculate.



**Component’lerde veri gösterimi:**

* Kredi hesaplama sonucu tabloya yansısın.
* Başvuru sonrası alert gösterilsin.



**Test ve hata kontrolü:**

* Hem frontend hem backend çalışıyor mu, network istekleri doğru mu?



**Styling ve bootstrap:**

* Kaydırılabilir kartlar, responsive tasarım ve genel UI.







