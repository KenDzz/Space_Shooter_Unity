using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Game.Logic;

public class Shoot : MonoBehaviour
{
    public GameObject playerBullet;
    public float waitShoot = 1f;
    private Shooting m_Shooting;

    // Start is called before the first frame update
    void Start()
    {
        this.m_Shooting = new Shooting();
        StartCoroutine(ShootPlayer());
    }

    // Update is called once per frame
    void Update()
    {
    }

    public IEnumerator ShootPlayer()
    {
        while (true)
        {
            yield return new WaitForSeconds(waitShoot);
            this.m_Shooting.eBullet(playerBullet, transform.position, Quaternion.identity);
        }
    }
}
