using System.Collections.Generic;
using UMPG.USL.Models.Recs;

namespace DataHarmonizationProcessor.Data.Providers
{
    public interface IRecsDataProvider
    {
        List<WorksRecording> RetrieveTracksWithWriters(int productId);
        ProductHeader RetrieveProductHeader(int productId);
    }
}