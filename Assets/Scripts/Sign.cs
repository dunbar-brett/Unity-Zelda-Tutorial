using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : MonoBehaviour
{
    public GameObject DialogBox;
    public Text DialogText;
    public string Dialog;
    public bool PlayerInRange;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && PlayerInRange)
		{
            if (DialogBox.activeInHierarchy)
			{
                DialogBox.SetActive(false);
			} else
			{
                DialogBox.SetActive(true);
                DialogText.text = Dialog;
            }
		}
    }

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
            PlayerInRange = true;
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
        if (other.CompareTag("Player"))
        {
            PlayerInRange = false;
            DialogBox.SetActive(false);
        }
    }
}
