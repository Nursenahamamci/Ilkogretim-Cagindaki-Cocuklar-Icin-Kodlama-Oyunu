using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO.Ports;



public class karakter_hareket : MonoBehaviour {
	
	public GameObject menupaneli; 
	public GameObject menupaneli1;
	public GameObject hedefpaneli;
	GameObject inputField;
	InputField inf;
	SerialPort sp;

	// Use this for initialization
	void Start () {
		sp = new SerialPort ("COM5",9600,Parity.None,8,StopBits.One);
		sp.Open();
		Vector3 eng1=GameObject.FindGameObjectWithTag ("eng1").transform.position;
		Vector3 eng2=GameObject.FindGameObjectWithTag ("eng2").transform.position;
		Vector3 hdf=GameObject.FindGameObjectWithTag ("hdf").transform.position;
		eng1x=eng1.x;eng1y=eng1.y;
		eng2x=eng2.x;eng2y=eng2.y;
		hdfX=hdf.x;hdfY=hdf.y;

		inputField = GameObject.FindGameObjectWithTag("listbox");
		inf = inputField.GetComponent<InputField>();
		  
  
	}
 
	public float hareket_hizi=250;

	public float x = 0;
	public float y = 0; 
	public float z = 0;

	public float hdfX = 0;
	public float hdfY = 0; 

	public float eng1x = -3.6f;
	public float eng1y = 3.6f;

	public float eng2x = -3.6f;
	public float eng2y = -2.4f;

	public Rigidbody2D cisim;

	public Rigidbody2D cisim2;
	Vector3 move=Vector3.zero;
	float hss=2.0f;
	float zhss=0.1f;
	List<int> yol= new List<int>();

	public string yoll="";

	public bool engelegeldi=false;
	public bool hedefevardi=false;

	public float say = 3.0f;
	public float say1 = 3.0f;
	public int top = 0;



	void Update ()
	{
 
		if (engelegeldi) {

			print ("ok");
			print (say.ToString());

			say -= Time.deltaTime;
			if (say < 1) {
				
				engelegeldi = false;
				SceneManager.LoadScene ("sahne1");
			}
		}

		if (hedefevardi) {
			 
			say1 -= Time.deltaTime;
			if (say1 < 1) {
				 
				if (top < yol.Count) {  
					say1 = 2.0f;
					seri_port_veri_gonder (yol [top].ToString ());
					top++;
				} 
				else  {hedefevardi = false;
				}

				 
			
			}

		}

			/*for (int i = 0; i < yol.Count; i++) {
				seri_port_veri_gonder (yol[i].ToString());
			}*/
 
			if (Input.GetKeyDown (KeyCode.A) || Input.GetKeyDown (KeyCode.W) || Input.GetKeyDown (KeyCode.S) || Input.GetKeyDown (KeyCode.D)) {
				//if (Input.GetKey (KeyCode.A)||Input.GetKey (KeyCode.W)||Input.GetKey (KeyCode.S)||Input.GetKey (KeyCode.D)) {

				if (Input.GetKey (KeyCode.D)) {
					move = new Vector3 (1.2f, 0, 0);
				}  
				if (Input.GetKey (KeyCode.A)) {
					move = new Vector3 (-1.2f, 0, 0);
				}  
				if (Input.GetKey (KeyCode.W)) {
					move = new Vector3 (0, 1.2f, 0);
				}  
				if (Input.GetKey (KeyCode.S)) {
					move = new Vector3 (0, -1.2f, 0);
				}  
				 
				cisim.MovePosition (transform.position + transform.TransformDirection (move));
		
				if (Input.GetKey (KeyCode.A)) {
					yol.Add (1);
					yoll = yoll + "Sol - "; 
				}
				if (Input.GetKey (KeyCode.D)) {
					yol.Add (2);
					yoll = yoll + "Sağ - ";
				}
				if (Input.GetKey (KeyCode.W)) {
					yol.Add (3);
					yoll = yoll + "Yukarı - ";
				}
				if (Input.GetKey (KeyCode.S)) {
					yol.Add (4);
					yoll = yoll + "Aşağı - ";
				}
			
				
 
				kontrolet (false);

			}

		 


	}

	public void kontrolet(bool f)
	{
 
			
		if (f) { hss = 0.7f;}else { hss = 2.0f;}
		float sonX = cisim.position.x;
		float sonY = cisim.position.y;

		print ("x " + transform.position.x + " y " + transform.position.y);
		print ((hdfX - hss) + " < " + sonX + " / " + sonX + " < " + (hdfX + hss) + " / " + (hdfY - hss) + " < " + sonY + " / " + sonY + " < " + (hdfY + hss));
		print ((eng1x - hss) + " < " + sonX + " / " + sonX + " < " + (eng1x + hss) + " / " + (eng1y - hss) + " < " + sonY + " / " + sonY + " < " + (eng1y + hss));
		print ((eng2x - hss) + " < " + sonX + " / " + sonX + " < " + (eng2x + hss) + " / " + (eng2y - hss) + " < " + sonY + " / " + sonY + " < " + (eng2y + hss));

		if ((hdfX - hss) < sonX && sonX < (hdfX + hss) && (hdfY - hss) < sonY && sonY < (hdfY + hss)) {
			hedefpaneli.SetActive (true); 

			hedefevardi = true;
			top = 0;say1 = 2.0f;

		} else if ((eng1x - hss) < sonX && sonX < (eng1x + hss) && (eng1y - hss) < sonY && sonY < (eng1y + hss)) {
		   
			menupaneli.SetActive (true); 
			engelegeldi=true;

		} else if ((eng2x - hss) < sonX && sonX < (eng2x + hss) && (eng2y - hss) < sonY && sonY < (eng2y + hss)) { 
			 
			menupaneli1.SetActive (true);  
			engelegeldi=true;
		}

	}

	public void yoladim_yazdır(){
		
		string se = "";
		for (int i = 0; i < yol.Count; i++) {

			se = se + "-" + yol [i];
		}

		print (se);
	}

	public void yoluyazdir()
	{

		inf.text = yoll;
	}

	public void buton_sol_click()
	{
		yol.Add (1);
		yoll = yoll + "Sol - "; yoluyazdir ();
	}

	public void buton_sag_click()
	{
		yol.Add (2);
		yoll = yoll + "Sağ - "; yoluyazdir ();
	}

	public void buton_yukari_click()
	{
		yol.Add (3);
		yoll = yoll + "Yukarı - "; yoluyazdir ();
	}

	public void buton_asagi_click()
	{
		yol.Add (4);
		yoll = yoll + "Aşağı - "; yoluyazdir ();
	}

	public void komutu_uygula()
	{
		 
			for (int i = 0; i < yol.Count; i++) { 
			
				if (yol [i] == 1) { 
					move = new Vector3 ((cisim.transform.position.x + (-1.2f)), cisim.transform.position.y, 0);

				}

				if (yol [i] == 2) { 
					move = new Vector3 ((cisim.transform.position.x + (1.2f)), cisim.transform.position.y, 0);
				 
				}


				if (yol [i] == 3) { 
					move = new Vector3 ((cisim.transform.position.x), cisim.transform.position.y + (1.2f), 0);
				}


				if (yol [i] == 4) { 

					move = new Vector3 ((cisim.transform.position.x), cisim.transform.position.y + (-1.2f), 0);
				}

				cisim.transform.position = move;



			}
			kontrolet (true);
			
		 
	}
	public void seri_port_veri_gonder(string s){
  
		sp.Write (s);  
	
	}

}






