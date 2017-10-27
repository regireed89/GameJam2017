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
    public Canvas canvas;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        data = ScriptableObject.CreateInstance<PlayerData>();
        data.sprintTimer = 10;
    }

    // Update is called once per frame
    void Update()
    {
        float roth = Input.GetAxis("Mouse X");


        transform.Rotate(0, roth * 2, 0);
        if (Input.GetKey(KeyCode.W))
            rb.MovePosition(transform.position + transform.forward * Time.deltaTime * 10);
        if (Input.GetKey(KeyCode.A))
            rb.MovePosition(transform.position + (transform.right * -1) * Time.deltaTime * 10);
        if (Input.GetKey(KeyCode.S))
            rb.MovePosition(transform.position + (transform.forward * -1 )* Time.deltaTime * 10);
        if (Input.GetKey(KeyCode.D))
            rb.MovePosition(transform.position + transform.right * Time.deltaTime * 10);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (data.sprintTimer <= 0)
            {
            
                data.sprintTimer = 0;
            }
      
            data.sprintTimer -= .1f;

        }
        if (!Input.GetKey(KeyCode.LeftShift))
        {
            data.sprintTimer += .1f;
            if (data.sprintTimer >= 10)
                data.sprintTimer = 10;
        }
        if(Input.GetKeyDown(KeyCode.Space))
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
        if(other.tag == "finish")
        {
            canvas.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
