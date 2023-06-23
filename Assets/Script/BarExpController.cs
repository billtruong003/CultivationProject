using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BarExpController : MonoBehaviour
{
    [Header("Exp Setup")]
    [SerializeField] private ProgressBarPro expBar; // Thanh Exp
    [SerializeField] private float[] baseExp; // Lượng exp cơ bản ở mỗi cấp bậc
    [SerializeField] private string[] stageNames; // Tên từng cấp bậc
    [SerializeField] private string currentStageName;
    [SerializeField, Range(0, 19)] private int currentStage; // Cấp bậc hiện tại, biểu diễn dưới dạng số
    [SerializeField, Range(1, 10)] private int currentStageLevel; // Level của cấp bậc hiện tại, biểu diễn dưới dạng số, có 10 level

    [Header("Xử lý exp system")]
    [SerializeField, Range(1, 1000000000)]private float currentExp; // Giá trị exp hiện tại
    [SerializeField] private float expForLeveling; // Lượng exp cần để thăng cấp
    [SerializeField, Range(1, 10)] private float growthRate; // Tốc độ tăng trưởng exp

    [Header("Text Display")]
    [SerializeField] TextMeshProUGUI Stage_Level;
    [SerializeField] TextMeshProUGUI Exp_Display;
    private void Start()
    {
        StartCoroutine(ExpGrowthCoroutine());

        // Khởi tạo mảng exp cơ bản ở mỗi cấp bậc
        baseExp = new float[]
        {
            100f,
            2000f,
            40000f,
            800000f,
            16000000f,
            320000000f,
            6400000000f,
            128000000000f,
            2560000000000f,
            51200000000000f,
            1.024E+15f,
            2.048E+16f,
            4.096E+17f,
            8.192E+18f,
            1.6384E+20f,
            3.2768E+21f,
            6.5536E+22f,
            1.31072E+24f,
            2.62144E+25f,
            5.24288E+26f
        };

        // Khởi tạo mảng tên từng cấp bậc
        stageNames = new string[]
        {
            "Phàm nhân",
            "Luyện thể",
            "Luyện khí",
            "Thoát phàm",
            "Kim đan",
            "Nguyên Anh",
            "Hóa Thần",
            "Hợp thể",
            "Độ Kiếp",
            "Địa tiên",
            "Chân tiên",
            "Thiên Tiên",
            "Hậu tiên",
            "Tiên vương",
            "Tiên tôn",
            "Vĩnh sinh",
            "Đại Vực",
            "Thánh Vương",
            "Thần Vương",
            "Thánh Thượng Độc Tôn"
        };

        CalculateExpNeeded(); // Tính toán giá trị exp ban đầu
        currentStage = 0;
        currentStageLevel = 1;
        Stage_Level.text = currentStageName + " " + currentStageLevel.ToString();
    }

    private void Update()
    {
        ValueChange(); // Cập nhật giá trị Exp.Value
    }

    // Phương thức để cập nhật giá trị Exp.Value
    private void ValueChange()
    {
        // Tính toán giá trị Exp.Value dựa trên exp hiện tại và exp cần thiết
        expBar.Value = (currentExp / expForLeveling);
    }

    // Phương thức để tính toán giá trị exp cần thiết
    public void CalculateExpNeeded()
    {
        // Lấy giá trị exp cần thiết từ mảng baseExp dựa trên cấp bậc hiện tại và level
        expForLeveling = baseExp[currentStage] * currentStageLevel;

        // Lấy tên cấp bậc từ mảng stageNames dựa trên cấp bậc hiện tại
        currentStageName = stageNames[currentStage];
        // In ra tên cấp bậc và giá trị exp cần thiết (dùng cho mục đích debug)
        Debug.Log("Current Stage Name: " + currentStageName);
        Debug.Log("Exp Needed: " + expForLeveling);
        Debug.Log("Lượng Exp còn lại cần là:" + exp_left());
    }
    private float exp_left(){
        float expleft = expForLeveling - currentExp;
        if (expleft <= 0) 
            expleft = 0;
        else
        {}
        return expleft;
    }

    private IEnumerator ExpGrowthCoroutine()
    {
        while (true)
        {
            // Tăng giá trị exp
            currentExp += growthRate;

            // Hiển thị exp
            Exp_Display.text = currentExp + " / " + expForLeveling;

            // In ra giá trị exp hiện tại (dùng cho mục đích debug)
            Debug.Log("Current Exp: " + currentExp);

            yield return new WaitForSeconds(0.5f); // Chờ 1 giây trước khi tăng trưởng tiếp
        }
    }
    public void UpLevel(){
        if(currentStageLevel < 10 && currentExp >= expForLeveling) {
            currentExp -= expForLeveling;
            currentStageLevel++;
            CalculateExpNeeded();
            Stage_Level.text = currentStageName + " " + currentStageLevel.ToString();
        }
        else if (currentStageLevel >= 10 && currentExp >= expForLeveling){
            currentExp -= expForLeveling;
            currentStage ++;
            currentStageLevel = 1;
            CalculateExpNeeded();
            Stage_Level.text = currentStageName + " " + currentStageLevel.ToString();
        }
        else 
        {

        }
    }
}
