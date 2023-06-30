using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneConector : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.GetInt("GDPR") == 0)
        {
            return;
        }
        SceneManager.LoadScene(1);
    }
}
