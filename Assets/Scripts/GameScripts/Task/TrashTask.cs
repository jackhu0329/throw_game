using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;


namespace GameFrame
{
    public class TrashTask : TaskBase
    {
        private GameObject objCup, objBottle, objPaper;


        // Start is called before the first frame update
        public override IEnumerator TaskInit()
        {
            Debug.Log("TaskInit start");
            GameEventCenter.AddEvent("SpawnCup", SpawnCup);

            objCup = GameEntityManager.Instance.GetCurrentSceneRes<MainSceneRes>().Cup.gameObject;
            //objBottle = GameEntityManager.Instance.GetCurrentSceneRes<MainSceneRes>().Bottle.gameObject;
            //objPaper = GameEntityManager.Instance.GetCurrentSceneRes<MainSceneRes>().Paper.gameObject;

            SpawnCup();

            yield return null;
        }

        //public void 
        public override IEnumerator TaskStart()
        {


            yield return null;
        }


        public override IEnumerator TaskStop()
        {
            yield return null;
        }

        public void SpawnCup()
        {
            GameObject.Instantiate(objCup, objCup.transform.position, Quaternion.identity);
        }




    }
}


