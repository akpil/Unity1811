using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour {

    [SerializeField]
    private Sprite[] Sprites;
    private SpriteRenderer rand;
    private float promoteGap;
    private int currentProgressPivot;
    private void Awake()
    {
        rand = GetComponent<SpriteRenderer>();
        promoteGap = 1f / Sprites.Length;
    }

    private void OnEnable()
    {
        currentProgressPivot = 1;
        rand.sprite = Sprites[0];
    }

    // Use this for initialization
    void Start () {
		
	}

    public void HideGem()
    {
        gameObject.SetActive(false);
    }

    public void SetProgress(float progress)
    {
        while (currentProgressPivot * promoteGap <= progress)
        {
            if (Sprites.Length > currentProgressPivot)
            {
                rand.sprite = Sprites[currentProgressPivot];
            }
            currentProgressPivot++;
        }
    }

}
