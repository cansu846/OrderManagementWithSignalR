async Task yapısı, asenkron programlama paradigmasını kullanarak zaman alan işlemleri
(örneğin, dosya okuma/yazma, ağ üzerinden veri alma/gönderme) gerçekleştirmek için kullanılır. 
Bu yapı, özellikle UI uygulamalarında kullanıcı arayüzünün donmamasını sağlamak ve 
sunucuda birden fazla işlemi eşzamanlı yürütmek için yaygın olarak kullanılır.

async Task Nedir?
async: Bu anahtar kelime, bir yöntemin asenkron olduğunu belirtir.
Bu yöntem, await anahtar kelimesini içererek uzun süren işlemleri beklerken başka işlerin yapılabilmesine izin verir.
Task: Yöntemin bir değer döndürmediğini (void yerine) ama bir görev (Task) döndürdüğünü ifade eder.
Yöntem tamamlandıktan sonra görev durumu Completed, Faulted veya Cancelled olabilir.