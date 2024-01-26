using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DVDLogo : MonoBehaviour
{
    //public List<Sprite> DefaultAnimationCycle;
    public SpriteRenderer SpriteRenderer;
    //Speed it moves at
    public float speed = 3;

    //Bounds of the screen (could get these with camera bounds but we can do this since it's a fixed camera)
    public float X_Max = 5, Y_Max = 4;
    public float rotateAmount = 0.5f;
    //Current direction
    private Vector3 direction;

    public GameObject particleSystemToSpawn;
    //private float animationTimerMax;
    //private int index;
    //private float animationTimer = 0f;
    //public float Framerate;

    // Start is called before the first frame update
    void Start()
    {
        //Randomly initialize direction
        direction = new Vector3(Random.Range(-1f,1f), Random.Range(-1f,1f));
        direction.Normalize();
        //animationTimerMax = 1.0f / ((float)(Framerate));
        //animationTimer = 0f;
        //index = 0;
    }

    private void FlipDirectionX(){
        direction.x*=-1;
        direction.x+= Random.Range(-0.1f,0.1f);
        direction.y+= Random.Range(-0.1f,0.1f);
        direction.Normalize();
    }

    private void FlipDirectionY(){
        direction.y*=-1;
        direction.x+= Random.Range(-0.1f,0.1f);
        direction.y+= Random.Range(-0.1f,0.1f);
        direction.Normalize();
    }
    private void ChangeColor()
    {
        SpriteRenderer.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0, 1f));
        Instantiate(particleSystemToSpawn, transform.position, Quaternion.identity);
    }
    // Update is called once per frame
    void Update()
    {
        
        //Move in direction unless we'd go out of bounds, if so bounce with some randomness
        //animationTimer += Time.deltaTime;
        //if (animationTimer > animationTimerMax)
        //{
        //    Debug.Log(animationTimer);
        //    animationTimer = 0;
        //    index++;

        //    //    //SpriteRenderer.sprite = DefaultAnimationCycle[index % DefaultAnimationCycle.Count];

        //}
        Vector3 newPosition = transform.position + direction*Time.deltaTime*speed;

        //See if a bounce needs to happen before moving
        if (newPosition.x>X_Max){
            FlipDirectionX();
            ChangeColor();

        }
        else if (newPosition.x<-1*X_Max){
            FlipDirectionX();
            ChangeColor();
        }

        if (newPosition.y>Y_Max){
            FlipDirectionY();
            ChangeColor();

        }
        else if (newPosition.y<-1*Y_Max){
            FlipDirectionY();
            ChangeColor();
        }

        transform.position += direction*Time.deltaTime*speed;
        transform.Rotate(0, 0, rotateAmount);
    }
}
