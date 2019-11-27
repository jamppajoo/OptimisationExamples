using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject bullet;

    public float shootingPower = 100;

    public int bulletAmountEachFrame = 1;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            for (int i = 0; i < bulletAmountEachFrame; i++)
            {
                Shoot();
            }
            //ShootAndDestroy();
        }
    }
    private void Shoot()
    {
        GameObject instantedBullet = Instantiate(bullet, gameObject.transform.position, Quaternion.identity);
        Rigidbody instantedBulletRB = instantedBullet.GetComponent<Rigidbody>();
        instantedBulletRB.AddForce(gameObject.transform.forward * shootingPower, ForceMode.Impulse);
    }


    #region Absolute minimum
    private void ShootAndDestroy()
    {
        GameObject instantedBullet = Instantiate(bullet, gameObject.transform.position, Quaternion.identity);
        Rigidbody instantedBulletRB = instantedBullet.GetComponent<Rigidbody>();
        instantedBulletRB.AddForce(gameObject.transform.forward * shootingPower, ForceMode.Impulse);
        Destroy(instantedBullet, 5);
    }
    #endregion
}
