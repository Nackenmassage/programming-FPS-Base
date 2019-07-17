using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToDoList : MonoBehaviour
{   
    //                                                     <<Not Implemented Yet>>
    //
    // Environment:
    //              1. atleast Level blocking to test around with jumping and wall running
    //
    // Models:
    //          1. Sniper Rifle
    //              -> reloading / shooting animations
    // 
    // Features:
    //          1. Options Menu
    //                  -> Sensitivity
    //          2. pick up / buy Weapons 
    //          3. RayCast shooting / instantiate projectile at the weapon FirePoint that flies towards a hitinfo transform from the RayCast 
    //                              / instantiated projectile gets a collider and a script which checks if the hit object is a player or environment
    //                              / -> instantiate blood effect if player or bullethole if environment / if nothing is hit put back too pool after timer
    //          4. BulletPool
    //          5. Weapon Pool? or Array
    //
    //                                                      <<Environment Stuff>>
    //
    // NavMesh:
    //          1. generate NavMesh to smooth out wall running / stop the collision of wall and player to remove the noise
    //
    //                                                          <<SCRIPTS>>
    //
    // Shoot:
    //       1. start animation when reloading
    //       2. instantiate bullethole where the bullet hit
    //       3. let bullets fly forward / WHY IS IT VECTOR3.RIGHT ???????
    //       4. Sounds
    //
    //                                                          <<MODELS>>
    //
    // DesertEagleParts:
    //                  1. Textures / create better ones
    //                  2. reloading animation
}
