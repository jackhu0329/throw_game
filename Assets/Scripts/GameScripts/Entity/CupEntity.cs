﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFrame
{
    public class CupEntity : GameEntityBase
    {
        private ParticleSystem particleObj;
        public void Awake()
        {
            particleObj = gameObject.GetComponentInChildren<ParticleSystem>();
            
            Physics.gravity = new Vector3(0, -30-(GameDataManager.FlowData.mode*20), 0);
            Debug.Log("gravity:"+ Physics.gravity);
        }
        public override void EntityDispose()
        {

        }

        public void Update()
        {

        }

        public void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Hand"))
            {
                return;
            }

            //Debug.Log(other.name);
            if(other.name == "TrashbinGreen")
            {
                Debug.Log("test" + other.name);
                GameEventCenter.DispatchEvent("GetScore");
                GameEventCenter.DispatchEvent("SpawnCup");
                GameEventCenter.DispatchEvent("ParticleStart");
                GameEventCenter.DispatchEvent<AudioSelect>("PlayAudio", AudioSelect.Success);
                Destroy(this.gameObject);
            }
            else 
            {
                GameEventCenter.DispatchEvent("SpawnCup");
                GameEventCenter.DispatchEvent("MotionFailed");
                GameEventCenter.DispatchEvent<AudioSelect>("PlayAudio", AudioSelect.fail);
                Destroy(this.gameObject);
            }
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


