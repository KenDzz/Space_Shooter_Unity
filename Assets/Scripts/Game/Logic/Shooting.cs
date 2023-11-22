using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Game.Logic
{
    public class Shooting : MonoBehaviour
    {
        public void eBullet(GameObject playerBullet, Vector3 pos, Quaternion quaternionValue)
        {
            //di chuyen dan theo may bay
            Instantiate(playerBullet, pos, quaternionValue);
        }

        public void moveBulletDirection(Transform bullet,Vector2 Dir, float bulletSpeed)
        {
            //di chuyen huong dan
            bullet.Translate(Dir * bulletSpeed * Time.deltaTime);
        }


    }
}
