using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchMapPrefInit : MonoBehaviour {

    [HideInInspector]
	private TouchManager.TouchTypes actButton;
    int i = 5;

    public void SelectedButton(TouchManager.TouchTypes touch)
    {
        actButton = touch;
    }

    public void TestEnum()
    {
        
    }
}
