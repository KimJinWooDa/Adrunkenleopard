using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.Two))
        {
            SceneManager.LoadScene(1);
        }
    }
}
