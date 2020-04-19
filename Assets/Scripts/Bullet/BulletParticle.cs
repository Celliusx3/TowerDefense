using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletParticle : MonoBehaviour 
 {
     private ParticleSystem ps;
     public Color bulletColor;
 
 
     public void Start() 
     {
        ps = GetComponent<ParticleSystem>();
        var main = ps.main;
        main.startColor = bulletColor;
     }
 
     public void Update() 
     {
         if(ps)
         {
             if(!ps.IsAlive())
             {
                 Destroy(gameObject);
             }
         }
     }
 }
