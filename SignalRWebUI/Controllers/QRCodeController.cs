using IronBarCode;
using Microsoft.AspNetCore.Mvc;


namespace SignalRWebUI.Controllers
{

    public class QRCodeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string value)
        {
            //qrCode.ToPngBinaryData(): QR kodun binary data(byte array) olarak PNG formatında çıktı verir.
            //Convert.ToBase64String(...): PNG verisini Base64 string'e dönüştürür.
            //data: image / png; base64,: Base64 string'in başına bu MIME tipi eklenir, böylece bir tarayıcı bu string'i görüntü dosyası olarak tanır.

            // QR kodu oluştur
            //var qrCode = QRCodeWriter.CreateQrCode(value, 300); // 300: QR kodun boyutu (pixel)

            //// QR kodu Base64 string'e dönüştür
            //string qrCodeBase64 = "data:image/png;base64," + Convert.ToBase64String(qrCode.ToPngBinaryData());

            //// Base64 string'i ViewBag ile View'e taşı
            //ViewBag.QrCodeImage = qrCodeBase64;

            return View();
        }
    }
}
