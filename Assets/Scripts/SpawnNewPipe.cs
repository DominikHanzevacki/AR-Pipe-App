using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNewPipe : MonoBehaviour
{
    [SerializeField]
    GameObject newPipe;
    [SerializeField]
    GameObject currentPipes;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.tag == "Pipe")
                {
                    Instantiate(newPipe, hit.transform.position, hit.transform.rotation, currentPipes.transform);
                    Debug.Log("Pipe Spawned: " + hit.transform.position + " " + hit.transform.rotation);
                }
            }
        }
    }
}
