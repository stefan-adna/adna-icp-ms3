using EdjCase.ICP.Agent.Agents;
using EdjCase.ICP.Agent.Identities;
using EdjCase.ICP.Agent.Standards.AssetCanister;
using EdjCase.ICP.Candid.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Adna.Bll.Icp
{
    public class ICPConnector : IICPConnector
    {
        private readonly string _baseUrl;
        private readonly string _cannisterId;

        public ICPConnector(IConfiguration config)
        {
            var configSection = config.GetSection("Icp");
            _baseUrl = configSection["BaseUrl"];
            _cannisterId = configSection["CannisterUrl"];
        }

        public async Task<byte[]> DownloadDocument(string identifier)
        {
            var client = CreateClient();
            try
            {
                var result = await client.DownloadAssetAsync(identifier);
                return result.Asset;
            }
            catch (Exception e)
            {
                return [];
            }
        }

        public async Task<bool> UploadDocument(string identifier, byte[] fileContent)
        {
            var client = CreateClient();

            var ms = new MemoryStream(fileContent);

            await client.UploadAssetChunkedAsync(
                key: identifier,
                contentType: "text/plain",
                contentEncoding: "br",
                contentStream: ms,
                sha256: null
            );

            return true;
        }
    }
}
