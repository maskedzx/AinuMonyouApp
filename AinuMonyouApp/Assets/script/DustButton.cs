using UnityEngine;
using System.Collections;

public class DustButton : MonoBehaviour
{

    [SerializeField]
    private GameObject canvasObj;
    [SerializeField]
    private GameObject dustCanvasObj;
    [SerializeField]
    private GameObject dustObj;

    public void ModeDust()
    {
        canvasObj.SetActive(false);
        dustCanvasObj.GetComponent<Canvas>().enabled = true;
        dustObj.SetActive(true);
    }

}
