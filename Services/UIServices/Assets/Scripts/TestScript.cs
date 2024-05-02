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
        if (Input.GetKey(KeyCode.R))
            AuthManager.RegisterUser(registerUsername, registerPassword);
        if (Input.GetKey(KeyCode.L))
            AuthManager.LoginUser(loginUsername, loginPassword);
    }
}
