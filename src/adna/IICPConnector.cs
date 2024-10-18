using System.Threading.Tasks;

namespace Adna.Bll.Icp
{
    public interface IICPConnector
    {
        public Task<bool> UploadDocument(string identifier, byte[] fileContent);
        public Task<byte[]> DownloadDocument(string identifier);
    }
}
