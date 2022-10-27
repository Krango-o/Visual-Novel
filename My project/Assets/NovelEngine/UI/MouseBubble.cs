using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MouseBubble : MonoBehaviour
{
    [SerializeField]
    private Image image;
    [SerializeField]
    private CanvasScaler cs;
    private Material mat;
    [SerializeField]
    private Color color;
    private float distance = 0;
    private Tween tween;
    [SerializeField]
    private float duration = 0.5f;
    [SerializeField]
    private Vector2 direction = new Vector2(0, 0);

    private Vector4[] pulseList = new Vector4[32];
    private List<Tween> tweens = new List<Tween>();
    private int currentIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        image.material = new Material(image.materialForRendering);
        mat = image.materialForRendering;
        mat.SetColor("_Color", color);
        mat.SetFloat("_Ratio", image.rectTransform.sizeDelta.x / image.rectTransform.sizeDelta.y);
        mat.SetVectorArray("_PulseArray", new Vector4[32]);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        //Vector2 mouseScale = new Vector2(cs.referenceResolution.x / Screen.width, cs.referenceResolution.y / Screen.height);
        Vector2 scale = new Vector2(cs.referenceResolution.x / image.rectTransform.sizeDelta.x, cs.referenceResolution.y / image.rectTransform.sizeDelta.y);

        Vector2 output;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(image.rectTransform, mousePosition, Camera.main, out output);
        output += (cs.referenceResolution / 2) / scale;
        output = output / image.rectTransform.sizeDelta;
        Vector4 finalPos = new Vector4(output.x, output.y, 0, 0);

        //Goal is to get screen space value
        mat.SetVector("_MousePos", finalPos);
        bool containsPoint = finalPos.x > 0 && finalPos.x <= 1.5f && finalPos.y > 0 && finalPos.y <= 1.0f;
        if (containsPoint && Input.GetMouseButtonDown(0))
        {
            //distance = 0.0f;
            //mat.SetVector("_PulsePos", finalPos);
            //tween = DOTween.To(() => distance, x => distance = x, 1.5f, duration).OnUpdate(() =>
            //{
            //    mat.SetFloat("_DistanceRadius", distance);
            //});

            Vector4 newPos = new Vector4(finalPos.x, finalPos.y, 0.0f);
            pulseList[currentIndex] = newPos;
            int index = currentIndex;
            currentIndex++;
            if(currentIndex >= pulseList.Length)
            {
                currentIndex = 0;
            }
            float newDist = 0.0f;
            DOTween.To(() => newDist, x => newDist = x, 1.5f, duration).OnUpdate(() =>
            {
                Debug.Log("Tweening" + pulseList[0].z);
                pulseList[index] = new Vector4(pulseList[index].x, pulseList[index].y, newDist, 0);
                mat.SetVectorArray("_PulseArray", pulseList);
                mat.SetInt("_ArrayLength", pulseList.Length);
            }).OnComplete(() => {
                pulseList[index] = new Vector4();
            });
        }
        mat.mainTextureOffset = mat.mainTextureOffset + (direction * Time.deltaTime);
    }
}
