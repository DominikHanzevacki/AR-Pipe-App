using TMPro;
using UnityEngine;

public class SpawnNewPipe : MonoBehaviour
{
    [SerializeField]
    GameObject newPipe;

    [SerializeField]
    GameObject currentPipes;

    [SerializeField]
    TMP_Dropdown chosenColor;
    [SerializeField]
    Material defaultMaterial;

    private GameObject newPipeChild;

    // Start is called before the first frame update
    void Start()
    {
        newPipeChild = newPipe.transform.GetChild(0).gameObject;
        newPipeChild.transform.GetChild(0).GetComponent<MeshRenderer>().sharedMaterial = defaultMaterial;
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
                    Material currentPipeMaterial = newPipeChild.transform.GetChild(0).GetComponent<MeshRenderer>().sharedMaterial;
                    Material newPipeMaterial = new Material(currentPipeMaterial);
                    newPipeMaterial.color = GetChosenColor();
                    newPipeChild.transform.GetChild(0).GetComponent<MeshRenderer>().sharedMaterial = newPipeMaterial;
                    Instantiate(newPipe, hit.transform.position, hit.transform.rotation, currentPipes.transform);
                    Debug.Log("Pipe Spawned: " + hit.transform.position + " " + hit.transform.rotation);
                }
            }
        }
    }

    private Color GetChosenColor()
    {
        if (chosenColor == null)
        {
            return Color.white;
        }
        switch (chosenColor.value)
        {
            case 0:
                return Color.white;
            case 1:
                return Color.red;
            case 2:
                return Color.blue;
            case 3:
                return Color.green;
            case 4:
                return Color.yellow;
            default: return Color.white;
        }
    }
}
