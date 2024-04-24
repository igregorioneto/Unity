using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SavePoint
{
    private static string path = Application.dataPath + "/log.txt";
    private static string content = "";
    public void FilePersistence(int life, int point, string position)
    {
        try
        {
            content += $"\tLife: {life}\tPoint:{point}\tPosition Player in World: {position}\n";

            using(StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(content);
            }
        }
        catch (IOException ex)
        {
            Debug.LogError($"Erro ao acessar o arquivo: {ex.Message}");
        }
    }

    public string FileRead()
    {
        using (StreamReader reader = new StreamReader(path))
        {
            return reader.ReadToEnd();
        }
    }
}
