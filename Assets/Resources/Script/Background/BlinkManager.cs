using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinkManager : MonoBehaviour
{
    public LoopType loopType;
    public Text text;
    void Start()
    {
        text.DOFade(0.0f, 1).SetLoops(-1, loopType);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
