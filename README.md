# Satellite Anomaly Detector

Bu proje, telemetri verilerini analiz ederek anomali tespiti yapan bir **Blazor Server** uygulamasıdır. Uygulama, makine öğrenmesi API'si ile entegre çalışarak gerçek zamanlı anomali tespiti yapar.

## 🚀 Özellikler

- **Gerçek Zamanlı Anomali Tespiti**: Telemetri verilerini sürekli analiz eder
- **Manuel Anomali Tespiti**: Kullanıcı tarafından manuel veri girişi ile anomali tespiti
- **Veritabanı Entegrasyonu**: PostgreSQL ile veri saklama ve yönetimi
- **Modern Web Arayüzü**: Blazor Server teknolojisi ile responsive tasarım
- **Veri Görselleştirmesi**: Telemetri verilerinin tablo formatında görüntülenmesi
- **Etiket Düzenleme**: Anomali etiketlerini düzenleme özelliği

## 🛠️ Teknolojiler

- **Backend**: ASP.NET Core 8.0, Blazor Server
- **Frontend**: Blazor Components, Bootstrap, Font Awesome
- **Veritabanı**: PostgreSQL
- **ORM**: Entity Framework Core
- **ML Integration**: HTTP API entegrasyonu
- **Cloud Infrastructure**: Azure Virtual Machine
- **Real-time**: SignalR (hazır yapılandırma)

## 📋 Gereksinimler

- .NET 8.0 SDK
- PostgreSQL Server
- Python ML API (anomali tespit servisi)

## ⚙️ Kurulum

### 1. Projeyi İndirin
```bash
git clone https://github.com/canertunc/satellite-anomaly-detector
cd satellite-anomaly-detector
```

### 2. PostgreSQL Veritabanını Hazırlayın
```sql
-- PostgreSQL'de veritabanı oluşturun
CREATE DATABASE TelemetryDb;
```

### 3. Bağlantı Ayarlarını Yapılandırın
`appsettings.json` dosyasındaki veritabanı bağlantı dizesini güncelleyin:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Database=TelemetryDb;Username=postgres;Password=YourPassword"
  }
}
```

### 4. Veritabanı Migration'larını Uygulayın
```bash
dotnet ef database update
```

### 5. ML API Servisini Başlatın
ML API servisi **Azure Virtual Machine** üzerinde çalışmaktadır ve `http://9.223.178.203:5001/predict` adresinde erişilebilir durumdadır.

### 6. Uygulamayı Çalıştırın
```bash
dotnet run
```

Uygulama `https://localhost:5001` adresinde çalışacaktır.

## 📊 Veri Modeli

### Telemetri Özellikleri
Uygulama aşağıdaki telemetri özelliklerini analiz eder:

- **İstatistiksel Özellikler**: Mean, Variance, Standard Deviation, Kurtosis, Skewness
- **Zaman Serisi Özellikleri**: Duration, Length, Peaks, Smoothed Peaks
- **Türev Özellikleri**: Difference Peaks, Difference Variance
- **Hesaplanan Özellikler**: Length Weighted, Gaps Squared, Variance Ratios

### Veri Tabloları
- **TelemetryRaw**: Ham telemetri verileri
- **TelemetryLabeled**: Etiketlenmiş ve işlenmiş veriler
- **TelemetryTraining**: Eğitim için hazırlanmış veriler

## 🖥️ Kullanım

### Ana Arayüz (`/interface`)

#### Anomali Tespiti
1. **Start Detection**: Otomatik anomali tespitini başlatır
2. **Stop Detection**: Tespit işlemini durdurur
3. **Manual Detect**: Manuel veri girişi ile anomali tespiti

#### Veri Yönetimi
- **Fix Label**: Anomali etiketlerini düzenleme modu
- **Send All**: Tüm verileri eğitim setine gönder
- **Clear All**: Tüm verileri temizle

### Manuel Anomali Tespiti
1. "Manual Detect" butonuna tıklayın
2. Telemetri özelliklerini girin
3. "Add & Detect" ile anomali tespiti yapın

## 🤖 Makine Öğrenmesi Modeli

### Model Mimarisi
Bu projede **FCNN (Fully Connected Neural Network)** mimarisi kullanılarak geliştirilen özel bir anomali tespit modeli kullanılmaktadır. Model, [OPSSAT-AD veri seti](https://zenodo.org/records/15108715) kullanılarak eğitilmiştir. Notebooks klasörü altında yer alan fcnn.ipynb dosyasında, FCNN mimarisiyle eğittiğim geliştirme kodlarına ulaşabilirsiniz.

### Veri Seti
Proje, Avrupa Uzay Ajansı (ESA) tarafından işletilen OPS-SAT CubeSat misyonundan elde edilen telemetri verilerini içeren **OPSSAT-AD** veri setini kullanmaktadır. Bu veri seti:
- ESA OPS-SAT uydusundan alınan gerçek telemetri sinyalleri
- Manuel olarak bölümlendirilmiş ve etiketlenmiş telemetri segmentleri
- Anomali tespiti için özel olarak hazırlanmış sentetik özellikler
- 30 farklı denetimli ve denetimsiz makine öğrenmesi algoritması ile benchmark sonuçları

### Model Performansı
FCNN modeli aşağıdaki test sonuçlarına ulaşmıştır:

| Metrik | Değer |
|--------|-------|
| **Doğruluk (Accuracy)** | **98.11%** |
| **Kesinlik (Precision)** | **96.40%** |
| **Duyarlılık (Recall)** | **94.69%** |
| **F1 Skoru** | **95.54%** |

**📈 Performans Karşılaştırması**: Bu sonuçlar, [orijinal OPSSAT-AD benchmark çalışmasında](https://arxiv.org/abs/2407.04730) test edilen 30 farklı denetimli ve denetimsiz makine öğrenmesi algoritmasından **daha yüksek doğruluk oranı** elde ettiğini göstermektedir. Geliştirilen FCNN modeli, benchmark çalışmasındaki en iyi sonuçları aşarak **state-of-the-art** performans sergilemektedir.

**🔬 Gelecek Çalışmalar**: Bu başarılı sonuçlara rağmen, doğruluk oranını daha da yükseltmek için farklı model yaklaşımları üzerinde çalışmalar devam etmektedir. Bu kapsamda ensemble yöntemler, derin öğrenme mimarileri ve hibrit modeller araştırılmaktadır.

## 🔧 API Entegrasyonu

Uygulama, geliştirilen FCNN modeli ile aşağıdaki format üzerinden iletişim kurar:

**Request:**
```json
{
  "values": [feature1, feature2, ..., feature18]
}
```

**Response:**
```json
{
  "prediction": 0 // 0: Normal, 1: Anomaly
}
```

## 🎨 Arayüz Özellikleri

- **Responsive Tasarım**: Tüm cihazlarda uyumlu
- **Gerçek Zamanlı Güncelleme**: Blazor Server ile anlık veri güncellemesi
- **Animasyonlar**: CSS animasyonları ile görsel efektler
- **Modern UI**: Bootstrap ve Font Awesome ile modern görünüm

## 📁 Proje Yapısı

```
AnomalyDetectionApp/
├── Components/
│   ├── Pages/
│   │   ├── Home/
│   │   └── Interface/
│   └── Layout/
├── Data/
│   └── AppDbContext.cs
├── Models/
│   ├── TelemetryModel.cs
│   ├── TelemetryLabeledModel.cs
│   ├── TelemetryRawModel.cs
│   └── TelemetryTrainingModel.cs
├── Migrations/
├── Helpers/
├── notebooks/
│   └── fcnn.ipynb
├── Hubs/
└── wwwroot/
    ├── css/
    ├── images/
    └── font-awesome/
```

## 🔍 Önemli Notlar

- ML API servisi sürekli çalışmalıdır
- PostgreSQL bağlantısı aktif olmalıdır
- Gerçek zamanlı tespit sırasında veriler 1 saniyelik aralıklarla işlenir
- Segment değerleri timestamp formatında (`yyyyMMddHHmmssfff`) otomatik oluşturulur

## 📚 Akademik Referanslar

Bu proje, aşağıdaki akademik kaynaklardan yararlanmıştır:

### Veri Seti
- **OPSSAT-AD Dataset**: Ruszczak, B., Kotowski, K., Evans, D., Nalepa, J. (2024). *OPSSAT-AD - anomaly detection dataset for satellite telemetry*. Zenodo. [https://doi.org/10.5281/zenodo.15108715](https://zenodo.org/records/15108715)

### İlgili Yayınlar
- Ruszczak, B., Kotowski, K., Nalepa, J., Evans, D. (2024). *The OPS-SAT benchmark for detecting anomalies in satellite telemetry*. arXiv preprint arXiv:2407.04730.
- Ruszczak, B., Kotowski, K., Andrzejewski, J., et al. (2023). *Machine Learning Detects Anomalies in OPS-SAT Telemetry*. Computational Science – ICCS 2023. LNCS, vol 14073. Springer, Cham.
