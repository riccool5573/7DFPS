using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NextLevel : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("got here");
     
            int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
            if (SceneManager.sceneCount > nextSceneIndex)
            {
                SceneManager.LoadScene(nextSceneIndex);
            }
        
    }
}
