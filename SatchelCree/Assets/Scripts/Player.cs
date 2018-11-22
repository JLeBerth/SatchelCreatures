using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public Vector3 startpoint;
	public Vector3 endpoint;
	public float speed;
	private float increment;
	public bool isMoving;
	public bool isInCombat;

	public Main mainScript;
	//cameras
	public GameObject CameraMain;
	public GameObject CombatCamera;

	//Region
	public string inRegion;


	// Use this for initialization
	void Start ()
	{
		CombatCamera.SetActive(false);
		startpoint = transform.position;
		endpoint = transform.position;
		isInCombat = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(increment <=1 && isMoving==true)
		{
			increment += speed / 100;
		}
		else
		{
			isMoving = false;
		}

		if(isMoving)
		{
			transform.position = Vector3.Lerp(startpoint, endpoint, increment);
		}

		if (!isInCombat)
		{
			Move();
			if (Input.GetKeyDown("c"))
			{
				EnterCombat();
			}
		}
	}

	/// <summary>
	/// Callable method to tell the player that combat has been initiated
	/// </summary>
	public void EnterCombat()
	{
		isInCombat = true;
		CameraMain.SetActive(false);
		CombatCamera.SetActive(true);
	}

	/// <summary>
	/// Takes user input and moves around screen.
	/// </summary>
	public void Move()
	{
		if (Input.GetKey("w") && isMoving == false)
		{
			bool disableMove = false; ;
			RaycastHit hit;
			if(Physics.Raycast (transform.position, Vector3.forward, out hit, 1))
			{
				float distancetoGround = hit.distance;

				if (hit.collider.gameObject.tag == "tree")
				{
					disableMove = true;
				}
			}

			if (!disableMove)
			{
				increment = 0;
				isMoving = true;
				startpoint = transform.position;
				endpoint = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1);
			}
		}
		else if (Input.GetKey("s") && isMoving == false)
		{
			bool disableMove = false; ;
			RaycastHit hit;
			if (Physics.Raycast(transform.position, Vector3.forward * -1, out hit, 1))
			{
				float distancetoGround = hit.distance;

				if (hit.collider.gameObject.tag == "tree")
				{
					disableMove = true;
				}
			}

			if (!disableMove)
			{
				increment = 0;
				isMoving = true;
				startpoint = transform.position;
				endpoint = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);
			}
		}
		else if (Input.GetKey("a") && isMoving == false)
		{
			bool disableMove = false; ;
			RaycastHit hit;
			if (Physics.Raycast(transform.position, Vector3.right * -1, out hit, 1))
			{
				float distancetoGround = hit.distance;

				if (hit.collider.gameObject.tag == "tree")
				{
					disableMove = true;
				}
			}

			if (!disableMove)
			{
				increment = 0;
				isMoving = true;
				startpoint = transform.position;
				endpoint = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
			}
		}
		else if (Input.GetKey("d") && isMoving == false)
		{
			bool disableMove = false; ;
			RaycastHit hit;
			if (Physics.Raycast(transform.position, Vector3.right, out hit, 1))
			{
				float distancetoGround = hit.distance;

				if (hit.collider.gameObject.tag == "tree")
				{
					disableMove = true;
				}
			}

			if (!disableMove)
			{
				increment = 0;
				isMoving = true;
				startpoint = transform.position;
				endpoint = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
			}
		}
	}
}
