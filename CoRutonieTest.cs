using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoRutonieTest : MonoBehaviour
{
    GameObject Object;

    Vector3 originalSizes;
    Vector3 currentSizes;
    Vector3 wantedSizes;
    Vector3 originalLocation;
    Vector3 currentLocation;
    Vector3 wantedLocation;


    IEnumerator CNC;
    IEnumerator Nums;
    IEnumerator SADJ;

    float SizeOriginalX;
    float SizeOriginalY;
    float SizeOriginalZ;

    float sizeXAdj;
    float sizeYAdj;
    float sizeZAdj;

    float LocationOriginalX;
    float LocationOriginalY;
    float LocationOriginalZ;

    float locationXAdj;
    float locationYAdj;
    float locationZAdj;

    public float sizeWantedX;
    public float sizeWantedY;
    public float sizeWantedZ;

    public float locationWantedX;
    public float locationWantedY;
    public float locationWantedZ;

    float sizeToReachDistance;
    float locationToReachDistance;


    // Start is called before the first frame update
    void Start()
    {
        Object = this.gameObject;

        xTobe = SizeOriginalX;
        yToBe = SizeOriginalY;
        zToBe = SizeOriginalZ;

        //Coroutines
        CNC = CurrentNumberCalculator(.1f);
        Nums = NumberTaker();
        SADJ = SizeAdjusting();

        //StartTheCoroutine

        StartCoroutine(Nums);
        StartCoroutine(CNC);
        StartCoroutine(SADJ);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Sizer()
    {



    }
    IEnumerator NumberTaker()
    {
        SizeOriginalX = Object.transform.localScale.x;
        SizeOriginalY = Object.transform.localScale.y;
        SizeOriginalZ = Object.transform.localScale.z;

        LocationOriginalX = Object.transform.localPosition.x;
        LocationOriginalY = Object.transform.localPosition.y;
        LocationOriginalZ = Object.transform.localPosition.z;

        sizeXAdj = SizeOriginalX - wantedSizes.x;
        sizeYAdj = SizeOriginalY - wantedSizes.y;
        sizeZAdj = SizeOriginalZ - wantedSizes.z;


        originalSizes = new Vector3(SizeOriginalX, SizeOriginalY, SizeOriginalZ);
        originalLocation = new Vector3(LocationOriginalX, LocationOriginalY, LocationOriginalZ);
        wantedSizes = new Vector3(sizeWantedX, sizeWantedY, sizeWantedZ);
        wantedLocation = new Vector3(locationWantedX, locationWantedY, locationWantedZ);






        yield return null;
    }




    IEnumerator CurrentNumberCalculator(float waitTime)
    {


        while (true)
        {
            //LocationCalculations
            currentLocation = Object.transform.localPosition;
            locationToReachDistance = Vector3.Distance(currentLocation, wantedLocation);
            //SizeCalculations
            currentSizes = Object.transform.localScale;
            sizeToReachDistance = Vector3.Distance(currentSizes, wantedSizes);
            


            

            yield return new WaitForSeconds(waitTime);
        }


    }

    float xTobe;
    float yToBe;
    float zToBe;

    IEnumerator SizeAdjusting()
    {
        while (true)
        {
            if (sizeToReachDistance < 0)
            {
                xTobe += sizeXAdj / 3;
                yToBe += sizeYAdj / 3;
                zToBe += sizeYAdj / 3;


            }
            if (sizeToReachDistance > 0)
            {
                xTobe -= sizeXAdj / 3;
                yToBe -= sizeYAdj / 3;
                zToBe -= sizeYAdj / 3;


            }

            Object.transform.localScale = new Vector3(xTobe, yToBe, zToBe);

            yield return null;
        }

    }
}
