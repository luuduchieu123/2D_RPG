using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] AudioClip audioClip;
    [SerializeField] int points = 10;
    bool wasCollected = false;


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !wasCollected)
        {
            wasCollected = true;
            AudioSource.PlayClipAtPoint(audioClip, Camera.main.transform.position);
            gameObject.SetActive(false);
            Destroy(gameObject);
            FindObjectOfType<GameSession>().AddToScore(points);
        }
    }
}
