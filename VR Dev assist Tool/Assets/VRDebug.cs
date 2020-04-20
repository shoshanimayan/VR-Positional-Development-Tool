

using UnityEngine;
using System.Collections;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.UI;

public class VRDebug : MonoBehaviour
{
	public XRController leftHand;
	public XRController rightHand;
	public XRController headNode;

	public Text L1;
	public Text L3;
	public Text L4;
	public Text L5;
	public Text L6;
	public Text L7;
	public Text L8;
	public Text L9;
	public Text L10;
    public Text L11;

	public Text R1;
	public Text R3;
	public Text R4;
	public Text R5;
	public Text R6;
	public Text R7;
	public Text R8;
	public Text R9;
	public Text R10;
    public Text R11;


    public Text H1;
    public Text H2;
    public Text H3;
    public Text H4;
    public Text H5;
    public Text H6;
    public Text H7;
    public Text H8;

    private void Update()
	{

        
		bool gripL = false;
		bool triggerL = false;
		bool primaryAxisTouchL = false;
		bool primaryTouchL = false;
		bool secondaryTouchL = false;
		float triggerDownL = 0;
		Vector3 positionL = Vector3.zero;
		Vector3 velocityL = Vector3.zero;
		Quaternion rotationL = new Quaternion();
        
        
		bool gripR = false;
		bool triggerR = false;
		bool primaryAxisTouchR = false;
		bool primaryTouchR = false;
		bool secondaryTouchR = false;
		float triggerDownR = 0;
		Vector3 positionR = Vector3.zero;
		Vector3 velocityR = Vector3.zero;
		Quaternion rotationR = new Quaternion();


        Vector3 positionH = Vector3.zero;
        Vector3 velocityH = Vector3.zero;
        Quaternion rotationH = new Quaternion();

        //1. Collect controller data
        InputDevice handL = InputDevices.GetDeviceAtXRNode(leftHand.controllerNode);
		InputDevice handR = InputDevices.GetDeviceAtXRNode(rightHand.controllerNode);
		InputDevice head = InputDevices.GetDeviceAtXRNode(headNode.controllerNode);

		handL.TryGetFeatureValue(CommonUsages.gripButton, out gripL);
		handL.TryGetFeatureValue(CommonUsages.triggerButton, out triggerL);
		handL.TryGetFeatureValue(CommonUsages.primary2DAxisTouch, out primaryAxisTouchL);
		handL.TryGetFeatureValue(CommonUsages.primaryTouch, out primaryTouchL);
		handL.TryGetFeatureValue(CommonUsages.secondaryTouch, out secondaryTouchL);
		handL.TryGetFeatureValue(CommonUsages.trigger, out triggerDownL);
		handL.TryGetFeatureValue(CommonUsages.devicePosition, out positionL);
		handL.TryGetFeatureValue(CommonUsages.deviceVelocity, out velocityL);
		handL.TryGetFeatureValue(CommonUsages.deviceRotation, out rotationL);

		handR.TryGetFeatureValue(CommonUsages.gripButton, out gripR);
		handR.TryGetFeatureValue(CommonUsages.triggerButton, out triggerR);
		handR.TryGetFeatureValue(CommonUsages.primary2DAxisTouch, out primaryAxisTouchR);
		handR.TryGetFeatureValue(CommonUsages.primaryTouch, out primaryTouchR);
		handR.TryGetFeatureValue(CommonUsages.secondaryTouch, out secondaryTouchR);
		handR.TryGetFeatureValue(CommonUsages.trigger, out triggerDownR);
		handR.TryGetFeatureValue(CommonUsages.devicePosition, out positionR);
		handR.TryGetFeatureValue(CommonUsages.deviceVelocity, out velocityR);
		handR.TryGetFeatureValue(CommonUsages.deviceRotation, out rotationR);

        head.TryGetFeatureValue(CommonUsages.devicePosition, out positionH);
        head.TryGetFeatureValue(CommonUsages.deviceVelocity, out velocityH);
        head.TryGetFeatureValue(CommonUsages.deviceRotation, out rotationH);


        float LeftToRight =Vector3.Distance(positionL,positionR);
        H1.text = "position: "+positionH.ToString();
        H2.text = "velocity: "+velocityH.ToString();
        H3.text = "rotation: "+rotationH.ToString();
        H4.text = "distance from hands:"+LeftToRight.ToString();
        H5.text = "positions added: "+(positionL + positionR).ToString();
        H6.text = "position added relative: "+(headNode.transform.InverseTransformDirection(positionR) + headNode.transform.InverseTransformDirection(positionL)).ToString();
        H7.text = "distance head to left: "+(positionL - positionH).ToString();
        H8.text = "distance head to right: "+(positionR - positionH).ToString();

        //h1h2h3h4

        L1.text = "grip: "+gripL.ToString();
		L3.text = "primary axis: "+primaryAxisTouchL.ToString();
		L4.text = "primary touch "+primaryTouchL.ToString();
		L5.text = "secondary touch: "+secondaryTouchL.ToString();
		L6.text = "trigger down: "+triggerDownL.ToString();
		L7.text = "trigger: "+triggerL.ToString();
        L8.text = "postion locat: "+headNode.transform.InverseTransformDirection(positionL).ToString();
        L9.text = "velocity: " +velocityL.ToString();
		L10.text = "rotation: "+rotationL.ToString();
        L11.text = "world position"+positionL.ToString();

		R1.text = "grip: "+gripR.ToString();
		R3.text = "primary axis: " + primaryAxisTouchR.ToString();
		R4.text = "primary touch " + primaryTouchR.ToString();
		R5.text = "secondary touch: " + secondaryTouchR.ToString();
		R6.text = "trigger down: " + triggerDownR.ToString();
		R7.text = "trigger: " + triggerR.ToString();
        R8.text = "postion locat: " + headNode.transform.InverseTransformDirection(positionR).ToString();
        R9.text = "velocity: " + velocityR.ToString();
		R10.text = "rotation: " + rotationR.ToString();
        R11.text = "world position" + positionR.ToString();




    }
}