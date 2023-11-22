using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Game.Logic
{
    public class Living : MonoBehaviour
    {
        public void die(GameObject living, float delay = 0)
        {
            Destroy(living, delay);
        }

    }
}
