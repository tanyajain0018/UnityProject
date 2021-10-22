using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public AudioClip tele;
    AudioSource _audiosrc;
    public string sceneName;

    private void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
          StartCoroutine(playaudio());
        }
    }

    IEnumerator playaudio(){
      PublicVars.move =false;
      _audiosrc= GetComponent<AudioSource>();
      _audiosrc.PlayOneShot(tele);
      yield return new WaitForSeconds(1f);
      PublicVars.move = true;
      PublicVars.prevcheese = PublicVars.cheeseScore;
      PublicVars.cheeseScore = 0;
      SceneManager.LoadScene(sceneName);
    }
}
