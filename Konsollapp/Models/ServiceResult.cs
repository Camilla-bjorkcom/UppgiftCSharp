
using Konsollapp_adressbok.Enums;
using Konsollapp_adressbok.Interface;

namespace Konsollapp_adressbok.Models;
public class ServiceResult : IServiceResult
{
    public ServiceStatus Status { get; set; }
    public object Result { get; set; } = null!;
}
