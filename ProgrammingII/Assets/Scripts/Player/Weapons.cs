using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    [SerializeField] GameObject macaPrefab, axesPrefab;
    private Transform handPlayer;
    private GameObject weaponPlayer;

    void Start()
    {
        Transform[] transformsPlayer = gameObject.GetComponentsInChildren<Transform>();
        for (int i = 0; i < transformsPlayer.Length; i++)
        {
            if (transformsPlayer[i].tag == "Hand")
            {
                handPlayer = transformsPlayer[i];
                break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            if (weaponPlayer != null)
                Destroy(weaponPlayer);
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (weaponPlayer != null)
                Destroy(weaponPlayer);

            weaponPlayer = Instantiate(
                    macaPrefab, 
                    handPlayer.position, 
                    handPlayer.rotation, 
                    handPlayer);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (weaponPlayer != null)
                Destroy(weaponPlayer);

            weaponPlayer = Instantiate(
                    axesPrefab,
                    handPlayer.position,
                    handPlayer.rotation,
                    handPlayer
                );
        }
    }
}
