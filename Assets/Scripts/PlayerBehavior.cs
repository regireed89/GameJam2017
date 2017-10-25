using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour, IKillable
{

    // Use this for initialization
    PlayerData data;

    public void Die()
    {
        data.alive = false;
        if (data.alive == false)
            transform.Rotate(90, 0, 0);
    }

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
                transform.Translate(moveh * -.4f, 0, movev * -.4f);
                data.sprintTimer = 0;
            }
            transform.Translate(moveh * .4f, 0, movev * .4f);
            data.sprintTimer -= .1f;

        }
        if (!Input.GetKey(KeyCode.LeftShift))
        {
            data.sprintTimer += .1f;
            if (data.sprintTimer >= 10)
                data.sprintTimer = 10;
        }
    }
}
