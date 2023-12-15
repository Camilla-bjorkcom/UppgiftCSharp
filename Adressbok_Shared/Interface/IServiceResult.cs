using Adressbok_Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adressbok_Shared.Interface;

public interface IServiceResult
{
    object Result { get; set; }
    ServiceStatus Status { get; set; }
}