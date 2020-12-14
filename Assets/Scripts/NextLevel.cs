using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NextLevel : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("got here");

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);


    }
}
