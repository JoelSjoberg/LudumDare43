using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class sactifice_ui_element : MonoBehaviour {

    [SerializeField]Image sacrifice_prompt;
    [SerializeField] Image launch_prompt;
    state_script state;
	// Use this for initialization
	void Start () {
        state = GetComponent<state_script>();
	}
	
	// Update is called once per frame
	void Update () {

        if (state.getDead() || !state.getLaunched())
        {
            sacrifice_prompt.gameObject.SetActive(false);
        }
        if (state.getLaunched() && !state.getDead())
        {
            launch_prompt.gameObject.SetActive(false);
            sacrifice_prompt.gameObject.SetActive(true);
        }
        if (!state.getDead() && !state.getLaunched())
        {
            launch_prompt.gameObject.SetActive(true);
        }

    }
}
