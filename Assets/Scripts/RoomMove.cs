using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomMove : MonoBehaviour
{
    public Vector3 PlayerChange;
    public Vector2 CameraChangeMax;
    public Vector2 CameraChangeMin;
    private CameraMovement Cam;
    public bool NeedText;
    public string PlaceName;
    public GameObject Text;
    public Text PlaceText;

    // Start is called before the first frame update
    void Start()
    {
        Cam = Camera.main.GetComponent<CameraMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnTriggerEnter2D(Collider2D other)
	{
        if (other.CompareTag("Player"))
        {
            Cam.MinPosition.x = CameraChangeMin.x;
            Cam.MinPosition.y = CameraChangeMin.y;
            Cam.MaxPosition.x = CameraChangeMax.x;
            Cam.MaxPosition.y = CameraChangeMax.y;
            other.transform.position += PlayerChange;

            if (NeedText)
			{
                StartCoroutine(ShowPlaceNameCoroutine());
            }
        }
    }

    private IEnumerator ShowPlaceNameCoroutine()
	{
        Text.SetActive(true);
        PlaceText.text = PlaceName;
        yield return new WaitForSeconds(4f);
        Text.SetActive(false);
	}
}
