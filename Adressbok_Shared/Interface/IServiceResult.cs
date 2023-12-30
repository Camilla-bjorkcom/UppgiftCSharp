using Adressbok_Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adressbok_Shared.Interface;

public interface IServiceResult
{

    /// <summary>
    /// Represents the result of a service operation, including a result object and the status of the operation.
    /// </summary>
    object Result { get; set; }
    ServiceStatus Status { get; set; }
}