using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class GunRecoilRandom : MonoBehaviour
{
    public GameObject bullet;
    public float maxX;
    public float maxY;
    private Ray ray = new Ray();
    private RaycastHit hit;
    [SerializeField]
    private float randR = 0f;
    [SerializeField]
    private float randT = 0f;
    [SerializeField]
    private float randX = 0f;
    [SerializeField]
    private float randY = 0f;
     
    private void Awake()
    {
        ray.origin = transform.position;
        ray.direction = transform.forward;
    }

    private float _Timer;
    private float _Interval = 0.1f;


    // Update is called once per frame
    void Update()
    {
        _Timer += Time.deltaTime;
     
        if(Input.GetMouseButton(0) && _Timer > _Interval)
        {
            _Timer = 0f;
            ray.origin = transform.position;
            ray.direction = transform.forward;
            if (Physics.Raycast(ray, out hit))
            {
                GameObject.Instantiate(bullet, hit.point, Quaternion.identity);
            }

            float a = Mathf.Sqrt(-2 * Mathf.Log(Random.Range(0f, 1f)));
            float b = Mathf.Cos(2f * Mathf.PI * Random.Range(0f, 1f));


            randR = (Mathf.Floor(a)) * (Mathf.Floor(b));

            a = Mathf.Sqrt(-2 * Mathf.Log(Random.Range(0f, 1f)));
            b = Mathf.Cos(2f * Mathf.PI * Random.Range(0f, 1f));
            randT = a * b;
            randX = randR * Mathf.Cos(randT) * maxX;
            randY = randR * Mathf.Sin(randT) * maxY;

        }
    }

    private void LateUpdate()
    {

        Vector3 localEuler = transform.localEulerAngles;
        localEuler.x += randX ; 
        localEuler.y += randY; 

        transform.localEulerAngles = localEuler;

        randX = 0f;
        randY = 0f;

       

    }
}
