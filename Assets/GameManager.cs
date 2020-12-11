using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager GM;
    Enemy[] Enemies;
    GameObject Player;
    Vector3 playerStart;
    Vector3 playerRot;
    private void Awake()
    {
        if (GM == null)
        {
            GM = this;
        }
        else Destroy(gameObject);
        DontDestroyOnLoad(this);
        Player = GameObject.FindGameObjectWithTag("Player");
        Enemies = GameObject.FindObjectsOfType<Enemy>();
        playerRot = Player.transform.localEulerAngles;
        playerStart = Player.transform.position;
    }
    public void Restart()
    {
        foreach(Enemy e in Enemies)
        {
            e.gameObject.SetActive(true);
            e.Respawn();
        }
        Player.transform.position = playerStart;
        Player.transform.localEulerAngles = playerRot;
    }
    
}
