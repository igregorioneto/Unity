using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class AuthManager : MonoBehaviour
{
    public static AuthManager instance;

    private void Awake() {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private readonly string urlRegister = "http://localhost:5046/register";
    private readonly string urlLogin = "http://localhost:5046/login";

    public static void RegisterUser(string username, string password)
    {
        instance.StartCoroutine(instance.RegisterUserAsync(username, password));   
    }

    private IEnumerator RegisterUserAsync(string username, string password)
    {
        var user = new UserData();
        user.username = username;
        user.password = password;

        string json = JsonUtility.ToJson(user);

        var req = new UnityWebRequest(urlRegister, "POST");
        byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
        req.uploadHandler = new UploadHandlerRaw(jsonToSend);
        req.downloadHandler = new DownloadHandlerBuffer();
        req.SetRequestHeader("Content-Type", "application/json");

        yield return req.SendWebRequest();

        if (req.isNetworkError)
        {
            Debug.Log("Error While Sending: " + req.error);
        }
        else
        {
            Debug.Log("Received: " + req.downloadHandler.text);
        }
    }

    public static void LoginUser(string username, string password)
    {
        instance.StartCoroutine(instance.LoginUserAsync(username, password));
    }

    private IEnumerator LoginUserAsync(string username, string password)
    {
        var user = new UserData();
        user.username = username;
        user.password = password;

        string json = JsonUtility.ToJson(user);

        var req = new UnityWebRequest(urlLogin, "POST");
        byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
        req.uploadHandler = new UploadHandlerRaw(jsonToSend);
        req.downloadHandler = new DownloadHandlerBuffer();
        req.SetRequestHeader("Content-Type", "application/json");

        yield return req.SendWebRequest();

        if (req.isNetworkError)
        {
            Debug.Log("Error While Sending: " + req.error);
        }
        else
        {
            Debug.Log("Received: " + req.downloadHandler.text);
        }

    }
}

public class UserData 
{
    public string username;
    public string password;
}
