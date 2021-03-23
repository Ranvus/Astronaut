using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroAttract : MonoBehaviour
{
    [SerializeField] AstroScript astroScr;

    [Header("Attract variables")]
    [SerializeField] private LayerMask whatIsObstacle;
    private bool isTouchingObstacle;
    private Vector3 posCur;
    private Quaternion rotCur;

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
        posCur = new Vector3(hit.point.x, hit.point.y, transform.position.z); //Координаты точки, где луч сталкивается с платформой.

        Vector2 posDif = new Vector2(transform.position.x, transform.position.y) - new Vector2(hit.point.x, hit.point.y);
        print(posDif);

        if (isTouchingObstacle && (Input.GetButtonDown("Fire2")))
        {
            //Булевые
            astroScr.canShoot = false;
            astroScr.mouseRotationActive = false;
            astroScr.astroInputScr.rotateBtnActive = false;
            astroScr.arrow.SetActive(true);

            //Физика
            astroScr.rb.velocity = Vector2.zero; 
            astroScr.rb.drag = 10f;
            transform.rotation = Quaternion.Lerp(transform.rotation, rotCur, 5f);
            //transform.position = Vector3.Lerp(transform.position, posCur, Time.deltaTime * 5f);
            //transform.position -= new Vector3(transform.position.x, transform.position.y, transform.position.z) - new Vector3(hit.point.x - .2f, hit.point.y - .2f, 0);
            /*if (posDif.x > 0)
            {
                transform.position += new Vector3(-.5f, 0f);
            }
            else if(posDif.x < 0)
            {
                transform.position += new Vector3(.5f, 0f);
            }
            else if(posDif.x == 0)
            {
                transform.position += Vector3.zero;
            }*/
            astroScr.rb.AddForce(hit.point * 20f);
        }
    }

    //Создание графического представления луча
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.TransformDirection(0f, -.7f, 0f));
    }
}
