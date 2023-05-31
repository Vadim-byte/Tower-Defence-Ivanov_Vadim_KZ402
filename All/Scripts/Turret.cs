using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform target;
    private Enemy targetEnemy;

    [Header("General")] // Заголовки для обрання різних характеристик турелі.

    public float range = 15f;

    [Header("User Bullets(default)")]
    public GameObject bulletPrefab;
    public float fireRate = 1f;
    private float fireCountdown = 0f;

    [Header("User Laser")]
    public bool useLaser = false;

    public int damageOverTime = 30; // - 30 hp в сек
    public float slowPct = .5f;

    public LineRenderer lineRenderer;
    public ParticleSystem impactEffect;
    public Light impactLight;

    [Header("Unity Setup Fields")]

    public string enemyTag = "Enemy";

    public Transform partToRotate;
    public float turnSpeed = 10f;

    

    public Transform firePoint;
   

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget() // Скрипт шукає противника по тегу енемі і якщо він входить в його зону - цілится в найближчого
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;

        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies) 
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if(nearestEnemy != null && shortestDistance <= range) // проводить перевірку чи супротивник в радіусі
        {
            target = nearestEnemy.transform;
            targetEnemy = nearestEnemy.GetComponent<Enemy>();
        }
        else
        {
            target = null;
        }

    }

    void Update()
    {
        if (target == null) { // перевірка чи ворог в зоні дії

            if (useLaser) // після перевірки на включення лазеру, якщо перевірка true - виключає його
            {
                if (lineRenderer.enabled)
                {
                    lineRenderer.enabled = false;
                    impactEffect.Stop();
                    impactLight.enabled = false;
                }

            }

            return;
        }

        LockOnTarget();

        if (useLaser) // перевірка лазерна тунель чи звичайна
        {
            Laser();
        }
        else
        {
            if (fireCountdown <= 0f) // визиває звичайний постріл якщо не лазерна тунель
            {
                Shoot();
                fireCountdown = 1f / fireRate;
            }
        }

        fireCountdown -= Time.deltaTime;
    }

    void LockOnTarget()
    {
        // Тримає приціл на російському солдаті
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    void Laser()
    {

        targetEnemy.TakeDamage(damageOverTime * Time.deltaTime);
        targetEnemy.Slow(slowPct);

        if (!lineRenderer.enabled) // включає лазер знову, після команди виключення
        {

            lineRenderer.enabled = true;
            impactEffect.Play();
            impactLight.enabled = true;

        }

        lineRenderer.SetPosition(0, firePoint.position); // кладе одну сторону лазера на файр пойнт, іншу на російського солдата
        lineRenderer.SetPosition(1, target.position);

        Vector3 dir = firePoint.position - target.position;

        impactEffect.transform.position = target.position + dir.normalized;

        impactEffect.transform.rotation = Quaternion.LookRotation(dir);

    }

    void Shoot() // Скрипт який каже коли і як випускати пулю турелі
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        

        Bullet bullet = bulletGO.GetComponent<Bullet>();
        

        if (bullet != null)
        {
            bullet.Seek(target);
        }

    
    }

    void OnDrawGizmosSelected() // міняє колір на червоний
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
