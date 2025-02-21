using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTransform : MonoBehaviour
{
    private float range = 4f;
    private void Start()
    {
        float x = Random.Range(-range, range);
        float z = Random.Range(-range, range);
        transform.position = new Vector3(x, transform.position.y, z);


    }
}
