using System.Threading.Tasks;

namespace Mmu.Mlazh.TfsProxy.Application.Common.Infrastructure.AzureFiles.Services
{
    public interface IFileService
    {
        Task AppendAsync(string text);
    }
}