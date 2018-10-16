using System;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.File;

namespace Mmu.Mlazh.TfsProxy.Application.Infrastructure.AzureFiles.Services.Implementation
{
    public class FileService : IFileService
    {
        public async Task AppendAsync(string text)
        {
            var baseUrl = new Uri("https://drmueller.file.core.windows.net/");
            var credentials = new StorageCredentials("drmueller", "JsrpGmmNdRByJrYirJ40XYotlPC9q2DsI7P2K2IaoCdTAUn6afDIEicRkP2qVszIMHDZklD8lxhEnDiFzfhctA==");

            var client = new CloudFileClient(baseUrl, credentials);
            var share = client.GetShareReference("mmu");

            var rootDir = share.GetRootDirectoryReference();
            var fileRef = rootDir.GetFileReference("Testmmu");
            await fileRef.UploadTextAsync(text);
        }
    }
}