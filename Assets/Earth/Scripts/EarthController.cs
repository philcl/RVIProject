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
	Vector3 posRightHandInitPosition;
	Quaternion posEarthInitRotation;
	public DataVisualizer Visualizer;

	// path real class : Assets/Oculus/Avatar/Samples/SocialStarter/Assets/Scripts/PlayerController.cs 
	// Start is called before the first frame update
	void Start()
	 {
		TextAsset jsonData = Resources.Load<TextAsset>("population");
		string json = jsonData.text;
		SeriesArray data = JsonUtility.FromJson<SeriesArray>(json);
		Visualizer.CreateMeshes(data.AllData);
		print("Data ready");
	}

	 // Update is called once per frame
	 void Update()
	 {
		if (Input.GetButtonDown("gachetDroite"))
		 {
			posRightHandInitPosition = RightHand.transform.localPosition;
			posEarthInitRotation = transform.rotation;
			//Manette regarder la position en x pour rotation en y
			gachetDroite = true;
			print("pos manette init = " + posRightHandInitPosition);
			print("Pos Earth init " + posEarthInitRotation.y);
		}
		 if(gachetDroite)
		{
			Vector3 gachetDroiteMvt = Vector3.zero;
			//Passage en valeur absolue 
			if(RightHand.transform.localPosition.x < 1)
				gachetDroiteMvt.x += -1 * RightHand.transform.localPosition.x;
			else
				gachetDroiteMvt.x += RightHand.transform.localPosition.x;
			if (posRightHandInitPosition.x < 1)
				gachetDroiteMvt.x -= -1 * posRightHandInitPosition.x;
			else
				gachetDroiteMvt.x -= posRightHandInitPosition.x;

			if (RightHand.transform.position.y < 1)
				gachetDroiteMvt.y += -1 * RightHand.transform.localPosition.y;
			else
				gachetDroiteMvt.y += RightHand.transform.localPosition.y;
			if (posRightHandInitPosition.y < 1)
				gachetDroiteMvt.y -= -1 * posRightHandInitPosition.y;
			else
				gachetDroiteMvt.y -= posRightHandInitPosition.y;

			//Mise a jour de la rotation de la Terre
			//Quaternion rotation1 = Quaternion.Euler(360.0f * gachetDroiteMvt.y, 0, 0.0f);
			//Quaternion rotation2 = Quaternion.Euler(0, 360.0f * gachetDroiteMvt.x, 0.0f);
			//transform.rotation = rotation2 * rotation1 * posEarthInitRotation;
			Quaternion rotation = Quaternion.Euler(360.0f * gachetDroiteMvt.y, 360.0f * gachetDroiteMvt.x, 0.0f);
			transform.rotation = rotation * Camera.main.transform.rotation * posEarthInitRotation;

		}

		 if(Input.GetButtonUp("gachetDroite"))
		{
			print("pos manette final = " + RightHand.transform.localPosition);
			print("Pos Earth final " + transform.localEulerAngles.y);
			gachetDroite = false;
		}
	}
}
