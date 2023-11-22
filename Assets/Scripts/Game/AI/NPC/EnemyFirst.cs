using Assets.Scripts.Game.Logic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyFirst : MonoBehaviour
{
    public GameObject npcBullet;
    public GameObject npcExplosion;
    public float waitShoot = 1f;
    private Shooting m_Shooting;
    private Living m_living;

    // Start is called before the first frame update
    void Start()
    {
        this.m_Shooting = new Shooting();
        this.m_living = new Living();
        StartCoroutine(ShootPlayer());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "playerBullet")
        {
            this.m_living.die(this.gameObject);
            GameObject expl = Instantiate(npcExplosion, transform.position, Quaternion.identity);
            this.m_living.die(expl, .5f);
        }
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
            this.m_Shooting.eBullet(npcBullet, transform.position, Quaternion.identity);
        }
    }
}
