using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class EarthController : MonoBehaviour
{
	public GameObject LeftHand;
	public GameObject RightHand;
	 public float speed = 0;
	private bool gachetDroite = false;
	 // path real class : Assets/Oculus/Avatar/Samples/SocialStarter/Assets/Scripts/PlayerController.cs 
	 // Start is called before the first frame update
	 void Start()
	 {
	}

	 // Update is called once per frame
	 void Update()
	 {
		 // get input data from keyboard or controller
		 float moveHorizontal = Input.GetAxis("Horizontal");
		 float moveVertical = Input.GetAxis("Vertical");
		 var posRightHandInit = RightHand.transform.position;
		var posEarthInit = transform.eulerAngles.y;
		 if (Input.GetButtonDown("gachetDroite"))
		 {
			//Manette regarder la position en x pour rotation en y
			gachetDroite = true;
			print("pos manette init = " + posRightHandInit);
			print("Pos Earth init " + posEarthInit);
		}
		 if(gachetDroite)
		{
			var rotation = transform.eulerAngles;
			rotation.y += 5 * speed;

			//print("gachetDroite avant rota " + transform.eulerAngles.y + " apres rota " + rotation.y);
			transform.eulerAngles = rotation;
		}

		 if(Input.GetButtonUp("gachetDroite"))
		{
			print("pos manette final = " + RightHand.transform.position);
			print("Pos Earth final " + transform.eulerAngles.y);
			gachetDroite = false;
		}
		if (Input.GetButtonDown("gachetGauche"))
		{
			//print("gachetGauche");

		}

		 // update player position based on input
		 Vector3 position = transform.position;
		 position.x += moveHorizontal * speed * Time.deltaTime;
		 position.z += moveVertical * speed * Time.deltaTime;
		 transform.position = position;
	}
}
