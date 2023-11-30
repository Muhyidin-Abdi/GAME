using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowSpear : MonoBehaviour
{
    private Rigidbody myBody;
    private float speed = 30f;
    public float deactivate_timer = 3f;
    public float damge = 15f;



    private void Awake()
    {
        myBody = GetComponent<Rigidbody>();
    }
    void Start()
    {
        Invoke("DeactivateGameObject", deactivate_timer);
    }
    public void Launch(Camera mainCamera)
    {
        myBody.velocity = mainCamera.transform.forward * speed;

        transform.LookAt(transform.position + myBody.velocity);
    }
    
   void deactivateGameObject()
    {
        if (gameObject.activeInHierarchy)
        {
            gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider target)
    {

    }
}
