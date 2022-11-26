using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePersist : MonoBehaviour
{
    void Awake()
    {
        int numGamePersist = FindObjectsOfType<GamePersist>().Length;
        
        if (numGamePersist > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void ResetGamePersist()
    {
        Destroy(gameObject);
    }
}
