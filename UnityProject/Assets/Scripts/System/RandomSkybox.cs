using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Skybox))]
public class RandomSkybox : MonoBehaviour {	
	public Material[] materials;
	
	private int skyboxId;
	
	void Start () {
		skyboxId = Random.Range(0, materials.Length);
		SetSkybox(skyboxId);
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.Space) || 
			Input.GetKeyDown(KeyCode.RightArrow) || 
			Input.GetKeyDown(KeyCode.Plus) || 
			Input.GetKeyDown(KeyCode.KeypadPlus) || 
			Input.GetButtonDown("Fire1")) {
			skyboxId = ++skyboxId % (materials.Length - 1);
			SetSkybox(skyboxId);
		}
	}
	
	void SetSkybox(int index) {
		Camera.main.GetComponent<Skybox>().material = materials[index];
	}
}
