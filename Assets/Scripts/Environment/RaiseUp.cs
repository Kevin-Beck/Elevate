using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaiseUp : MonoBehaviour
{
    public float raiseChance = .05f;
    public float raiseHeight = 1.5f;

    Rigidbody myRigidbody;
    Renderer myRenderer;

    private Vector3 startPosition;
    private Vector3 raisePosition;

    private bool isRaised = false;


    // Start is called before the first frame update
    void Start()
    {        
        myRigidbody = GetComponent<Rigidbody>();
        myRenderer = GetComponent<Renderer>();

        startPosition = myRigidbody.position;
        raisePosition = startPosition + new Vector3(0, raiseHeight, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        myRigidbody.velocity = Vector3.zero;
        myRigidbody.angularVelocity = Vector3.zero;
        if (isRaised)
        {
            return;
        }
        if (Random.Range(0f, 1f) < raiseChance)
        {
            isRaised = true;
            StartCoroutine(RaiseSequence());
        }
        
    }
    private void SetToRed()
    {
        myRenderer.material.color = Color.red;
    }
    private void SetToWhite()
    {
        myRenderer.material.color = Color.white;
    }
    private IEnumerator RaiseSequence()
    {
        SetToRed();
        yield return new WaitForSeconds(0.2f);
        SetToWhite();
        yield return new WaitForSeconds(0.2f);
        SetToRed();
        yield return new WaitForSeconds(0.2f);
        SetToWhite();
        yield return new WaitForSeconds(0.2f);
        SetToRed();

        while (Vector3.SqrMagnitude(myRigidbody.position - raisePosition) > 0.1)
        {
            RaiseTile();
        }

        yield return new WaitForSeconds(3.0f);
        SetToWhite();
        while(Vector3.SqrMagnitude(myRigidbody.position - startPosition) > 0.1)
        {
            LowerTile();
        }
        isRaised = false;
    }
    private void LowerTile()
    {
        myRigidbody.MovePosition(startPosition);        
    }
    private void RaiseTile()
    {
        myRigidbody.MovePosition(raisePosition);
    }
}
