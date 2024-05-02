using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    public string registerUsername;
    public string registerPassword;

    public string loginUsername;
    public string loginPassword;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            AuthManager.RegisterUser(registerUsername, registerPassword);
        if (Input.GetKeyDown(KeyCode.L))
            AuthManager.LoginUser(loginUsername, loginPassword);
    }
}
