using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroAttract : MonoBehaviour
{
    [SerializeField] AstroScript astroScr;

    [Header("Attract variables")]
    internal bool isTouchingObstacle;
    internal bool isAttract;
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
        hit = Physics2D.Raycast(transform.position, transform.TransformDirection(-Vector3.up), .7f, astroScr.obstacleLayer); //Задания параметров луча

        if (hit.collider.tag == "Obstacle")
        {
            isTouchingObstacle = true;
        }
        else
        {
            isTouchingObstacle = false;
        }
        print(hit.collider.tag);

        rotCur = Quaternion.FromToRotation(Vector3.up, hit.normal); //Создание нормали к поверхности 
        posCur = new Vector3(hit.point.x, hit.point.y, transform.position.z); //Координаты точки, где луч сталкивается с платформой.

        // Притяжение игрока к стене
        if (isTouchingObstacle && (Input.GetButtonDown("Fire2")))
        {
            //Булевые
            astroScr.canShoot = false;
            astroScr.mouseRotationActive = false;
            astroScr.astroInputScr.rotateBtnActive = false;
            isAttract = true;
            astroScr.arrow.SetActive(true);
            astroScr.hand.SetActive(false);
            astroScr.secondHand.SetActive(false);

            //astroScr.hand.transform.localRotation = Quaternion.Euler(0f, 0f, astroScr.astroHandsRot.angle);

            //Физика
            astroScr.rb.velocity = Vector2.zero; 
            astroScr.rb.drag = 10f;
            transform.rotation = Quaternion.Lerp(transform.rotation, rotCur, 5f);
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
