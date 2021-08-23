using System.Diagnostics;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Database;
public class FirebaseDBScript : MonoBehaviour
{
    DatabaseReference reference;
    public Text showSuhu;
    public Text showKelembaban;
    // Start is called before the first frame update
    void Start()
    {
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        // Fetch Data Suhu
        FirebaseDatabase.DefaultInstance
            .GetReference("suhu")
            .ValueChanged += HandleSuhu;
        // Fetch Data Kelembaban
        FirebaseDatabase.DefaultInstance
            .GetReference("kelembaban")
            .ValueChanged += HandleKelembaban;
    }

    public void HandleSuhu(object sender, ValueChangedEventArgs args) {
        DataSnapshot snapshot = args.Snapshot;
        UnityEngine.Debug.Log(snapshot.Value);
        showSuhu.text = snapshot.Value.ToString();
    }

     public void HandleKelembaban(object sender, ValueChangedEventArgs args) {
        DataSnapshot snapshot = args.Snapshot;
        UnityEngine.Debug.Log(snapshot.Value);
        showKelembaban.text = snapshot.Value.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
