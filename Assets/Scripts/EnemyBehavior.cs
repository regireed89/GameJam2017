using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyBehavior : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
         anim= GetComponent<Animator>();
        anim.SetBool("Running",true);
    }
    void OnTriggerEnter(Collider other)
    {
        anim.SetTrigger("Attack");
        if (other.tag == "Player")
        {
            GetComponent<AudioSource>().Play();
            StartCoroutine(GameOver());
        }
           
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(3.5f);
        SceneManager.LoadScene("1.MainMenu");
    }
}
