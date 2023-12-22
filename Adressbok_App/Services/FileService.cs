using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adressbok_App.Services;

public class FileService
{
    public string GetContentFromFile(string filePath)
    {
        try
        {
            if (File.Exists(filePath))
            {
                using (var sr = new StreamReader(filePath))
                {
                    return sr.ReadToEnd();
                }
            }

        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        {
            return null!;
        }
    }

    public bool SaveContentToFile(string content, string filePath)
    {
        try
        {
            using (var sw = new StreamWriter(filePath))
            {
                sw.WriteLine(content);
            }

            return true;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        {
            return false;
        }
    }
}
