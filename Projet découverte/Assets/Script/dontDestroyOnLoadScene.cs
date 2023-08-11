using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dontDestroyOnLoadScene : MonoBehaviour
{
    
    public GameObject[] objects;

    private void Start()
    {
        
        foreach (var element in objects)
        {
            if (element != null)
            {
                DontDestroyOnLoad(element);
            }
        }

    }

    public void destroyElement()
    {
        for (int i = 0; i < objects.Length; i++)
        {
            Destroy(objects[i]);   
        }
    }
}
