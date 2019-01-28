using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour {
    [SerializeField]
    private EffectPool pool;

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
        pool = GameObject.FindGameObjectWithTag("EffectPool").GetComponent<EffectPool>();
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
                //GameObject effect = pool.GetFromPool((int)eEffectType.phaseShift);
                //effect.transform.position = transform.position;
                pool.GetFromPool((int)eEffectType.phaseShift).
                    transform.position = transform.position;
            }
            currentProgressPivot++;
        }
    }

}
