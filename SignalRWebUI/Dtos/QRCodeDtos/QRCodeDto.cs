using System.ComponentModel.DataAnnotations;

namespace SignalRWebUI.Dtos.QRCodeDtos
{
    public class QRCodeDto
    {
        [Display]
        [Required]
        public string QRCodeText { get; set; }
    }
}
