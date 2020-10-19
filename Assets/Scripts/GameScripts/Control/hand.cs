﻿using RootMotion.Demos;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class hand : MonoBehaviour
{
    public SteamVR_Action_Boolean mGrabAction = null;
    private SteamVR_Behaviour_Pose mPose = null;
    private FixedJoint mJoint = null;

    private Interactable mCurrentInteractable = null;
    private List<Interactable> mContactInteractables = new List<Interactable>();

    public int testHand;

    // Start is called before the first frame update
    void Start()
    {
        mPose = GetComponent<SteamVR_Behaviour_Pose>();
        mJoint = GetComponent<FixedJoint>();
    }

    // Update is called once per frame
    void Update()
    {



        if (mGrabAction.GetStateDown(mPose.inputSource))
        {
            Debug.Log(mPose.inputSource + " down ");
            Pickup();
        }
        if (mGrabAction.GetStateUp(mPose.inputSource))
        {
            Debug.Log(mPose.inputSource + " up ");
            Drop();

        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (!other.gameObject.CompareTag("Interactable"))
        {
            return;
        }
        else if (other.gameObject.CompareTag("Interactable"))
        {
            mContactInteractables.Add(other.gameObject.GetComponent<Interactable>());
        }


    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.CompareTag("Interactable") || !other.gameObject.CompareTag("PickUpArea"))
        {
            return;
        }
        if (other.gameObject.CompareTag("PickUpArea"))
        {
            other.transform.GetChild(2).gameObject.SetActive(false);
        }
        else if (other.gameObject.CompareTag("Interactable"))
        {
            mContactInteractables.Remove(other.gameObject.GetComponent<Interactable>());
        }
    }

    private void Pickup()
    {
        mCurrentInteractable = GetNearestInteractable();

        if (!mCurrentInteractable)
            return;

        if (mCurrentInteractable.mActiveHand)
            mCurrentInteractable.mActiveHand.Drop();

        //mCurrentInteractable.transform.position =new Vector3(transform.position.x - 0.2f, transform.position.y-0.2f, transform.position.z);
        //mCurrentInteractable.transform.eulerAngles = new Vector3(transform.rotation.x , 0 , -90);

        mCurrentInteractable.transform.position = transform.position;


        Rigidbody targetBody = mCurrentInteractable.GetComponent<Rigidbody>();
        mJoint.connectedBody = targetBody;

        mCurrentInteractable.mActiveHand = this;
    }

    private void Drop()
    {
        if (!mCurrentInteractable)
            return;

        /*mCurrentInteractable.transform.position = originPosition;
        mCurrentInteractable.transform.rotation = originRotation;*/

        Rigidbody targetBody = mCurrentInteractable.GetComponent<Rigidbody>();
        targetBody.velocity = mPose.GetVelocity();
        targetBody.angularVelocity = mPose.GetAngularVelocity();


        mContactInteractables = new List<Interactable>();
        mJoint.connectedBody = null;
        mCurrentInteractable.mActiveHand = null;
        mCurrentInteractable = null;


    }

    private Interactable GetNearestInteractable()
    {
        Interactable nearest = null;
        float minDistance = float.MaxValue;
        float distance = 0.0f;

        foreach (Interactable interactive in mContactInteractables)
        {
            distance = (interactive.transform.position - transform.position).sqrMagnitude;

            if (distance < minDistance && distance < 0.1f && interactive.tag == ("Interactable"))//手把真的有碰到物體 且物體還是可以動的狀態
            {
                minDistance = distance;
                nearest = interactive;

            }

        }
        //Debug.Log("GetNearestInteractable:  "+ nearest.gameObject.name);

        return nearest;
    }



    public void ResetHand()
    {
        Drop();
    }
}