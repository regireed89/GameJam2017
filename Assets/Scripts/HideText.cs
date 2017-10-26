using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideText : MonoBehaviour
{
	// Use this for initialization
	void Start ()
	{
	    StartCoroutine(Timer());
	}

    public IEnumerator Timer()
    {
        yield return new WaitForSeconds(5);
        GetComponent<Text>().enabled = false;
    }
}
