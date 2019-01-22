using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObjs : MonoBehaviour
{
    public GameObject SomeObj;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CreateSpheres());
    }

    IEnumerator CreateSpheres()
    {
        for (int i = 0; i < 10; i++)
        { 
            Vector3 vpos = new Vector3(i, 5, 0);
            Instantiate(SomeObj, vpos, Quaternion.identity);
            yield return new WaitForSeconds(1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
