using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelsetup : MonoBehaviour {

    //[SerializeField]List<GameObject> player_objs;
    [SerializeField] Transform spawnfield;

    [SerializeField] List<GameObject> char_types;
    //[SerializeField] Transform player_object;
    List<GameObject> sacrifices = new List<GameObject>();
    GameObject selected_type;

    //int pivot;
    int type_pivot;
    // Use this for initialization
    //private Transform inst_obj;
    bool choosing_next;

    void Awake ()
    {
        choosing_next = true;
        //pivot = 0;
        type_pivot = -1;
        /*
        foreach (GameObject g in player_objs)
        {
            g.SetActive(false);
            g.transform.position = spawnfield.position;
        }
        player_objs[0].SetActive(true);
        player_objs[0].GetComponent<sacrifice_script>().die += activateNext;
        */


    }

    void activateNext()
    {
        choosing_next = true;
        /*
        if (pivot < player_objs.Count - 1)
        {
            pivot++;
            player_objs[pivot].SetActive(true);
            player_objs[pivot].GetComponent<sacrifice_script>().die += activateNext;
        }
        */
    }

    public Transform getActivePlayer()
    {
        //return player_objs[pivot].transform;
        if (type_pivot < 0) return null; 
        return sacrifices[type_pivot].transform;
    }



	// Update is called once per frame
	void Update () {

        if (choosing_next)
        {
            // bounce
            if (Input.GetKey(KeyCode.Q))
            {
                sacrifices.Add(CreateNewChar(0));
            }

            // boost
            if (Input.GetKey(KeyCode.W))
            {
                sacrifices.Add(CreateNewChar(1));
            }

            // secondWind
            if (Input.GetKey(KeyCode.E))
            {
                sacrifices.Add(CreateNewChar(2));
            }

            // shrink
            if (Input.GetKey(KeyCode.R))
            {
                sacrifices.Add(CreateNewChar(3));
            }

            // christmas
            if (Input.GetKey(KeyCode.T))
            {
                sacrifices.Add(CreateNewChar(4));
            }
        }
	}

    // order: 0 bounce, 1 boost, 2 secondWind, 3 shrink, 4 christmas
    GameObject CreateNewChar(int index)
    {
        choosing_next = false;
        selected_type = Instantiate(char_types[index], spawnfield.position, Quaternion.identity);
        selected_type.SetActive(true);
        selected_type.GetComponent<sacrifice_script>().die += activateNext;
        type_pivot++;
        return selected_type;
    }
}
