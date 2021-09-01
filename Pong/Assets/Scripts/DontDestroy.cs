using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    GameObject[] objs;
    private void Awake()
    {
        objs = GameObject.FindGameObjectsWithTag("Music");
        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        else if (objs.Length == 1)
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }

}
