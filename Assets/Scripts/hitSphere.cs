using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitSphere : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire1"))
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
