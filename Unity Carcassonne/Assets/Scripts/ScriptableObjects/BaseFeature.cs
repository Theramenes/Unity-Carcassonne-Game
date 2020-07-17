using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "Tiles/Feature")]
public class BaseFeature : ScriptableObject
{
    public string FeatureName;

    public int FeatureIndex;

}
