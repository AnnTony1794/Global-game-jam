using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Checkpoint : MonoBehaviour
{
    private static Checkpoint sharedInstance;
    private Transform transform;
    float x, y , z;
    // Start is called before the first frame update
    private void Awake() {
        transform = GetComponent<Transform>();
    }
    void Start()
    {
        if(sharedInstance == null){
            sharedInstance = this;
        }
        PlayerPrefs.SetFloat("checkpointX", transform.position.x);
        PlayerPrefs.SetFloat("checkpointY", transform.position.y);
        PlayerPrefs.SetFloat("checkpointZ", transform.position.z);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "checkpoint"){
            PlayerPrefs.SetFloat("checkpointX", other.transform.position.x);
            PlayerPrefs.SetFloat("checkpointY", other.transform.position.y);
            PlayerPrefs.SetFloat("checkpointZ", other.transform.position.z);
            Debug.Log(PlayerPrefs.GetFloat("checkpointX"));
        }
    }

    public void restartOnCheckpoint(){
        x = PlayerPrefs.GetFloat("checkpointX");
        y = PlayerPrefs.GetFloat("checkpointY");
        z = PlayerPrefs.GetFloat("checkpointZ");
        transform.position = new Vector3(x, y ,z);
    }
    public void restartInitialState(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
