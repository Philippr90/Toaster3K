using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PackageSpawnScript : MonoBehaviour
{
    private Vector3 Min;
    private Vector3 Max;
    private float _xAxis;
    private float _yAxis;
    private float _zAxis; //If you need this, use it
    private Vector3 _randomPosition;
    public bool enableSpawn = false, _canInstantiate = false;

    public int waitTimeMin = 90; // 
    public int waitTimeMax = 120; // 
    private float timer = 0.0f;
    private float visualTime = 0.0f;

    public Text helpTextField;
    private bool helpDisplayed = false;
    public GameObject PackageToSpwan;

    private void Start()
    {
        if (enableSpawn)
        {
            SetRanges();
            StartCoroutine(waiter());
            if (helpTextField != null)
                helpTextField.gameObject.SetActive(false);
        }
    }

    private bool newInstance = false;
    [SerializeField] private Color textColor = Color.yellow;
    Rect scoreRect;
    GUIStyle style;
    private void Update()
    {

        _xAxis = UnityEngine.Random.Range(Min.x, Max.x);
        _yAxis = UnityEngine.Random.Range(Min.y, Max.y);
        _zAxis = UnityEngine.Random.Range(Min.z, Max.z);
        _randomPosition = new Vector3(_xAxis, _yAxis, _zAxis);

        if (newInstance && enableSpawn)
        {
            newInstance = false;
            InstantiateRandomObjects();
            if (helpTextField != null)
            {
                if (helpTextField.gameObject.active)
                {
                    helpTextField.gameObject.SetActive(false); ;
                }
                helpTextField.text = "Hint: Try picking up by flying over it while holding left <CTRL>";

                if (!helpDisplayed)
                {
                    helpTextField.gameObject.SetActive(true);
                    helpDisplayed = true;
                }
                StartCoroutine(waiterHelpTextField());
                StartCoroutine(waiter());
            }



        }
        // Check if we have reached beyond 2 seconds.
        // Subtracting two is more accurate over time than resetting to zero.


    }

    private void generateRandom()
    {
        SetRanges();
        _xAxis = UnityEngine.Random.Range(Min.x, Max.x);
        _yAxis = UnityEngine.Random.Range(Min.y, Max.y);
        _zAxis = UnityEngine.Random.Range(Min.z, Max.z);
        _randomPosition = new Vector3(_xAxis, _yAxis, _zAxis);

    }


    IEnumerator waiter()
    {

        // Wait for 4 seconds
        yield return new WaitForSeconds(UnityEngine.Random.Range(waitTimeMin, waitTimeMax));
        newInstance = true;
    }

    IEnumerator waiterHelpTextField()
    {

        // Wait for 4 seconds
        yield return new WaitForSeconds(10);
        helpTextField.gameObject.SetActive(false);
    }

    //Here put the ranges where your object will appear, or put it in the inspector.
    private void SetRanges()
    {
        // 6 - Make sure we are not outside the camera bounds
        var dist = (transform.position - Camera.main.transform.position).z;

        var leftBorder = Camera.main.ViewportToWorldPoint(
          new Vector3(0, 0, dist)
        ).x;

        var rightBorder = Camera.main.ViewportToWorldPoint(
          new Vector3(1, 0, dist)
        ).x;

        var topBorder = Camera.main.ViewportToWorldPoint(
          new Vector3(0, 0, dist)
        ).y;

        var bottomBorder = Camera.main.ViewportToWorldPoint(
          new Vector3(0, 1, dist)
        ).y;


        Max = new Vector3(leftBorder, topBorder, 1);
        Min = new Vector3(rightBorder, bottomBorder, 1);//%= new Vector3(20, 10, 1); //Another ramdon value, just for the example.        

    }
    private void InstantiateRandomObjects()
    {
        if (_canInstantiate)
        {
            generateRandom();
            Instantiate(PackageToSpwan, _randomPosition, Quaternion.identity);
        }

    }

}


