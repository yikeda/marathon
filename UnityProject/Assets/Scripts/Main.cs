using UnityEngine;

public class Main : MonoBehaviour
{
	void Awake ()		
    {
		Application.targetFrameRate = 60;
		Input.gyro.updateInterval = 0.01f;
    }
}
