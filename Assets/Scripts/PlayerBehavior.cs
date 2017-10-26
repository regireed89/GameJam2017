using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehavior : MonoBehaviour
{

    // Use this for initialization
    [HideInInspector]
    public PlayerData data;
    bool lightToggle;

    void Start()
    {
        data = ScriptableObject.CreateInstance<PlayerData>();
        data.sprintTimer = 10;
    }

    // Update is called once per frame
    void Update()
    {
        float moveh = Input.GetAxis("Horizontal");
        float movev = Input.GetAxis("Vertical");
        float roth = Input.GetAxis("Mouse X");


        transform.Translate(moveh * .2f, 0, movev * .2f);
        transform.Rotate(0, roth * 2, 0);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (data.sprintTimer <= 0)
            {
                transform.Translate(moveh * -.3f, 0, movev * -.3f);
                data.sprintTimer = 0;
            }
            transform.Translate(moveh * .3f, 0, movev * .3f);
            data.sprintTimer -= .1f;

        }
        if (!Input.GetKey(KeyCode.LeftShift))
        {
            data.sprintTimer += .1f;
            if (data.sprintTimer >= 10)
                data.sprintTimer = 10;
        }
        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            
            if(lightToggle == false)
            {
                lightToggle = true;
                GetComponentInChildren<Light>().enabled = lightToggle;
                return;
            }
            lightToggle = false;
            GetComponentInChildren<Light>().enabled = lightToggle;

        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Finish")
        { }
    }
}
