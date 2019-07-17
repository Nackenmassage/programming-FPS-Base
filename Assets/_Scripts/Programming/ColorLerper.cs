//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class ColorLerper : MonoBehaviour
//{
//    [SerializeField] private Color color1;
//    [SerializeField] private Color color2;
//    [SerializeField] private float speed = 0.2f;
//    private Renderer rend;
//    private WaitForSeconds wfs1 = new WaitForSeconds(1f); //wfs1 = WaitForSeconds1
//    private bool keepdGoing = true;
//    private Coroutine animateColor;

//    void Start()
//    {
//        rend = GetComponent<Renderer>();
//        rend.material.color = color1;
//    }

//    void Update()
//    {
//        if (Input.GetButtonDown("Jump"))
//        {
//            animateColor = StartCoroutine(AnimateColor());
//        }
//        else if (Input.GetKeyDown(KeyCode.Escape))
//        {
//            StopCoroutine(animateColor);
//            //StopAllCoroutines();
//            //keepdGoing = false;
//        }
//    }

//    private IEnumerator AnimateColor()
//    {
//        float t = 0f;
//        while (t < 1)
//        {
//            rend.material.color = Color.Lerp(color1, color2, t);
//            t += speed * Time.deltaTime;
//            yield return null;
//        }
//        t = 0f;
//        yield return wfs1;
//        while (t < 1)
//        {
//            rend.material.color = Color.Lerp(color2, color1, t);
//            t += speed * Time.deltaTime;
//            yield return null;
//        }
//        Debug.Log("Coroutine ended");

//        animateColor = StartCoroutine(AnimateColor());

//        //if (keepdGoing)
//        //{
//        //    animateColor = StartCoroutine(AnimateColor());

//        //}
//    }
//}
