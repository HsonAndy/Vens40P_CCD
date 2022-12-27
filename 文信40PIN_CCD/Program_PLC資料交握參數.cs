using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyUI;
using Basic;
using AxAxAltairUDrv;
using AxAxOvkBase;
using AxAxOvkImage;
using SQLUI;
namespace 文信40PIN_CCD
{
    public partial class Form1 : Form
    {
        public enum enum_PLC資料交握參數
        {
            GUID,
            參數名稱,
            參數內容,
            PLC位址,
            讀寫,
            註解,
        }
        private void Program_PLC資料交握參數_Init()
        {
            SQLUI.SQL_DataGridView.SQL_Set_Properties(this.sqL_DataGridView_PLC資料交握參數, this.connentionClass);
            this.sqL_DataGridView_PLC資料交握參數.Init();

            if (!this.sqL_DataGridView_PLC資料交握參數.SQL_IsTableCreat()) this.sqL_DataGridView_PLC資料交握參數.SQL_CreateTable();

            this.sqL_DataGridView_PLC資料交握參數.RowDoubleClickEvent += SqL_DataGridView_PLC資料交握參數_RowDoubleClickEvent;

            this.plC_RJ_Button_PLC資料交握參數_刪除資料.MouseDownEvent += PlC_RJ_Button_PLC資料交握參數_刪除資料_MouseDownEvent;
            this.plC_RJ_Button_PLC資料交握參數_登錄資料.MouseDownEvent += PlC_RJ_Button_PLC資料交握參數_登錄資料_MouseDownEvent;
            this.plC_RJ_Button_PLC資料交握參數_顯示全部.MouseDownEvent += PlC_RJ_Button_PLC資料交握參數_顯示全部_MouseDownEvent;
            this.plC_RJ_Button_PLC資料交握參數_資料庫與PLC資料交換.MouseDownEvent += PlC_RJ_Button_PLC資料交握參數_資料庫與PLC資料交換_MouseDownEvent;

            this.plC_UI_Init1.Add_Method(Program_PLC資料交握參數);
        }
        private void Program_PLC資料交握參數()
        {
            sub_Program_檢查PLC資料交握參數();
        }

        #region PLC_檢查PLC資料交握參數
        PLC_Device PLC_Device_檢查PLC資料交握參數 = new PLC_Device("");
        PLC_Device PLC_Device_檢查PLC資料交握參數_OK = new PLC_Device("");
        Task Task_檢查PLC資料交握參數;
        MyTimer MyTimer_檢查PLC資料交握參數_結束延遲 = new MyTimer();
        int cnt_Program_檢查PLC資料交握參數 = 65534;
        void sub_Program_檢查PLC資料交握參數()
        {
            PLC_Device_檢查PLC資料交握參數.Bool = true;
            if (cnt_Program_檢查PLC資料交握參數 == 65534)
            {
                this.MyTimer_檢查PLC資料交握參數_結束延遲.StartTickTime(0);
                PLC_Device_檢查PLC資料交握參數.SetComment("PLC_檢查PLC資料交握參數");
                PLC_Device_檢查PLC資料交握參數_OK.SetComment("PLC_檢查PLC資料交握參數_OK");
                PLC_Device_檢查PLC資料交握參數.Bool = false;
                cnt_Program_檢查PLC資料交握參數 = 65535;
            }
            if (cnt_Program_檢查PLC資料交握參數 == 65535) cnt_Program_檢查PLC資料交握參數 = 1;
            if (cnt_Program_檢查PLC資料交握參數 == 1) cnt_Program_檢查PLC資料交握參數_檢查按下(ref cnt_Program_檢查PLC資料交握參數);
            if (cnt_Program_檢查PLC資料交握參數 == 2) cnt_Program_檢查PLC資料交握參數_初始化(ref cnt_Program_檢查PLC資料交握參數);
            if (cnt_Program_檢查PLC資料交握參數 == 3) cnt_Program_檢查PLC資料交握參數 = 65500;
            if (cnt_Program_檢查PLC資料交握參數 > 1) cnt_Program_檢查PLC資料交握參數_檢查放開(ref cnt_Program_檢查PLC資料交握參數);

            if (cnt_Program_檢查PLC資料交握參數 == 65500)
            {
                this.MyTimer_檢查PLC資料交握參數_結束延遲.TickStop();
                this.MyTimer_檢查PLC資料交握參數_結束延遲.StartTickTime(0);
                PLC_Device_檢查PLC資料交握參數.Bool = false;
                PLC_Device_檢查PLC資料交握參數_OK.Bool = false;
                cnt_Program_檢查PLC資料交握參數 = 65535;
            }
        }
        void cnt_Program_檢查PLC資料交握參數_檢查按下(ref int cnt)
        {
            if (PLC_Device_檢查PLC資料交握參數.Bool) cnt++;
        }
        void cnt_Program_檢查PLC資料交握參數_檢查放開(ref int cnt)
        {
            if (!PLC_Device_檢查PLC資料交握參數.Bool) cnt = 65500;
        }
        void cnt_Program_檢查PLC資料交握參數_初始化(ref int cnt)
        {
            if (this.MyTimer_檢查PLC資料交握參數_結束延遲.IsTimeOut())
            {
                if (Task_檢查PLC資料交握參數 == null)
                {
                    Task_檢查PLC資料交握參數 = new Task(new Action(delegate { this.PlC_RJ_Button_PLC資料交握參數_資料庫與PLC資料交換_MouseDownEvent(null); }));
                }
                if (Task_檢查PLC資料交握參數.Status == TaskStatus.RanToCompletion)
                {
                    Task_檢查PLC資料交握參數 = new Task(new Action(delegate { this.PlC_RJ_Button_PLC資料交握參數_資料庫與PLC資料交換_MouseDownEvent(null); }));
                }
                if (Task_檢查PLC資料交握參數.Status == TaskStatus.Created)
                {
                    Task_檢查PLC資料交握參數.Start();
                }
                cnt++;
            }
        }







        #endregion
        #region Function

        #endregion
        #region Event
        private void SqL_DataGridView_PLC資料交握參數_RowDoubleClickEvent(object[] RowValue)
        {
            this.Invoke(new Action(delegate 
            {
                this.rJ_TextBox_PLC資料交握參數_PLC位址.Text = RowValue[(int)enum_PLC資料交握參數.PLC位址].ObjectToString();
                this.rJ_TextBox_PLC資料交握參數_參數內容.Text = RowValue[(int)enum_PLC資料交握參數.參數內容].ObjectToString();
                this.rJ_TextBox_PLC資料交握參數_參數名稱.Text = RowValue[(int)enum_PLC資料交握參數.參數名稱].ObjectToString();
                this.rJ_TextBox_PLC資料交握參數_註解.Text = RowValue[(int)enum_PLC資料交握參數.註解].ObjectToString();
                this.plC_RJ_ComboBox_PLC資料交握參數_讀寫.Text = RowValue[(int)enum_PLC資料交握參數.讀寫].ObjectToString();
            }));
   
        }
        private void PlC_RJ_Button_PLC資料交握參數_顯示全部_MouseDownEvent(MouseEventArgs mevent)
        {
            this.sqL_DataGridView_PLC資料交握參數.SQL_GetAllRows(true);
        }
        private void PlC_RJ_Button_PLC資料交握參數_登錄資料_MouseDownEvent(MouseEventArgs mevent)
        {
            string PLC位址 = this.rJ_TextBox_PLC資料交握參數_PLC位址.Text;
            string 參數內容 = this.rJ_TextBox_PLC資料交握參數_參數內容.Text;
            string 參數名稱 = this.rJ_TextBox_PLC資料交握參數_參數名稱.Text;
            string 註解 = this.rJ_TextBox_PLC資料交握參數_註解.Text;
            string 讀寫 = this.plC_RJ_ComboBox_PLC資料交握參數_讀寫.Text;
            if (參數名稱.StringIsEmpty())
            {
                MyMessageBox.ShowDialog($"參數名稱不得為空白!");
                return;
            }
            if (讀寫.StringIsEmpty())
            {
                MyMessageBox.ShowDialog($"讀寫不得為空白!");
                return;
            }
            if (!LadderProperty.DEVICE.TestDevice(PLC位址))
            {
                MyMessageBox.ShowDialog($"PLC位址為非法字元! {PLC位址}");
                return;
            }
            if(PLC位址.Substring(0,1) == "S" || PLC位址.Substring(0, 1) == "M")
            {
                if (參數內容.ToUpper() != true.ToString().ToUpper() && 參數內容.ToUpper() != false.ToString().ToUpper())
                {
                    MyMessageBox.ShowDialog($"參數內容為非法字元! {參數內容}");
                    return;
                }
            }
            if (PLC位址.Substring(0, 1) == "D" || PLC位址.Substring(0, 1) == "F")
            {
                if(!參數內容.StringIsInt32())
                {
                    MyMessageBox.ShowDialog($"參數內容為非法字元! {參數內容}");
                    return;
                }
            }

            List<object[]> list_value = this.sqL_DataGridView_PLC資料交握參數.SQL_GetAllRows(false);

            list_value = list_value.GetRows((int)enum_PLC資料交握參數.參數名稱, 參數名稱);

            if (list_value.Count == 0)
            {
                object[] value = new object[new enum_PLC資料交握參數().GetLength()];
                value[(int)enum_PLC資料交握參數.GUID] = Guid.NewGuid().ToString();
                value[(int)enum_PLC資料交握參數.參數名稱] = 參數名稱;
                value[(int)enum_PLC資料交握參數.參數內容] = 參數內容;
                value[(int)enum_PLC資料交握參數.PLC位址] = PLC位址;
                value[(int)enum_PLC資料交握參數.讀寫] = 讀寫;
                value[(int)enum_PLC資料交握參數.註解] = 註解;

                this.sqL_DataGridView_PLC資料交握參數.SQL_AddRow(value, true);
            }
            else
            {
                object[] value = list_value[0];
                value[(int)enum_PLC資料交握參數.參數名稱] = 參數名稱;
                value[(int)enum_PLC資料交握參數.參數內容] = 參數內容;
                value[(int)enum_PLC資料交握參數.PLC位址] = PLC位址;
                value[(int)enum_PLC資料交握參數.讀寫] = 讀寫;
                value[(int)enum_PLC資料交握參數.註解] = 註解;

                this.sqL_DataGridView_PLC資料交握參數.SQL_ReplaceExtra(value, false);
                this.sqL_DataGridView_PLC資料交握參數.ReplaceExtra(value, true);
            }

        }
        private void PlC_RJ_Button_PLC資料交握參數_刪除資料_MouseDownEvent(MouseEventArgs mevent)
        {
            List<object[]> list_value = this.sqL_DataGridView_PLC資料交握參數.Get_All_Select_RowsValues();
            if (list_value.Count == 0)
            {
                MyMessageBox.ShowDialog("未選取資料!");
                return;
            }
            if (MyMessageBox.ShowDialog("是否刪除選取資料?", MyMessageBox.enum_BoxType.Warning, MyMessageBox.enum_Button.Confirm_Cancel) != DialogResult.Yes) return;

            this.sqL_DataGridView_PLC資料交握參數.SQL_DeleteExtra(list_value, false);
            this.sqL_DataGridView_PLC資料交握參數.DeleteExtra(list_value, true);

        }
        private void PlC_RJ_Button_PLC資料交握參數_資料庫與PLC資料交換_MouseDownEvent(MouseEventArgs mevent)
        {
            MyTimer myTimer = new MyTimer();
            myTimer.StartTickTime(50000);

            List<object[]> list_value = this.sqL_DataGridView_PLC資料交握參數.SQL_GetAllRows(false);
            Console.WriteLine($"取得PLC資料交握參數,耗時 {myTimer.ToString()}");
            List<object[]> list_value_replace = new List<object[]>();
            string PLC位址 = "";
            string 參數內容 = "";
            string 參數名稱 = "";
            string 註解 = "";
            string 讀寫 = "";
            PLC_Device pLC_Device;
            for (int i = 0; i < list_value.Count; i++)
            {
                PLC位址 = list_value[i][(int)enum_PLC資料交握參數.PLC位址].ObjectToString();
                參數內容 = list_value[i][(int)enum_PLC資料交握參數.參數內容].ObjectToString();
                讀寫 = list_value[i][(int)enum_PLC資料交握參數.讀寫].ObjectToString();
                pLC_Device = new PLC_Device(PLC位址);
                if(讀寫 == "W")
                {
                    if (PLC位址.Substring(0, 1) == "S" || PLC位址.Substring(0, 1) == "M")
                    {
                        list_value[i][(int)enum_PLC資料交握參數.參數內容] = pLC_Device.Bool.ToString();
                    }
                    if (PLC位址.Substring(0, 1) == "D" || PLC位址.Substring(0, 1) == "F")
                    {
                        list_value[i][(int)enum_PLC資料交握參數.參數內容] = pLC_Device.Value.ToString();
                    }
                    list_value_replace.Add(list_value[i]);
                }
                else if(讀寫 == "R")
                {
                    if (PLC位址.Substring(0, 1) == "S" || PLC位址.Substring(0, 1) == "M")
                    {
                        if(參數內容.ToUpper() == true.ToString().ToUpper())
                        {
                            pLC_Device.Bool = true;
                        }
                        else if (參數內容.ToUpper() == false.ToString().ToUpper())
                        {
                            pLC_Device.Bool = false;
                        }
                    }
                    if (PLC位址.Substring(0, 1) == "D" || PLC位址.Substring(0, 1) == "F")
                    {
                        if (參數內容.StringIsInt32())
                        {
                            pLC_Device.Value = 參數內容.StringToInt32();
                        }
                    }
                }

            }
            this.sqL_DataGridView_PLC資料交握參數.SQL_ReplaceExtra(list_value_replace, false);
            Console.WriteLine($"更新PLC資料交握參數,耗時 {myTimer.ToString()}");

        }
        #endregion
    }
}
