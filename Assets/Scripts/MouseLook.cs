using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
	Vector2 rotation = Vector2.zero;
	public float speed = 3;

	void Update()
	{
		rotation.y += Input.GetAxis("Mouse X");
		rotation.x += -Input.GetAxis("Mouse Y");
		transform.eulerAngles = (Vector2)rotation * speed;

		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;

		if(Input.GetMouseButtonDown(0))
        {
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			if (Physics.Raycast(ray, out hit))
			{
				Transform objectHit = hit.transform;

				if(hit.collider != null)
                {
					SphereManager SM = GameObject.FindObjectOfType<SphereManager>();
					SM.NextSphere();
                }
			}
		}
	}
}
