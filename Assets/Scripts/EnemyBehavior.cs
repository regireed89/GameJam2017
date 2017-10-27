using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyBehavior : MonoBehaviour
{
    private Animator anim;
    public Transform goal;
    NavMeshAgent agent;
    void Start()
    {
         anim= GetComponent<Animator>();
        anim.SetBool("Running",true);
        agent = GetComponent<NavMeshAgent>();
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
    private void Update()
    {
        agent.destination = goal.position;
    }
    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(3.5f);
        SceneManager.LoadScene("1.MainMenu");
    }
}
