using Konsollapp_adressbok.Enums;

namespace Konsollapp_adressbok.Interface
{
    public interface IServiceResult
    {
        object Result { get; set; }
        ServiceStatus Status { get; set; }
    }
}