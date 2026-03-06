using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceAnimator : MonoBehaviour
{
    public enum FACE_ANIMATION
    {
        E_MOUTH_A,
        E_MOUTH_O,
        E_MOUTH_M,
        E_EYES_ANGER,
        E_EYES_TIRED,
        //E_EARS_DOWN,
    }

    [SerializeField]
    float _speed = 1f;
    private SkinnedMeshRenderer skinnedMeshRenderer;
    
    void Start()
    {
        skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();

        StartCoroutine(StartAni());
    }

    IEnumerator StartAni()
    {
        for (float weight = 0; weight <= 100f; weight += _speed)
        {
            skinnedMeshRenderer.SetBlendShapeWeight(0, weight);
            yield return null;
        }
    }

    IEnumerator StartAni(int idx)
    {
        for (float weight = skinnedMeshRenderer.GetBlendShapeWeight(idx); weight >= 0; weight -= _speed)
        {
            skinnedMeshRenderer.SetBlendShapeWeight(idx, weight);
            yield return null;
        }
    }


    public void Animate(params FACE_ANIMATION[] ele)
    {
        foreach(FACE_ANIMATION e in ele)
        {
            StartCoroutine(StartAni((int)e));
        }
    }
}
