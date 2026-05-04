using Domain.Models.History;
using Web.Response.History_Response;

namespace Web.Extensions;

public static class HistoryExtensions
{
    public static PlantScanResponse ToPlantScanResponse(this PlantScanHistory plantScanHistory)
    {
        return new PlantScanResponse(
            Id: plantScanHistory.Id,
            UserId: plantScanHistory.UserId,
            ScannedAt: plantScanHistory.ScannedAt,
            ResultText: plantScanHistory.ResultText
        );
    }

    public static DiseaseScanResponse ToDiseaseScanResponse(this DiseaseScanHistory diseaseScanHistory)
    {
        return new DiseaseScanResponse(
            diseaseScanHistory.Id,
            diseaseScanHistory.UserId,
            diseaseScanHistory.ScannedAt,
            diseaseScanHistory.ResultText
        );
    }
}