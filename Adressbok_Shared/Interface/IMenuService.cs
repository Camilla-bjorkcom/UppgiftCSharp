using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adressbok_Shared.Interface;

public interface IMenuService
{
    /// <summary>
    /// Shows a menu with options the user chooses from and then applies further methods/services depending on which choice is made
    /// </summary>
    void ShowMainMenu();

}
