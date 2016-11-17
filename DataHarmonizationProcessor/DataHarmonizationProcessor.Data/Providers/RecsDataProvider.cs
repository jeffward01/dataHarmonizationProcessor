using System.Collections.Generic;
using UMPG.USL.Models.Recs;

namespace DataHarmonizationProcessor.Data.Providers
{
    public class RecsDataProvider : IRecsDataProvider
    {
        private readonly IRecsProvider _recs;

        public RecsDataProvider(IRecsProvider recsProvider)
        {
            _recs = recsProvider;
        }

        public List<WorksRecording> RetrieveTracksWithWriters(int productId)
        {
            return _recs.RetrieveTracksWithWriters(productId);
        }

        public ProductHeader RetrieveProductHeader(int productId)
        {
            var product = _recs.RetrieveProductHeader(productId);
            return product;
        }
    }
}