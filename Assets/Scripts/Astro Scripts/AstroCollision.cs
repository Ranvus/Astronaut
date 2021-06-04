using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AstroCollision : MonoBehaviour
{
    [SerializeField] AstroScript astroScr;

    internal Material matFlash;
    internal Material matDefault;
    internal SpriteRenderer sr;

    [SerializeField] private AudioSource hitSound;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        matFlash = Resources.Load("Flash", typeof(Material)) as Material;
        matDefault = sr.material;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DeathWire") || collision.CompareTag("Rocket"))
        {
            astroScr.astroDmg.TakeDamage(1);
            astroScr.rb.AddForce(-astroScr.rb.velocity.normalized * astroScr.knockbackForce, ForceMode2D.Impulse);
            CinemachineShake.Instance.ShakeCamera(.5f, .1f);
        }

        if (collision.CompareTag("Enemy") || collision.CompareTag("DeathWire") || collision.CompareTag("Rocket"))
        {
            sr.material = matFlash;
            astroScr.astroHandsChScr.handsSr.material = matFlash;
            hitSound.Play();
            if (HPVisual.hpSystemStatic.IsDead())
            {
                StartCoroutine(DeathFlash());
            }
            else
            {
                Invoke("ResetMaterial", .1f);
            }
        }

        if (collision.CompareTag("Hole"))
        {
            SceneManager.LoadScene("Final");
        }

    }
    private void ResetMaterial()
    {
        sr.material = matDefault;
        astroScr.astroHandsChScr.handsSr.material = matDefault;
    }

    internal IEnumerator DeathFlash()
    {
        yield return new WaitForSeconds(.2f);
        sr.material = matDefault;
        astroScr.astroHandsChScr.handsSr.material = matDefault;
    }

}
