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
    private readonly string urlLogin = "http://localhost:5046/register";

    public static void RegisterUser(string username, string password)
    {
        instance.StartCoroutine(instance.RegisterUserAsync(username, password));   
    }

    private IEnumerator RegisterUserAsync(string username, string password)
    {
        var request = new
        {
            Username = username,
            Password = password
        };

        string jsonRequest = JsonUtility.ToJson(request);
        UnityWebRequest webRequest = new UnityWebRequest(urlRegister, "POST");
        byte[] jsonToSend = new System.Text.UnicodeEncoding().GetBytes(jsonRequest);
        webRequest.uploadHandler = new UploadHandlerRaw(jsonToSend);
        webRequest.downloadHandler = new DownloadHandlerBuffer();

        webRequest.SetRequestHeader("Content-Type", "application/json");
        webRequest.SetRequestHeader("accept", "*/*"); 

        yield return webRequest.SendWebRequest();

        if (webRequest.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("User registered successfully");
        }
        else
        {
            Debug.LogError($"Error: {webRequest.error}");
        }
    }

    public static void LoginUser(string username, string password)
    {
        instance.StartCoroutine(instance.LoginUserAsync(username, password));
    }

    private IEnumerator LoginUserAsync(string username, string password)
    {
        var request = new 
        {
            Username = username,
            Password = password
        };

        string jsonRequest = JsonUtility.ToJson(request);
        UnityWebRequest webRequest = new UnityWebRequest(urlLogin, "POST");
        byte[] jsonToSend = new System.Text.UnicodeEncoding().GetBytes(jsonRequest);
        webRequest.uploadHandler = new UploadHandlerRaw(jsonToSend);
        webRequest.downloadHandler = new DownloadHandlerBuffer();
        webRequest.SetRequestHeader("Content-Type", "application/json");

        yield return webRequest.SendWebRequest();

        if (webRequest.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("Login successful");
        }
        else
        {
            Debug.LogError($"Error: {webRequest.error}");
        }

    }
}
