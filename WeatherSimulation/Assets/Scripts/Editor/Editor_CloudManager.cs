using UnityEditor;

//NOTE (Tane) This script allows the variables related to the clouds's size to be custom inspector elements for easy 
// editing and reading
[CustomEditor(typeof(test_CloudManager))]
public class Editor_CloudProperties : Editor
{
    #region
    SerializedProperty _cloudProperties;

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
    SerializedProperty _isRaining;

    bool cloudTinyGroup, cloudSmallGroup, cloudMediumGroup, cloudLargeGroup, cloudHugeGroup, cloudAddpropsGroup = false;
    #endregion

    //NOTE (Tane) This function gets the variables from the chosen script 'RainManager' 
    private void OnEnable()
    {
        _cloudProperties = serializedObject.FindProperty("_cloudProperties");

        tinyMin = serializedObject.FindProperty("tinyMin");
        tinyMax = serializedObject.FindProperty("tinyMax");

        smallMin = serializedObject.FindProperty("smallMin");
        smallMax = serializedObject.FindProperty("smallMax");

        mediumMin = serializedObject.FindProperty("mediumMin");
        mediumMax = serializedObject.FindProperty("mediumMax");

        largeMin = serializedObject.FindProperty("largeMin");
        largeMax = serializedObject.FindProperty("largeMax");

        hugeMin = serializedObject.FindProperty("hugeMin");
        hugeMax = serializedObject.FindProperty("hugeMax");

        _cloudSize = serializedObject.FindProperty("_cloudSize");
        _waterStored = serializedObject.FindProperty("_waterStored");
        _rainingThreshold = serializedObject.FindProperty("_rainingThreshold");
        _timeTillRain = serializedObject.FindProperty("_timeTillRain");
        _duration = serializedObject.FindProperty("_duration");
        _intensity = serializedObject.FindProperty("_intensity");
        _isRaining = serializedObject.FindProperty("_isRaining");
    }

    //NOTE (Tane) This function puts the variabels on the UI in the new custom way 
    public override void OnInspectorGUI()
    {
        cloudTinyGroup = EditorGUILayout.BeginFoldoutHeaderGroup(cloudTinyGroup, "Tiny Cloud Properties");
        if (cloudTinyGroup)
        {
            EditorGUILayout.PropertyField(tinyMin);
            EditorGUILayout.PropertyField(tinyMax);
        }
        EditorGUILayout.EndFoldoutHeaderGroup();

        cloudSmallGroup = EditorGUILayout.BeginFoldoutHeaderGroup(cloudSmallGroup, "Small Cloud Properties");
        if (cloudSmallGroup)
        {
            EditorGUILayout.PropertyField(smallMin);
            EditorGUILayout.PropertyField(smallMax);
        }
        EditorGUILayout.EndFoldoutHeaderGroup();

        cloudMediumGroup = EditorGUILayout.BeginFoldoutHeaderGroup(cloudMediumGroup, "Medium Cloud Properties");
        if (cloudMediumGroup)
        {
            EditorGUILayout.PropertyField(mediumMin);
            EditorGUILayout.PropertyField(mediumMax);
        }
        EditorGUILayout.EndFoldoutHeaderGroup();

        cloudLargeGroup = EditorGUILayout.BeginFoldoutHeaderGroup(cloudLargeGroup, "Large Cloud Properties");
        if (cloudLargeGroup)
        {
            EditorGUILayout.PropertyField(largeMin);
            EditorGUILayout.PropertyField(largeMax);
        }
        EditorGUILayout.EndFoldoutHeaderGroup();

        cloudHugeGroup = EditorGUILayout.BeginFoldoutHeaderGroup(cloudHugeGroup, "Huge Cloud Properties");
        if (cloudHugeGroup)
        {
            EditorGUILayout.PropertyField(hugeMin);
            EditorGUILayout.PropertyField(hugeMax);
        }
        EditorGUILayout.EndFoldoutHeaderGroup();

        cloudAddpropsGroup = EditorGUILayout.BeginFoldoutHeaderGroup(cloudAddpropsGroup, "Additional Cloud Properties");
        if(cloudAddpropsGroup)
        {
            EditorGUILayout.PropertyField(_cloudSize);
            EditorGUILayout.PropertyField(_waterStored);
            EditorGUILayout.PropertyField(_rainingThreshold);
            EditorGUILayout.PropertyField(_timeTillRain);
            EditorGUILayout.PropertyField(_duration);
            EditorGUILayout.PropertyField(_intensity);
            EditorGUILayout.PropertyField(_isRaining);
        }
        EditorGUILayout.EndFoldoutHeaderGroup();
    }

}

