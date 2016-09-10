using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

/// <summary>
/// The Data Manager component. Handles saving and loading data to the persistent datapath.
/// http://docs.unity3d.com/ScriptReference/Application-persistentDataPath.html
/// </summary>
public static class DataManager
{
    /// <summary>
    /// Saves the data.
    /// </summary>
    /// <typeparam name="T">The type of the data object to save.</typeparam>
    /// <param name="data">The data.</param>
    /// <param name="fileName">Name of the file.</param>
    public static void SaveData<T>(T data, string fileName)
        where T : class
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(
            string.Format("{0}/{1}.dat", Application.persistentDataPath, fileName),
            FileMode.OpenOrCreate);
        bf.Serialize(file, data);
        file.Close();
    }

    /// <summary>
    /// Loads the data.
    /// </summary>
    /// <typeparam name="T">The type of the data object to load.</typeparam>
    /// <param name="fileName">Name of the file.</param>
    /// <returns>The file loaded as the provided type.</returns>
    public static T LoadData<T>(string fileName)
        where T : class
    {
        string path = string.Format("{0}/{1}.dat", Application.persistentDataPath, fileName);
        if (File.Exists(path))
        {
            var bf = new BinaryFormatter();
            var file = File.Open(path, FileMode.Open);
            var data = (T)bf.Deserialize(file);
            file.Close();

            return data;
        }

        return null;
    }
}