using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    public Rigidbody myRig;

    [SerializeField]
    private float speed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        myRig = this.gameObject.GetComponent<Rigidbody>();

        if (myRig == null)
        {
            //throw exception
            throw new System.Exception("Could not find Ridgedbody");
        }
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        //moves camera
        myRig.velocity = new Vector3(h, 0, v).normalized * speed + new Vector3(0, myRig.velocity.y, 0);  //normalize to stop diagnl for being faster
    }

   
}
