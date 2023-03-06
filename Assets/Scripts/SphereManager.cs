using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereManager : MonoBehaviour
{
    public GameObject[] spheres;
    private int currentSphere;
    [SerializeField] private AudioSource audioSource;
    private RhythmClick _rhythmClick;
    private float awardScore, maxPoints = 100, currentScore, progress;
    public int maxMissTiming = 3;

    private void Start()
    {
        currentSphere = 0;
        _rhythmClick = spheres[0].GetComponent<RhythmClick>();
    }

    void Update(){
        if (audioSource.isPlaying)
            progress = Mathf.RoundToInt((progress = audioSource.time / audioSource.clip.length) * 100);
        Debug.Log("Current score " + currentScore);
        Debug.Log(progress);
    }

    public void NextSphere()
    {
        if(currentSphere < spheres.Length)
        {
            spheres[currentSphere].SetActive(false);
            _rhythmClick = spheres[currentSphere].GetComponent<RhythmClick>();
            spheres[++currentSphere].SetActive(true);

            if(checkRange(progress, _rhythmClick.clickProcent, maxMissTiming)){
                awardScore = (maxPoints / minVal(abs(progress - _rhythmClick.clickProcent), 1));
            }else{
                awardScore = 0;
            }
            
            Debug.Log("Added " + awardScore + " timing off by" + abs(progress - _rhythmClick.clickProcent));
            currentScore += awardScore;
        }
    }

    public bool checkRange(float val, float timing, float maxMiss){
        if(val >= (timing - maxMiss) && val <= (timing + maxMiss)) 
            return true;
        return false;
    }

    private float abs(float val){
        if(val >= 0)
            return val;
        return -val;
    }

    private float minVal(float val, float minVal){
        if (val > -minVal && val < 0)
			return -minVal;

		if (val < minVal && val >= 0)
			return minVal;

		return val;
    }
}