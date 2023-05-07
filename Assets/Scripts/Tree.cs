using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    // Start is called before the first frame update
    private float speed;
    // Update is called once per frame
    private void Update()
    {
        transform.Translate(Vector3.right * 0 * Time.deltaTime);
    }
}
