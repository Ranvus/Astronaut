using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroAttract : MonoBehaviour
{
    [SerializeField] AstroScript astroScr;

    [Header("Attract variables")]
    private bool isTouchingObstacle;
    [SerializeField] private LayerMask whatIsObstacle;
    private Vector3 posCur;
    private Quaternion rotCur;

    [Header("Arrow ref")]
    [SerializeField] internal GameObject arrow;

    private void Start()
    {
        print("Astro Attract");
        astroScr.rb.constraints = RigidbodyConstraints2D.FreezeRotation; //Остановка вращения дабы, персонаж не вращался по инерции
    }

    private void Update()
    {
        RaycastHit2D hit = new RaycastHit2D(); //Инициализация луча для распознования столкновения
        hit = Physics2D.Raycast(transform.position, transform.TransformDirection(-Vector3.up), .7f, whatIsObstacle); //Задания параметров луча
        if (hit.collider.tag == "Obstacle")
        {
            isTouchingObstacle = true;
        }
        else
        {
            isTouchingObstacle = false;
        }

        rotCur = Quaternion.FromToRotation(Vector3.up, hit.normal); //Создание нормали к поверхности 
        posCur = new Vector3(transform.position.x, hit.point.y, transform.position.z); //Текущее положение луча

        if (isTouchingObstacle && (Input.GetButtonDown("Fire2")))
        {
            //Булевые
            astroScr.canShoot = false;
            astroScr.mouseRotationActive = false;
            astroScr.astroInputScr.rotateBtnActive = false;
            arrow.SetActive(true);

            //Физика
            astroScr.rb.velocity = Vector2.zero; 
            astroScr.rb.drag = 5f;
            transform.rotation = Quaternion.Lerp(transform.rotation, rotCur, 5f);
            astroScr.rb.AddForce(posCur * 20f);
        }
    }

    //Создание графического представления луча
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.TransformDirection(0f, -.7f, 0f));
    }
}
