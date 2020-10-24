using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFrame
{
    public class CupEntity : GameEntityBase
    {
        public void Awake()
        {
            Debug.Log("gravity");
            Physics.gravity = new Vector3(0, -20, 0);
        }
        public override void EntityDispose()
        {

        }

        public void Update()
        {

        }

        public void OnTriggerEnter(Collider other)
        {
            if(other.name == "TrashbinGreen")
            {
                Debug.Log("test" + other.name);
                GameEventCenter.DispatchEvent("GetScore");
                GameEventCenter.DispatchEvent("SpawnCup");
                Destroy(this.gameObject);
            }

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


