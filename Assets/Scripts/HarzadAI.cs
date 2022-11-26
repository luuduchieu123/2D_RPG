using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarzadAI : MonoBehaviour
{
    [SerializeField] Transform playertransform;
    [SerializeField] GameObject GetObject;
    // Start is called before the first frame update
    void Start()
    {
        GetObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        SetActive1();
    }

    void SetActive1()
    {
        if (Mathf.Abs(transform.position.x - playertransform.position.x) <= 1.5f)
        {
            
            GetObject.SetActive(true);
        }

        else
        {
            GetObject.SetActive(false);
        }
    }
}
