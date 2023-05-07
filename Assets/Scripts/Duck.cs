using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Duck : MonoBehaviour
{
    [SerializeField] private TerrainGenerator terrainGenerator;
    [SerializeField, Range(0,1)] float moveDuration = 0.5f;
    [SerializeField, Range(0,1)] float jumpHeight = 0.3f;
    [SerializeField] private Text scoreText;
    [SerializeField] private GameObject scoreboard;

    private Collision pohon;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(DOTween.IsTweening(transform))
        {
            terrainGenerator.SpawnTerrain(false, transform.position);
            return;
        }
        
        Vector3 direction = Vector3.zero;
        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            
            direction += Vector3.forward;
        }
        else if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            if(transform.position.z < -1)
            {
                return;
            }
            direction += Vector3.back;
        }
        else if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if(transform.position.x < -3.9f && transform.position.x > -4.3f)
            {
                return;
            }
            
            //transform.DOMoveX(transform.position.x-1, 0.2f);
            direction += Vector3.left;

        }
        else if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            if(transform.position.x > 3.9f && transform.position.x < 4.3f)
            {
                return;
            }
            
            //transform.DOMoveX(transform.position.x+1, 0.2f);
            direction += Vector3.right;
        }
        if(direction == Vector3.zero)
        {
            return;
        }
        Move(direction);
    }

    public void Move(Vector3 direction)
    {
        transform.DOJump(transform.position + direction, jumpHeight, 1, moveDuration);
        transform.DOLookAt(transform.position + direction, jumpHeight);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.GetComponent<Vehicle>() != null)
        {
            Destroy(gameObject);
            scoreboard.SetActive(true);
        }

        if(collision.collider.GetComponent<Tree>() != null)
        {
            scoreText.text = "nabrak";
            Destroy(gameObject);
            scoreboard.SetActive(true);
        }
    }
}

//if(pohon.collider.GetComponent<Tree>() != null)
//            {
//                direction += Vector3.zero;
//                return;
//            }
