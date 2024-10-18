//only a very small part of this file is shown here as Adna is not open-source

namespace Adna.Bll.DocumentsBll
{
    public class DocumentsBll : IDocumentsBll 
    {
        private readonly IICPConnector _icpConnector;

        public DocumentsBll(IICPConnector icpConnector)
        {
            _icpConnector = icpConnector;
        }
        private async Task UploadRevision(DocumentRevision documentRevision, Guid companyId) 
        {
            //store document in icp
            await _icpConnector.UploadDocument(documentRevision.Id.ToString().ToLower(), documentRevision.Data);
        }

        private async Task GetRevision(DocumentRevision documentRevision) 
        {
            //retrieve document from icp
            var assetFromCannister = await _icpConnector.DownloadDocument(documentRevision.Id.ToString().ToLower());
        }
    }
}