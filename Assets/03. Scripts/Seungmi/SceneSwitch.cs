using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSwitch : MonoBehaviour
{
    //public Image fill;

    /*
     
         void Start()
	{
        fill.color = new Color(0f, 0f, 0f, 1f);
        StartCoroutine("fadeout");
    }
     * 
    IEnumerator fadein()
	{
		while (fill.color.a < 1f)
		{
            yield return null;
            Color c = fill.color;
            c.a += Time.deltaTime;
            fill.color = c;
		}
    }

    IEnumerator fadeout()
    {   
        while (fill.color.a > 0f)
        {
            yield return null;
            Color c = fill.color;
            c.a -= Time.deltaTime;
            fill.color = c;
        }
    }
     */

    // Update is called once per frame
    public void SceneLoad(int n)
    {
        //StartCoroutine("fadein");
        SceneManager.LoadScene(n);
    }

}
