using DataHarmonizationProcessor.Data.RecsConfiguration;
using System.Collections.Generic;
using UMPG.USL.Common.Transport;
using UMPG.USL.Models.Recs;

namespace DataHarmonizationProcessor.Data.Providers
{
    public class RecsProvider : IRecsProvider
    {
        private readonly IRecsRequestHandler _recsRequestHandler;
        private readonly IRecsConfigurationRetrieverService _recsConfigurationRetriever;

        public RecsProvider(IRecsRequestHandler recsRequestHandler, IRecsConfigurationRetrieverService recsConfigurationRetriever)
        {
            _recsConfigurationRetriever = recsConfigurationRetriever;
            _recsRequestHandler = recsRequestHandler;
        }

        public List<WorksRecording> RetrieveTracksWithWriters(int productId)
        {
            const string countryCode = "US2";
            var url =
                $"{_recsConfigurationRetriever.RecsConfiguration.UnSecureUrl}/http/recs/product/trackListingWithWriters/{productId}/{countryCode}";
            return _recsRequestHandler.Get<List<WorksRecording>>(url);
        }

        public ProductHeader RetrieveProductHeader(int productId)
        {
            var url = string.Format("{0}/http/recs/product/header/{1}", _recsConfigurationRetriever.RecsConfiguration.UnSecureUrl, productId);
            return _recsRequestHandler.Get<ProductHeader>(url);
        }
    }
}