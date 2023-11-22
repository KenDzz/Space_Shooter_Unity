using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Game.Logic;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 10f;
    private Shooting m_Shooting;

    // Start is called before the first frame update
    void Start()
    {
        this.m_Shooting = new Shooting();
    }

    // Update is called once per frame
    void Update()
    {
        this.m_Shooting.moveBulletDirection(transform, Vector2.up, bulletSpeed);
    }
}
