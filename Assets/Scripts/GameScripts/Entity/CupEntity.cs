using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFrame
{
    public class CupEntity : GameEntityBase
    {
        public void Awake()
        {

        }
        public override void EntityDispose()
        {

        }

        public void Update()
        {

        }

        public void OnTriggerEnter(Collider other)
        {
            Debug.Log("test"+other.name);
            GameEventCenter.DispatchEvent("GetScore");
            GameEventCenter.DispatchEvent("SpawnCup");
            Destroy(this.gameObject);
        }

        public void OnTriggerExit(Collider other)
        {

        }

        public void OnTriggerStay(Collider other)
        {


        }

        private void Throw()
        {


        }

    }
}


