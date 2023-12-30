using Adressbok_Shared.Enums;
using Adressbok_Shared.Interface;

namespace Adressbok_Shared.Services;
public class ServiceResult : IServiceResult
{
    public ServiceStatus Status { get; set; }
    public object Result { get; set; } = null!;
}
