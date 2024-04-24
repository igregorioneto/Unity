using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] int life = 0;
    [SerializeField] int point = 0;
    Transform positionPlayer;

    public int Life { get { return life; } set { life = value; } }
    public int Point { get { return point;} set { point = value; } }
    public string Position { get; set; }
    public Transform PositionPlayer { get { return positionPlayer;} set { positionPlayer = value; } }

    SavePoint savePoint;

    void Start ()
    {
        savePoint = new SavePoint();
    }

    // Update is called once per frame
    void Update()
    {
        positionPlayer = transform;
        Life = life;
        Point = point;
        
        if (positionPlayer != null)
        {
            PositionPlayer = positionPlayer;
            float x = positionPlayer.position.x;
            float y = positionPlayer.position.y;
            float z = positionPlayer.position.z;
            Position = $"|x = {x}|y = {y}|z = {z}|";

            if (savePoint != null)
            {
                savePoint.FilePersistence(Life, Point, Position);
                Debug.Log($"\tLife: {Life}\tPoint:{Point}\tPosition Player in World: {Position}\n");
            }
            else
            {
                Debug.Log("SavePoint ou Player não esta inicializado.");
            }
        }
    }
}
