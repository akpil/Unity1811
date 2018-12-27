using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUPScript : MonoBehaviour {
    public int Score;
    public float xRot;
    public float yRot;
    public float zRot;

    private GameController control;

	// Use this for initialization
	void Start () {
        GameObject controllerObj = GameObject.FindGameObjectWithTag("GameController");
        control = controllerObj.GetComponent<GameController>();
	}

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(xRot, yRot, zRot) * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            control.AddScore(Score);
        }
    }

}
