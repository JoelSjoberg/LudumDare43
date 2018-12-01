using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelsetup : MonoBehaviour {

    [SerializeField]List<GameObject> player_objs;
    [SerializeField] Transform spawnfield;
    int pivot;
    // Use this for initialization
    private Transform inst_obj;

    void Awake ()
    {
        pivot = 0;
        foreach (GameObject g in player_objs)
        {
            g.SetActive(false);
            g.transform.position = spawnfield.position;
        }
        player_objs[0].SetActive(true);
        player_objs[0].GetComponent<sacrifice_script>().die += activateNext;
    }

    void activateNext()
    {
        if (pivot < player_objs.Count - 1)
        {
            pivot++;
            player_objs[pivot].SetActive(true);
            player_objs[pivot].GetComponent<sacrifice_script>().die += activateNext;
        }
    }

    public Transform getActivePlayer()
    {
        return player_objs[pivot].transform;
    }

	// Update is called once per frame
	void Update () {
		
	}
}
