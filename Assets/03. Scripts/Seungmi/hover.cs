using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hover : MonoBehaviour
{
	public GameObject join;
    void OnPointerEnter()
	{
		join.SetActive(true);
	}
	void OnPointerExit()
	{
		join.SetActive(false);
	}
}
