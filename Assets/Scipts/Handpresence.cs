using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
public class Handpresence : ControllerInput
{


    private Animator handAnimatorR;
    private Animator handAnimatorL;
    private float triggerR;
    void Update()
    {
        
        //assign the animators to the correct variable
      /*  if (handAnimatorR == null)
        {
            handAnimatorR = GameObject.FindGameObjectWithTag("RightHand").GetComponent<Animator>();
      
        }
        if (handAnimatorL == null)
        {
            handAnimatorL = GameObject.FindGameObjectWithTag("LeftHand").GetComponent<Animator>();
            
        }
       
        if (!rightHand.isValid)
        {
            InitializeControllers();
           
        }
        // get the values from the controllers and give them to the animators for said controller
        if (rightHand.TryGetFeatureValue(CommonUsages.trigger, out float triggerValueR))
        {
      
            handAnimatorR.SetFloat("Trigger", triggerValueR);
        }
            
           
 

        if (rightHand.TryGetFeatureValue(CommonUsages.grip, out float gripValueR))
        {
            handAnimatorR.SetFloat("Grip", gripValueR);
        }
        

       /* if (leftHand.TryGetFeatureValue(CommonUsages.trigger, out float triggerValueL))
        {
            handAnimatorL.SetFloat("Trigger", triggerValueL);
            
        }
        if (leftHand.TryGetFeatureValue(CommonUsages.grip, out float gripValueL))
        {
            handAnimatorL.SetFloat("Grip", gripValueL);
        } */
    }

}
