using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class aciklama : MonoBehaviour {

		public GameObject Panel;

		public void PanelAcma()
		{
		if (Panel != null) {
			bool isActive = Panel.activeSelf;
			Panel.SetActive (!isActive);

		}

}
}