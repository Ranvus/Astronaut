using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleController : MonoBehaviour
{
    [SerializeField] private Transform pos1, pos2;
    [SerializeField] private float speed;
    [SerializeField] private Transform startPos;

    private Vector3 nextPos;
    [SerializeField] private float delay;
    private float currentTime;

    private void Start()
    {
        nextPos = startPos.position;
        currentTime = delay;
    }

    void Update()
    {
        if (transform.position == pos1.position)
        {
            currentTime -= Time.deltaTime;
            if (currentTime <= 0f)
            {
                nextPos = pos2.position;
                currentTime = delay;
            }
            print(currentTime);
        }
        if (transform.position == pos2.position)
        {
            nextPos = pos1.position;
        }

        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
    }
}
