using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    // Update is called once per frame
    public void SceneLoad(int n)
    {
        SceneManager.LoadScene(n);
    }
}
