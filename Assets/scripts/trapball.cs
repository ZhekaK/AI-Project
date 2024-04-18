using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapball : MonoBehaviour
{

    public float speedCircle;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, speedCircle) * Time.deltaTime);
    }
}
