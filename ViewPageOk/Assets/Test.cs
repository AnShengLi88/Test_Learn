using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

    public GameController controller;

	void Start ()
    {
        controller.LoadPhotoAlbum(5);
        //controller.SetTexture();
    }
	
	
	void Update ()
    {
		
	}
}
