using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Assessment : MonoBehaviour {

    //The answer to the assessment - value must be from 0 - 2;
    [SerializeField]
    int answer;

    private Dropdown dropdown;
    private Button button;

    private void Start()
    {
        dropdown = gameObject.GetComponent<Dropdown>();
        button = gameObject.GetComponent<Button>();
    }

    // Update is called once per frame
    void Update ()
    {
		if(dropdown.value == answer)
        {
            button.enabled = true;
        }
	}
}
