using System.IO;
using UnityEngine;

namespace ASP.DataManager
{
    /// <summary>
    /// Handling data saved in json files on the user's device
    /// </summary>
    public static class Json
    {
        private static string dir, subdir, file, jsonData;

        /// <summary>
        /// Saves the data in a json file on the user's machine
        /// </summary>
        /// <typeparam name="T">Class that conforms to JsonUtility manipulation and is inherited from <see cref="IDatable"/></typeparam>
        /// <param name="data">Instance of class <typeparamref name="T"/></param>
        public static void Save<T>(T data) where T : IDatable
        {
            subdir = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
            dir = $"{Application.persistentDataPath}/Data/{subdir}";
            file = $"{dir}/{typeof(T)}.json";
            Directory.CreateDirectory(dir);
            jsonData = JsonUtility.ToJson(data, true);
            File.WriteAllText(file, jsonData);
        }
        /// <summary>
        /// Saves the data in a json file on the user's machine
        /// </summary>
        /// <typeparam name="T">Class that conforms to JsonUtility manipulation and is inherited from <see cref="IDatable"/></typeparam>
        /// <param name="data">Instance of class <typeparamref name="T"/></param>
        /// <param name="subDirectory">Path subdrictory to save</param>
        public static void Save<T>(T data, string subDirectory) where T : IDatable
        {
            subdir = subDirectory;
            dir = $"{Application.persistentDataPath}/Data/{subdir}";
            file = $"{dir}/{typeof(T)}.json";
            Directory.CreateDirectory(dir);
            jsonData = JsonUtility.ToJson(data, true);
            File.WriteAllText(file, jsonData);
        }
        /// <summary>
        /// Loads the data saved in a json file onto the user's machine
        /// </summary>
        /// <typeparam name="T">Class that conforms to JsonUtility manipulation and is inherited from <see cref="IDatable"/></typeparam>
        /// <returns>Returns an instance of class <typeparamref name="T"/> with the data embedded</returns>
        public static T Load<T>() where T : IDatable
        {
            subdir = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
            dir = $"{Application.persistentDataPath}/Data/{subdir}";
            file = $"{dir}/{typeof(T)}.json";

            if (File.Exists(file))
            {
                jsonData = File.ReadAllText(file);
                T data = JsonUtility.FromJson<T>(jsonData);
                return data;
            }
            else
            {
                Debug.LogWarning($"Json file not found in \"{file}\"");
                return default;
            }
        }
        /// <summary>
        /// Loads the data saved in a json file onto the user's machine
        /// </summary>
        /// <typeparam name="T">Class that conforms to JsonUtility manipulation and is inherited from <see cref="IDatable"/></typeparam>
        /// <returns>Returns an instance of class <typeparamref name="T"/> with the data embedded</returns>
        /// <param name="subDirectory">Path subdrictory to save</param>
        public static T Load<T>(string subDirectory) where T : IDatable
        {
            subdir = subDirectory;
            dir = $"{Application.persistentDataPath}/Data/{subdir}";
            file = $"{dir}/{typeof(T)}.json";

            if (File.Exists(file))
            {
                jsonData = File.ReadAllText(file);
                T data = JsonUtility.FromJson<T>(jsonData);
                return data;
            }
            else
            {
                Debug.LogWarning($"Json file not found in \"{file}\"");
                return default;
            }
        }
        /// <summary>
        /// Try Loads the data saved in a json file onto the user's machine
        /// </summary>
        /// <typeparam name="T">Class that conforms to JsonUtility manipulation and is inherited from <see cref="IDatable"/></typeparam>
        /// <param name="data">Instance of class</param>
        /// <returns>True if there is a json file within the parameters set by the class that inherits from <see cref="IDatable"/></returns>
        public static bool TryLoad<T>(out T data) where T : IDatable
        {
            subdir = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
            dir = $"{Application.persistentDataPath}/Data/{subdir}";
            file = $"{dir}/{typeof(T)}.json";

            if (File.Exists(file))
            {
                jsonData = File.ReadAllText(file);
                data = JsonUtility.FromJson<T>(jsonData);
                return true;
            }
            else
            {
                data = default;
                return false;
            }
        }
        /// <summary>
        /// Try Loads the data saved in a json file onto the user's machine
        /// </summary>
        /// <typeparam name="T">Class that conforms to JsonUtility manipulation and is inherited from <see cref="IDatable"/></typeparam>
        /// <param name="data">Instance of class</param>
        /// <returns>True if there is a json file within the parameters set by the class that inherits from <see cref="IDatable"/></returns>
        /// <param name="subDirectory">Path subdrictory to save</param>
        public static bool TryLoad<T>(out T data, string subDirectory) where T : IDatable
        {
            subdir = subDirectory;
            dir = $"{Application.persistentDataPath}/Data/{subdir}";
            file = $"{dir}/{typeof(T)}.json";

            if (File.Exists(file))
            {
                jsonData = File.ReadAllText(file);
                data = JsonUtility.FromJson<T>(jsonData);
                return true;
            }
            else
            {
                data = default;
                return false;
            }
        }
    }
}