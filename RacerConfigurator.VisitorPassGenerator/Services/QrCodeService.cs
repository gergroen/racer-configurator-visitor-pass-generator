using QRCoder;
using System.Text.Json;
using RacerConfigurator.VisitorPassGenerator.Models;

namespace RacerConfigurator.VisitorPassGenerator.Services;

public class QrCodeService
{
    public string GenerateQrCodeBase64(VisitorData visitorData)
    {
        var json = JsonSerializer.Serialize(visitorData, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });
        
        using var qrGenerator = new QRCodeGenerator();
        using var qrCodeData = qrGenerator.CreateQrCode(json, QRCodeGenerator.ECCLevel.Q);
        using var qrCode = new PngByteQRCode(qrCodeData);
        
        var qrCodeBytes = qrCode.GetGraphic(20);
        return Convert.ToBase64String(qrCodeBytes);
    }
}
