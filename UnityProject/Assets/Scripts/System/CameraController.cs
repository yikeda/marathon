using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour
{
	private DeviceRotation deviceRotation;	
	[SerializeField] private CurvySplineBase spline;
    [SerializeField] private float speed = 10;	
	[SerializeField] private float initialPositionRate = 0.0f;	
	[SerializeField] private float aimPositionRateDiff = 0.1f;	
	[SerializeField] private int direction = 1;
	
	private float positionRate;
	
	void Awake ()		
    {
		this.deviceRotation = (DeviceRotation)gameObject.AddComponent("DeviceRotation");
		this.deviceRotation.ResetDeviceRotation();
    }
		
    void Update()
    {
		if (spline == null || (spline != null && !spline.IsInitialized))
			return;
		
		float aimPositionRate = positionRate + aimPositionRateDiff;
		Vector3 position = spline.MoveBy(ref positionRate, ref direction, speed * Time.deltaTime, CurvyClamping.Loop);
		Vector3 aimPosition = spline.MoveBy(ref aimPositionRate, ref direction, speed * Time.deltaTime, CurvyClamping.Loop);

		Vector3 directionVec = aimPosition - position;
		directionVec = directionVec.normalized;
		
		var newRotation = deviceRotation.Current.eulerAngles;
		this.transform.position = position;
		this.transform.LookAt(aimPosition, Quaternion.AngleAxis(newRotation.z, directionVec) * Vector3.up);
	}
}
