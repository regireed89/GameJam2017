using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WinBehaviour : MonoBehaviour
{
    Random rand;
    // Use this for initialization
    void Start()
    {
        rand = new Random();
        List<GameObject> finishes = new List<GameObject>();
        foreach (var finishingGameObject in GameObject.FindGameObjectsWithTag("Finish"))
        {
                finishes.Add(finishingGameObject);
        }
        GameObject gameOver = finishes[Random.Range(0, finishes.Count)];
        gameOver.AddComponent<BoxCollider>();
        gameOver.GetComponent<BoxCollider>().size = new Vector3(5,5,5);
        gameOver.GetComponent<BoxCollider>().isTrigger = true;
    }

}
