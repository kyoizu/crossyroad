using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terrain : MonoBehaviour
{
    [SerializeField] GameObject tilePrefab;
    // Start is called before the first frame update
    private void Start()
    {
        Generate(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void Generate(int size)
    {
        var go = Instantiate(
            tilePrefab, 
            transform);
    }
}
