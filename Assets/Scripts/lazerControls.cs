using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lazerControls   : MonoBehaviour
{
    private int laserSpeed = 5;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * laserSpeed * Time.deltaTime);

        if (transform.position.y >= 5.7)
        {
            Destroy(this.gameObject, 2);
        }
    }
}
