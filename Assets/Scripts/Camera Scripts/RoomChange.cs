using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomChange : MonoBehaviour
{
    [SerializeField] private GameObject virtualCam;


    [Header("Other objects references")]
    [SerializeField] private GameObject[] enemies;

    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Character"))
        {
            virtualCam.SetActive(true);
            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i].gameObject.SetActive(true);
            }
        }
    }

    public virtual void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Character"))
        {
            virtualCam.SetActive(false);
            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i].gameObject.SetActive(false);
            }
        }
    }
}
