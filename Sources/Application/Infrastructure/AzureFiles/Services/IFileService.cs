using System.Threading.Tasks;

namespace Mmu.Mlazh.TfsProxy.Application.Infrastructure.AzureFiles.Services
{
    public interface IFileService
    {
        Task AppendAsync(string text);
    }
}