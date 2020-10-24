using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleControl : MonoBehaviour
{
    private ParticleSystem particleObj;
    private Vector3 objPosition;
    // Start is called before the first frame update
    void Start()
    {
        particleObj = gameObject.GetComponentInChildren<ParticleSystem>();
        GameEventCenter.AddEvent("ParticleStart", ParticleStart);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("particleObj");
            particleObj.Play();
        }
    }

    private void ParticleStart()
    {
        objPosition = GameObject.Find("CupRegular(Clone)").transform.position;
        transform.position = objPosition;
        particleObj.Play();
    }
}
