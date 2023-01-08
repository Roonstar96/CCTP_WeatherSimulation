/*using UnityEditor;

//NOTE (Tane) This script allows the variables related to the clouds's size to be custom inspector elements for easy 
// editing and reading
[CustomEditor(typeof(RainManager))]
public class Editor_CloudProperties : Editor
{
    #region
    SerializedProperty _cloudProperties;

    SerializedProperty tinyMin, tinyMax;
    SerializedProperty smallMin, smallMax;
    SerializedProperty mediumMin, mediumMax;
    SerializedProperty largeMin, largeMax;
    SerializedProperty hugeMin, hugeMax;

    SerializedProperty _downpourThreshTiny;
    SerializedProperty _downpourThreshSmall;
    SerializedProperty _downpourThreshMedium;
    SerializedProperty _downpourThreshLarge;
    SerializedProperty _downpourThreshHuge;

    /*SerializedProperty _waterStored;
    SerializedProperty _duration;
    SerializedProperty _intensity;
    SerializedProperty _timeTillRain;
    SerializedProperty _isRainging;

    //bool cloudTinyGroup, cloudSmallGroup, cloudMediumGroup, cloudLargeGroup, cloudHugeGroup, cloudAddpropsGroup = false;
    #endregion

    //NOTE (Tane) This function gets the variables from the chosen script 'RainManager' 
    private void OnEnable()
    {
        _cloudProperties = serializedObject.FindProperty("_cloudProperties");

        tinyMin = serializedObject.FindProperty("tinyMin");
        tinyMax = serializedObject.FindProperty("tinyMax");
        _downpourThreshTiny = serializedObject.FindProperty("_downpourThreshTiny");

        smallMin = serializedObject.FindProperty("smallMin");
        smallMax = serializedObject.FindProperty("smallMax");
        _downpourThreshSmall = serializedObject.FindProperty("_downpourThreshSmall");

        mediumMin = serializedObject.FindProperty("mediumMin");
        mediumMax = serializedObject.FindProperty("mediumMax");
        _downpourThreshMedium = serializedObject.FindProperty("_downpourThreshMedium");

        largeMin = serializedObject.FindProperty("largeMin");
        largeMax = serializedObject.FindProperty("largeMax");
        _downpourThreshLarge = serializedObject.FindProperty("_downpourThreshLarge;");

        hugeMin = serializedObject.FindProperty("hugeMin");
        hugeMax = serializedObject.FindProperty("hugeMax");
        _downpourThreshHuge = serializedObject.FindProperty("_downpourThreshHuge;");

        /*_waterStored = serializedObject.FindProperty("_waterStored");
        _duration = serializedObject.FindProperty("_duration");
        _intensity = serializedObject.FindProperty("_intensity");
        _timeTillRain = serializedObject.FindProperty("_timeTillRain");
        _isRainging = serializedObject.FindProperty("_isRaining");
    }

    //NOTE (Tane) This function puts the variabels on the UI in the new custom way 
    public override void OnInspectorGUI()
    {
        RainManager _rainManager = (RainManager)target;

        serializedObject.Update();

        EditorGUILayout.PropertyField(_cloudProperties);

        if (_rainManager._cloudProperties == RainManager.CloudProperties.Tiny)
        {
            EditorGUILayout.PropertyField(tinyMin);
            EditorGUILayout.PropertyField(tinyMax);
            EditorGUILayout.PropertyField(_downpourThreshTiny);
        }

        if (_rainManager._cloudProperties == RainManager.CloudProperties.Small)
        {
            EditorGUILayout.PropertyField(smallMin);
            EditorGUILayout.PropertyField(smallMax);
            EditorGUILayout.PropertyField(_downpourThreshSmall);
        }

        if (_rainManager._cloudProperties == RainManager.CloudProperties.Medium)
        {
            EditorGUILayout.PropertyField(mediumMin);
            EditorGUILayout.PropertyField(mediumMax);
            EditorGUILayout.PropertyField(_downpourThreshMedium);
        }

        if (_rainManager._cloudProperties == RainManager.CloudProperties.Large)
        {
            EditorGUILayout.PropertyField(largeMin);
            EditorGUILayout.PropertyField(largeMax);
            EditorGUILayout.PropertyField(_downpourThreshLarge);
        }

        if (_rainManager._cloudProperties == RainManager.CloudProperties.Huge)
        {
            EditorGUILayout.PropertyField(hugeMin);
            EditorGUILayout.PropertyField(hugeMax);
            EditorGUILayout.PropertyField(_downpourThreshHuge);
        }

        //EditorGUILayout.PropertyField(_waterStored);
        //EditorGUILayout.PropertyField(_duration);
        //EditorGUILayout.PropertyField(_intensity);
        //EditorGUILayout.PropertyField(_timeTillRain);
        //EditorGUILayout.PropertyField(_isRainging);

        //serializedObject.ApplyModifiedProperties();

        cloudTinyGroup = EditorGUILayout.BeginFoldoutHeaderGroup(cloudTinyGroup, "Tiny Cloud Properties");
        if (cloudTinyGroup)
        {
            EditorGUILayout.PropertyField(tinyMin);
            EditorGUILayout.PropertyField(tinyMax);
            EditorGUILayout.PropertyField(_downpourThreshTiny);
        }
        EditorGUILayout.EndFoldoutHeaderGroup();

        cloudSmallGroup = EditorGUILayout.BeginFoldoutHeaderGroup(cloudSmallGroup, "Small Cloud Properties");
        else if (cloudSmallGroup)
        {
            EditorGUILayout.PropertyField(smallMin);
            EditorGUILayout.PropertyField(smallMax);
            EditorGUILayout.PropertyField(_downpourThreshSmall);
        }
        EditorGUILayout.EndFoldoutHeaderGroup();

        cloudMediumGroup = EditorGUILayout.BeginFoldoutHeaderGroup(cloudMediumGroup, "Medium Cloud Properties");
        else if (cloudMediumGroup)
        {
            EditorGUILayout.PropertyField(mediumMin);
            EditorGUILayout.PropertyField(mediumMax);
            EditorGUILayout.PropertyField(_downpourThreshMedium);
        }
        EditorGUILayout.EndFoldoutHeaderGroup();

        cloudLargeGroup = EditorGUILayout.BeginFoldoutHeaderGroup(cloudLargeGroup, "Large Cloud Properties");
        else if (cloudLargeGroup)
        {
            EditorGUILayout.PropertyField(largeMin);
            EditorGUILayout.PropertyField(largeMax);
            EditorGUILayout.PropertyField(_downpourThreshLarge);
        }
        EditorGUILayout.EndFoldoutHeaderGroup();

        cloudHugeGroup = EditorGUILayout.BeginFoldoutHeaderGroup(cloudHugeGroup, "Huge Cloud Properties");
        else if (cloudHugeGroup)
        {
            EditorGUILayout.PropertyField(hugeMin);
            EditorGUILayout.PropertyField(hugeMax);
            EditorGUILayout.PropertyField(_downpourThreshHuge);
        }
        EditorGUILayout.EndFoldoutHeaderGroup();

        cloudAddpropsGroup = EditorGUILayout.BeginFoldoutHeaderGroup(cloudAddpropsGroup, "Additional Cloud Properties");
        if(cloudAddpropsGroup)
        {
            EditorGUILayout.PropertyField(_waterStored);
            EditorGUILayout.PropertyField(_duration);
            EditorGUILayout.PropertyField(_intensity);
            EditorGUILayout.PropertyField(_timeTillRain);
            EditorGUILayout.PropertyField(_isRainging);
        }
        EditorGUILayout.EndFoldoutHeaderGroup();
    }

}
*/
