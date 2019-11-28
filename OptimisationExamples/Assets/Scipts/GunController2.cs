using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController2 : MonoBehaviour
{
    public GameObject bullet;

    public float shootingPower = 100;
    public int poolSize = 100;

    private List<GameObject> bulletPool = new List<GameObject>();

    private int currentPoolIndex = 0;

    private Rigidbody currentBulletRB;
    private GameObject poolParent;

    public int bulletAmountEachFrame = 1;
    private void Awake()
    {
        poolParent = new GameObject("Bullet Pool");
        for (int i = 0; i < poolSize; i++)
        {
            GameObject instantedBullet = Instantiate(bullet, gameObject.transform.position, Quaternion.identity, poolParent.transform);
            instantedBullet.SetActive(false);
            bulletPool.Add(instantedBullet);
        }
    }
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            for (int i = 0; i < bulletAmountEachFrame; i++)
            {
                Shoot();
            }

        }
    }
    private void Shoot()
    {
        bulletPool[currentPoolIndex].SetActive(true);
        bulletPool[currentPoolIndex].transform.position = gameObject.transform.position;
        bulletPool[currentPoolIndex].transform.rotation = Quaternion.identity;
        currentBulletRB = bulletPool[currentPoolIndex].GetComponent<Rigidbody>();
        currentBulletRB.velocity = Vector3.zero;
        currentBulletRB.AddForce(gameObject.transform.forward * shootingPower, ForceMode.Impulse);
        currentPoolIndex++;
        if (currentPoolIndex >= poolSize)
            currentPoolIndex = 0;
    }

}
