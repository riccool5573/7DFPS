using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager GM;
    Enemy[] Enemies;
    GameObject Player;
    
    private void Awake()
    {
        if (GM == null)
        {
            GM = this;
        }
        else Destroy(gameObject);
        DontDestroyOnLoad(this);

        Enemies = GameObject.FindObjectsOfType<Enemy>();
    }
    private void Start()
    {
        foreach(Enemy e in Enemies)
        {
            e.gameObject.SetActive(true);
           e.Invoke("Respawn",5);
        }
    }
}
