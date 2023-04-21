/*using UnityEditor;

//SUMMARY: This script allows the variables related to the clouds's size to be custom inspector elements for easy 
// reading. The min & Max values of each catagory are put into tabs that can be hidden
[CustomEditor(typeof(CloudManager))]
public class Editor_CloudProperties : Editor
{
    #region
    //SerializedProperty _cloudProperties;

    SerializedProperty tinyMin, tinyMax;
    SerializedProperty smallMin, smallMax;
    SerializedProperty mediumMin, mediumMax;
    SerializedProperty largeMin, largeMax;
    SerializedProperty hugeMin, hugeMax;

    SerializedProperty _cloudSize;
    SerializedProperty _waterStored;
    SerializedProperty _rainingThreshold;
    SerializedProperty _timeTillRain;
    SerializedProperty _duration;
    SerializedProperty _intensity;
    SerializedProperty _rateMulti;

    SerializedProperty _isRaining;
    SerializedProperty _isSnowing;
    SerializedProperty _isStoring;
    SerializedProperty _isCounting;

    SerializedProperty _weather;
    SerializedProperty _wind;
    SerializedProperty _cloud;
    SerializedProperty _rainMat;
    SerializedProperty _snowMat;

    bool cloudSizeGroup, cloudAddpropsGroup, cloudStateGroup = false;
    #endregion

    //NOTE: This function gets the variables from the chosen script 'RainManager' 
    private void OnEnable()
    {
        tinyMin   = serializedObject.FindProperty("tinyMin");
        tinyMax   = serializedObject.FindProperty("tinyMax");
        smallMin  = serializedObject.FindProperty("smallMin");
        smallMax  = serializedObject.FindProperty("smallMax");
        mediumMin = serializedObject.FindProperty("mediumMin");
        mediumMax = serializedObject.FindProperty("mediumMax");
        largeMin  = serializedObject.FindProperty("largeMin");
        largeMax  = serializedObject.FindProperty("largeMax");
        hugeMin   = serializedObject.FindProperty("hugeMin");
        hugeMax   = serializedObject.FindProperty("hugeMax");

        _cloudSize        = serializedObject.FindProperty("_cloudSize");
        _waterStored      = serializedObject.FindProperty("_waterStored");
        _rainingThreshold = serializedObject.FindProperty("_rainingThreshold");
        _timeTillRain     = serializedObject.FindProperty("_timeTillRain");
        _duration         = serializedObject.FindProperty("_duration");
        _intensity        = serializedObject.FindProperty("_intensity");
        _rateMulti        = serializedObject.FindProperty("_rateMulti");

        _isRaining  = serializedObject.FindProperty("_isRaining");
        _isSnowing = serializedObject.FindProperty("_isSnowing");
        _isStoring  = serializedObject.FindProperty("_isStoring");
        _isCounting = serializedObject.FindProperty("_isCounting");

        _weather = serializedObject.FindProperty("_weather");
        _wind    = serializedObject.FindProperty("_wind");
        _cloud   = serializedObject.FindProperty("_cloud");
        _rainMat = serializedObject.FindProperty("_rainMat");
        _snowMat = serializedObject.FindProperty("_snowNat");
    }

    //NOTE: This function puts the variabels on the UI in the new custom way 
    public override void OnInspectorGUI()
    {
        cloudSizeGroup = EditorGUILayout.BeginFoldoutHeaderGroup(cloudSizeGroup, "Cloud Size Catagory Values");
        if (cloudSizeGroup)
        {
            EditorGUILayout.PropertyField(tinyMin);
            EditorGUILayout.PropertyField(tinyMax);
            EditorGUILayout.LabelField(" ");
            EditorGUILayout.PropertyField(smallMin);
            EditorGUILayout.PropertyField(smallMax);
            EditorGUILayout.LabelField(" ");
            EditorGUILayout.PropertyField(mediumMin);
            EditorGUILayout.PropertyField(mediumMax);
            EditorGUILayout.LabelField(" ");
            EditorGUILayout.PropertyField(largeMin);
            EditorGUILayout.PropertyField(largeMax);
            EditorGUILayout.LabelField(" ");
            EditorGUILayout.PropertyField(hugeMin);
            EditorGUILayout.PropertyField(hugeMax);
        }
        EditorGUILayout.EndFoldoutHeaderGroup();

        cloudAddpropsGroup = EditorGUILayout.BeginFoldoutHeaderGroup(cloudAddpropsGroup, "Cloud Behavior Variables");
        if (cloudAddpropsGroup)
        {
            EditorGUILayout.PropertyField(_cloudSize);
            EditorGUILayout.PropertyField(_waterStored);
            EditorGUILayout.PropertyField(_rainingThreshold);
            EditorGUILayout.LabelField(" ");
            EditorGUILayout.PropertyField(_timeTillRain);
            EditorGUILayout.PropertyField(_duration);
            EditorGUILayout.PropertyField(_intensity);
            EditorGUILayout.PropertyField(_rateMulti);
        }
        EditorGUILayout.EndFoldoutHeaderGroup();

        cloudStateGroup = EditorGUILayout.BeginFoldoutHeaderGroup(cloudStateGroup, "Current State & Additional Components");
        if (cloudStateGroup)
        {
            EditorGUILayout.PropertyField(_isRaining);
            EditorGUILayout.PropertyField(_isSnowing);
            EditorGUILayout.PropertyField(_isStoring);
            EditorGUILayout.PropertyField(_isCounting);
            EditorGUILayout.LabelField(" ");
            EditorGUILayout.PropertyField(_weather);
            EditorGUILayout.PropertyField(_wind);
            EditorGUILayout.PropertyField(_cloud);
            EditorGUILayout.PropertyField(_rainMat);
            EditorGUILayout.PropertyField(_snowMat);
        }
        EditorGUILayout.EndFoldoutHeaderGroup();
    }
}*/