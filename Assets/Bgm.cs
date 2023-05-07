using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bgm : MonoBehaviour
{
    // Start is called before the first frame update
    private static Bgm bgm;

    void Awake() 
    {
        if(bgm == null)
        {
            bgm = this;
            DontDestroyOnLoad(bgm);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
