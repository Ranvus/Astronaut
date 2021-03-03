using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FauxGravityAttractor : MonoBehaviour
{
    internal Rigidbody2D rb;

    [SerializeField] private float gravity = -10f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        print("tr" + transform.position);
    }

    public void Attract(Transform body)
    {
        Vector2 gravityUp = (body.position - transform.position).normalized;
        Vector2 bodyUp = body.up;

        rb.AddForce(gravityUp * gravity);

        Quaternion targetRotation = Quaternion.FromToRotation(bodyUp, gravityUp) * body.rotation;
        body.rotation = Quaternion.Slerp(body.rotation, targetRotation, 50 * Time.deltaTime);
    }
}
