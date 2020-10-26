using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GameFrame
{
    public class FloatingTextEntity : GameEntityBase
    {
        private string text;
        private int textNo;

        public void Awake()
        {
            RandomText();
            this.GetComponent<TextMesh>().text = text;
            transform.eulerAngles = new Vector3(0, 90, 0);
            Destroy(this.gameObject, 1.0f);
        }
        public override void EntityDispose()
        {

        }

        private void RandomText()
        {
            textNo = Random.Range(0, 3);
            switch (textNo)
            {
                case 0:
                    text = "得分";
                    break;
                case 1:
                    text = "非常好";
                    break;
                case 2:
                    text = "太棒了";
                    break;
            }
            Debug.Log(textNo);
        }

        public void Update()
        {
            RandomText();
            Debug.Log("test");
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y+1f, transform.position.z),  2f* Time.deltaTime);
            //transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(transform.localScale.x-1f, transform.localScale.y-1f, transform.localScale.z-1f), 2f * Time.deltaTime);
        }
    }
}

