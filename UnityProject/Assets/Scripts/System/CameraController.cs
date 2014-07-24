using UnityEngine;

public class CameraController : MonoBehaviour
{
	private DeviceRotation deviceRotation;
				
	void Awake ()		
    {
		this.deviceRotation = (DeviceRotation)gameObject.AddComponent("DeviceRotation");
		this.deviceRotation.ResetDeviceRotation();
		Application.targetFrameRate = 60;
		Input.gyro.updateInterval = 0.01f;
    }

    void Update()		
    {		
		transform.rotation = Quaternion.Inverse(this.deviceRotation.Z);
	}	
}
