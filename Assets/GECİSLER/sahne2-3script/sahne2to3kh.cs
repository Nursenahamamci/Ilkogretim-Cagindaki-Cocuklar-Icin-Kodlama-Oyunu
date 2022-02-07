using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class sahne2to3kh : MonoBehaviour {

		public GameObject menupaneli; 
		public GameObject menupaneli1;
		public GameObject hedefpaneli;
		// Use this for initialization
		void Start () {
			Vector3 v=GameObject.FindGameObjectWithTag ("kp").transform.position;
			print ("x " + v.x+"y " + v.y);

			hdfX = v.x;
			hdfY = v.y;

		}

		public float hareket_hizi;

		public float x = 0;
		public float y = 0; 
		public float z = 0;

		public float hdfX = 0;
		public float hdfY = 0;
		public Rigidbody2D cisim;

		public Rigidbody2D cisim2;
		Vector3 move=Vector3.zero;
		float hss=0.5f;
		float zhss=0.05f;
		List<int> yol= new List<int>();
		// Update is called once per frame
		void Update () {


			if (Input.GetKey (KeyCode.A)||Input.GetKey (KeyCode.W)||Input.GetKey (KeyCode.S)||Input.GetKey (KeyCode.D)) {
				x = Input.GetAxis ("Horizontal");
				y = Input.GetAxis ("Vertical");
				move = new Vector3 (x, y, 0) * zhss * hareket_hizi;
				cisim.MovePosition (transform.position + transform.TransformDirection (move));

				if (Input.GetKey (KeyCode.A)) { yol.Add (1);}
				if (Input.GetKey (KeyCode.D)) { yol.Add (2);}
				if (Input.GetKey (KeyCode.W)) { yol.Add (3);}
				if (Input.GetKey (KeyCode.S)) { yol.Add (4);}
			}


			float sonX = cisim.position.x;
			float sonY = cisim.position.y;

			print ("x " + transform.position.x+" y " + transform.position.y);
			if ((hdfX - hss) < sonX && sonX < (hdfX + hss) && (hdfY - hss) < sonY && sonY < (hdfY + hss)) {
				hedefpaneli.SetActive (true); 
				if (Input.GetKeyDown (KeyCode.Escape)) {
					SceneManager.LoadScene("sahne3");
				}
				print ("ok");

			} else if (sonX < -3 && sonY > 2) {
				print ("bitti");


				menupaneli.SetActive (true); 
				if (Input.GetKeyDown (KeyCode.Escape)) {
					this.gameObject.SetActive (false);
					SceneManager.LoadScene("sahne2");
				}
			} else if (sonX > -5 && sonY < -2) {
				print ("bitti");
				menupaneli1.SetActive (true); 
				if (Input.GetKeyDown (KeyCode.Escape)) {
					this.gameObject.SetActive (false);
					SceneManager.LoadScene("sahne2");
				}

			}

			string se = "";
			for (int i = 0; i < yol.Count; i++) {

				se = se +"-"+ yol [i];
			}

			print (se);
			//if (x > 3 && y < -3)
			//{
			//	this.gameObject.SetActive (false);
			//}




		}



	}







