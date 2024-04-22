using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoard : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float y = this.transform.position.y;
        Vector3 camera = new Vector3(Camera.main.transform.position.x, y, Camera.main.transform.position.z);
        transform.LookAt(camera , Vector3.up);
    }
}
