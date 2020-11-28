using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Akm2_0 : MonoBehaviour
{

    private GameObject Object;
    private GameObject Children;

    private Vector3 ObjectSizes;
    [SerializeField]
    [Range(0,1)]
    float CallFrameTime;



    public bool randomStartSizes;
    public bool givenSizeShrinker;
    public bool randomSizeShrinker;




    public bool canRotate;
    public bool randomRotations;
    public bool rotateOnReverse;


    public bool rotateOnX;
    public bool rotateOnY;
    public bool rotateOnZ;
    [Range(0f, 1000f)]
    public float SizeXShrinker;
    [Range(0f, 1000f)]
    public float SizeYShrinker;
    [Range(0f, 1000f)]
    public float SizeZShrinker;

    public float rotateSpeedControlX;
    public float rotateSpeedControlY;
    public float rotateSpeedControlZ;


    private float randomRotateSpeedControlX;
    private float randomRotateSpeedControlY;
    private float randomRotateSpeedControlZ;



    private float SizeX;
    private float SizeY;
    private float SizeZ;


    private float SizeXU;
    private float SizeYU;
    private float SizeZU;

    private float Xmin;
    private float Ymin;
    private float Zmin;



    private bool biggerX;
    private bool biggerY;
    private bool biggerZ;

    private float RotationX;
    private float RotationY;
    private float RotationZ;

    private float rotateAmount1;
    private float rotateAmount2;
    private float rotateAmount3;


    private float shrinkSpeedX;
    private float shrinkSpeedY;
    private float shrinkSpeedZ;

    private float randomSpeedX;
    private float randomSpeedY;
    private float randomSpeedZ;



    private float randomSizeX;
    private float randomSizeY;
    private float randomSizeZ;



    IEnumerator ADJ1;
    IEnumerator MVM1;
    IEnumerator RTS;
    IEnumerator RTT;
    IEnumerator RTTR;




    private void Awake()
    {
        Fixers();


    }
    // Start is called before the first frame update
    void Start()
    {
        Object = this.gameObject;

        

        ADJ1 = AdjusterSize1(CallFrameTime);
        MVM1 = Moves1(CallFrameTime);
        RTS = RotatorSpeeds(CallFrameTime);
        RTT = RotatorsThat(CallFrameTime);
        RTTR = RotatorsRandom(CallFrameTime);


        randomSizeX = Random.Range(this.gameObject.transform.localScale.x / 2, this.gameObject.transform.localScale.x * 6);
        randomSizeY = Random.Range(this.gameObject.transform.localScale.y / 2, this.gameObject.transform.localScale.y * 6);
        randomSizeZ = Random.Range(this.gameObject.transform.localScale.z / 2, this.gameObject.transform.localScale.z * 6);

        if (randomStartSizes)
        {
            ObjectSizes = new Vector3(randomSizeX, randomSizeY, randomSizeZ);

            SizeXU = randomSizeX;
            SizeYU = randomSizeY;
            SizeZU = randomSizeZ;

            SizeX = randomSizeX;
            SizeY = randomSizeY;
            SizeZ = randomSizeZ;



        }
        else
        {
            SizeXU = this.gameObject.transform.localScale.x;
            SizeYU = this.gameObject.transform.localScale.y;
            SizeZU = this.gameObject.transform.localScale.z;

            SizeX = this.gameObject.transform.localScale.x;
            SizeY = this.gameObject.transform.localScale.y;
            SizeZ = this.gameObject.transform.localScale.z;
        }

        if (randomSizeShrinker)
        {
            givenSizeShrinker = false;

            randomSpeedX = Random.Range(SizeXU / 4, SizeXU * 4);
            randomSpeedY = Random.Range(SizeYU / 4, SizeYU * 4);
            randomSpeedZ = Random.Range(SizeZU / 4, SizeZU * 4);


            SizeXShrinker = randomSpeedX;
            SizeYShrinker = randomSpeedY;
            SizeZShrinker = randomSpeedZ;
        }
        else if (givenSizeShrinker)
        {
            randomSizeShrinker = false;
        }








        if (randomRotations)
        {
            this.gameObject.transform.localEulerAngles = new Vector3(Random.Range(-360, 360), Random.Range(-360, 360), Random.Range(-360, 360));


            randomRotateSpeedControlX = Random.Range(-90, 90);
            randomRotateSpeedControlY = Random.Range(-90, 90);
            randomRotateSpeedControlZ = Random.Range(-90, 90);

            RotationX = gameObject.transform.localEulerAngles.x;
            RotationY = gameObject.transform.localEulerAngles.y;
            RotationZ = gameObject.transform.localEulerAngles.z;

            rotateAmount1 = randomRotateSpeedControlX - RotationX;
            rotateAmount2 = randomRotateSpeedControlY - RotationY;
            rotateAmount3 = randomRotateSpeedControlZ - RotationZ;

            rotateOnX = true;
            rotateOnY = true;
            rotateOnZ = true;






        }
        else
        {
            RotationX = gameObject.transform.localEulerAngles.x;
            RotationY = gameObject.transform.localEulerAngles.y;
            RotationZ = gameObject.transform.localEulerAngles.z;

            rotateAmount1 = rotateAmount1 - RotationX;
            rotateAmount2 = rotateAmount2 - RotationY;
            rotateAmount3 = rotateAmount3 - RotationZ;
        }


        StartCoroutine(RTS);
        if (canRotate)
        {
            randomRotations = false;
            StartCoroutine(RTT);

        }
        else if (randomRotations)
        {
            canRotate = false;
            StartCoroutine(RTTR);
        }

        if (givenSizeShrinker || randomSizeShrinker)
        {
            StartCoroutine(ADJ1);
            StartCoroutine(MVM1);
        }

    }

    // Update is called once per frame
    void Update()
    {      
        DynamicSize();
        NumberTaker();
    }


    public void NumberTaker()
    {
        shrinkSpeedX = Time.deltaTime * (SizeXShrinker / (2 * 3));
        shrinkSpeedY = Time.deltaTime * (SizeYShrinker / (2 * 3));
        shrinkSpeedZ = Time.deltaTime * (SizeZShrinker / (2 * 3));
    }

    IEnumerator AdjusterSize1(float waittime)
    {
        while (true)
        {

            Xmin = SizeXU - SizeXShrinker;
            Ymin = SizeYU - SizeYShrinker;
            Zmin = SizeZU - SizeZShrinker;

            SizeX = Mathf.Clamp(SizeX, Xmin, SizeXU);
            SizeY = Mathf.Clamp(SizeY, Ymin, SizeYU);
            SizeZ = Mathf.Clamp(SizeZ, Zmin, SizeZU);

            ObjectSizes = new Vector3(SizeX, SizeY, SizeZ);

            yield return new WaitForSeconds(waittime);
        }



    }
   /* public void SizeAdjuster1()
    {
        Xmin = SizeXU - SizeXShrinker;
        Ymin = SizeYU - SizeYShrinker;
        Zmin = SizeZU - SizeZShrinker;

        SizeX = Mathf.Clamp(SizeX, Xmin, SizeXU);
        SizeY = Mathf.Clamp(SizeY, Ymin, SizeYU);
        SizeZ = Mathf.Clamp(SizeZ, Zmin, SizeZU);

        ObjectSizes = new Vector3(SizeX, SizeY, SizeZ);
    }
   */
    public void DynamicSize()
    {
        Object.transform.localScale = ObjectSizes;
    }

    IEnumerator Moves1(float waittime)
    {

        while (true)
        {
            if (SizeX <= Xmin)
            {
                biggerX = false;
            }
            if (SizeX >= SizeXU)
            {
                biggerX = true;
            }

            if (SizeY <= Ymin)
            {
                biggerY = false;
            }
            if (SizeY >= SizeYU)
            {
                biggerY = true;
            }

            if (SizeZ <= Zmin)
            {
                biggerZ = false;
            }
            if (SizeZ >= SizeZU)
            {
                biggerZ = true;
            }

            if (!biggerX)
            {
                SizeX += shrinkSpeedX;

            }
            if (biggerX)
            {
                SizeX -= shrinkSpeedX;

            }

            if (!biggerY)
            {
                SizeY += shrinkSpeedY;

            }
            if (biggerY)
            {
                SizeY -= shrinkSpeedY;

            }

            if (!biggerZ)
            {
                SizeZ += shrinkSpeedZ;

            }
            if (biggerZ)
            {
                SizeZ -= shrinkSpeedZ;

            }

            yield return new WaitForSeconds(waittime);
        }
 
        
    }

   /* public void MoveIt1()
    {
        if (SizeX <= Xmin)
        {
            biggerX = false;
        }
        if (SizeX >= SizeXU)
        {
            biggerX = true;
        }

        if (SizeY <= Ymin)
        {
            biggerY = false;
        }
        if (SizeY >= SizeYU)
        {
            biggerY = true;
        }

        if (SizeZ <= Zmin)
        {
            biggerZ = false;
        }
        if (SizeZ >= SizeZU)
        {
            biggerZ = true;
        }

        if (!biggerX)
        {
            SizeX += shrinkSpeedX;

        }
        if (biggerX)
        {
            SizeX -= shrinkSpeedX;

        }

        if (!biggerY)
        {
            SizeY += shrinkSpeedY;

        }
        if (biggerY)
        {
            SizeY -= shrinkSpeedY;

        }

        if (!biggerZ)
        {
            SizeZ += shrinkSpeedZ;

        }
        if (biggerZ)
        {
            SizeZ -= shrinkSpeedZ;

        }
    }
   */

    IEnumerator RotatorSpeeds(float waittime)
    {

        while (true)
        {

            if (randomRotations)
            {
                rotateAmount1 += Time.deltaTime * randomRotateSpeedControlX;
                rotateAmount2 += Time.deltaTime * randomRotateSpeedControlY;
                rotateAmount3 += Time.deltaTime * randomRotateSpeedControlZ;
            }
            else
            {
                if (!rotateOnReverse)
                {

                    rotateAmount1 += Time.deltaTime * rotateSpeedControlX;
                    rotateAmount2 += Time.deltaTime * rotateSpeedControlY;
                    rotateAmount3 += Time.deltaTime * rotateSpeedControlZ;
                }
                else
                {

                    rotateAmount1 -= Time.deltaTime * rotateSpeedControlX;
                    rotateAmount2 -= Time.deltaTime * rotateSpeedControlY;
                    rotateAmount3 -= Time.deltaTime * rotateSpeedControlZ;
                }
            }

            yield return new WaitForSeconds(waittime);
        }

        
    }
    /*public void RotateSpeed()
    {
        if (randomRotations)
        {
            rotateAmount1 += Time.deltaTime * randomRotateSpeedControlX;
            rotateAmount2 += Time.deltaTime * randomRotateSpeedControlY;
            rotateAmount3 += Time.deltaTime * randomRotateSpeedControlZ;
        }
        else
        {
            if (!rotateOnReverse)
            {

                rotateAmount1 += Time.deltaTime * rotateSpeedControlX;
                rotateAmount2 += Time.deltaTime * rotateSpeedControlY;
                rotateAmount3 += Time.deltaTime * rotateSpeedControlZ;
            }
            else
            {

                rotateAmount1 -= Time.deltaTime * rotateSpeedControlX;
                rotateAmount2 -= Time.deltaTime * rotateSpeedControlY;
                rotateAmount3 -= Time.deltaTime * rotateSpeedControlZ;
            }
        }


    }
    */

    IEnumerator RotatorsThat(float waittime)
    {

        while (true)
        {

            if (rotateOnX && !rotateOnY && !rotateOnZ)
            {
                Object.transform.rotation = Quaternion.Euler(rotateAmount1, RotationY, RotationZ);
            }
            else if (rotateOnX && rotateOnY && !rotateOnZ)
            {
                Object.transform.rotation = Quaternion.Euler(rotateAmount1, rotateAmount2, RotationZ);
            }
            else if (rotateOnX && rotateOnY && rotateOnZ)
            {
                Object.transform.rotation = Quaternion.Euler(rotateAmount1, rotateAmount2, rotateAmount3);
            }
            else if (!rotateOnX && rotateOnY && !rotateOnZ)
            {
                Object.transform.rotation = Quaternion.Euler(RotationX, rotateAmount2, RotationZ);
            }
            else if (!rotateOnX && rotateOnY && rotateOnZ)
            {
                Object.transform.rotation = Quaternion.Euler(RotationX, rotateAmount2, rotateAmount3);
            }
            else if (!rotateOnX && !rotateOnY && rotateOnZ)
            {
                Object.transform.rotation = Quaternion.Euler(RotationX, RotationY, rotateAmount3);
            }

            yield return new WaitForSeconds(waittime);
        }

        
    }
    /*public void RotateThat()
    {
        if (rotateOnX && !rotateOnY && !rotateOnZ)
        {
            Object.transform.rotation = Quaternion.Euler(rotateAmount1, RotationY, RotationZ);
        }
        else if (rotateOnX && rotateOnY && !rotateOnZ)
        {
            Object.transform.rotation = Quaternion.Euler(rotateAmount1, rotateAmount2, RotationZ);
        }
        else if (rotateOnX && rotateOnY && rotateOnZ)
        {
            Object.transform.rotation = Quaternion.Euler(rotateAmount1, rotateAmount2, rotateAmount3);
        }
        else if (!rotateOnX && rotateOnY && !rotateOnZ)
        {
            Object.transform.rotation = Quaternion.Euler(RotationX, rotateAmount2, RotationZ);
        }
        else if (!rotateOnX && rotateOnY && rotateOnZ)
        {
            Object.transform.rotation = Quaternion.Euler(RotationX, rotateAmount2, rotateAmount3);
        }
        else if (!rotateOnX && !rotateOnY && rotateOnZ)
        {
            Object.transform.rotation = Quaternion.Euler(RotationX, RotationY, rotateAmount3);
        }
    }*/

    IEnumerator RotatorsRandom(float waittime)
    {

        while (true)
        {
            if (rotateOnX && !rotateOnY && !rotateOnZ)
            {
                Object.transform.rotation = Quaternion.Euler(rotateAmount1, RotationY, RotationZ);
            }
            else if (rotateOnX && rotateOnY && !rotateOnZ)
            {
                Object.transform.rotation = Quaternion.Euler(rotateAmount1, rotateAmount2, RotationZ);
            }
            else if (rotateOnX && rotateOnY && rotateOnZ)
            {
                Object.transform.rotation = Quaternion.Euler(rotateAmount1, rotateAmount2, rotateAmount3);
            }
            else if (!rotateOnX && rotateOnY && !rotateOnZ)
            {
                Object.transform.rotation = Quaternion.Euler(RotationX, rotateAmount2, RotationZ);
            }
            else if (!rotateOnX && rotateOnY && rotateOnZ)
            {
                Object.transform.rotation = Quaternion.Euler(RotationX, rotateAmount2, rotateAmount3);
            }
            else if (!rotateOnX && !rotateOnY && rotateOnZ)
            {
                Object.transform.rotation = Quaternion.Euler(RotationX, RotationY, rotateAmount3);
            }

            yield return new WaitForSeconds(waittime);
        }


        

    }
    /*public void RotateThatRandom()
    {
        if (rotateOnX && !rotateOnY && !rotateOnZ)
        {
            Object.transform.rotation = Quaternion.Euler(rotateAmount1, RotationY, RotationZ);
        }
        else if (rotateOnX && rotateOnY && !rotateOnZ)
        {
            Object.transform.rotation = Quaternion.Euler(rotateAmount1, rotateAmount2, RotationZ);
        }
        else if (rotateOnX && rotateOnY && rotateOnZ)
        {
            Object.transform.rotation = Quaternion.Euler(rotateAmount1, rotateAmount2, rotateAmount3);
        }
        else if (!rotateOnX && rotateOnY && !rotateOnZ)
        {
            Object.transform.rotation = Quaternion.Euler(RotationX, rotateAmount2, RotationZ);
        }
        else if (!rotateOnX && rotateOnY && rotateOnZ)
        {
            Object.transform.rotation = Quaternion.Euler(RotationX, rotateAmount2, rotateAmount3);
        }
        else if (!rotateOnX && !rotateOnY && rotateOnZ)
        {
            Object.transform.rotation = Quaternion.Euler(RotationX, RotationY, rotateAmount3);
        }
    }*/



    public void Fixers()
    {
        if (randomSizeShrinker && givenSizeShrinker)
        {
            randomSizeShrinker = false;
            givenSizeShrinker = true;
        }
        if (canRotate && randomRotations)
        {
            canRotate = true;
            randomRotations = false;
        }

        if (!randomSizeShrinker && !givenSizeShrinker)
        {
            givenSizeShrinker = true;
        }
        if(CallFrameTime == 0)
        {
            CallFrameTime = 0.02f;
        }
        /*if(!childrenHasRigidbody && childHasGravity) 
        {
            childHasGravity = false;
        }*/


    }
    /*
        public void ClutterFixer()
        {
            if(this.transform.childCount == 0)
            {
                Destroy(this.gameObject);
            }
        }

        public void CompForChild()
        {



            List<GameObject> childrenList = new List<GameObject>();

            Transform[] children = GetComponentsInChildren<Transform>(true);


            for (int i = 0; i < children.Length; i++)
            {
                Transform child = children[i];
                if (child != transform && child.childCount > 0)
                {
                    childrenList.Add(child.gameObject);
                }
            }
            for (int i = 0; i < childrenList.Count; i++)
            {
                AKMChildren akmc = childrenList[i].AddComponent<AKMChildren>();
                Rigidbody akmCRB = childrenList[i].AddComponent<Rigidbody>();



            }
        }*/

}
