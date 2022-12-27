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
using AxAxOvkImage;

namespace 文信40PIN_CCD
{
    public partial class Form1 : Form
    {


        DialogResult err_message1;

        void Program_CCD01_01()
        {
            this.sub_Program_CCD01_01_SNAP_拼接圖1();
            this.sub_Program_CCD01_01_SNAP_拼接圖2();
            this.sub_Program_CCD01_01_Main_取像並檢驗();
            this.sub_Program_CCD01_01_Main_取像拼接();
            this.sub_Program_CCD01_01_Tech_檢驗一次();
            this.sub_Program_CCD01_01_計算一次();
            this.sub_Program_CCD01_01_拼接校正();
            this.sub_Program_CCD01_01_校正量測框();
            this.sub_Program_CCD01_01_影像拼接();
            this.sub_Program_CCD01_01_基準線量測();
            this.sub_Program_CCD01_01基準圓量測框調整();
            

            this.Program_CCD01_01_PIN量測_combobox();

        }

        #region PLC_CCD01_01_SNAP_拼接圖1
        PLC_Device PLC_Device_CCD01_01_SNAP_拼接圖1_按鈕 = new PLC_Device("S15010");
        PLC_Device PLC_Device_CCD01_01_SNAP_拼接圖1 = new PLC_Device("S15005");
        PLC_Device PLC_Device_CCD01_01_SNAP_拼接圖1_LIVE = new PLC_Device("S15006");
        PLC_Device PLC_Device_CCD01_01_SNAP_拼接圖1_電子快門 = new PLC_Device("F9000");
        PLC_Device PLC_Device_CCD01_01_SNAP_拼接圖1_視訊增益 = new PLC_Device("F9001");
        PLC_Device PLC_Device_CCD01_01_SNAP_拼接圖1_銳利度 = new PLC_Device("F9002");
        PLC_Device PLC_Device_CCD01_01_SNAP_拼接圖1_光源亮度_白正照 = new PLC_Device("F25020");
        PLC_Device PLC_Device_CCD01_01_SNAP_拼接圖1_光源亮度_藍側照 = new PLC_Device("F25021");

        int cnt_Program_CCD01_01_SNAP_拼接圖1 = 65534;
        void sub_Program_CCD01_01_SNAP_拼接圖1()
        {
            if (cnt_Program_CCD01_01_SNAP_拼接圖1 == 65534)
            {
                PLC_Device_CCD01_01_SNAP_拼接圖1.SetComment("PLC_CCD01_01_SNAP_拼接圖1");
                PLC_Device_CCD01_01_SNAP_拼接圖1.Bool = false;
                cnt_Program_CCD01_01_SNAP_拼接圖1 = 65535;
            }
            if (cnt_Program_CCD01_01_SNAP_拼接圖1 == 65535) cnt_Program_CCD01_01_SNAP_拼接圖1 = 1;
            if (cnt_Program_CCD01_01_SNAP_拼接圖1 == 1) cnt_Program_CCD01_01_SNAP_拼接圖1_檢查按下(ref cnt_Program_CCD01_01_SNAP_拼接圖1);
            if (cnt_Program_CCD01_01_SNAP_拼接圖1 == 2) cnt_Program_CCD01_01_SNAP_拼接圖1_初始化(ref cnt_Program_CCD01_01_SNAP_拼接圖1);
            if (cnt_Program_CCD01_01_SNAP_拼接圖1 == 3) cnt_Program_CCD01_01_SNAP_拼接圖1_開始取像(ref cnt_Program_CCD01_01_SNAP_拼接圖1);
            if (cnt_Program_CCD01_01_SNAP_拼接圖1 == 4) cnt_Program_CCD01_01_SNAP_拼接圖1_取像結束(ref cnt_Program_CCD01_01_SNAP_拼接圖1);
            if (cnt_Program_CCD01_01_SNAP_拼接圖1 == 5) cnt_Program_CCD01_01_SNAP_拼接圖1_繪製影像(ref cnt_Program_CCD01_01_SNAP_拼接圖1);
            if (cnt_Program_CCD01_01_SNAP_拼接圖1 == 6) cnt_Program_CCD01_01_SNAP_拼接圖1 = 65500;
            if (cnt_Program_CCD01_01_SNAP_拼接圖1 > 1) cnt_Program_CCD01_01_SNAP_拼接圖1_檢查放開(ref cnt_Program_CCD01_01_SNAP_拼接圖1);

            if (cnt_Program_CCD01_01_SNAP_拼接圖1 == 65500)
            {
                PLC_Device_CCD01_SNAP.Bool = false;
                PLC_Device_CCD01_01_SNAP_拼接圖1.Bool = false;
                cnt_Program_CCD01_01_SNAP_拼接圖1 = 65535;
            }
        }
        void cnt_Program_CCD01_01_SNAP_拼接圖1_檢查按下(ref int cnt)
        {
            if (PLC_Device_CCD01_01_SNAP_拼接圖1.Bool) cnt++;
        }
        void cnt_Program_CCD01_01_SNAP_拼接圖1_檢查放開(ref int cnt)
        {
            if (!PLC_Device_CCD01_01_SNAP_拼接圖1.Bool) cnt = 65500;
        }
        void cnt_Program_CCD01_01_SNAP_拼接圖1_初始化(ref int cnt)
        {
            PLC_Device_CCD01_SNAP_電子快門.Value = PLC_Device_CCD01_01_SNAP_拼接圖1_電子快門.Value;
            PLC_Device_CCD01_SNAP_視訊增益.Value = PLC_Device_CCD01_01_SNAP_拼接圖1_視訊增益.Value;
            PLC_Device_CCD01_SNAP_銳利度.Value = PLC_Device_CCD01_01_SNAP_拼接圖1_銳利度.Value;

            cnt++;
        }
        void cnt_Program_CCD01_01_SNAP_拼接圖1_開始取像(ref int cnt)
        {
            if (!PLC_Device_CCD01_SNAP.Bool)
            {
                PLC_Device_CCD01_SNAP.Bool = true;
                cnt++;
            }
        }
        void cnt_Program_CCD01_01_SNAP_拼接圖1_取像結束(ref int cnt)
        {
            if (!PLC_Device_CCD01_SNAP.Bool)
            {
                cnt++;
            }
        }
        void cnt_Program_CCD01_01_SNAP_拼接圖1_繪製影像(ref int cnt)
        {
            this.CCD01_01_SrcImageHandle_拼接圖1 = this.h_Canvas_Tech_CCD01_01_拼接圖1.VegaHandle;
            this.h_Canvas_Tech_CCD01_01_拼接圖1.ImageCopy(this.CCD01_AxImageBW8.VegaHandle);
            this.h_Canvas_Tech_CCD01_01_拼接圖1.SetImageSize(this.h_Canvas_Tech_CCD01_01_拼接圖1.ImageWidth, this.h_Canvas_Tech_CCD01_01_拼接圖1.ImageHeight);
            if (this.PLC_Device_CCD01_01_SNAP_拼接圖1_按鈕.Bool) this.h_Canvas_Tech_CCD01_01_拼接圖1.RefreshCanvas();

            if (PLC_Device_CCD01_01_SNAP_拼接圖1_LIVE.Bool)
            {
                cnt = 2;
                return;
            }
            cnt++;
        }





        #endregion
        #region PLC_CCD01_01_SNAP_拼接圖2
        PLC_Device PLC_Device_CCD01_01_SNAP_拼接圖2_按鈕 = new PLC_Device("S15030");
        PLC_Device PLC_Device_CCD01_01_SNAP_拼接圖2 = new PLC_Device("S15025");
        PLC_Device PLC_Device_CCD01_01_SNAP_拼接圖2_LIVE = new PLC_Device("S15016");

        int cnt_Program_CCD01_01_SNAP_拼接圖2 = 65534;
        void sub_Program_CCD01_01_SNAP_拼接圖2()
        {
            if (cnt_Program_CCD01_01_SNAP_拼接圖2 == 65534)
            {
                PLC_Device_CCD01_01_SNAP_拼接圖2.SetComment("PLC_CCD01_01_SNAP_拼接圖2");
                PLC_Device_CCD01_01_SNAP_拼接圖2.Bool = false;
                cnt_Program_CCD01_01_SNAP_拼接圖2 = 65535;
            }
            if (cnt_Program_CCD01_01_SNAP_拼接圖2 == 65535) cnt_Program_CCD01_01_SNAP_拼接圖2 = 1;
            if (cnt_Program_CCD01_01_SNAP_拼接圖2 == 1) cnt_Program_CCD01_01_SNAP_拼接圖2_檢查按下(ref cnt_Program_CCD01_01_SNAP_拼接圖2);
            if (cnt_Program_CCD01_01_SNAP_拼接圖2 == 2) cnt_Program_CCD01_01_SNAP_拼接圖2_初始化(ref cnt_Program_CCD01_01_SNAP_拼接圖2);
            if (cnt_Program_CCD01_01_SNAP_拼接圖2 == 3) cnt_Program_CCD01_01_SNAP_拼接圖2_開始取像(ref cnt_Program_CCD01_01_SNAP_拼接圖2);
            if (cnt_Program_CCD01_01_SNAP_拼接圖2 == 4) cnt_Program_CCD01_01_SNAP_拼接圖2_取像結束(ref cnt_Program_CCD01_01_SNAP_拼接圖2);
            if (cnt_Program_CCD01_01_SNAP_拼接圖2 == 5) cnt_Program_CCD01_01_SNAP_拼接圖2_繪製影像(ref cnt_Program_CCD01_01_SNAP_拼接圖2);
            if (cnt_Program_CCD01_01_SNAP_拼接圖2 == 6) cnt_Program_CCD01_01_SNAP_拼接圖2 = 65500;
            if (cnt_Program_CCD01_01_SNAP_拼接圖2 > 1) cnt_Program_CCD01_01_SNAP_拼接圖2_檢查放開(ref cnt_Program_CCD01_01_SNAP_拼接圖2);

            if (cnt_Program_CCD01_01_SNAP_拼接圖2 == 65500)
            {
                PLC_Device_CCD01_SNAP.Bool = false;
                PLC_Device_CCD01_01_SNAP_拼接圖2.Bool = false;
                cnt_Program_CCD01_01_SNAP_拼接圖2 = 65535;
            }
        }
        void cnt_Program_CCD01_01_SNAP_拼接圖2_檢查按下(ref int cnt)
        {
            if (PLC_Device_CCD01_01_SNAP_拼接圖2.Bool) cnt++;
        }
        void cnt_Program_CCD01_01_SNAP_拼接圖2_檢查放開(ref int cnt)
        {
            if (!PLC_Device_CCD01_01_SNAP_拼接圖2.Bool) cnt = 65500;
        }
        void cnt_Program_CCD01_01_SNAP_拼接圖2_初始化(ref int cnt)
        {
            PLC_Device_CCD01_SNAP_電子快門.Value = PLC_Device_CCD01_01_SNAP_拼接圖1_電子快門.Value;
            PLC_Device_CCD01_SNAP_視訊增益.Value = PLC_Device_CCD01_01_SNAP_拼接圖1_視訊增益.Value;
            PLC_Device_CCD01_SNAP_銳利度.Value = PLC_Device_CCD01_01_SNAP_拼接圖1_銳利度.Value;

            cnt++;
        }
        void cnt_Program_CCD01_01_SNAP_拼接圖2_開始取像(ref int cnt)
        {
            if (!PLC_Device_CCD01_SNAP.Bool)
            {
                PLC_Device_CCD01_SNAP.Bool = true;
                cnt++;
            }
        }
        void cnt_Program_CCD01_01_SNAP_拼接圖2_取像結束(ref int cnt)
        {
            if (!PLC_Device_CCD01_SNAP.Bool)
            {
                cnt++;
            }
        }
        void cnt_Program_CCD01_01_SNAP_拼接圖2_繪製影像(ref int cnt)
        {
            this.CCD01_01_SrcImageHandle_拼接圖2 = this.h_Canvas_Tech_CCD01_01_拼接圖2.VegaHandle;
            this.h_Canvas_Tech_CCD01_01_拼接圖2.ImageCopy(this.CCD01_AxImageBW8.VegaHandle);
            this.h_Canvas_Tech_CCD01_01_拼接圖2.SetImageSize(this.h_Canvas_Tech_CCD01_01_拼接圖2.ImageWidth, this.h_Canvas_Tech_CCD01_01_拼接圖2.ImageHeight);
            if (this.PLC_Device_CCD01_01_SNAP_拼接圖2_按鈕.Bool) this.h_Canvas_Tech_CCD01_01_拼接圖2.RefreshCanvas();

            if (PLC_Device_CCD01_01_SNAP_拼接圖2_LIVE.Bool)
            {
                cnt = 2;
                return;
            }
            cnt++;
        }





        #endregion               
        #region PLC_CCD01_01_拼接校正
        PLC_Device PLC_Device_CCD01_01_拼接校正_按鈕 = new PLC_Device("S18010");
        PLC_Device PLC_Device_CCD01_01_拼接校正 = new PLC_Device("S18005");
        PLC_Device PLC_Device_CCD01_01_拼接校正_RefreshCanvas = new PLC_Device("S18006");
        private PLC_Device PLC_Device_CCD01_01_校正量測框_Real1_1_X = new PLC_Device("F6050");
        private PLC_Device PLC_Device_CCD01_01_校正量測框_Real1_2_X = new PLC_Device("F6051");
        private PLC_Device PLC_Device_CCD01_01_校正量測框_Real1_3_X = new PLC_Device("F6052");
        private PLC_Device PLC_Device_CCD01_01_校正量測框_Real1_4_X = new PLC_Device("F6053");
        private PLC_Device PLC_Device_CCD01_01_校正量測框_Real2_1_X = new PLC_Device("F6054");
        private PLC_Device PLC_Device_CCD01_01_校正量測框_Real2_2_X = new PLC_Device("F6055");
        private PLC_Device PLC_Device_CCD01_01_校正量測框_Real2_3_X = new PLC_Device("F6056");
        private PLC_Device PLC_Device_CCD01_01_校正量測框_Real2_4_X = new PLC_Device("F6057");

        private PLC_Device PLC_Device_CCD01_01_校正量測框_Real1_1_Y = new PLC_Device("F6060");
        private PLC_Device PLC_Device_CCD01_01_校正量測框_Real1_2_Y = new PLC_Device("F6061");
        private PLC_Device PLC_Device_CCD01_01_校正量測框_Real1_3_Y = new PLC_Device("F6062");
        private PLC_Device PLC_Device_CCD01_01_校正量測框_Real1_4_Y = new PLC_Device("F6063");
        private PLC_Device PLC_Device_CCD01_01_校正量測框_Real2_1_Y = new PLC_Device("F6064");
        private PLC_Device PLC_Device_CCD01_01_校正量測框_Real2_2_Y = new PLC_Device("F6065");
        private PLC_Device PLC_Device_CCD01_01_校正量測框_Real2_3_Y = new PLC_Device("F6066");
        private PLC_Device PLC_Device_CCD01_01_校正量測框_Real2_4_Y = new PLC_Device("F6067");
        private AxOvkImage.AxImageSewer CCD01_01_AxImageSewer;
        #region 拼圖座標
        double CCD01_01拼圖1_X1 = new double();
        double CCD01_01拼圖1_Y1 = new double();
        double CCD01_01拼圖1_X2 = new double();
        double CCD01_01拼圖1_Y2 = new double();
        double CCD01_01拼圖1_X3 = new double();
        double CCD01_01拼圖1_Y3 = new double();
        double CCD01_01拼圖1_X4 = new double();
        double CCD01_01拼圖1_Y4 = new double();

        double CCD01_01拼圖2_X1 = new double();
        double CCD01_01拼圖2_Y1 = new double();
        double CCD01_01拼圖2_X2 = new double();
        double CCD01_01拼圖2_Y2 = new double();
        double CCD01_01拼圖2_X3 = new double();
        double CCD01_01拼圖2_Y3 = new double();
        double CCD01_01拼圖2_X4 = new double();
        double CCD01_01拼圖2_Y4 = new double();
        #endregion
        private void H_Canvas_Tech_CCD01_01_拼接校正_OnCanvasDrawEvent(long HDC, float ZoomX, float ZoomY, int CanvasHandle)
        {
            PointF CCD01_01拼圖1校正點座標 = new PointF();
            try
            {

                if (this.PLC_Device_CCD01_01_拼接校正_RefreshCanvas.Bool)
                {

                    Graphics g = Graphics.FromHdc((IntPtr)HDC);
                    



                   DrawingClass.Draw.十字中心(CCD01_01拼圖1校正點座標, 50, Color.Lime, 1, g, ZoomX, ZoomY);
                    g.Dispose();
                    g = null;
                }
            }
            catch
            {

            }

            this.PLC_Device_CCD01_01_拼接校正_RefreshCanvas.Bool = false;
        }
        int cnt_Program_CCD01_01_拼接校正 = 65534;
        void sub_Program_CCD01_01_拼接校正()
        {
            if (CCD01_01_AxImageSewer != null)
            {
                if (cnt_Program_CCD01_01_拼接校正 == 65534)
                {
                    this.CCD01_01_AxImageSewer.LoadFile(@"C:\Users\aaa\Desktop\文信40PIN_CCD\Imagesewer_File\CCD01_01_Calibrate.cb");
                    h_Canvas_Tech_CCD01_01_拼接完成圖.OnCanvasDrawEvent += H_Canvas_Tech_CCD01_01_拼接校正_OnCanvasDrawEvent;
                    #region 拼圖座標
                    CCD01_01拼圖1_X1 = PLC_Device_CCD01_01_校正量測框_拼圖1校正座標1_X.Value / 1000D;
                    CCD01_01拼圖1_Y1 = PLC_Device_CCD01_01_校正量測框_拼圖1校正座標1_Y.Value / 1000D;
                    CCD01_01拼圖1_X2 = PLC_Device_CCD01_01_校正量測框_拼圖1校正座標2_X.Value / 1000D;
                    CCD01_01拼圖1_Y2 = PLC_Device_CCD01_01_校正量測框_拼圖1校正座標2_Y.Value / 1000D;
                    CCD01_01拼圖1_X3 = PLC_Device_CCD01_01_校正量測框_拼圖1校正座標3_X.Value / 1000D;
                    CCD01_01拼圖1_Y3 = PLC_Device_CCD01_01_校正量測框_拼圖1校正座標3_Y.Value / 1000D;
                    CCD01_01拼圖1_X4 = PLC_Device_CCD01_01_校正量測框_拼圖1校正座標4_X.Value / 1000D;
                    CCD01_01拼圖1_Y4 = PLC_Device_CCD01_01_校正量測框_拼圖1校正座標4_Y.Value / 1000D;

                    CCD01_01拼圖2_X1 = PLC_Device_CCD01_01_校正量測框_拼圖2校正座標1_X.Value / 1000D;
                    CCD01_01拼圖2_Y1 = PLC_Device_CCD01_01_校正量測框_拼圖2校正座標1_Y.Value / 1000D;
                    CCD01_01拼圖2_X2 = PLC_Device_CCD01_01_校正量測框_拼圖2校正座標2_X.Value / 1000D;
                    CCD01_01拼圖2_Y2 = PLC_Device_CCD01_01_校正量測框_拼圖2校正座標2_Y.Value / 1000D;
                    CCD01_01拼圖2_X3 = PLC_Device_CCD01_01_校正量測框_拼圖2校正座標3_X.Value / 1000D;
                    CCD01_01拼圖2_Y3 = PLC_Device_CCD01_01_校正量測框_拼圖2校正座標3_Y.Value / 1000D;
                    CCD01_01拼圖2_X4 = PLC_Device_CCD01_01_校正量測框_拼圖2校正座標4_X.Value / 1000D;
                    CCD01_01拼圖2_Y4 = PLC_Device_CCD01_01_校正量測框_拼圖2校正座標4_Y.Value / 1000D;
                    #endregion
                    PLC_Device_CCD01_01_拼接校正.SetComment("PLC_CCD01_01_拼接校正");
                    PLC_Device_CCD01_01_拼接校正.Bool = false;
                    cnt_Program_CCD01_01_拼接校正 = 65535;
                }
                if (cnt_Program_CCD01_01_拼接校正 == 65535) cnt_Program_CCD01_01_拼接校正 = 1;
                if (cnt_Program_CCD01_01_拼接校正 == 1) cnt_Program_CCD01_01_拼接校正_檢查按下(ref cnt_Program_CCD01_01_拼接校正);
                if (cnt_Program_CCD01_01_拼接校正 == 2) cnt_Program_CCD01_01_拼接校正_初始化(ref cnt_Program_CCD01_01_拼接校正);
                if (cnt_Program_CCD01_01_拼接校正 == 3) cnt_Program_CCD01_01_拼接校正_拼接教導完成(ref cnt_Program_CCD01_01_拼接校正);
                if (cnt_Program_CCD01_01_拼接校正 == 4) cnt_Program_CCD01_01_拼接校正_繪製影像(ref cnt_Program_CCD01_01_拼接校正);
                if (cnt_Program_CCD01_01_拼接校正 == 5) cnt_Program_CCD01_01_拼接校正 = 65500;
                if (cnt_Program_CCD01_01_拼接校正 > 1) cnt_Program_CCD01_01_拼接校正_檢查放開(ref cnt_Program_CCD01_01_拼接校正);
                if (cnt_Program_CCD01_01_拼接校正 == 65500)
                {
                    PLC_Device_CCD01_01_拼接校正.Bool = false;
                    cnt_Program_CCD01_01_拼接校正 = 65535;
                }
            }
        }
        void cnt_Program_CCD01_01_拼接校正_檢查按下(ref int cnt)
        {
            
            if (PLC_Device_CCD01_01_拼接校正.Bool) cnt++;
        }
        void cnt_Program_CCD01_01_拼接校正_檢查放開(ref int cnt)
        {
            if (!PLC_Device_CCD01_01_拼接校正.Bool) cnt = 65500;
        }
        void cnt_Program_CCD01_01_拼接校正_初始化(ref int cnt)
        {
            this.CCD01_01_AxImageSewer.UseGreylevelImage = true;
            this.CCD01_01_AxImageSewer.GreylevelBlankColor = 0;
            //this.CCD01_01_AxImageSewer.DstImageWidth = h_Canvas_Tech_CCD01_01_拼接完成圖.ImageWidth;
            //this.CCD01_01_AxImageSewer.DstImageHeight = h_Canvas_Tech_CCD01_01_拼接完成圖.ImageHeight;
            this.CCD01_01_AxImageSewer.DstImageWidth = 2592;
            this.CCD01_01_AxImageSewer.DstImageHeight = 1944;

            this.CCD01_01_AxImageSewer.NumOfSrcImages = 2;

            this.CCD01_01_AxImageSewer.SrcImageIndex = 0;
            this.CCD01_01_AxImageSewer.SrcImageWidth = h_Canvas_Tech_CCD01_01_拼接圖1.ImageWidth;
            this.CCD01_01_AxImageSewer.SrcImageHeight = h_Canvas_Tech_CCD01_01_拼接圖1.ImageHeight;
            this.CCD01_01_AxImageSewer.MapperMethod = AxOvkImage.TxAxImageSewerWorldMapperMethod.AX_IMAGE_SEWER_MAPPER_METHOD_PERSPECTIVE_METHOD;
            this.CCD01_01_AxImageSewer.SetCalibrationData(AxOvkImage.TxAxImageSewerWorldMapperDataType.AX_IMAGE_SEWER_PERSPECTIVE_MAPPER_DATA1, CCD01_01拼圖1_X1, CCD01_01拼圖1_Y1, PLC_Device_CCD01_01_校正量測框_Real1_1_X.Value, PLC_Device_CCD01_01_校正量測框_Real1_1_Y.Value);
            this.CCD01_01_AxImageSewer.SetCalibrationData(AxOvkImage.TxAxImageSewerWorldMapperDataType.AX_IMAGE_SEWER_PERSPECTIVE_MAPPER_DATA2, CCD01_01拼圖1_X2, CCD01_01拼圖1_Y2, PLC_Device_CCD01_01_校正量測框_Real1_2_X.Value, PLC_Device_CCD01_01_校正量測框_Real1_2_Y.Value);
            this.CCD01_01_AxImageSewer.SetCalibrationData(AxOvkImage.TxAxImageSewerWorldMapperDataType.AX_IMAGE_SEWER_PERSPECTIVE_MAPPER_DATA3, CCD01_01拼圖1_X3, CCD01_01拼圖1_Y3, PLC_Device_CCD01_01_校正量測框_Real1_3_X.Value, PLC_Device_CCD01_01_校正量測框_Real1_3_Y.Value);
            this.CCD01_01_AxImageSewer.SetCalibrationData(AxOvkImage.TxAxImageSewerWorldMapperDataType.AX_IMAGE_SEWER_PERSPECTIVE_MAPPER_DATA4, CCD01_01拼圖1_X4, CCD01_01拼圖1_Y4, PLC_Device_CCD01_01_校正量測框_Real1_4_X.Value, PLC_Device_CCD01_01_校正量測框_Real1_4_Y.Value);



            this.CCD01_01_AxImageSewer.SrcImageIndex = 1;
            this.CCD01_01_AxImageSewer.SrcImageWidth = h_Canvas_Tech_CCD01_01_拼接圖2.ImageWidth;
            this.CCD01_01_AxImageSewer.SrcImageHeight = h_Canvas_Tech_CCD01_01_拼接圖2.ImageHeight;
            this.CCD01_01_AxImageSewer.MapperMethod = AxOvkImage.TxAxImageSewerWorldMapperMethod.AX_IMAGE_SEWER_MAPPER_METHOD_PERSPECTIVE_METHOD;
            this.CCD01_01_AxImageSewer.SetCalibrationData(AxOvkImage.TxAxImageSewerWorldMapperDataType.AX_IMAGE_SEWER_PERSPECTIVE_MAPPER_DATA1, CCD01_01拼圖2_X1, CCD01_01拼圖2_Y1, PLC_Device_CCD01_01_校正量測框_Real2_1_X.Value, PLC_Device_CCD01_01_校正量測框_Real2_1_Y.Value);
            this.CCD01_01_AxImageSewer.SetCalibrationData(AxOvkImage.TxAxImageSewerWorldMapperDataType.AX_IMAGE_SEWER_PERSPECTIVE_MAPPER_DATA2, CCD01_01拼圖2_X2, CCD01_01拼圖2_Y2, PLC_Device_CCD01_01_校正量測框_Real2_2_X.Value, PLC_Device_CCD01_01_校正量測框_Real2_2_Y.Value);
            this.CCD01_01_AxImageSewer.SetCalibrationData(AxOvkImage.TxAxImageSewerWorldMapperDataType.AX_IMAGE_SEWER_PERSPECTIVE_MAPPER_DATA3, CCD01_01拼圖2_X3, CCD01_01拼圖2_Y3, PLC_Device_CCD01_01_校正量測框_Real2_3_X.Value, PLC_Device_CCD01_01_校正量測框_Real2_3_Y.Value);
            this.CCD01_01_AxImageSewer.SetCalibrationData(AxOvkImage.TxAxImageSewerWorldMapperDataType.AX_IMAGE_SEWER_PERSPECTIVE_MAPPER_DATA4, CCD01_01拼圖2_X4, CCD01_01拼圖2_Y4, PLC_Device_CCD01_01_校正量測框_Real2_4_X.Value, PLC_Device_CCD01_01_校正量測框_Real2_4_Y.Value);

            this.CCD01_01_AxImageSewer.Calibrate();
            cnt++;

        }
        void cnt_Program_CCD01_01_拼接校正_拼接教導完成(ref int cnt)
        {
            if (CCD01_01_AxImageSewer.Calibrate() == true)
            {
                cnt++;
            }
        }
        void cnt_Program_CCD01_01_拼接校正_繪製影像(ref int cnt)
        {
                cnt++;
        }





        #endregion
        #region PLC_CCD01_01_影像拼接
        PLC_Device PLC_Device_CCD01_01_影像拼接_按鈕 = new PLC_Device("S18030");
        PLC_Device PLC_Device_CCD01_01_影像拼接 = new PLC_Device("S18025");
        PLC_Device PLC_Device_CCD01_01_影像拼接_RefreshCanvas = new PLC_Device("S18026");

        private void H_Canvas_Tech_CCD01_01_影像拼接_OnCanvasDrawEvent(long HDC, float ZoomX, float ZoomY, int CanvasHandle)
        {
            try
            {

                if (this.PLC_Device_CCD01_01_影像拼接_RefreshCanvas.Bool)
                {

                    Graphics g = Graphics.FromHdc((IntPtr)HDC);
                   // DrawingClass.Draw.十字中心(CCD01_01拼圖1校正點座標, 50, Color.Lime, 1, g, ZoomX, ZoomY);
                    g.Dispose();
                    g = null;
                }
            }
            catch
            {

            }

            this.PLC_Device_CCD01_01_影像拼接_RefreshCanvas.Bool = false;
        }
        int cnt_Program_CCD01_01_影像拼接 = 65534;
        void sub_Program_CCD01_01_影像拼接()
        {
            if (cnt_Program_CCD01_01_影像拼接 == 65534)
            {
                h_Canvas_Tech_CCD01_01_拼接完成圖.OnCanvasDrawEvent += H_Canvas_Tech_CCD01_01_影像拼接_OnCanvasDrawEvent;

                PLC_Device_CCD01_01_影像拼接.SetComment("PLC_CCD01_01_影像拼接");
                PLC_Device_CCD01_01_影像拼接.Bool = false;
                cnt_Program_CCD01_01_影像拼接 = 65535;
            }
            if (cnt_Program_CCD01_01_影像拼接 == 65535) cnt_Program_CCD01_01_影像拼接 = 1;
            if (cnt_Program_CCD01_01_影像拼接 == 1) cnt_Program_CCD01_01_影像拼接_檢查按下(ref cnt_Program_CCD01_01_影像拼接);
            if (cnt_Program_CCD01_01_影像拼接 == 2) cnt_Program_CCD01_01_影像拼接_初始化(ref cnt_Program_CCD01_01_影像拼接);
            if (cnt_Program_CCD01_01_影像拼接 == 3) cnt_Program_CCD01_01_影像拼接_影像拼接(ref cnt_Program_CCD01_01_影像拼接);
            if (cnt_Program_CCD01_01_影像拼接 == 4) cnt_Program_CCD01_01_影像拼接_繪製影像(ref cnt_Program_CCD01_01_影像拼接);
            if (cnt_Program_CCD01_01_影像拼接 == 5) cnt_Program_CCD01_01_影像拼接 = 65500;
            if (cnt_Program_CCD01_01_影像拼接 > 1) cnt_Program_CCD01_01_影像拼接_檢查放開(ref cnt_Program_CCD01_01_影像拼接);
            if (cnt_Program_CCD01_01_影像拼接 == 65500)
            {
                PLC_Device_CCD01_01_影像拼接.Bool = false;
                cnt_Program_CCD01_01_影像拼接 = 65535;
            }
        }
        void cnt_Program_CCD01_01_影像拼接_檢查按下(ref int cnt)
        {
            if (PLC_Device_CCD01_01_影像拼接.Bool) cnt++;
        }
        void cnt_Program_CCD01_01_影像拼接_檢查放開(ref int cnt)
        {
            if (!PLC_Device_CCD01_01_影像拼接.Bool) cnt = 65500;
        }
        void cnt_Program_CCD01_01_影像拼接_初始化(ref int cnt)
        {
            
            this.CCD01_01_AxImageSewer.SrcImageIndex = 0;
            this.CCD01_01_AxImageSewer.SrcImageHandle = h_Canvas_Tech_CCD01_01_拼接圖1.VegaHandle;
            this.CCD01_01_AxImageSewer.SrcImageIndex = 1;
            this.CCD01_01_AxImageSewer.SrcImageHandle = h_Canvas_Tech_CCD01_01_拼接圖2.VegaHandle;

            cnt++;
        }
        
        void cnt_Program_CCD01_01_影像拼接_影像拼接(ref int cnt)
        {

            CCD01_01_AxImageSewer.Sew();
            cnt++;

        }
        void cnt_Program_CCD01_01_影像拼接_繪製影像(ref int cnt)
        {
            if (CCD01_01_AxImageSewer.Sew())
            {
                PLC_Device_CCD01_01_影像拼接_RefreshCanvas.Bool = true;
                this.h_Canvas_Tech_CCD01_01_拼接完成圖.ImageCopy(this.CCD01_01_AxImageSewer.DstImageHandle);
                this.CCD01_01_SrcImageHandle_拼接完成圖 = this.CCD01_01_AxImageSewer.DstImageHandle;
                this.h_Canvas_Tech_CCD01_01_拼接完成圖.RefreshCanvas();
                cnt++;
            }
        }





        #endregion
        #region PLC_CCD01_01_校正量測框調整
        PLC_Device PLC_Device_CCD01_01_校正量測框調整_按鈕 = new PLC_Device("S18050");
        PLC_Device PLC_Device_CCD01_01_校正量測框調整 = new PLC_Device("S18045");
        PLC_Device PLC_Device_CCD01_01_拼圖1校正量測框調整_RefreshCanvas = new PLC_Device("S6000");
        PLC_Device PLC_Device_CCD01_01_拼圖2校正量測框調整_RefreshCanvas = new PLC_Device("S6001");
        private AxOvkBase.AxROIBW8 CCD01_01_AxROIBW8_拼圖1校正量測框調整;
        private AxOvkBlob.AxObject CCD01_01_AxObject_拼圖1校正量測框調整;
        private AxOvkBase.AxROIBW8 CCD01_01_AxROIBW8_拼圖2校正量測框調整;
        private AxOvkBlob.AxObject CCD01_01_AxObject_拼圖2校正量測框調整;
        private PLC_Device PLC_Device_CCD01_01_校正量測框_灰階門檻值 = new PLC_Device("F6000");
        private PLC_Device PLC_Device_CCD01_01_拼圖1校正量測框_OrgX = new PLC_Device("F6001");
        private PLC_Device PLC_Device_CCD01_01_拼圖1校正量測框_OrgY = new PLC_Device("F6002");
        private PLC_Device PLC_Device_CCD01_01_拼圖1校正量測框_Width = new PLC_Device("F6003");
        private PLC_Device PLC_Device_CCD01_01_拼圖1校正量測框_Height = new PLC_Device("F6004");
        private PLC_Device PLC_Device_CCD01_01_校正量測框_面積上限 = new PLC_Device("F6005");
        private PLC_Device PLC_Device_CCD01_01_校正量測框_面積下限 = new PLC_Device("F6006");
        private PLC_Device PLC_Device_CCD01_01_拼圖2校正量測框_OrgX = new PLC_Device("F6011");
        private PLC_Device PLC_Device_CCD01_01_拼圖2校正量測框_OrgY = new PLC_Device("F6012");
        private PLC_Device PLC_Device_CCD01_01_拼圖2校正量測框_Width = new PLC_Device("F6013");
        private PLC_Device PLC_Device_CCD01_01_拼圖2校正量測框_Height = new PLC_Device("F6014");
        private PLC_Device PLC_Device_CCD01_01_校正量測框_拼圖1座標X = new PLC_Device("F6020");
        private PLC_Device PLC_Device_CCD01_01_校正量測框_拼圖1座標Y = new PLC_Device("F6021");
        private PLC_Device PLC_Device_CCD01_01_校正量測框_拼圖1校正座標1_X = new PLC_Device("F6022");
        private PLC_Device PLC_Device_CCD01_01_校正量測框_拼圖1校正座標1_Y = new PLC_Device("F6023");
        private PLC_Device PLC_Device_CCD01_01_校正量測框_拼圖1校正座標2_X = new PLC_Device("F6024");
        private PLC_Device PLC_Device_CCD01_01_校正量測框_拼圖1校正座標2_Y = new PLC_Device("F6025");
        private PLC_Device PLC_Device_CCD01_01_校正量測框_拼圖1校正座標3_X = new PLC_Device("F6026");
        private PLC_Device PLC_Device_CCD01_01_校正量測框_拼圖1校正座標3_Y = new PLC_Device("F6027");
        private PLC_Device PLC_Device_CCD01_01_校正量測框_拼圖1校正座標4_X = new PLC_Device("F6028");
        private PLC_Device PLC_Device_CCD01_01_校正量測框_拼圖1校正座標4_Y = new PLC_Device("F6029");

        private PLC_Device PLC_Device_CCD01_01_校正量測框_拼圖2座標X = new PLC_Device("F6030");
        private PLC_Device PLC_Device_CCD01_01_校正量測框_拼圖2座標Y = new PLC_Device("F6031");
        private PLC_Device PLC_Device_CCD01_01_校正量測框_拼圖2校正座標1_X = new PLC_Device("F6032");
        private PLC_Device PLC_Device_CCD01_01_校正量測框_拼圖2校正座標1_Y = new PLC_Device("F6033");
        private PLC_Device PLC_Device_CCD01_01_校正量測框_拼圖2校正座標2_X = new PLC_Device("F6034");
        private PLC_Device PLC_Device_CCD01_01_校正量測框_拼圖2校正座標2_Y = new PLC_Device("F6035");
        private PLC_Device PLC_Device_CCD01_01_校正量測框_拼圖2校正座標3_X = new PLC_Device("F6036");
        private PLC_Device PLC_Device_CCD01_01_校正量測框_拼圖2校正座標3_Y = new PLC_Device("F6037");
        private PLC_Device PLC_Device_CCD01_01_校正量測框_拼圖2校正座標4_X = new PLC_Device("F6038");
        private PLC_Device PLC_Device_CCD01_01_校正量測框_拼圖2校正座標4_Y = new PLC_Device("F6039");
        PointF CCD01_01拼圖1校正點座標 = new PointF();
        PointF CCD01_01拼圖2校正點座標 = new PointF();

        private AxOvkBase.TxAxHitHandle CCD01_01_TxAxHitHandle_AxROIBW8_拼圖1校正量測框調整 = new AxOvkBase.TxAxHitHandle();
        private bool flag_CCD01_01_拼圖1校正量測框調整_AxROIBW8_MouseDown;
        private AxOvkBase.TxAxHitHandle CCD01_01_TxAxHitHandle_AxROIBW8_拼圖2校正量測框調整 = new AxOvkBase.TxAxHitHandle();
        private bool flag_CCD01_01_拼圖2校正量測框調整_AxROIBW8_MouseDown;
        private void H_Canvas_Tech_CCD01_01_拼圖1校正量測框調整_OnCanvasDrawEvent(long HDC, float ZoomX, float ZoomY, int CanvasHandle)
        {
            
            try
            {

                if (this.PLC_Device_CCD01_01_拼圖1校正量測框調整_RefreshCanvas.Bool)
                {

                    Graphics g = Graphics.FromHdc((IntPtr)HDC);

                    this.CCD01_01_AxROIBW8_拼圖1校正量測框調整.ShowTitle = true;
                    this.CCD01_01_AxROIBW8_拼圖1校正量測框調整.ShowPlacement = false;
                    this.CCD01_01_AxROIBW8_拼圖1校正量測框調整.Title = "拼圖1量測框";
                    this.CCD01_01_AxROIBW8_拼圖1校正量測框調整.DrawFrame(HDC, ZoomX, ZoomY, 0, 0, 0x0000FF);

                    if (this.plC_CheckBox_CCD01_01_校正量測框_繪製量測區塊.Checked)
                    {
                        this.CCD01_01_AxObject_拼圖1校正量測框調整.DrawBlobs(HDC, -1, ZoomX, ZoomY, 0, 0, true, -1);

                    }
                    DrawingClass.Draw.十字中心(CCD01_01拼圖1校正點座標, 50, Color.Lime, 1, g, ZoomX, ZoomY);
                    g.Dispose();
                    g = null;
                }
            }
            catch
            {

            }

            this.PLC_Device_CCD01_01_拼圖1校正量測框調整_RefreshCanvas.Bool = false;
        }
        private void H_Canvas_Tech_CCD01_01_拼圖1校正量測框調整_OnCanvasMouseDownEvent(int x, int y, float ZoomX, float ZoomY, ref int InUsedEventNum, int InUsedCanvasHandle)
        {
            if (this.PLC_Device_CCD01_01_校正量測框調整.Bool)
            {
                this.CCD01_01_TxAxHitHandle_AxROIBW8_拼圖1校正量測框調整 = this.CCD01_01_AxROIBW8_拼圖1校正量測框調整.HitTest(x, y, ZoomX, ZoomY, 0, 0);
                if (this.CCD01_01_TxAxHitHandle_AxROIBW8_拼圖1校正量測框調整 != AxOvkBase.TxAxHitHandle.AX_HANDLE_NONE)
                {
                    this.flag_CCD01_01_拼圖1校正量測框調整_AxROIBW8_MouseDown = true;
                    InUsedEventNum = 10;
                    return;
                }

            }

        }
        private void H_Canvas_Tech_CCD01_01_拼圖1校正量測框調整_OnCanvasMouseMoveEvent(int x, int y, float ZoomX, float ZoomY)
        {
            if (this.flag_CCD01_01_拼圖1校正量測框調整_AxROIBW8_MouseDown)
            {
                this.CCD01_01_AxROIBW8_拼圖1校正量測框調整.DragROI(this.CCD01_01_TxAxHitHandle_AxROIBW8_拼圖1校正量測框調整, x, y, ZoomX, ZoomY, 0, 0);
                this.PLC_Device_CCD01_01_拼圖1校正量測框_OrgX.Value = this.CCD01_01_AxROIBW8_拼圖1校正量測框調整.OrgX;
                this.PLC_Device_CCD01_01_拼圖1校正量測框_OrgY.Value = this.CCD01_01_AxROIBW8_拼圖1校正量測框調整.OrgY;
                this.PLC_Device_CCD01_01_拼圖1校正量測框_Width.Value = this.CCD01_01_AxROIBW8_拼圖1校正量測框調整.ROIWidth;
                this.PLC_Device_CCD01_01_拼圖1校正量測框_Height.Value = this.CCD01_01_AxROIBW8_拼圖1校正量測框調整.ROIHeight;
            }

        }
        private void H_Canvas_Tech_CCD01_01_拼圖1校正量測框調整_OnCanvasMouseUpEvent(int x, int y, float ZoomX, float ZoomY)
        {
            this.flag_CCD01_01_拼圖1校正量測框調整_AxROIBW8_MouseDown = false;
        }

        private void H_Canvas_Tech_CCD01_01_拼圖2校正量測框調整_OnCanvasDrawEvent(long HDC, float ZoomX, float ZoomY, int CanvasHandle)
        {
            try
            {

                if (this.PLC_Device_CCD01_01_拼圖2校正量測框調整_RefreshCanvas.Bool)
                {

                    Graphics g = Graphics.FromHdc((IntPtr)HDC);

                    this.CCD01_01_AxROIBW8_拼圖2校正量測框調整.ShowTitle = true;
                    this.CCD01_01_AxROIBW8_拼圖2校正量測框調整.ShowPlacement = false;
                    this.CCD01_01_AxROIBW8_拼圖2校正量測框調整.Title = "拼圖2量測框";
                    this.CCD01_01_AxROIBW8_拼圖2校正量測框調整.DrawFrame(HDC, ZoomX, ZoomY, 0, 0, 0x0000FF);

                    if (this.plC_CheckBox_CCD01_01_校正量測框_繪製量測區塊.Checked)
                    {
                        this.CCD01_01_AxObject_拼圖2校正量測框調整.DrawBlobs(HDC, -1, ZoomX, ZoomY, 0, 0, true, -1);

                    }
                    DrawingClass.Draw.十字中心(CCD01_01拼圖2校正點座標, 50, Color.Lime, 1, g, ZoomX, ZoomY);
                    g.Dispose();
                    g = null;
                }
            }
            catch
            {

            }

            this.PLC_Device_CCD01_01_拼圖2校正量測框調整_RefreshCanvas.Bool = false;
        }
        private void H_Canvas_Tech_CCD01_01_拼圖2校正量測框調整_OnCanvasMouseDownEvent(int x, int y, float ZoomX, float ZoomY, ref int InUsedEventNum, int InUsedCanvasHandle)
        {
            if (this.PLC_Device_CCD01_01_校正量測框調整.Bool)
            {
                this.CCD01_01_TxAxHitHandle_AxROIBW8_拼圖2校正量測框調整 = this.CCD01_01_AxROIBW8_拼圖2校正量測框調整.HitTest(x, y, ZoomX, ZoomY, 0, 0);
                if (this.CCD01_01_TxAxHitHandle_AxROIBW8_拼圖2校正量測框調整 != AxOvkBase.TxAxHitHandle.AX_HANDLE_NONE)
                {
                    this.flag_CCD01_01_拼圖2校正量測框調整_AxROIBW8_MouseDown = true;
                    InUsedEventNum = 10;
                    return;
                }

            }

        }
        private void H_Canvas_Tech_CCD01_01_拼圖2校正量測框調整_OnCanvasMouseMoveEvent(int x, int y, float ZoomX, float ZoomY)
        {
            if (this.flag_CCD01_01_拼圖2校正量測框調整_AxROIBW8_MouseDown)
            {
                this.CCD01_01_AxROIBW8_拼圖2校正量測框調整.DragROI(this.CCD01_01_TxAxHitHandle_AxROIBW8_拼圖2校正量測框調整, x, y, ZoomX, ZoomY, 0, 0);
                this.PLC_Device_CCD01_01_拼圖2校正量測框_OrgX.Value = this.CCD01_01_AxROIBW8_拼圖2校正量測框調整.OrgX;
                this.PLC_Device_CCD01_01_拼圖2校正量測框_OrgY.Value = this.CCD01_01_AxROIBW8_拼圖2校正量測框調整.OrgY;
                this.PLC_Device_CCD01_01_拼圖2校正量測框_Width.Value = this.CCD01_01_AxROIBW8_拼圖2校正量測框調整.ROIWidth;
                this.PLC_Device_CCD01_01_拼圖2校正量測框_Height.Value = this.CCD01_01_AxROIBW8_拼圖2校正量測框調整.ROIHeight;
            }

        }
        private void H_Canvas_Tech_CCD01_01_拼圖2校正量測框調整_OnCanvasMouseUpEvent(int x, int y, float ZoomX, float ZoomY)
        {
            this.flag_CCD01_01_拼圖2校正量測框調整_AxROIBW8_MouseDown = false;
        }
        int cnt_Program_CCD01_01_校正量測框 = 65534;
        void sub_Program_CCD01_01_校正量測框()
        {
            if (cnt_Program_CCD01_01_校正量測框 == 65534)
            {
                

                this.h_Canvas_Tech_CCD01_01_拼接圖1.OnCanvasDrawEvent += H_Canvas_Tech_CCD01_01_拼圖1校正量測框調整_OnCanvasDrawEvent;
                this.h_Canvas_Tech_CCD01_01_拼接圖1.OnCanvasMouseDownEvent += H_Canvas_Tech_CCD01_01_拼圖1校正量測框調整_OnCanvasMouseDownEvent;
                this.h_Canvas_Tech_CCD01_01_拼接圖1.OnCanvasMouseMoveEvent += H_Canvas_Tech_CCD01_01_拼圖1校正量測框調整_OnCanvasMouseMoveEvent;
                this.h_Canvas_Tech_CCD01_01_拼接圖1.OnCanvasMouseUpEvent += H_Canvas_Tech_CCD01_01_拼圖1校正量測框調整_OnCanvasMouseUpEvent;

                this.h_Canvas_Tech_CCD01_01_拼接圖2.OnCanvasDrawEvent += H_Canvas_Tech_CCD01_01_拼圖2校正量測框調整_OnCanvasDrawEvent;
                this.h_Canvas_Tech_CCD01_01_拼接圖2.OnCanvasMouseDownEvent += H_Canvas_Tech_CCD01_01_拼圖2校正量測框調整_OnCanvasMouseDownEvent;
                this.h_Canvas_Tech_CCD01_01_拼接圖2.OnCanvasMouseMoveEvent += H_Canvas_Tech_CCD01_01_拼圖2校正量測框調整_OnCanvasMouseMoveEvent;
                this.h_Canvas_Tech_CCD01_01_拼接圖2.OnCanvasMouseUpEvent += H_Canvas_Tech_CCD01_01_拼圖2校正量測框調整_OnCanvasMouseUpEvent;


                if (PLC_Device_CCD01_01_拼圖1校正量測框_OrgX.Value <= 0) PLC_Device_CCD01_01_拼圖1校正量測框_OrgX.Value = 20;
                if (PLC_Device_CCD01_01_拼圖1校正量測框_OrgY.Value <= 0) PLC_Device_CCD01_01_拼圖1校正量測框_OrgY.Value = 20;
                if (PLC_Device_CCD01_01_拼圖1校正量測框_Width.Value <= 0) PLC_Device_CCD01_01_拼圖1校正量測框_Width.Value = 20;
                if (PLC_Device_CCD01_01_拼圖1校正量測框_Height.Value <= 0) PLC_Device_CCD01_01_拼圖1校正量測框_Height.Value = 20;
                if (PLC_Device_CCD01_01_拼圖2校正量測框_OrgX.Value <= 0) PLC_Device_CCD01_01_拼圖2校正量測框_OrgX.Value = 20;
                if (PLC_Device_CCD01_01_拼圖2校正量測框_OrgY.Value <= 0) PLC_Device_CCD01_01_拼圖2校正量測框_OrgY.Value = 20;
                if (PLC_Device_CCD01_01_拼圖2校正量測框_Width.Value <= 0) PLC_Device_CCD01_01_拼圖2校正量測框_Width.Value = 20;
                if (PLC_Device_CCD01_01_拼圖2校正量測框_Height.Value <= 0) PLC_Device_CCD01_01_拼圖2校正量測框_Height.Value = 20;

                PLC_Device_CCD01_01_校正量測框調整.SetComment("PLC_CCD01_01_校正量測框");
                PLC_Device_CCD01_01_校正量測框調整.Bool = false;
                cnt_Program_CCD01_01_校正量測框 = 65535;
            }
            if (cnt_Program_CCD01_01_校正量測框 == 65535) cnt_Program_CCD01_01_校正量測框 = 1;
            if (cnt_Program_CCD01_01_校正量測框 == 1) cnt_Program_CCD01_01_校正量測框_檢查按下(ref cnt_Program_CCD01_01_校正量測框);
            if (cnt_Program_CCD01_01_校正量測框 == 2) cnt_Program_CCD01_01_校正量測框_初始化(ref cnt_Program_CCD01_01_校正量測框);
            if (cnt_Program_CCD01_01_校正量測框 == 3) cnt_Program_CCD01_01_校正量測框_區塊分析(ref cnt_Program_CCD01_01_校正量測框);
            if (cnt_Program_CCD01_01_校正量測框 == 4) cnt_Program_CCD01_01_校正量測框_繪製影像(ref cnt_Program_CCD01_01_校正量測框);
            if (cnt_Program_CCD01_01_校正量測框 == 5) cnt_Program_CCD01_01_校正量測框 = 65500;
            if (cnt_Program_CCD01_01_校正量測框 > 1) cnt_Program_CCD01_01_校正量測框_檢查放開(ref cnt_Program_CCD01_01_校正量測框);
            if (cnt_Program_CCD01_01_校正量測框 == 65500)
            {
                //PLC_Device_CCD01_01_校正量測框調整.Bool = false;
                cnt_Program_CCD01_01_校正量測框 = 65535;
            }
        }
        void cnt_Program_CCD01_01_校正量測框_檢查按下(ref int cnt)
        {
            if (PLC_Device_CCD01_01_校正量測框調整.Bool) cnt++;
        }
        void cnt_Program_CCD01_01_校正量測框_檢查放開(ref int cnt)
        {
            if (!PLC_Device_CCD01_01_校正量測框調整.Bool) cnt = 65500;
        }
        void cnt_Program_CCD01_01_校正量測框_初始化(ref int cnt)
        {


            this.CCD01_01_AxROIBW8_拼圖1校正量測框調整.ParentHandle = this.CCD01_01_SrcImageHandle_拼接圖1;
            this.CCD01_01_AxROIBW8_拼圖1校正量測框調整.OrgX = this.PLC_Device_CCD01_01_拼圖1校正量測框_OrgX.Value;
            this.CCD01_01_AxROIBW8_拼圖1校正量測框調整.OrgY = this.PLC_Device_CCD01_01_拼圖1校正量測框_OrgY.Value;
            this.CCD01_01_AxROIBW8_拼圖1校正量測框調整.ROIWidth = this.PLC_Device_CCD01_01_拼圖1校正量測框_Width.Value;
            this.CCD01_01_AxROIBW8_拼圖1校正量測框調整.ROIHeight = this.PLC_Device_CCD01_01_拼圖1校正量測框_Height.Value;
            this.CCD01_01_AxROIBW8_拼圖1校正量測框調整.SkewAngle = 0;

            this.CCD01_01_AxROIBW8_拼圖2校正量測框調整.ParentHandle = this.CCD01_01_SrcImageHandle_拼接圖2;
            this.CCD01_01_AxROIBW8_拼圖2校正量測框調整.OrgX = this.PLC_Device_CCD01_01_拼圖2校正量測框_OrgX.Value;
            this.CCD01_01_AxROIBW8_拼圖2校正量測框調整.OrgY = this.PLC_Device_CCD01_01_拼圖2校正量測框_OrgY.Value;
            this.CCD01_01_AxROIBW8_拼圖2校正量測框調整.ROIWidth = this.PLC_Device_CCD01_01_拼圖2校正量測框_Width.Value;
            this.CCD01_01_AxROIBW8_拼圖2校正量測框調整.ROIHeight = this.PLC_Device_CCD01_01_拼圖2校正量測框_Height.Value;
            this.CCD01_01_AxROIBW8_拼圖2校正量測框調整.SkewAngle = 0;
            cnt++;
        }
        void cnt_Program_CCD01_01_校正量測框_區塊分析(ref int cnt)
        {
            uint 區塊特徵總和 = 4294951423;
            this.CCD01_01_AxObject_拼圖1校正量測框調整.SrcImageHandle = this.CCD01_01_AxROIBW8_拼圖1校正量測框調整.VegaHandle;

            this.CCD01_01_AxObject_拼圖1校正量測框調整.ObjectClass = AxOvkBlob.TxAxObjClass.AX_OBJECT_DETECT_LIGHTER_CLASS;
            this.CCD01_01_AxObject_拼圖1校正量測框調整.HighThreshold = PLC_Device_CCD01_01_校正量測框_灰階門檻值.Value;
            this.CCD01_01_AxObject_拼圖1校正量測框調整.BlobAnalyze(true);
            this.CCD01_01_AxObject_拼圖1校正量測框調整.CalculateFeatures((int)區塊特徵總和, -1);
            this.CCD01_01_AxObject_拼圖1校正量測框調整.SortObjects(AxOvkBlob.TxAxObjFeatureSortOrder.AX_OBJECT_SORT_ORDER_LARGE_TO_SMALL, AxOvkBlob.TxAxObjFeature.AX_OBJECT_FEATURE_AREA, 0, -1);
            this.CCD01_01_AxObject_拼圖1校正量測框調整.SelectObjects(AxOvkBlob.TxAxObjFeature.AX_OBJECT_FEATURE_AREA, AxOvkBlob.TxAxObjFeatureOperation.AX_OBJECT_REMOVE_LESS_THAN, this.PLC_Device_CCD01_01_校正量測框_面積下限.Value);
            this.CCD01_01_AxObject_拼圖1校正量測框調整.SelectObjects(AxOvkBlob.TxAxObjFeature.AX_OBJECT_FEATURE_AREA, AxOvkBlob.TxAxObjFeatureOperation.AX_OBJECT_REMOVE_GREAT_THAN, this.PLC_Device_CCD01_01_校正量測框_面積上限.Value);
            if (this.CCD01_01_AxObject_拼圖1校正量測框調整.DetectedNumObjs > 0)
            {
                this.CCD01_01_AxObject_拼圖1校正量測框調整.BlobIndex = 0;
                int 拼圖1_X0 = this.CCD01_01_AxObject_拼圖1校正量測框調整.BlobLimBoxX;
                int 拼圖1_Y0 = this.CCD01_01_AxObject_拼圖1校正量測框調整.BlobLimBoxY;
                float 拼圖1_X1 = this.CCD01_01_AxObject_拼圖1校正量測框調整.BlobCentroidX;
                float 拼圖1_Y1 = this.CCD01_01_AxObject_拼圖1校正量測框調整.BlobCentroidY;

                this.CCD01_01拼圖1校正點座標.X = 拼圖1_X1;
                this.CCD01_01拼圖1校正點座標.X += this.CCD01_01_AxROIBW8_拼圖1校正量測框調整.OrgX;
                this.CCD01_01拼圖1校正點座標.Y = 拼圖1_Y1;
                this.CCD01_01拼圖1校正點座標.Y += this.CCD01_01_AxROIBW8_拼圖1校正量測框調整.OrgY;
                this.PLC_Device_CCD01_01_校正量測框_拼圖1座標X.Value = (int)(CCD01_01拼圖1校正點座標.X * 1000);
                this.PLC_Device_CCD01_01_校正量測框_拼圖1座標Y.Value = (int)(CCD01_01拼圖1校正點座標.Y * 1000);

            }

            this.CCD01_01_AxObject_拼圖2校正量測框調整.SrcImageHandle = this.CCD01_01_AxROIBW8_拼圖2校正量測框調整.VegaHandle;

            this.CCD01_01_AxObject_拼圖2校正量測框調整.ObjectClass = AxOvkBlob.TxAxObjClass.AX_OBJECT_DETECT_LIGHTER_CLASS;
            this.CCD01_01_AxObject_拼圖2校正量測框調整.HighThreshold = PLC_Device_CCD01_01_校正量測框_灰階門檻值.Value;
            this.CCD01_01_AxObject_拼圖2校正量測框調整.BlobAnalyze(true);
            this.CCD01_01_AxObject_拼圖2校正量測框調整.CalculateFeatures((int)區塊特徵總和, -1);
            this.CCD01_01_AxObject_拼圖2校正量測框調整.SortObjects(AxOvkBlob.TxAxObjFeatureSortOrder.AX_OBJECT_SORT_ORDER_LARGE_TO_SMALL, AxOvkBlob.TxAxObjFeature.AX_OBJECT_FEATURE_AREA, 0, -1);
            this.CCD01_01_AxObject_拼圖2校正量測框調整.SelectObjects(AxOvkBlob.TxAxObjFeature.AX_OBJECT_FEATURE_AREA, AxOvkBlob.TxAxObjFeatureOperation.AX_OBJECT_REMOVE_LESS_THAN, this.PLC_Device_CCD01_01_校正量測框_面積下限.Value);
            this.CCD01_01_AxObject_拼圖2校正量測框調整.SelectObjects(AxOvkBlob.TxAxObjFeature.AX_OBJECT_FEATURE_AREA, AxOvkBlob.TxAxObjFeatureOperation.AX_OBJECT_REMOVE_GREAT_THAN, this.PLC_Device_CCD01_01_校正量測框_面積上限.Value);
            if (this.CCD01_01_AxObject_拼圖2校正量測框調整.DetectedNumObjs > 0)
            {
                this.CCD01_01_AxObject_拼圖2校正量測框調整.BlobIndex = 0;
                int 拼圖2_X0 = this.CCD01_01_AxObject_拼圖2校正量測框調整.BlobLimBoxX;
                int 拼圖2_Y0 = this.CCD01_01_AxObject_拼圖2校正量測框調整.BlobLimBoxY;
                float 拼圖2_X1 = this.CCD01_01_AxObject_拼圖2校正量測框調整.BlobCentroidX;
                float 拼圖2_Y1 = this.CCD01_01_AxObject_拼圖2校正量測框調整.BlobCentroidY;

                this.CCD01_01拼圖2校正點座標.X = 拼圖2_X1;
                this.CCD01_01拼圖2校正點座標.X += this.CCD01_01_AxROIBW8_拼圖2校正量測框調整.OrgX;
                this.CCD01_01拼圖2校正點座標.Y = 拼圖2_Y1;
                this.CCD01_01拼圖2校正點座標.Y += this.CCD01_01_AxROIBW8_拼圖2校正量測框調整.OrgY;
                this.PLC_Device_CCD01_01_校正量測框_拼圖2座標X.Value = (int)(CCD01_01拼圖2校正點座標.X * 1000);
                this.PLC_Device_CCD01_01_校正量測框_拼圖2座標Y.Value = (int)(CCD01_01拼圖2校正點座標.Y * 1000);

            }

            cnt++;


        }
        void cnt_Program_CCD01_01_校正量測框_繪製影像(ref int cnt)
        {

            if (PLC_Device_CCD01_01_校正量測框調整_按鈕.Bool)
            {
                this.PLC_Device_CCD01_01_拼圖1校正量測框調整_RefreshCanvas.Bool = true;
                this.h_Canvas_Tech_CCD01_01_拼接圖1.RefreshCanvas();
            }


            if (PLC_Device_CCD01_01_校正量測框調整_按鈕.Bool)
            {
                this.PLC_Device_CCD01_01_拼圖2校正量測框調整_RefreshCanvas.Bool = true;
                this.h_Canvas_Tech_CCD01_01_拼接圖2.RefreshCanvas();
            }

            cnt++;
        }





        #endregion

        #region PLC_CCD01_01_Main_取像並檢驗
        PLC_Device PLC_Device_CCD01_01_Main_取像並檢驗 = new PLC_Device("S39900");
        PLC_Device PLC_Device_CCD01_01_PLC觸發檢測 = new PLC_Device("S39700");
        PLC_Device PLC_Device_CCD01_01_PLC觸發檢測完成 = new PLC_Device("S39701");
        MyTimer CCD01_01_Init_Timer = new MyTimer();
        int cnt_Program_CCD01_01_Main_取像並檢驗 = 65534;
        void sub_Program_CCD01_01_Main_取像並檢驗()
        {
            if (cnt_Program_CCD01_01_Main_取像並檢驗 == 65534)
            {
                PLC_Device_CCD01_01_Main_取像並檢驗.SetComment("PLC_CCD01_01_Main_取像並檢驗");
                PLC_Device_CCD01_01_Main_取像並檢驗.Bool = false;
                PLC_Device_CCD01_01_PLC觸發檢測.Bool = false;

            }
            if (cnt_Program_CCD01_01_Main_取像並檢驗 == 65535) cnt_Program_CCD01_01_Main_取像並檢驗 = 1;
            if (cnt_Program_CCD01_01_Main_取像並檢驗 == 1) cnt_Program_CCD01_01_Main_取像並檢驗_檢查按下(ref cnt_Program_CCD01_01_Main_取像並檢驗);
            if (cnt_Program_CCD01_01_Main_取像並檢驗 == 2) cnt_Program_CCD01_01_Main_取像並檢驗_初始化(ref cnt_Program_CCD01_01_Main_取像並檢驗);
            if (cnt_Program_CCD01_01_Main_取像並檢驗 == 3) cnt_Program_CCD01_01_Main_取像並檢驗_開始SNAP(ref cnt_Program_CCD01_01_Main_取像並檢驗);
            if (cnt_Program_CCD01_01_Main_取像並檢驗 == 4) cnt_Program_CCD01_01_Main_取像並檢驗_結束SNAP(ref cnt_Program_CCD01_01_Main_取像並檢驗);
            if (cnt_Program_CCD01_01_Main_取像並檢驗 == 5) cnt_Program_CCD01_01_Main_取像並檢驗_開始計算一次(ref cnt_Program_CCD01_01_Main_取像並檢驗);
            if (cnt_Program_CCD01_01_Main_取像並檢驗 == 6) cnt_Program_CCD01_01_Main_取像並檢驗_結束計算一次(ref cnt_Program_CCD01_01_Main_取像並檢驗);
            if (cnt_Program_CCD01_01_Main_取像並檢驗 == 7) cnt_Program_CCD01_01_Main_取像並檢驗_繪製畫布(ref cnt_Program_CCD01_01_Main_取像並檢驗);
            if (cnt_Program_CCD01_01_Main_取像並檢驗 == 8) cnt_Program_CCD01_01_Main_取像並檢驗_檢查重測次數(ref cnt_Program_CCD01_01_Main_取像並檢驗);
            if (cnt_Program_CCD01_01_Main_取像並檢驗 == 9) cnt_Program_CCD01_01_Main_取像並檢驗 = 65500;
            if (cnt_Program_CCD01_01_Main_取像並檢驗 > 1) cnt_Program_CCD01_01_Main_取像並檢驗_檢查放開(ref cnt_Program_CCD01_01_Main_取像並檢驗);

            if (cnt_Program_CCD01_01_Main_取像並檢驗 == 65500)
            {
                PLC_Device_CCD01_01_Main_取像並檢驗.Bool = false;
                PLC_Device_CCD01_01_PLC觸發檢測.Bool = false;
                PLC_Device_CCD01_01_PLC觸發檢測完成.Bool = false;
                cnt_Program_CCD01_01_Main_取像並檢驗 = 65535;
            }
        }
        void cnt_Program_CCD01_01_Main_取像並檢驗_檢查按下(ref int cnt)
        {

            if (PLC_Device_CCD01_01_Main_取像並檢驗.Bool && !PLC_Device_CCD01_01_PLC觸發檢測.Bool)
            {

                cnt++;
            }

            else if (PLC_Device_CCD01_01_PLC觸發檢測.Bool)
            {
                PLC_Device_CCD01_01_Main_取像並檢驗.Bool = true;
                cnt++;
            }



        }
        void cnt_Program_CCD01_01_Main_取像並檢驗_檢查放開(ref int cnt)
        {
            if (!PLC_Device_CCD01_01_Main_取像並檢驗.Bool && !PLC_Device_CCD01_01_PLC觸發檢測.Bool) cnt = 65500;
        }
        void cnt_Program_CCD01_01_Main_取像並檢驗_初始化(ref int cnt)
        {
            cnt++;
        }
        void cnt_Program_CCD01_01_Main_取像並檢驗_開始SNAP(ref int cnt)
        {
                cnt++;
            
        }
        void cnt_Program_CCD01_01_Main_取像並檢驗_結束SNAP(ref int cnt)
        {
           // this.h_Canvas_Main_CCD01_01_檢測畫面.ImageCopy(h_Canvas_Tech_CCD01_01_拼接完成圖.VegaHandle);
            cnt++;
            
        }
        void cnt_Program_CCD01_01_Main_取像並檢驗_開始計算一次(ref int cnt)
        {
            if (!this.PLC_Device_CCD01_01_計算一次.Bool)
            {
                this.PLC_Device_CCD01_01_計算一次.Bool = true;
                cnt++;
            }
        }
        void cnt_Program_CCD01_01_Main_取像並檢驗_結束計算一次(ref int cnt)
        {
            if (!this.PLC_Device_CCD01_01_計算一次.Bool)
            {
                cnt++;
            }
        }
        void cnt_Program_CCD01_01_Main_取像並檢驗_繪製畫布(ref int cnt)
        {
            if (CCD01_01_SrcImageHandle_拼接完成圖 != 0)
            {
                this.h_Canvas_Main_CCD01_01_檢測畫面.RefreshCanvas();
                PLC_Device_CCD01_01_PLC觸發檢測完成.Bool = true;
            }
            cnt++;
        }
        void cnt_Program_CCD01_01_Main_取像並檢驗_檢查重測次數(ref int cnt)
        {
            cnt ++;
        }





        #endregion
        #region PLC_CCD01_01_Main_取像拼接
        PLC_Device PLC_Device_CCD01_01_Main_取像拼接 = new PLC_Device("S38000");
        PLC_Device PLC_Device_CCD01_01_觸發PLC步進移動 = new PLC_Device("S38010");
        PLC_Device PLC_Device_CCD01_01_觸發PLC步進移動完成 = new PLC_Device("S38011");
        int cnt_Program_CCD01_01_Main_取像拼接 = 65534;
        void sub_Program_CCD01_01_Main_取像拼接()
        {
            if (cnt_Program_CCD01_01_Main_取像拼接 == 65534)
            {
                PLC_Device_CCD01_01_Main_取像拼接.SetComment("PLC_CCD01_01_Main_取像拼接");
                PLC_Device_CCD01_01_Main_取像拼接.Bool = false;

            }
            if (cnt_Program_CCD01_01_Main_取像拼接 == 65535) cnt_Program_CCD01_01_Main_取像拼接 = 1;
            if (cnt_Program_CCD01_01_Main_取像拼接 == 1) cnt_Program_CCD01_01_Main_取像拼接_檢查按下(ref cnt_Program_CCD01_01_Main_取像拼接);
            if (cnt_Program_CCD01_01_Main_取像拼接 == 2) cnt_Program_CCD01_01_Main_取像拼接_初始化(ref cnt_Program_CCD01_01_Main_取像拼接);
            if (cnt_Program_CCD01_01_Main_取像拼接 == 3) cnt_Program_CCD01_01_Main_取像拼接_拼接1開始SNAP(ref cnt_Program_CCD01_01_Main_取像拼接);
            if (cnt_Program_CCD01_01_Main_取像拼接 == 4) cnt_Program_CCD01_01_Main_取像拼接_拼接1結束SNAP(ref cnt_Program_CCD01_01_Main_取像拼接);
            if (cnt_Program_CCD01_01_Main_取像拼接 == 5) cnt_Program_CCD01_01_Main_取像拼接_步進到第二張位置開始(ref cnt_Program_CCD01_01_Main_取像拼接);
            if (cnt_Program_CCD01_01_Main_取像拼接 == 6) cnt_Program_CCD01_01_Main_取像拼接_步進到第二張位置結束(ref cnt_Program_CCD01_01_Main_取像拼接);
            if (cnt_Program_CCD01_01_Main_取像拼接 == 7) cnt_Program_CCD01_01_Main_取像拼接_拼接2開始SNAP(ref cnt_Program_CCD01_01_Main_取像拼接);
            if (cnt_Program_CCD01_01_Main_取像拼接 == 8) cnt_Program_CCD01_01_Main_取像拼接_拼接2結束SNAP(ref cnt_Program_CCD01_01_Main_取像拼接);
            if (cnt_Program_CCD01_01_Main_取像拼接 == 9) cnt_Program_CCD01_01_Main_取像拼接_影像拼接開始(ref cnt_Program_CCD01_01_Main_取像拼接);
            if (cnt_Program_CCD01_01_Main_取像拼接 == 10) cnt_Program_CCD01_01_Main_取像拼接_影像拼接結束(ref cnt_Program_CCD01_01_Main_取像拼接);
            if (cnt_Program_CCD01_01_Main_取像拼接 == 11) cnt_Program_CCD01_01_Main_取像拼接_繪製畫布(ref cnt_Program_CCD01_01_Main_取像拼接);
            if (cnt_Program_CCD01_01_Main_取像拼接 == 12) cnt_Program_CCD01_01_Main_取像拼接 = 65500;
            if (cnt_Program_CCD01_01_Main_取像拼接 > 1) cnt_Program_CCD01_01_Main_取像拼接_檢查放開(ref cnt_Program_CCD01_01_Main_取像拼接);

            if (cnt_Program_CCD01_01_Main_取像拼接 == 65500)
            {
                PLC_Device_CCD01_01_Main_取像拼接.Bool = false;
                cnt_Program_CCD01_01_Main_取像拼接 = 65535;
            }
        }
        void cnt_Program_CCD01_01_Main_取像拼接_檢查按下(ref int cnt)
        {
            if (PLC_Device_CCD01_01_Main_取像拼接.Bool) cnt++;
        }
        void cnt_Program_CCD01_01_Main_取像拼接_檢查放開(ref int cnt)
        {
            if (!PLC_Device_CCD01_01_Main_取像拼接.Bool) cnt = 65500;
        }
        void cnt_Program_CCD01_01_Main_取像拼接_初始化(ref int cnt)
        {
            cnt++;
        }
        void cnt_Program_CCD01_01_Main_取像拼接_拼接1開始SNAP(ref int cnt)
        {
            if (!PLC_Device_CCD01_01_SNAP_拼接圖1.Bool)
            {

                PLC_Device_CCD01_01_SNAP_拼接圖1.Bool = true;
                cnt++;
            }

        }
        void cnt_Program_CCD01_01_Main_取像拼接_拼接1結束SNAP(ref int cnt)
        {
            if (!PLC_Device_CCD01_01_SNAP_拼接圖1.Bool)
            {
                cnt++;
            }

        }
        void cnt_Program_CCD01_01_Main_取像拼接_步進到第二張位置開始(ref int cnt)
        {
            //if (!PLC_Device_CCD01_01_觸發PLC步進移動.Bool)
            //{

            //    PLC_Device_CCD01_01_觸發PLC步進移動.Bool = true;
            //    cnt++;
            //}
            cnt++;
        }
        void cnt_Program_CCD01_01_Main_取像拼接_步進到第二張位置結束(ref int cnt)
        {
            //if (!PLC_Device_CCD01_01_觸發PLC步進移動.Bool && PLC_Device_CCD01_01_觸發PLC步進移動完成.Bool)
            //{
            //    cnt++;
            //}
            cnt++;
        }
        void cnt_Program_CCD01_01_Main_取像拼接_拼接2開始SNAP(ref int cnt)
        {
            if (!PLC_Device_CCD01_01_SNAP_拼接圖2.Bool)
            {

                PLC_Device_CCD01_01_SNAP_拼接圖2.Bool = true;
                cnt++;
            }

        }
        void cnt_Program_CCD01_01_Main_取像拼接_拼接2結束SNAP(ref int cnt)
        {
            if (!PLC_Device_CCD01_01_SNAP_拼接圖2.Bool)
            {
                cnt++;
            }

        }
        void cnt_Program_CCD01_01_Main_取像拼接_影像拼接開始(ref int cnt)
        {
            if (!this.PLC_Device_CCD01_01_影像拼接.Bool)
            {
                this.PLC_Device_CCD01_01_影像拼接.Bool = true;
                cnt++;
            }
        }
        void cnt_Program_CCD01_01_Main_取像拼接_影像拼接結束(ref int cnt)
        {
            if (!this.PLC_Device_CCD01_01_影像拼接.Bool)
            {
                this.h_Canvas_Main_CCD01_01_檢測畫面.ImageCopy(h_Canvas_Tech_CCD01_01_拼接完成圖.VegaHandle);
                cnt++;
            }
        }
        void cnt_Program_CCD01_01_Main_取像拼接_繪製畫布(ref int cnt)
        {
            if (CCD01_01_SrcImageHandle_拼接完成圖 != 0)
            {
                this.h_Canvas_Main_CCD01_01_檢測畫面.RefreshCanvas();
            }
            cnt++;
        }



        #endregion
        #region PLC_CCD01_01_Tech_檢驗一次
        PLC_Device PLC_Device_CCD01_01_Tech_檢驗一次 = new PLC_Device("S15045");
        int cnt_Program_CCD01_01_Tech_檢驗一次 = 65534;
        void sub_Program_CCD01_01_Tech_檢驗一次()
        {
            if (cnt_Program_CCD01_01_Tech_檢驗一次 == 65534)
            {
                PLC_Device_CCD01_01_Tech_檢驗一次.SetComment("PLC_CCD01_01_Tech_檢驗一次");
                PLC_Device_CCD01_01_Tech_檢驗一次.Bool = false;
                cnt_Program_CCD01_01_Tech_檢驗一次 = 65535;
            }
            if (cnt_Program_CCD01_01_Tech_檢驗一次 == 65535) cnt_Program_CCD01_01_Tech_檢驗一次 = 1;
            if (cnt_Program_CCD01_01_Tech_檢驗一次 == 1) cnt_Program_CCD01_01_Tech_檢驗一次_檢查按下(ref cnt_Program_CCD01_01_Tech_檢驗一次);
            if (cnt_Program_CCD01_01_Tech_檢驗一次 == 2) cnt_Program_CCD01_01_Tech_檢驗一次_初始化(ref cnt_Program_CCD01_01_Tech_檢驗一次);
            if (cnt_Program_CCD01_01_Tech_檢驗一次 == 3) cnt_Program_CCD01_01_Tech_檢驗一次_計算一次開始(ref cnt_Program_CCD01_01_Tech_檢驗一次);
            if (cnt_Program_CCD01_01_Tech_檢驗一次 == 4) cnt_Program_CCD01_01_Tech_檢驗一次_計算一次結束(ref cnt_Program_CCD01_01_Tech_檢驗一次);
            if (cnt_Program_CCD01_01_Tech_檢驗一次 == 5) cnt_Program_CCD01_01_Tech_檢驗一次_繪製畫布(ref cnt_Program_CCD01_01_Tech_檢驗一次);
            if (cnt_Program_CCD01_01_Tech_檢驗一次 == 6) cnt_Program_CCD01_01_Tech_檢驗一次 = 65500;
            if (cnt_Program_CCD01_01_Tech_檢驗一次 > 1) cnt_Program_CCD01_01_Tech_檢驗一次_檢查放開(ref cnt_Program_CCD01_01_Tech_檢驗一次);

            if (cnt_Program_CCD01_01_Tech_檢驗一次 == 65500)
            {
                PLC_Device_CCD01_01_Tech_檢驗一次.Bool = false;
                cnt_Program_CCD01_01_Tech_檢驗一次 = 65535;
            }
        }
        void cnt_Program_CCD01_01_Tech_檢驗一次_檢查按下(ref int cnt)
        {
            if (PLC_Device_CCD01_01_Tech_檢驗一次.Bool) cnt++;
        }
        void cnt_Program_CCD01_01_Tech_檢驗一次_檢查放開(ref int cnt)
        {
            if (!PLC_Device_CCD01_01_Tech_檢驗一次.Bool) cnt = 65500;
        }
        void cnt_Program_CCD01_01_Tech_檢驗一次_初始化(ref int cnt)
        {

            cnt++;
        }
        void cnt_Program_CCD01_01_Tech_檢驗一次_計算一次開始(ref int cnt)
        {
            if (!this.PLC_Device_CCD01_01_計算一次.Bool)
            {
                this.PLC_Device_CCD01_01_計算一次.Bool = true;
                cnt++;
            }
        }
        void cnt_Program_CCD01_01_Tech_檢驗一次_計算一次結束(ref int cnt)
        {
            if (!this.PLC_Device_CCD01_01_計算一次.Bool)
            {
                cnt++;
            }
        }
        void cnt_Program_CCD01_01_Tech_檢驗一次_繪製畫布(ref int cnt)
        {
            if (CCD01_01_SrcImageHandle_拼接完成圖 != 0)
            {
                this.h_Canvas_Tech_CCD01_01_拼接完成圖.RefreshCanvas();
            }
            cnt++;
        }

































        #endregion
        #region PLC_CCD01_01_計算一次
        PLC_Device PLC_Device_CCD01_01_計算一次 = new PLC_Device("S5005");
        PLC_Device PLC_Device_CCD01_01_計算一次_OK = new PLC_Device("S5006");
        PLC_Device PLC_Device_CCD01_01_計算一次_READY = new PLC_Device("S5007");
        MyTimer MyTimer_CCD01_01_計算一次 = new MyTimer();
        double GetTickTime = 0;
        int cnt_Program_CCD01_01_計算一次 = 65534;
        void sub_Program_CCD01_01_計算一次()
        {
            this.PLC_Device_CCD01_01_計算一次_READY.Bool = !this.PLC_Device_CCD01_01_計算一次.Bool;
            if (cnt_Program_CCD01_01_計算一次 == 65534)
            {
                PLC_Device_CCD01_01_計算一次.SetComment("PLC_CCD01_01_計算一次");
                PLC_Device_CCD01_01_計算一次.Bool = false;

                cnt_Program_CCD01_01_計算一次 = 65535;
            }
            if (cnt_Program_CCD01_01_計算一次 == 65535) cnt_Program_CCD01_01_計算一次 = 1;
            if (cnt_Program_CCD01_01_計算一次 == 1) cnt_Program_CCD01_01_計算一次_檢查按下(ref cnt_Program_CCD01_01_計算一次);
            if (cnt_Program_CCD01_01_計算一次 == 2) cnt_Program_CCD01_01_計算一次_步驟01開始(ref cnt_Program_CCD01_01_計算一次);
            if (cnt_Program_CCD01_01_計算一次 == 3) cnt_Program_CCD01_01_計算一次_步驟01結束(ref cnt_Program_CCD01_01_計算一次);
            if (cnt_Program_CCD01_01_計算一次 == 4) cnt_Program_CCD01_01_計算一次_步驟02開始(ref cnt_Program_CCD01_01_計算一次);
            if (cnt_Program_CCD01_01_計算一次 == 5) cnt_Program_CCD01_01_計算一次_步驟02結束(ref cnt_Program_CCD01_01_計算一次);
            if (cnt_Program_CCD01_01_計算一次 == 6) cnt_Program_CCD01_01_計算一次_步驟03開始(ref cnt_Program_CCD01_01_計算一次);
            if (cnt_Program_CCD01_01_計算一次 == 7) cnt_Program_CCD01_01_計算一次_步驟03結束(ref cnt_Program_CCD01_01_計算一次);
            if (cnt_Program_CCD01_01_計算一次 == 8) cnt_Program_CCD01_01_計算一次_步驟04開始(ref cnt_Program_CCD01_01_計算一次);
            if (cnt_Program_CCD01_01_計算一次 == 9) cnt_Program_CCD01_01_計算一次_步驟04結束(ref cnt_Program_CCD01_01_計算一次);
            if (cnt_Program_CCD01_01_計算一次 == 10) cnt_Program_CCD01_01_計算一次_步驟05開始(ref cnt_Program_CCD01_01_計算一次);
            if (cnt_Program_CCD01_01_計算一次 == 11) cnt_Program_CCD01_01_計算一次_步驟05結束(ref cnt_Program_CCD01_01_計算一次);
            if (cnt_Program_CCD01_01_計算一次 == 12) cnt_Program_CCD01_01_計算一次_步驟06開始(ref cnt_Program_CCD01_01_計算一次);
            if (cnt_Program_CCD01_01_計算一次 == 13) cnt_Program_CCD01_01_計算一次_步驟06結束(ref cnt_Program_CCD01_01_計算一次);
            if (cnt_Program_CCD01_01_計算一次 == 14) cnt_Program_CCD01_01_計算一次_計算結果(ref cnt_Program_CCD01_01_計算一次);
            if (cnt_Program_CCD01_01_計算一次 == 15) cnt_Program_CCD01_01_計算一次 = 65500;
            if (cnt_Program_CCD01_01_計算一次 > 1) cnt_Program_CCD01_01_計算一次_檢查放開(ref cnt_Program_CCD01_01_計算一次);

            if (cnt_Program_CCD01_01_計算一次 == 65500)
            {
                PLC_Device_CCD01_01_計算一次.Bool = false;
                cnt_Program_CCD01_01_計算一次 = 65535;
            }
        }
        void cnt_Program_CCD01_01_計算一次_檢查按下(ref int cnt)
        {
            if (PLC_Device_CCD01_01_計算一次.Bool) cnt++;
        }
        void cnt_Program_CCD01_01_計算一次_檢查放開(ref int cnt)
        {
            if (!PLC_Device_CCD01_01_計算一次.Bool) cnt = 65500;
        }
        void cnt_Program_CCD01_01_計算一次_初始化(ref int cnt)
        {
            PLC_Device_CCD01_01_基準線量測.Bool = false;
            cnt++;
        }
        void cnt_Program_CCD01_01_計算一次_步驟01開始(ref int cnt)
        {
            this.MyTimer_CCD01_01_計算一次.TickStop();
            GetTickTime = this.MyTimer_CCD01_01_計算一次.GetTickTime();
            this.MyTimer_CCD01_01_計算一次.StartTickTime(99999);

            if (!this.PLC_Device_CCD01_01_基準線量測.Bool)
            {
                this.PLC_Device_CCD01_01_基準線量測.Bool = true;
                cnt++;
            }

        }
        void cnt_Program_CCD01_01_計算一次_步驟01結束(ref int cnt)
        {
            if (!this.PLC_Device_CCD01_01_基準線量測.Bool)
            {
                cnt++;
            }
        }
        void cnt_Program_CCD01_01_計算一次_步驟02開始(ref int cnt)
        {
            if (!this.PLC_Device_CCD01_01基準圓量測框調整.Bool)
            {
                this.PLC_Device_CCD01_01基準圓量測框調整.Bool = true;
                cnt++;
            }
        }
        void cnt_Program_CCD01_01_計算一次_步驟02結束(ref int cnt)
        {
            if (!this.PLC_Device_CCD01_01基準圓量測框調整.Bool)
            {
                cnt++;
            }
        }
        void cnt_Program_CCD01_01_計算一次_步驟03開始(ref int cnt)
        {
            cnt++;
        }
        void cnt_Program_CCD01_01_計算一次_步驟03結束(ref int cnt)
        {

                cnt++;
            
            
        }
        void cnt_Program_CCD01_01_計算一次_步驟04開始(ref int cnt)
        {
            cnt++;
        }
        void cnt_Program_CCD01_01_計算一次_步驟04結束(ref int cnt)
        {

                cnt++;
            
        }
        void cnt_Program_CCD01_01_計算一次_步驟05開始(ref int cnt)
        {
            cnt++;
        }
        void cnt_Program_CCD01_01_計算一次_步驟05結束(ref int cnt)
        {
            cnt++;
        }
        void cnt_Program_CCD01_01_計算一次_步驟06開始(ref int cnt)
        {
            cnt++;
        }
        void cnt_Program_CCD01_01_計算一次_步驟06結束(ref int cnt)
        {
            cnt++;
        }
        void cnt_Program_CCD01_01_計算一次_計算結果(ref int cnt)
        {
            bool flag = true;
            if (!this.PLC_Device_CCD01_01_基準線量測_OK.Bool) flag = false;
            this.PLC_Device_CCD01_01_計算一次_OK.Bool = flag;
            //flag_CCD01_01_上端水平度寫入列表資料 = true;
            //flag_CCD01_01_上端間距寫入列表資料 = true;
            //flag_CCD01_01_上端水平度差值寫入列表資料 = true;

            cnt++;
        }





        #endregion
        #region PLC_CCD01_01_基準線量測
        AxOvkMsr.AxLineMsr CCD01_01_水平基準線量測_AxLineMsr;
        AxOvkMsr.AxLineRegression CCD01_01_水平基準線量測_AxLineRegression;
        AxOvkMsr.AxLineMsr CCD01_01_垂直基準線量測_AxLineMsr;
        AxOvkMsr.AxLineRegression CCD01_01_垂直基準線量測_AxLineRegression;
        AxOvkMsr.AxIntersectionMsr CCD01_01_基準線量測_AxIntersectionMsr;
        private PointF Point_CCD01_01_中心基準座標_量測點 = new PointF();
        PLC_Device PLC_Device_CCD01_01_基準線量測按鈕 = new PLC_Device("S6230");
        PLC_Device PLC_Device_CCD01_01_基準線量測 = new PLC_Device("S6225");
        PLC_Device PLC_Device_CCD01_01_基準線量測_OK = new PLC_Device("S6226");
        PLC_Device PLC_Device_CCD01_01_基準線量測_測試完成 = new PLC_Device("S6227");
        PLC_Device PLC_Device_CCD01_01_基準線量測_RefreshCanvas = new PLC_Device("S6228");

        PLC_Device PLC_Device_CCD01_01_基準線量測_變化銳利度 = new PLC_Device("F18000");
        PLC_Device PLC_Device_CCD01_01_基準線量測_延伸變化強度 = new PLC_Device("F18001");
        PLC_Device PLC_Device_CCD01_01_基準線量測_灰階變化面積 = new PLC_Device("F18002");
        PLC_Device PLC_Device_CCD01_01_基準線量測_雜訊抑制 = new PLC_Device("F18003");
        PLC_Device PLC_Device_CCD01_01_基準線量測_最佳回歸線計算次數 = new PLC_Device("F18004");
        PLC_Device PLC_Device_CCD01_01_基準線量測_最佳回歸線濾波 = new PLC_Device("F18005");
        PLC_Device PLC_Device_CCD01_01_基準線量測_量測顏色變化 = new PLC_Device("F18010");
        PLC_Device PLC_Device_CCD01_01_基準線量測_基準線偏移 = new PLC_Device("F18011");

        PLC_Device PLC_Device_CCD01_01_水平基準線量測_量測框起點X座標 = new PLC_Device("F18006");
        PLC_Device PLC_Device_CCD01_01_水平基準線量測_量測框起點Y座標 = new PLC_Device("F18007");
        PLC_Device PLC_Device_CCD01_01_水平基準線量測_量測框終點X座標 = new PLC_Device("F18008");
        PLC_Device PLC_Device_CCD01_01_水平基準線量測_量測框終點Y座標 = new PLC_Device("F18009");
        PLC_Device PLC_Device_CCD01_01_水平基準線量測_量測高度 = new PLC_Device("F18012");
        PLC_Device PLC_Device_CCD01_01_水平基準線量測_量測中心_X = new PLC_Device("F18020");
        PLC_Device PLC_Device_CCD01_01_水平基準線量測_量測中心_Y = new PLC_Device("F18021");

        PLC_Device PLC_Device_CCD01_01_垂直基準線量測_量測框起點X座標 = new PLC_Device("F18013");
        PLC_Device PLC_Device_CCD01_01_垂直基準線量測_量測框起點Y座標 = new PLC_Device("F18014");
        PLC_Device PLC_Device_CCD01_01_垂直基準線量測_量測框終點X座標 = new PLC_Device("F18015");
        PLC_Device PLC_Device_CCD01_01_垂直基準線量測_量測框終點Y座標 = new PLC_Device("F18016");
        PLC_Device PLC_Device_CCD01_01_垂直基準線量測_量測高度 = new PLC_Device("F18017");




        private void H_Canvas_Tech_CCD01_01_基準線量測_OnCanvasDrawEvent(long HDC, float ZoomX, float ZoomY, int CanvasHandle)
        {
            try
            {
                PointF 水平量測中心 = new PointF(Point_CCD01_01_中心基準座標_量測點.X, Point_CCD01_01_中心基準座標_量測點.Y);

                if (PLC_Device_CCD01_01_Main_取像並檢驗.Bool || PLC_Device_CCD01_01_PLC觸發檢測.Bool)
                {
                    if (this.PLC_Device_CCD01_01_基準線量測_RefreshCanvas.Bool)
                    {
                        Graphics g = Graphics.FromHdc((IntPtr)HDC);

                        DrawingClass.Draw.水平線段繪製(0, 10000, CCD01_01_水平基準線量測_AxLineMsr.MeasuredSlope, CCD01_01_水平基準線量測_AxLineMsr.MeasuredPivotX, CCD01_01_水平基準線量測_AxLineMsr.MeasuredPivotY + this.PLC_Device_CCD01_01_基準線量測_基準線偏移.Value, Color.Lime, 2, g, ZoomX, ZoomY);
                        DrawingClass.Draw.垂直線段繪製(0, 10000, CCD01_01_垂直基準線量測_AxLineMsr.MeasuredSlope, CCD01_01_垂直基準線量測_AxLineMsr.MeasuredPivotX, CCD01_01_垂直基準線量測_AxLineMsr.MeasuredPivotY, Color.Lime, 2, g, ZoomX, ZoomY);
                        DrawingClass.Draw.十字中心(水平量測中心, 100, Color.Red, 2, g, ZoomX, ZoomY);
                        g.Dispose();
                        g = null;
                    }
                }
                else if(PLC_Device_CCD01_01_Tech_檢驗一次.Bool)
                {
                    if (this.PLC_Device_CCD01_01_基準線量測_RefreshCanvas.Bool)
                    {
                        Graphics g = Graphics.FromHdc((IntPtr)HDC);

                        DrawingClass.Draw.水平線段繪製(0, 10000, CCD01_01_水平基準線量測_AxLineMsr.MeasuredSlope, CCD01_01_水平基準線量測_AxLineMsr.MeasuredPivotX, CCD01_01_水平基準線量測_AxLineMsr.MeasuredPivotY + this.PLC_Device_CCD01_01_基準線量測_基準線偏移.Value, Color.Lime, 2, g, ZoomX, ZoomY);
                        DrawingClass.Draw.垂直線段繪製(0, 10000, CCD01_01_垂直基準線量測_AxLineMsr.MeasuredSlope, CCD01_01_垂直基準線量測_AxLineMsr.MeasuredPivotX, CCD01_01_垂直基準線量測_AxLineMsr.MeasuredPivotY, Color.Lime, 2, g, ZoomX, ZoomY);
                        DrawingClass.Draw.十字中心(水平量測中心, 100, Color.Red, 2, g, ZoomX, ZoomY);
                        if(PLC_Device_CCD01_01_基準線量測_OK.Bool)
                        {
                            DrawingClass.Draw.文字左上繪製("基準線OK!", new PointF(0, 0), new Font("標楷體", 16), Color.Black, Color.Lime, g, ZoomX, ZoomY);

                        }
                        else
                        {
                            DrawingClass.Draw.文字左上繪製("基準線NG!", new PointF(0, 0), new Font("標楷體", 16), Color.Black, Color.Red, g, ZoomX, ZoomY);
                        }
                        g.Dispose();
                        g = null;
                    }
                }

                else
                {
                    if (this.PLC_Device_CCD01_01_基準線量測_RefreshCanvas.Bool)
                    {
                        Graphics g = Graphics.FromHdc((IntPtr)HDC);


                        if (this.plC_CheckBox_CCD01_01_基準線量測_繪製量測框.Checked)
                        {
                            this.CCD01_01_水平基準線量測_AxLineMsr.Title = ("水平基準線");
                            this.CCD01_01_水平基準線量測_AxLineMsr.DrawFrame(HDC, ZoomX, ZoomY, 0, 0);
                            this.CCD01_01_垂直基準線量測_AxLineMsr.Title = ("垂直基準線");
                            this.CCD01_01_垂直基準線量測_AxLineMsr.DrawFrame(HDC, ZoomX, ZoomY, 0, 0);
                        }
                        if (this.plC_CheckBox_CCD01_01_基準線量測_繪製量測線段.Checked)
                        {
                            this.CCD01_01_水平基準線量測_AxLineMsr.DrawFittedPrimitives(HDC, ZoomX, ZoomY, 0, 0);
                            this.CCD01_01_垂直基準線量測_AxLineMsr.DrawFittedPrimitives(HDC, ZoomX, ZoomY, 0, 0);
                            //DrawingClass.Draw.水平線段繪製(0, 10000, CCD01_01_水平基準線量測_AxLineMsr.MeasuredSlope, CCD01_01_水平基準線量測_AxLineMsr.MeasuredPivotX, CCD01_01_水平基準線量測_AxLineMsr.MeasuredPivotY + this.PLC_Device_CCD01_01_基準線量測_基準線偏移.Value, Color.Yellow, 2, g, ZoomX, ZoomY);
                            //DrawingClass.Draw.垂直線段繪製(0, 10000, CCD01_01_垂直基準線量測_AxLineMsr.MeasuredSlope, CCD01_01_垂直基準線量測_AxLineMsr.MeasuredPivotX, CCD01_01_垂直基準線量測_AxLineMsr.MeasuredPivotY + this.PLC_Device_CCD01_01_基準線量測_基準線偏移.Value, Color.Yellow, 2, g, ZoomX, ZoomY);
                        }
                        if (this.plC_CheckBox_CCD01_01_基準線量測_繪製量測點.Checked)
                        {
                            this.CCD01_01_水平基準線量測_AxLineMsr.DrawPoints(HDC, ZoomX, ZoomY, 0, 0);
                            this.CCD01_01_垂直基準線量測_AxLineMsr.DrawPoints(HDC, ZoomX, ZoomY, 0, 0);
                        }
                        DrawingClass.Draw.十字中心(水平量測中心, 100, Color.Red, 2, g, ZoomX, ZoomY);


                        if (PLC_Device_CCD01_01_基準線量測_OK.Bool)
                        {
                            DrawingClass.Draw.文字左上繪製("基準線OK!", new PointF(0, 0), new Font("標楷體", 16), Color.Black, Color.Lime, g, ZoomX, ZoomY);

                        }
                        else
                        {
                            DrawingClass.Draw.文字左上繪製("基準線NG!", new PointF(0, 0), new Font("標楷體", 16), Color.Black, Color.Red, g, ZoomX, ZoomY);
                        }
                        g.Dispose();
                        g = null;
                    }
                }
                
            }
            
            catch
            {

            }

            this.PLC_Device_CCD01_01_基準線量測_RefreshCanvas.Bool = false;
        }
        private AxOvkMsr.TxAxLineMsrDragHandle CCD01_01_AxOvkMsr_水平基準線量測_TxAxLineMsrDragHandle = new AxOvkMsr.TxAxLineMsrDragHandle();
        private bool flag_CCD01_01_AxOvkMsr_水平基準線量測_MouseDown = false;
        private AxOvkMsr.TxAxLineMsrDragHandle CCD01_01_AxOvkMsr_垂直基準線量測_TxAxLineMsrDragHandle = new AxOvkMsr.TxAxLineMsrDragHandle();
        private bool flag_CCD01_01_AxOvkMsr_垂直基準線量測_MouseDown = false;

        private void H_Canvas_Tech_CCD01_01_基準線量測_OnCanvasMouseDownEvent(int x, int y, float ZoomX, float ZoomY, ref int InUsedEventNum, int InUsedCanvasHandle)
        {

            if (this.PLC_Device_CCD01_01_基準線量測.Bool)
            {
                this.CCD01_01_AxOvkMsr_水平基準線量測_TxAxLineMsrDragHandle = this.CCD01_01_水平基準線量測_AxLineMsr.HitTest(x, y, ZoomX, ZoomY, 0, 0);
                if (this.CCD01_01_AxOvkMsr_水平基準線量測_TxAxLineMsrDragHandle != AxOvkMsr.TxAxLineMsrDragHandle.AX_LINEMSR_NONE)
                {
                    this.flag_CCD01_01_AxOvkMsr_水平基準線量測_MouseDown = true;
                    InUsedEventNum = 10;
                }

                this.CCD01_01_AxOvkMsr_垂直基準線量測_TxAxLineMsrDragHandle = this.CCD01_01_垂直基準線量測_AxLineMsr.HitTest(x, y, ZoomX, ZoomY, 0, 0);
                if (this.CCD01_01_AxOvkMsr_垂直基準線量測_TxAxLineMsrDragHandle != AxOvkMsr.TxAxLineMsrDragHandle.AX_LINEMSR_NONE)
                {
                    this.flag_CCD01_01_AxOvkMsr_垂直基準線量測_MouseDown = true;
                    InUsedEventNum = 10;
                }
            }

        }
        private void H_Canvas_Tech_CCD01_01_基準線量測_OnCanvasMouseMoveEvent(int x, int y, float ZoomX, float ZoomY)
        {
            if (this.flag_CCD01_01_AxOvkMsr_水平基準線量測_MouseDown)
            {
                this.CCD01_01_水平基準線量測_AxLineMsr.DragFrame(this.CCD01_01_AxOvkMsr_水平基準線量測_TxAxLineMsrDragHandle, x, y, ZoomX, ZoomY, 0, 0);
                this.PLC_Device_CCD01_01_水平基準線量測_量測框起點X座標.Value = CCD01_01_水平基準線量測_AxLineMsr.NLineStartX;
                this.PLC_Device_CCD01_01_水平基準線量測_量測框起點Y座標.Value = CCD01_01_水平基準線量測_AxLineMsr.NLineStartY;
                this.PLC_Device_CCD01_01_水平基準線量測_量測框終點X座標.Value = CCD01_01_水平基準線量測_AxLineMsr.NLineEndX;
                this.PLC_Device_CCD01_01_水平基準線量測_量測框終點Y座標.Value = CCD01_01_水平基準線量測_AxLineMsr.NLineEndY;
                this.PLC_Device_CCD01_01_水平基準線量測_量測高度.Value = CCD01_01_水平基準線量測_AxLineMsr.HalfHeight;
            }

            if (this.flag_CCD01_01_AxOvkMsr_垂直基準線量測_MouseDown)
            {
                this.CCD01_01_垂直基準線量測_AxLineMsr.DragFrame(this.CCD01_01_AxOvkMsr_垂直基準線量測_TxAxLineMsrDragHandle, x, y, ZoomX, ZoomY, 0, 0);
                this.PLC_Device_CCD01_01_垂直基準線量測_量測框起點X座標.Value = CCD01_01_垂直基準線量測_AxLineMsr.NLineStartX;
                this.PLC_Device_CCD01_01_垂直基準線量測_量測框起點Y座標.Value = CCD01_01_垂直基準線量測_AxLineMsr.NLineStartY;
                this.PLC_Device_CCD01_01_垂直基準線量測_量測框終點X座標.Value = CCD01_01_垂直基準線量測_AxLineMsr.NLineEndX;
                this.PLC_Device_CCD01_01_垂直基準線量測_量測框終點Y座標.Value = CCD01_01_垂直基準線量測_AxLineMsr.NLineEndY;
                this.PLC_Device_CCD01_01_垂直基準線量測_量測高度.Value = CCD01_01_垂直基準線量測_AxLineMsr.HalfHeight;
            }


        }
        private void H_Canvas_Tech_CCD01_01_基準線量測_OnCanvasMouseUpEvent(int x, int y, float ZoomX, float ZoomY)
        {
            this.flag_CCD01_01_AxOvkMsr_水平基準線量測_MouseDown = false;
            this.flag_CCD01_01_AxOvkMsr_垂直基準線量測_MouseDown = false;
        }

        int cnt_Program_CCD01_01_基準線量測 = 65534;
        void sub_Program_CCD01_01_基準線量測()
        {
            if (cnt_Program_CCD01_01_基準線量測 == 65534)
            {
                this.h_Canvas_Tech_CCD01_01_拼接完成圖.OnCanvasMouseDownEvent += H_Canvas_Tech_CCD01_01_基準線量測_OnCanvasMouseDownEvent;
                this.h_Canvas_Tech_CCD01_01_拼接完成圖.OnCanvasMouseMoveEvent += H_Canvas_Tech_CCD01_01_基準線量測_OnCanvasMouseMoveEvent;
                this.h_Canvas_Tech_CCD01_01_拼接完成圖.OnCanvasMouseUpEvent += H_Canvas_Tech_CCD01_01_基準線量測_OnCanvasMouseUpEvent;
                this.h_Canvas_Tech_CCD01_01_拼接完成圖.OnCanvasDrawEvent += H_Canvas_Tech_CCD01_01_基準線量測_OnCanvasDrawEvent;

                this.h_Canvas_Main_CCD01_01_檢測畫面.OnCanvasDrawEvent += H_Canvas_Tech_CCD01_01_基準線量測_OnCanvasDrawEvent;
                PLC_Device_CCD01_01_基準線量測.SetComment("PLC_CCD01_01_基準線量測");
                PLC_Device_CCD01_01_基準線量測.Bool = false;
                cnt_Program_CCD01_01_基準線量測 = 65535;
            }
            if (cnt_Program_CCD01_01_基準線量測 == 65535) cnt_Program_CCD01_01_基準線量測 = 1;
            if (cnt_Program_CCD01_01_基準線量測 == 1) cnt_Program_CCD01_01_基準線量測_檢查按下(ref cnt_Program_CCD01_01_基準線量測);
            if (cnt_Program_CCD01_01_基準線量測 == 2) cnt_Program_CCD01_01_基準線量測_初始化(ref cnt_Program_CCD01_01_基準線量測);
            if (cnt_Program_CCD01_01_基準線量測 == 3) cnt_Program_CCD01_01_基準線量測_開始量測(ref cnt_Program_CCD01_01_基準線量測);
            if (cnt_Program_CCD01_01_基準線量測 == 4) cnt_Program_CCD01_01_基準線量測_兩線交點(ref cnt_Program_CCD01_01_基準線量測);
            if (cnt_Program_CCD01_01_基準線量測 == 5) cnt_Program_CCD01_01_基準線量測_兩線交點量測(ref cnt_Program_CCD01_01_基準線量測);
            if (cnt_Program_CCD01_01_基準線量測 == 6) cnt_Program_CCD01_01_基準線量測_開始繪製(ref cnt_Program_CCD01_01_基準線量測);
            if (cnt_Program_CCD01_01_基準線量測 == 7) cnt_Program_CCD01_01_基準線量測 = 65500;
            if (cnt_Program_CCD01_01_基準線量測 > 1) cnt_Program_CCD01_01_基準線量測_檢查放開(ref cnt_Program_CCD01_01_基準線量測);

            if (cnt_Program_CCD01_01_基準線量測 == 65500)
            {
                PLC_Device_CCD01_01_基準線量測.Bool = false;
                cnt_Program_CCD01_01_基準線量測 = 65535;
            }
        }
        void cnt_Program_CCD01_01_基準線量測_檢查按下(ref int cnt)
        {
            if (PLC_Device_CCD01_01_基準線量測.Bool) cnt++;
        }
        void cnt_Program_CCD01_01_基準線量測_檢查放開(ref int cnt)
        {
            if (!PLC_Device_CCD01_01_基準線量測.Bool) cnt = 65500;
        }
        void cnt_Program_CCD01_01_基準線量測_初始化(ref int cnt)
        {
            this.PLC_Device_CCD01_01_基準線量測_OK.Bool = false;

            this.CCD01_01_水平基準線量測_AxLineMsr.SrcImageHandle = this.CCD01_01_SrcImageHandle_拼接完成圖;
            this.CCD01_01_水平基準線量測_AxLineMsr.Hysteresis = PLC_Device_CCD01_01_基準線量測_延伸變化強度.Value;
            this.CCD01_01_水平基準線量測_AxLineMsr.DeriThreshold = PLC_Device_CCD01_01_基準線量測_變化銳利度.Value;
            this.CCD01_01_水平基準線量測_AxLineMsr.MinGreyStep = PLC_Device_CCD01_01_基準線量測_灰階變化面積.Value;
            this.CCD01_01_水平基準線量測_AxLineMsr.SmoothFactor = PLC_Device_CCD01_01_基準線量測_雜訊抑制.Value;
            this.CCD01_01_水平基準線量測_AxLineMsr.HalfProfileThickness = 5;
            this.CCD01_01_水平基準線量測_AxLineMsr.SampleStep = 1;
            this.CCD01_01_水平基準線量測_AxLineMsr.FilterCount = PLC_Device_CCD01_01_基準線量測_最佳回歸線計算次數.Value;
            this.CCD01_01_水平基準線量測_AxLineMsr.FilterThreshold = PLC_Device_CCD01_01_基準線量測_最佳回歸線濾波.Value / 10;

            if (this.PLC_Device_CCD01_01_水平基準線量測_量測框起點X座標.Value == 0 && this.PLC_Device_CCD01_01_水平基準線量測_量測框終點X座標.Value == 0)
            {
                this.PLC_Device_CCD01_01_水平基準線量測_量測框起點X座標.Value = 100;
                this.PLC_Device_CCD01_01_水平基準線量測_量測框終點X座標.Value = 100;
            }
            if (this.PLC_Device_CCD01_01_水平基準線量測_量測框起點Y座標.Value == 0 && this.PLC_Device_CCD01_01_水平基準線量測_量測框終點Y座標.Value == 0)
            {
                this.PLC_Device_CCD01_01_水平基準線量測_量測框起點Y座標.Value = 200;
                this.PLC_Device_CCD01_01_水平基準線量測_量測框終點Y座標.Value = 200;
            }
            if (this.PLC_Device_CCD01_01_水平基準線量測_量測高度.Value == 0)
            {
                this.PLC_Device_CCD01_01_水平基準線量測_量測高度.Value = 100;
            }

            this.CCD01_01_水平基準線量測_AxLineMsr.NLineStartX = PLC_Device_CCD01_01_水平基準線量測_量測框起點X座標.Value;
            this.CCD01_01_水平基準線量測_AxLineMsr.NLineStartY = PLC_Device_CCD01_01_水平基準線量測_量測框起點Y座標.Value;
            this.CCD01_01_水平基準線量測_AxLineMsr.NLineEndX = PLC_Device_CCD01_01_水平基準線量測_量測框終點X座標.Value;
            this.CCD01_01_水平基準線量測_AxLineMsr.NLineEndY = PLC_Device_CCD01_01_水平基準線量測_量測框終點Y座標.Value;
            this.CCD01_01_水平基準線量測_AxLineMsr.HalfHeight = PLC_Device_CCD01_01_水平基準線量測_量測高度.Value;

            this.CCD01_01_水平基準線量測_AxLineMsr.EdgeType = (AxOvkMsr.TxAxTransitionType)PLC_Device_CCD01_01_基準線量測_量測顏色變化.Value;
            this.CCD01_01_水平基準線量測_AxLineMsr.LockedMsrDirection = AxOvkMsr.TxAxLineMsrLockedMsrDirection.AX_LINEMSR_LOCKED_CLOCKWISE;


            this.CCD01_01_垂直基準線量測_AxLineMsr.SrcImageHandle = this.CCD01_01_SrcImageHandle_拼接完成圖;
            this.CCD01_01_垂直基準線量測_AxLineMsr.Hysteresis = PLC_Device_CCD01_01_基準線量測_延伸變化強度.Value;
            this.CCD01_01_垂直基準線量測_AxLineMsr.DeriThreshold = PLC_Device_CCD01_01_基準線量測_變化銳利度.Value;
            this.CCD01_01_垂直基準線量測_AxLineMsr.MinGreyStep = PLC_Device_CCD01_01_基準線量測_灰階變化面積.Value;
            this.CCD01_01_垂直基準線量測_AxLineMsr.SmoothFactor = PLC_Device_CCD01_01_基準線量測_雜訊抑制.Value;
            this.CCD01_01_垂直基準線量測_AxLineMsr.HalfProfileThickness = 5;
            this.CCD01_01_垂直基準線量測_AxLineMsr.SampleStep = 1;
            this.CCD01_01_垂直基準線量測_AxLineMsr.FilterCount = PLC_Device_CCD01_01_基準線量測_最佳回歸線計算次數.Value;
            this.CCD01_01_垂直基準線量測_AxLineMsr.FilterThreshold = PLC_Device_CCD01_01_基準線量測_最佳回歸線濾波.Value / 10;

            if (this.PLC_Device_CCD01_01_垂直基準線量測_量測框起點X座標.Value == 0 && this.PLC_Device_CCD01_01_垂直基準線量測_量測框終點X座標.Value == 0)
            {
                this.PLC_Device_CCD01_01_垂直基準線量測_量測框起點X座標.Value = 100;
                this.PLC_Device_CCD01_01_垂直基準線量測_量測框終點X座標.Value = 100;
            }
            if (this.PLC_Device_CCD01_01_垂直基準線量測_量測框起點Y座標.Value == 0 && this.PLC_Device_CCD01_01_垂直基準線量測_量測框終點Y座標.Value == 0)
            {
                this.PLC_Device_CCD01_01_垂直基準線量測_量測框起點Y座標.Value = 200;
                this.PLC_Device_CCD01_01_垂直基準線量測_量測框終點Y座標.Value = 200;
            }
            if (this.PLC_Device_CCD01_01_垂直基準線量測_量測高度.Value == 0)
            {
                this.PLC_Device_CCD01_01_垂直基準線量測_量測高度.Value = 100;
            }

            this.CCD01_01_垂直基準線量測_AxLineMsr.NLineStartX = PLC_Device_CCD01_01_垂直基準線量測_量測框起點X座標.Value;
            this.CCD01_01_垂直基準線量測_AxLineMsr.NLineStartY = PLC_Device_CCD01_01_垂直基準線量測_量測框起點Y座標.Value;
            this.CCD01_01_垂直基準線量測_AxLineMsr.NLineEndX = PLC_Device_CCD01_01_垂直基準線量測_量測框終點X座標.Value;
            this.CCD01_01_垂直基準線量測_AxLineMsr.NLineEndY = PLC_Device_CCD01_01_垂直基準線量測_量測框終點Y座標.Value;
            this.CCD01_01_垂直基準線量測_AxLineMsr.HalfHeight = PLC_Device_CCD01_01_垂直基準線量測_量測高度.Value;

            this.CCD01_01_垂直基準線量測_AxLineMsr.EdgeType = (AxOvkMsr.TxAxTransitionType)PLC_Device_CCD01_01_基準線量測_量測顏色變化.Value;
            this.CCD01_01_垂直基準線量測_AxLineMsr.LockedMsrDirection = AxOvkMsr.TxAxLineMsrLockedMsrDirection.AX_LINEMSR_LOCKED_CLOCKWISE;
            cnt++;

        }
        void cnt_Program_CCD01_01_基準線量測_開始量測(ref int cnt)
        {
            if (CCD01_01_SrcImageHandle_拼接完成圖 != 0)
            {
                this.CCD01_01_水平基準線量測_AxLineMsr.DetectPrimitives();
                this.CCD01_01_垂直基準線量測_AxLineMsr.DetectPrimitives();
            }

            if (this.CCD01_01_水平基準線量測_AxLineMsr.LineIsFitted && this.CCD01_01_垂直基準線量測_AxLineMsr.LineIsFitted)
            {

                PointF 水平量測點p1 = new PointF();
                PointF 水平量測點p2 = new PointF();

                CCD01_01_水平基準線量測_AxLineMsr.ValidPointIndex = 0;
                水平量測點p1.X = (int)CCD01_01_水平基準線量測_AxLineMsr.ValidPointX;
                水平量測點p1.Y = (int)CCD01_01_水平基準線量測_AxLineMsr.ValidPointY;
                CCD01_01_水平基準線量測_AxLineMsr.ValidPointIndex = CCD01_01_水平基準線量測_AxLineMsr.ValidPointCount;
                水平量測點p2.X = (int)CCD01_01_水平基準線量測_AxLineMsr.ValidPointX;
                水平量測點p2.Y = (int)CCD01_01_水平基準線量測_AxLineMsr.ValidPointY;
                //Point_CCD01_01_中心基準座標_量測點.X = (int)((水平量測點p1.X + 水平量測點p2.X) / 2);
                //Point_CCD01_01_中心基準座標_量測點.Y = (int)((水平量測點p1.Y + 水平量測點p2.Y) / 2);

                PointF 水平p1 = new PointF();
                PointF 水平p2 = new PointF();
                double 水平confB;
                double 水平Slope = this.CCD01_01_水平基準線量測_AxLineMsr.MeasuredSlope;
                double 水平PivotX = this.CCD01_01_水平基準線量測_AxLineMsr.MeasuredPivotX;
                double 水平PivotY = this.CCD01_01_水平基準線量測_AxLineMsr.MeasuredPivotY;
                水平confB = Conf0Msr(水平Slope, 水平PivotX, 水平PivotY);
                水平p1.X = 1;
                水平p1.Y = (float)FunctionMsr_Y(水平confB, 水平Slope, 水平p1.X);
                水平p2.X = 10000;
                水平p2.Y = (float)FunctionMsr_Y(水平confB, 水平Slope, 水平p2.X);
                水平p1 = new PointF((水平p1.X), (水平p1.Y));
                水平p2 = new PointF((水平p2.X), (水平p2.Y));

                this.CCD01_01_水平基準線量測_AxLineRegression.RegressionOrientation = AxOvkMsr.TxAxLineRegressionOrientation.AX_QUASI_HORIZONTAL_REGRESSION;
                this.CCD01_01_水平基準線量測_AxLineRegression.PointIndex = 0;
                this.CCD01_01_水平基準線量測_AxLineRegression.PointX = 水平p1.X;
                this.CCD01_01_水平基準線量測_AxLineRegression.PointY = 水平p1.Y + (this.PLC_Device_CCD01_01_基準線量測_基準線偏移.Value / 1000) * CCD01_比例尺_mm_To_pixcel;
                this.CCD01_01_水平基準線量測_AxLineRegression.PointIndex = 1;
                this.CCD01_01_水平基準線量測_AxLineRegression.PointX = 水平p2.X;
                this.CCD01_01_水平基準線量測_AxLineRegression.PointY = 水平p2.Y + (this.PLC_Device_CCD01_01_基準線量測_基準線偏移.Value / 1000) * CCD01_比例尺_mm_To_pixcel;
                this.CCD01_01_水平基準線量測_AxLineRegression.DetectPrimitives();

                PointF 垂直p1 = new PointF();
                PointF 垂直p2 = new PointF();
                double 垂直confB;
                double 垂直Slope = this.CCD01_01_垂直基準線量測_AxLineMsr.MeasuredSlope;
                double 垂直PivotX = this.CCD01_01_垂直基準線量測_AxLineMsr.MeasuredPivotX;
                double 垂直PivotY = this.CCD01_01_垂直基準線量測_AxLineMsr.MeasuredPivotY;
                垂直confB = Conf0Msr(垂直Slope, 垂直PivotX, 垂直PivotY);
                垂直p1.X = (float)FunctionMsr_Y(垂直confB, 垂直Slope, 垂直p1.X);
                垂直p1.Y = 1;
                垂直p2.X = (float)FunctionMsr_Y(垂直confB, 垂直Slope, 垂直p2.X);
                垂直p2.Y = 10000;
                垂直p1 = new PointF((垂直p1.X), (垂直p1.Y));
                垂直p2 = new PointF((垂直p2.X), (垂直p2.Y));

                this.CCD01_01_垂直基準線量測_AxLineRegression.RegressionOrientation = AxOvkMsr.TxAxLineRegressionOrientation.AX_QUASI_VERTICAL_REGRESSION;
                this.CCD01_01_垂直基準線量測_AxLineRegression.PointIndex = 0;
                this.CCD01_01_垂直基準線量測_AxLineRegression.PointX = 垂直p1.X;
                this.CCD01_01_垂直基準線量測_AxLineRegression.PointY = 垂直p1.Y;
                this.CCD01_01_垂直基準線量測_AxLineRegression.PointIndex = 1;
                this.CCD01_01_垂直基準線量測_AxLineRegression.PointX = 垂直p2.X;
                this.CCD01_01_垂直基準線量測_AxLineRegression.PointY = 垂直p2.Y;
                this.CCD01_01_垂直基準線量測_AxLineRegression.DetectPrimitives();

                this.PLC_Device_CCD01_01_基準線量測_OK.Bool = true;
            }

            cnt++;
        }
        void cnt_Program_CCD01_01_基準線量測_兩線交點(ref int cnt)
        {
            CCD01_01_基準線量測_AxIntersectionMsr.Line1HorzVert = AxOvkMsr.TxAxLineHorzVert.AX_LINE_QUASI_HORIZONTAL;
            CCD01_01_基準線量測_AxIntersectionMsr.Line1PivotX = CCD01_01_水平基準線量測_AxLineMsr.MeasuredPivotX;
            CCD01_01_基準線量測_AxIntersectionMsr.Line1PivotY = CCD01_01_水平基準線量測_AxLineMsr.MeasuredPivotY;
            CCD01_01_基準線量測_AxIntersectionMsr.Line1Slope = CCD01_01_水平基準線量測_AxLineMsr.MeasuredSlope;

            CCD01_01_基準線量測_AxIntersectionMsr.Line2HorzVert = AxOvkMsr.TxAxLineHorzVert.AX_LINE_QUASI_VERTICAL;
            CCD01_01_基準線量測_AxIntersectionMsr.Line2PivotX = CCD01_01_垂直基準線量測_AxLineMsr.MeasuredPivotX;
            CCD01_01_基準線量測_AxIntersectionMsr.Line2PivotY = CCD01_01_垂直基準線量測_AxLineMsr.MeasuredPivotY;
            CCD01_01_基準線量測_AxIntersectionMsr.Line2Slope = CCD01_01_垂直基準線量測_AxLineMsr.MeasuredSlope;

            CCD01_01_基準線量測_AxIntersectionMsr.FindIntersection();

            cnt++;
        }
        void cnt_Program_CCD01_01_基準線量測_兩線交點量測(ref int cnt)
        {
            Point_CCD01_01_中心基準座標_量測點.X = (float)CCD01_01_基準線量測_AxIntersectionMsr.IntersectionX;
            Point_CCD01_01_中心基準座標_量測點.Y = (float)CCD01_01_基準線量測_AxIntersectionMsr.IntersectionY;

            if (!PLC_Device_CCD01_01_計算一次.Bool)
            {
                PLC_Device_CCD01_01_水平基準線量測_量測中心_X.Value = (int)CCD01_01_基準線量測_AxIntersectionMsr.IntersectionX;
                PLC_Device_CCD01_01_水平基準線量測_量測中心_Y.Value = (int)CCD01_01_基準線量測_AxIntersectionMsr.IntersectionY;
                //PLC_Device_CCD01_01_水平基準線量測_量測中心_X.Value = 2199;
                //PLC_Device_CCD01_01_水平基準線量測_量測中心_Y.Value = 1175;
            }

            cnt++;
        }
        void cnt_Program_CCD01_01_基準線量測_開始繪製(ref int cnt)
        {

            this.PLC_Device_CCD01_01_基準線量測_RefreshCanvas.Bool = true;
            if (this.PLC_Device_CCD01_01_基準線量測按鈕.Bool && !PLC_Device_CCD01_01_計算一次.Bool)
            {
                this.h_Canvas_Tech_CCD01_01_拼接完成圖.RefreshCanvas();
            }
            cnt++;
        }




        #endregion
        #region PLC_CCD01_01基準圓量測框調整

        private List<AxOvkBase.AxROIBW8> List_CCD01_01_基準圓量測_AxCircleROIBW8_量測框調整 = new List<AxOvkBase.AxROIBW8>();
        private List<AxOvkBlob.AxObject> List_CCD01_01_基準圓量測_AxObject_區塊分析 = new List<AxOvkBlob.AxObject>();


        private AxOvkPat.AxVisionInspectionFrame CCD01_01基準圓AxVisionInspectionFrame_量測框調整;

        private PLC_Device PLC_Device_CCD01_01基準圓量測框調整按鈕 = new PLC_Device("S6370");
        private PLC_Device PLC_Device_CCD01_01基準圓量測框調整 = new PLC_Device("S6365");
        private PLC_Device PLC_Device_CCD01_01基準圓量測框調整_OK = new PLC_Device("S6366");
        private PLC_Device PLC_Device_CCD01_01基準圓量測框調整_測試完成 = new PLC_Device("S6367");
        private PLC_Device PLC_Device_CCD01_01基準圓量測框調整_RefreshCanvas = new PLC_Device("S6368");
        private List<PLC_Device> List_PLC_Device_CCD01_01_基準圓量測_灰階門檻值 = new List<PLC_Device>();
        private List<PLC_Device> List_PLC_Device_CCD01_01_基準圓量測_CenterX = new List<PLC_Device>();
        private List<PLC_Device> List_PLC_Device_CCD01_01_基準圓量測_CenterY = new List<PLC_Device>();
        private List<PLC_Device> List_PLC_Device_CCD01_01_基準圓量測_Width = new List<PLC_Device>();
        private List<PLC_Device> List_PLC_Device_CCD01_01_基準圓量測_Height = new List<PLC_Device>();
        private List<PLC_Device> List_PLC_Device_CCD01_01_基準圓量測_面積上限 = new List<PLC_Device>();
        private List<PLC_Device> List_PLC_Device_CCD01_01_基準圓量測_面積下限 = new List<PLC_Device>();

        private PLC_Device PLC_Device_CCD01_01_左基準圓量測_灰階門檻值 = new PLC_Device("F7000");
        private PLC_Device PLC_Device_CCD01_01_左基準圓量測_CenterX = new PLC_Device("F7001");
        private PLC_Device PLC_Device_CCD01_01_左基準圓量測_CenterY = new PLC_Device("F7002");
        private PLC_Device PLC_Device_CCD01_01_左基準圓量測_Width = new PLC_Device("F7003");
        private PLC_Device PLC_Device_CCD01_01_左基準圓量測_Height = new PLC_Device("F7004");

        private PLC_Device PLC_Device_CCD01_01_左基準圓量測_面積上限 = new PLC_Device("F7005");
        private PLC_Device PLC_Device_CCD01_01_左基準圓量測_面積下限 = new PLC_Device("F7006");

        private PLC_Device PLC_Device_CCD01_01_右基準圓量測_灰階門檻值 = new PLC_Device("F7010");
        private PLC_Device PLC_Device_CCD01_01_右基準圓量測_CenterX = new PLC_Device("F7011");
        private PLC_Device PLC_Device_CCD01_01_右基準圓量測_CenterY = new PLC_Device("F7012");
        private PLC_Device PLC_Device_CCD01_01_右基準圓量測_Width = new PLC_Device("F7013");
        private PLC_Device PLC_Device_CCD01_01_右基準圓量測_Height = new PLC_Device("F7014");

        private PLC_Device PLC_Device_CCD01_01_右基準圓量測_面積上限 = new PLC_Device("F7015");
        private PLC_Device PLC_Device_CCD01_01_右基準圓量測_面積下限 = new PLC_Device("F7016");


        private float[] List_CCD01_01_基準圓_CenterX = new float[2];
        private float[] List_CCD01_01_基準圓_CenterY = new float[2];
        private float[] List_CCD01_01_基準圓_Radius = new float[2];
        private PointF[] List_CCD01_01_基準圓_量測點 = new PointF[2];
        private PointF[] List_CCD01_01_基準圓_量測點_結果 = new PointF[2];
        private Point[] List_CCD01_01_基準圓_量測點_轉換後座標 = new Point[2];
        private bool[] List_CCD01_01_基準圓_量測點_有無 = new bool[2];
        private double 圓柱相距長度 = new double();



        private void H_Canvas_Tech_CCD01_01基準圓量測框調整_OnCanvasDrawEvent(long HDC, float ZoomX, float ZoomY, int CanvasHandle)
        {

            if (PLC_Device_CCD01_01_Main_取像並檢驗.Bool || PLC_Device_CCD01_01_PLC觸發檢測.Bool)
            {
                if (this.PLC_Device_CCD01_01基準圓量測框調整_RefreshCanvas.Bool)
                {
                    try
                    {
                        Graphics g = Graphics.FromHdc((IntPtr)HDC);
                        Font font = new Font("微軟正黑體", 10);
                        for (int i = 0; i < 2; i++)
                        {
                            this.List_CCD01_01_基準圓量測_AxCircleROIBW8_量測框調整[i].ShowTitle = true;
                            this.List_CCD01_01_基準圓量測_AxCircleROIBW8_量測框調整[0].Title = "左圓";
                            this.List_CCD01_01_基準圓量測_AxCircleROIBW8_量測框調整[1].Title = "右圓";
                            this.List_CCD01_01_基準圓量測_AxCircleROIBW8_量測框調整[i].DrawFrame(HDC, ZoomX, ZoomY, 0, 0, 0x0000FF);
                        }
                        for (int i = 0; i < this.List_CCD01_01_基準圓_量測點.Length; i++)
                        {
                            DrawingClass.Draw.十字中心(this.List_CCD01_01_基準圓_量測點[i], 50, Color.Lime, 2, g, ZoomX, ZoomY);
                        }
                        DrawingClass.Draw.線段繪製(List_CCD01_01_基準圓_量測點[0], List_CCD01_01_基準圓_量測點[1], Color.Lime, 1, g, ZoomX, ZoomY);
                        DrawingClass.Draw.文字中心繪製(圓柱相距長度.ToString("0.000"), new PointF((List_CCD01_01_基準圓_量測點[0].X + List_CCD01_01_基準圓_量測點[1].X) / 2, List_CCD01_01_基準圓_量測點[0].Y),
                            font, Color.Black, Color.Lime, g, ZoomX, ZoomY);

                        g.Dispose();
                        g = null;
                    }
                    catch
                    {

                    }


                }


            }
            else if (PLC_Device_CCD01_01_Tech_檢驗一次.Bool)
            {
                if (this.PLC_Device_CCD01_01基準圓量測框調整_RefreshCanvas.Bool)
                {
                    try
                    {
                        Graphics g = Graphics.FromHdc((IntPtr)HDC);
                        Font font = new Font("微軟正黑體", 10);
                        for (int i = 0; i < 2; i++)
                        {
                            this.List_CCD01_01_基準圓量測_AxCircleROIBW8_量測框調整[i].ShowTitle = true;
                            this.List_CCD01_01_基準圓量測_AxCircleROIBW8_量測框調整[0].Title = "左圓";
                            this.List_CCD01_01_基準圓量測_AxCircleROIBW8_量測框調整[1].Title = "右圓";
                            this.List_CCD01_01_基準圓量測_AxCircleROIBW8_量測框調整[i].DrawFrame(HDC, ZoomX, ZoomY, 0, 0, 0x0000FF);
                        }
                        for (int i = 0; i < this.List_CCD01_01_基準圓_量測點.Length; i++)
                        {
                            DrawingClass.Draw.十字中心(this.List_CCD01_01_基準圓_量測點[i], 50, Color.Lime, 2, g, ZoomX, ZoomY);
                        }
                        DrawingClass.Draw.線段繪製(List_CCD01_01_基準圓_量測點[0], List_CCD01_01_基準圓_量測點[1], Color.Lime, 1, g, ZoomX, ZoomY);
                        DrawingClass.Draw.文字中心繪製(圓柱相距長度.ToString("0.000"), new PointF((List_CCD01_01_基準圓_量測點[0].X + List_CCD01_01_基準圓_量測點[1].X) / 2, List_CCD01_01_基準圓_量測點[0].Y),
                            font, Color.Black, Color.Lime, g, ZoomX, ZoomY);

                        g.Dispose();
                        g = null;
                    }
                    catch
                    {

                    }


                }


            }
            else
            {
                if (this.PLC_Device_CCD01_01基準圓量測框調整_RefreshCanvas.Bool)
                {
                    try
                    {
                        Graphics g = Graphics.FromHdc((IntPtr)HDC);
                        Font font = new Font("微軟正黑體", 10);


                        if (this.plC_CheckBox_CCD01_01基準圓繪製量測框.Checked)
                        {
                            for (int i = 0; i < 2; i++)
                            {
                                this.List_CCD01_01_基準圓量測_AxCircleROIBW8_量測框調整[i].ShowTitle = true;
                                this.List_CCD01_01_基準圓量測_AxCircleROIBW8_量測框調整[0].Title = "左圓";
                                this.List_CCD01_01_基準圓量測_AxCircleROIBW8_量測框調整[1].Title = "右圓";
                                this.List_CCD01_01_基準圓量測_AxCircleROIBW8_量測框調整[i].DrawFrame(HDC, ZoomX, ZoomY, 0, 0, 0x0000FF);
                            }
                        }
                        if (this.plC_CheckBox_CCD01_01基準圓繪製量測區塊.Checked)
                        {
                            for (int i = 0; i < this.List_CCD01_01_基準圓量測_AxCircleROIBW8_量測框調整.Count; i++)
                            {
                                this.List_CCD01_01_基準圓量測_AxObject_區塊分析[i].DrawBlobs(HDC, -1, ZoomX, ZoomY, 0, 0, true, -1);
                            }

                        }
                        for (int i = 0; i < this.List_CCD01_01_基準圓_量測點.Length; i++)
                        {
                            DrawingClass.Draw.十字中心(this.List_CCD01_01_基準圓_量測點[i], 50, Color.Lime, 2, g, ZoomX, ZoomY);
                        }
                        DrawingClass.Draw.線段繪製(List_CCD01_01_基準圓_量測點[0], List_CCD01_01_基準圓_量測點[1], Color.Lime, 1, g, ZoomX, ZoomY);
                        DrawingClass.Draw.文字中心繪製(圓柱相距長度.ToString("0.000"), new PointF((List_CCD01_01_基準圓_量測點[0].X + List_CCD01_01_基準圓_量測點[1].X) / 2, List_CCD01_01_基準圓_量測點[0].Y),
                            font, Color.Black, Color.Lime, g, ZoomX, ZoomY);

                        g.Dispose();
                        g = null;
                    }
                    catch
                    {

                    }


                }
            }



            this.PLC_Device_CCD01_01基準圓量測框調整_RefreshCanvas.Bool = false;
        }

        AxOvkBase.TxAxHitHandle[] CCD01_01基準圓AxCircleROIBW8_TxAxCircleRoiHitHandle = new AxOvkBase.TxAxHitHandle[2];
        bool[] flag_CCD01_01基準圓AxCircleROIBW8_MouseDown = new bool[2];

        private void H_Canvas_Tech_CCD01_01基準圓量測框調整_OnCanvasMouseDownEvent(int x, int y, float ZoomX, float ZoomY, ref int InUsedEventNum, int InUsedCanvasHandle)
        {
            if (this.PLC_Device_CCD01_01基準圓量測框調整.Bool)
            {
                for (int i = 0; i < 2; i++)
                {
                    this.CCD01_01基準圓AxCircleROIBW8_TxAxCircleRoiHitHandle[i] = this.List_CCD01_01_基準圓量測_AxCircleROIBW8_量測框調整[i].HitTest(x, y, ZoomX, ZoomY, 0, 0);
                    if (this.CCD01_01基準圓AxCircleROIBW8_TxAxCircleRoiHitHandle[i] != AxOvkBase.TxAxHitHandle.AX_HANDLE_NONE)
                    {
                        this.flag_CCD01_01基準圓AxCircleROIBW8_MouseDown[i] = true;
                        InUsedEventNum = 10;
                    }
                    
                }


            }

        }
        private void H_Canvas_Tech_CCD01_01基準圓量測框調整_OnCanvasMouseMoveEvent(int x, int y, float ZoomX, float ZoomY)
        {
            for (int i = 0; i < 2; i++)
            {
                if (this.flag_CCD01_01基準圓AxCircleROIBW8_MouseDown[i])
                {
                    this.List_CCD01_01_基準圓量測_AxCircleROIBW8_量測框調整[i].DragROI(this.CCD01_01基準圓AxCircleROIBW8_TxAxCircleRoiHitHandle[i], x, y, ZoomX, ZoomY, 0, 0);
                    List_PLC_Device_CCD01_01_基準圓量測_CenterX[i].Value = (int)this.List_CCD01_01_基準圓量測_AxCircleROIBW8_量測框調整[i].OrgX;
                    List_PLC_Device_CCD01_01_基準圓量測_CenterY[i].Value = (int)this.List_CCD01_01_基準圓量測_AxCircleROIBW8_量測框調整[i].OrgY;
                    List_PLC_Device_CCD01_01_基準圓量測_Height[i].Value = (int)this.List_CCD01_01_基準圓量測_AxCircleROIBW8_量測框調整[i].ROIHeight;
                    List_PLC_Device_CCD01_01_基準圓量測_Width[i].Value = (int)this.List_CCD01_01_基準圓量測_AxCircleROIBW8_量測框調整[i].ROIWidth;

                }
            }

        }
        private void H_Canvas_Tech_CCD01_01基準圓量測框調整_OnCanvasMouseUpEvent(int x, int y, float ZoomX, float ZoomY)
        {
            for (int i = 0; i < 2; i++)
            {
                this.flag_CCD01_01基準圓AxCircleROIBW8_MouseDown[i] = false;
            }
        }

        int cnt_Program_CCD01_01基準圓量測框調整 = 65534;
        void sub_Program_CCD01_01基準圓量測框調整()
        {
            if (cnt_Program_CCD01_01基準圓量測框調整 == 65534)
            {
                this.h_Canvas_Tech_CCD01_01_拼接完成圖.OnCanvasDrawEvent += H_Canvas_Tech_CCD01_01基準圓量測框調整_OnCanvasDrawEvent;
                this.h_Canvas_Tech_CCD01_01_拼接完成圖.OnCanvasMouseDownEvent += H_Canvas_Tech_CCD01_01基準圓量測框調整_OnCanvasMouseDownEvent;
                this.h_Canvas_Tech_CCD01_01_拼接完成圖.OnCanvasMouseMoveEvent += H_Canvas_Tech_CCD01_01基準圓量測框調整_OnCanvasMouseMoveEvent;
                this.h_Canvas_Tech_CCD01_01_拼接完成圖.OnCanvasMouseUpEvent += H_Canvas_Tech_CCD01_01基準圓量測框調整_OnCanvasMouseUpEvent;

                this.h_Canvas_Main_CCD01_01_檢測畫面.OnCanvasDrawEvent += H_Canvas_Tech_CCD01_01基準圓量測框調整_OnCanvasDrawEvent;

                #region list add
                this.List_PLC_Device_CCD01_01_基準圓量測_灰階門檻值.Add(this.PLC_Device_CCD01_01_左基準圓量測_灰階門檻值);
                this.List_PLC_Device_CCD01_01_基準圓量測_灰階門檻值.Add(this.PLC_Device_CCD01_01_右基準圓量測_灰階門檻值);

                this.List_PLC_Device_CCD01_01_基準圓量測_CenterX.Add(this.PLC_Device_CCD01_01_左基準圓量測_CenterX);
                this.List_PLC_Device_CCD01_01_基準圓量測_CenterX.Add(this.PLC_Device_CCD01_01_右基準圓量測_CenterX);

                this.List_PLC_Device_CCD01_01_基準圓量測_CenterY.Add(this.PLC_Device_CCD01_01_左基準圓量測_CenterY);
                this.List_PLC_Device_CCD01_01_基準圓量測_CenterY.Add(this.PLC_Device_CCD01_01_右基準圓量測_CenterY);

                this.List_PLC_Device_CCD01_01_基準圓量測_Width.Add(this.PLC_Device_CCD01_01_左基準圓量測_Width);
                this.List_PLC_Device_CCD01_01_基準圓量測_Width.Add(this.PLC_Device_CCD01_01_右基準圓量測_Width);

                this.List_PLC_Device_CCD01_01_基準圓量測_Height.Add(this.PLC_Device_CCD01_01_左基準圓量測_Height);
                this.List_PLC_Device_CCD01_01_基準圓量測_Height.Add(this.PLC_Device_CCD01_01_右基準圓量測_Height);

                this.List_PLC_Device_CCD01_01_基準圓量測_面積上限.Add(this.PLC_Device_CCD01_01_左基準圓量測_面積上限);
                this.List_PLC_Device_CCD01_01_基準圓量測_面積上限.Add(this.PLC_Device_CCD01_01_右基準圓量測_面積上限);

                this.List_PLC_Device_CCD01_01_基準圓量測_面積下限.Add(this.PLC_Device_CCD01_01_左基準圓量測_面積下限);
                this.List_PLC_Device_CCD01_01_基準圓量測_面積下限.Add(this.PLC_Device_CCD01_01_右基準圓量測_面積下限);
                #endregion
                for (int i = 0; i < 2; i++)
                {
                    if (this.List_PLC_Device_CCD01_01_基準圓量測_灰階門檻值[i].Value == 0) this.List_PLC_Device_CCD01_01_基準圓量測_灰階門檻值[i].Value = 200;
                    if (this.List_PLC_Device_CCD01_01_基準圓量測_Height[i].Value == 0) this.List_PLC_Device_CCD01_01_基準圓量測_Height[i].Value = 150;
                    if (this.List_PLC_Device_CCD01_01_基準圓量測_Width[i].Value == 0) this.List_PLC_Device_CCD01_01_基準圓量測_Width[i].Value = 150;

                }
                
                PLC_Device_CCD01_01基準圓量測框調整.SetComment("PLC_CCD01_01基準圓量測框調整");
                PLC_Device_CCD01_01基準圓量測框調整.Bool = false;
                cnt_Program_CCD01_01基準圓量測框調整 = 65535;
            }
            if (cnt_Program_CCD01_01基準圓量測框調整 == 65535) cnt_Program_CCD01_01基準圓量測框調整 = 1;
            if (cnt_Program_CCD01_01基準圓量測框調整 == 1) cnt_Program_CCD01_01基準圓量測框調整_檢查按下(ref cnt_Program_CCD01_01基準圓量測框調整);
            if (cnt_Program_CCD01_01基準圓量測框調整 == 2) cnt_Program_CCD01_01基準圓量測框調整_初始化(ref cnt_Program_CCD01_01基準圓量測框調整);
            if (cnt_Program_CCD01_01基準圓量測框調整 == 3) cnt_Program_CCD01_01基準圓量測框調整_座標轉換(ref cnt_Program_CCD01_01基準圓量測框調整);
            if (cnt_Program_CCD01_01基準圓量測框調整 == 4) cnt_Program_CCD01_01基準圓量測框調整_讀取參數(ref cnt_Program_CCD01_01基準圓量測框調整);
            if (cnt_Program_CCD01_01基準圓量測框調整 == 5) cnt_Program_CCD01_01基準圓量測框調整_開始區塊分析(ref cnt_Program_CCD01_01基準圓量測框調整);
            if (cnt_Program_CCD01_01基準圓量測框調整 == 6) cnt_Program_CCD01_01基準圓量測框調整_圓柱間距量測(ref cnt_Program_CCD01_01基準圓量測框調整);
            if (cnt_Program_CCD01_01基準圓量測框調整 == 7) cnt_Program_CCD01_01基準圓量測框調整_繪製畫布(ref cnt_Program_CCD01_01基準圓量測框調整);
            if (cnt_Program_CCD01_01基準圓量測框調整 == 8) cnt_Program_CCD01_01基準圓量測框調整 = 65500;
            if (cnt_Program_CCD01_01基準圓量測框調整 > 1) cnt_Program_CCD01_01基準圓量測框調整_檢查放開(ref cnt_Program_CCD01_01基準圓量測框調整);

            if (cnt_Program_CCD01_01基準圓量測框調整 == 65500)
            {
                PLC_Device_CCD01_01基準圓量測框調整.Bool = false;
                cnt_Program_CCD01_01基準圓量測框調整 = 65535;
            }
        }
        void cnt_Program_CCD01_01基準圓量測框調整_檢查按下(ref int cnt)
        {
            if (PLC_Device_CCD01_01基準圓量測框調整.Bool) cnt++;
        }
        void cnt_Program_CCD01_01基準圓量測框調整_檢查放開(ref int cnt)
        {
            if (!PLC_Device_CCD01_01基準圓量測框調整.Bool) cnt = 65500;
        }
        void cnt_Program_CCD01_01基準圓量測框調整_初始化(ref int cnt)
        {
            this.List_CCD01_01_基準圓_量測點 = new PointF[2];
            this.List_CCD01_01_基準圓_量測點_結果 = new PointF[2];
            this.List_CCD01_01_基準圓_量測點_轉換後座標 = new Point[2];
            this.List_CCD01_01_基準圓_量測點_有無 = new bool[2];
            this.圓柱相距長度 = new double();
            cnt++;
        }
        void cnt_Program_CCD01_01基準圓量測框調整_座標轉換(ref int cnt)
        {
            if (PLC_Device_CCD01_01_計算一次.Bool)
            {
                CCD01_01基準圓AxVisionInspectionFrame_量測框調整.RefPointX = PLC_Device_CCD01_01_水平基準線量測_量測中心_X.Value;
                CCD01_01基準圓AxVisionInspectionFrame_量測框調整.RefPointY = PLC_Device_CCD01_01_水平基準線量測_量測中心_Y.Value;
                CCD01_01基準圓AxVisionInspectionFrame_量測框調整.RefAngle = 0;
                CCD01_01基準圓AxVisionInspectionFrame_量測框調整.CurrentRefPointX = Point_CCD01_01_中心基準座標_量測點.X;
                CCD01_01基準圓AxVisionInspectionFrame_量測框調整.CurrentRefPointY = Point_CCD01_01_中心基準座標_量測點.Y;
                CCD01_01基準圓AxVisionInspectionFrame_量測框調整.CurrentRefAngle = 0;
                CCD01_01基準圓AxVisionInspectionFrame_量測框調整.NumOfVisionPoints = 2;

                for (int j = 0; j < 2; j++)
                {
                    if (this.List_PLC_Device_CCD01_01_基準圓量測_CenterX[j].Value == 0) this.List_PLC_Device_CCD01_01_基準圓量測_CenterX[j].Value = 100;
                    if (this.List_PLC_Device_CCD01_01_基準圓量測_CenterY[j].Value == 0) this.List_PLC_Device_CCD01_01_基準圓量測_CenterY[j].Value = 100;
                    if (this.List_PLC_Device_CCD01_01_基準圓量測_Width[j].Value == 0) this.List_PLC_Device_CCD01_01_基準圓量測_Width[j].Value = 100;
                    if (this.List_PLC_Device_CCD01_01_基準圓量測_Height[j].Value == 0) this.List_PLC_Device_CCD01_01_基準圓量測_Height[j].Value = 100;

                    CCD01_01基準圓AxVisionInspectionFrame_量測框調整.VisionPointIndex = j;
                    CCD01_01基準圓AxVisionInspectionFrame_量測框調整.VisionPointX = this.List_PLC_Device_CCD01_01_基準圓量測_CenterX[j].Value;
                    CCD01_01基準圓AxVisionInspectionFrame_量測框調整.VisionPointY = this.List_PLC_Device_CCD01_01_基準圓量測_CenterY[j].Value;
                }
                CCD01_01基準圓AxVisionInspectionFrame_量測框調整.EstimateCurrentVisionPoints();
                for (int j = 0; j < 2; j++)
                {
                    CCD01_01基準圓AxVisionInspectionFrame_量測框調整.VisionPointIndex = j;
                    List_CCD01_01_基準圓_量測點_轉換後座標[j].X = (int)CCD01_01基準圓AxVisionInspectionFrame_量測框調整.CurrentVisionPointX;
                    List_CCD01_01_基準圓_量測點_轉換後座標[j].Y = (int)CCD01_01基準圓AxVisionInspectionFrame_量測框調整.CurrentVisionPointY;
                }
            }
            cnt++;

        }
        void cnt_Program_CCD01_01基準圓量測框調整_讀取參數(ref int cnt)
        {
            for (int i = 0; i < this.List_CCD01_01_基準圓量測_AxCircleROIBW8_量測框調整.Count; i++)
            {
                if (this.List_PLC_Device_CCD01_01_基準圓量測_CenterX[i].Value > 2596) this.List_PLC_Device_CCD01_01_基準圓量測_CenterX[i].Value = 0;
                if (this.List_PLC_Device_CCD01_01_基準圓量測_CenterY[i].Value > 1922) this.List_PLC_Device_CCD01_01_基準圓量測_CenterY[i].Value = 0;
                if (this.List_PLC_Device_CCD01_01_基準圓量測_CenterX[i].Value < 0) this.List_PLC_Device_CCD01_01_基準圓量測_CenterX[i].Value = 0;
                if (this.List_PLC_Device_CCD01_01_基準圓量測_CenterY[i].Value < 0) this.List_PLC_Device_CCD01_01_基準圓量測_CenterY[i].Value = 0;

                if (this.List_CCD01_01_基準圓_量測點_轉換後座標[i].X > 2596) this.List_CCD01_01_基準圓_量測點_轉換後座標[i].X = 0;
                if (this.List_CCD01_01_基準圓_量測點_轉換後座標[i].Y > 1922) this.List_CCD01_01_基準圓_量測點_轉換後座標[i].Y = 0;
                if (this.List_CCD01_01_基準圓_量測點_轉換後座標[i].X < 0) this.List_CCD01_01_基準圓_量測點_轉換後座標[i].X = 0;
                if (this.List_CCD01_01_基準圓_量測點_轉換後座標[i].Y < 0) this.List_CCD01_01_基準圓_量測點_轉換後座標[i].Y = 0;

                this.List_CCD01_01_基準圓量測_AxCircleROIBW8_量測框調整[i].ParentHandle = this.CCD01_01_SrcImageHandle_拼接完成圖;

                if (PLC_Device_CCD01_01_計算一次.Bool)
                {
                    this.List_CCD01_01_基準圓量測_AxCircleROIBW8_量測框調整[i].OrgX = List_CCD01_01_基準圓_量測點_轉換後座標[i].X;
                    this.List_CCD01_01_基準圓量測_AxCircleROIBW8_量測框調整[i].OrgY = List_CCD01_01_基準圓_量測點_轉換後座標[i].Y;
                    this.List_CCD01_01_基準圓量測_AxCircleROIBW8_量測框調整[i].ROIWidth = List_PLC_Device_CCD01_01_基準圓量測_Width[i].Value;
                    this.List_CCD01_01_基準圓量測_AxCircleROIBW8_量測框調整[i].ROIHeight = List_PLC_Device_CCD01_01_基準圓量測_Height[i].Value;
                }
                else
                {
                    this.List_CCD01_01_基準圓量測_AxCircleROIBW8_量測框調整[i].OrgX = List_PLC_Device_CCD01_01_基準圓量測_CenterX[i].Value;
                    this.List_CCD01_01_基準圓量測_AxCircleROIBW8_量測框調整[i].OrgY = List_PLC_Device_CCD01_01_基準圓量測_CenterY[i].Value;
                    this.List_CCD01_01_基準圓量測_AxCircleROIBW8_量測框調整[i].ROIWidth = List_PLC_Device_CCD01_01_基準圓量測_Width[i].Value;
                    this.List_CCD01_01_基準圓量測_AxCircleROIBW8_量測框調整[i].ROIHeight = List_PLC_Device_CCD01_01_基準圓量測_Height[i].Value;

                }

                
            }
            cnt++;
        }
        void cnt_Program_CCD01_01基準圓量測框調整_開始區塊分析(ref int cnt)
        {
                uint object_value = 4294963615;

                for (int i = 0; i < 2; i++)
                {

                    this.List_CCD01_01_基準圓量測_AxObject_區塊分析[i].SrcImageHandle = this.List_CCD01_01_基準圓量測_AxCircleROIBW8_量測框調整[i].VegaHandle;
                    this.List_CCD01_01_基準圓量測_AxObject_區塊分析[i].ObjectClass = AxOvkBlob.TxAxObjClass.AX_OBJECT_DETECT_LIGHTER_CLASS;
                    this.List_CCD01_01_基準圓量測_AxObject_區塊分析[i].HighThreshold = List_PLC_Device_CCD01_01_基準圓量測_灰階門檻值[i].Value;
                    if (this.CCD01_01_SrcImageHandle_拼接完成圖 != 0)
                    {

                        this.List_CCD01_01_基準圓量測_AxObject_區塊分析[i].BlobAnalyze(false);

                    }
                    this.List_CCD01_01_基準圓量測_AxObject_區塊分析[i].CalculateFeatures((int)object_value, -1);
                    this.List_CCD01_01_基準圓量測_AxObject_區塊分析[i].SortObjects(AxOvkBlob.TxAxObjFeatureSortOrder.AX_OBJECT_SORT_ORDER_LARGE_TO_SMALL, AxOvkBlob.TxAxObjFeature.AX_OBJECT_FEATURE_AREA, 0, -1);
                    this.List_CCD01_01_基準圓量測_AxObject_區塊分析[i].SelectObjects(AxOvkBlob.TxAxObjFeature.AX_OBJECT_FEATURE_AREA, AxOvkBlob.TxAxObjFeatureOperation.AX_OBJECT_REMOVE_LESS_THAN, this.List_PLC_Device_CCD01_01_基準圓量測_面積下限[i].Value);
                    this.List_CCD01_01_基準圓量測_AxObject_區塊分析[i].SelectObjects(AxOvkBlob.TxAxObjFeature.AX_OBJECT_FEATURE_AREA, AxOvkBlob.TxAxObjFeatureOperation.AX_OBJECT_REMOVE_GREAT_THAN, this.List_PLC_Device_CCD01_01_基準圓量測_面積上限[i].Value);
                    if (this.List_CCD01_01_基準圓量測_AxObject_區塊分析[i].DetectedNumObjs > 0)
                    {
                        this.List_CCD01_01_基準圓_量測點_有無[i] = true;
                        this.List_CCD01_01_基準圓量測_AxObject_區塊分析[i].BlobIndex = 0;
                        this.List_CCD01_01_基準圓_量測點[i].X = (float)this.List_CCD01_01_基準圓量測_AxObject_區塊分析[i].BlobCentroidX;
                        this.List_CCD01_01_基準圓_量測點[i].X += this.List_CCD01_01_基準圓量測_AxCircleROIBW8_量測框調整[i].OrgX;
                        this.List_CCD01_01_基準圓_量測點[i].Y = (float)this.List_CCD01_01_基準圓量測_AxObject_區塊分析[i].BlobCentroidY;
                        //this.List_CCD01_01_基準圓量測_量測點[i].Y = (float)this.List_CCD01_01基準圓AxObject_區塊分析[i].BlobCentroidY - (float)this.List_CCD01_01基準圓AxObject_區塊分析[i].BlobLimBoxHeight / 2;
                        this.List_CCD01_01_基準圓_量測點[i].Y += this.List_CCD01_01_基準圓量測_AxCircleROIBW8_量測框調整[i].OrgY;
                    }


                }

                cnt++;
        }
        void cnt_Program_CCD01_01基準圓量測框調整_圓柱間距量測(ref int cnt)
        {
            double x = this.List_CCD01_01_基準圓_量測點[1].X - this.List_CCD01_01_基準圓_量測點[0].X;
            double y = this.List_CCD01_01_基準圓_量測點[1].Y - this.List_CCD01_01_基準圓_量測點[0].Y;
            double temp1 = Math.Pow(x, 2);
            double temp2 = Math.Pow(y, 2);
            double reslut = temp1 + temp2;

            圓柱相距長度 = Math.Sqrt(reslut) * CCD01_比例尺_pixcel_To_mm;



            cnt++;
        }
        void cnt_Program_CCD01_01基準圓量測框調整_繪製畫布(ref int cnt)
        {
            this.PLC_Device_CCD01_01基準圓量測框調整_RefreshCanvas.Bool = true;
            if (this.PLC_Device_CCD01_01基準圓量測框調整按鈕.Bool && !PLC_Device_CCD01_01_計算一次.Bool)
            {
                this.h_Canvas_Tech_CCD01_01_拼接完成圖.RefreshCanvas();
            }

            cnt++;
        }





        #endregion

        //#region PLC_CCD01_01_基準圓量測
        //AxOvkMsr.AxCircleMsr CCD01_01_左基準圓量測_AxCircleMsr;
        //AxOvkMsr.AxCircleMsr CCD01_01_右基準圓量測_AxCircleMsr;

        //AxOvkMsr.AxLineRegression CCD01_01_基準線量測_AxLineRegression;


        //private PointF Point_CCD01_01_中心基準圓心座標_量測點 = new PointF();
        //private PointF Point_CCD01_01_左基準圓心座標_量測點 = new PointF();
        //private PointF Point_CCD01_01_右基準圓心座標_量測點 = new PointF();
        //PLC_Device PLC_Device_CCD01_01_基準圓量測按鈕 = new PLC_Device("S6350");
        //PLC_Device PLC_Device_CCD01_01_基準圓量測 = new PLC_Device("S6345");
        //PLC_Device PLC_Device_CCD01_01_基準圓量測_OK = new PLC_Device("S6346");
        //PLC_Device PLC_Device_CCD01_01_基準圓量測_測試完成 = new PLC_Device("S6347");
        //PLC_Device PLC_Device_CCD01_01_基準圓量測_RefreshCanvas = new PLC_Device("S6348");

        //PLC_Device PLC_Device_CCD01_01_基準圓量測_變化銳利度 = new PLC_Device("F18300");
        //PLC_Device PLC_Device_CCD01_01_基準圓量測_延伸變化強度 = new PLC_Device("F18301");
        //PLC_Device PLC_Device_CCD01_01_基準圓量測_灰階變化面積 = new PLC_Device("F18302");
        //PLC_Device PLC_Device_CCD01_01_基準圓量測_雜訊抑制 = new PLC_Device("F18303");
        //PLC_Device PLC_Device_CCD01_01_基準圓量測_最佳回歸線計算次數 = new PLC_Device("F18304");
        //PLC_Device PLC_Device_CCD01_01_基準圓量測_最佳回歸線濾波 = new PLC_Device("F18305");
        //PLC_Device PLC_Device_CCD01_01_基準圓量測_量測顏色變化 = new PLC_Device("F18306");
        //PLC_Device PLC_Device_CCD01_01_基準圓量測_基準圓偏移 = new PLC_Device("F18307");


        //PLC_Device PLC_Device_CCD01_01_左基準圓量測_量測圓心座標X = new PLC_Device("F18308");
        //PLC_Device PLC_Device_CCD01_01_左基準圓量測_量測圓心座標Y = new PLC_Device("F18309");
        //PLC_Device PLC_Device_CCD01_01_左基準圓量測_量測框架內圓半徑 = new PLC_Device("F18310");
        //PLC_Device PLC_Device_CCD01_01_左基準圓量測_量測框架外圓半徑 = new PLC_Device("F18311");
        //PLC_Device PLC_Device_CCD01_01_右基準圓量測_量測圓心座標X = new PLC_Device("F18312");
        //PLC_Device PLC_Device_CCD01_01_右基準圓量測_量測圓心座標Y = new PLC_Device("F18313");
        //PLC_Device PLC_Device_CCD01_01_右基準圓量測_量測框架內圓半徑 = new PLC_Device("F18314");
        //PLC_Device PLC_Device_CCD01_01_右基準圓量測_量測框架外圓半徑 = new PLC_Device("F18315");
        //PLC_Device PLC_Device_CCD01_01_基準圓量測_中心圓座標X = new PLC_Device("F18316");
        //PLC_Device PLC_Device_CCD01_01_基準圓量測_中心圓座標Y = new PLC_Device("F18317");
        //PLC_Device PLC_Device_CCD01_01_基準圓量測_中心圓角度 = new PLC_Device("F18318");




        //private void H_Canvas_Tech_CCD01_01_基準圓量測_OnCanvasDrawEvent(long HDC, float ZoomX, float ZoomY, int CanvasHandle)
        //{
        //    try
        //    {
        //        PointF 左圓 = new PointF();
        //        左圓.X = PLC_Device_CCD01_01_左基準圓量測_量測圓心座標X.Value;
        //        左圓.Y = PLC_Device_CCD01_01_左基準圓量測_量測圓心座標Y.Value - PLC_Device_CCD01_01_基準線量測_基準線偏移.Value;
        //        PointF 右圓 = new PointF();
        //        右圓.X = PLC_Device_CCD01_01_右基準圓量測_量測圓心座標X.Value;
        //        右圓.Y = PLC_Device_CCD01_01_右基準圓量測_量測圓心座標Y.Value - PLC_Device_CCD01_01_基準線量測_基準線偏移.Value;
        //        PointF 中心圓 = new PointF();
        //        中心圓.X = Point_CCD01_01_中心基準圓心座標_量測點.X;
        //        中心圓.Y = Point_CCD01_01_中心基準圓心座標_量測點.Y - PLC_Device_CCD01_01_基準線量測_基準線偏移.Value;


        //         if (PLC_Device_CCD01_01_Tech_檢驗一次.Bool)
        //        {
        //            Graphics g = Graphics.FromHdc((IntPtr)HDC);
        //            DrawingClass.Draw.十字中心(new PointF(中心圓.X, 中心圓.Y), 100, Color.Red, 2, g, ZoomX, ZoomY);
        //            g.Dispose();
        //            g = null;
        //        }
        //        else
        //        {
        //            if (this.PLC_Device_CCD01_01_基準圓量測_RefreshCanvas.Bool)
        //            {
        //                Graphics g = Graphics.FromHdc((IntPtr)HDC);
        //                if (this.plC_CheckBox_CCD01_01_基準圓量測_繪製量測框.Checked)
        //                {
        //                    this.CCD01_01_左基準圓量測_AxCircleMsr.Title = ("左基準圓");
        //                    this.CCD01_01_左基準圓量測_AxCircleMsr.DrawFrame(HDC, ZoomX, ZoomY, 0, 0);

        //                    this.CCD01_01_右基準圓量測_AxCircleMsr.Title = ("右基準圓");
        //                    this.CCD01_01_右基準圓量測_AxCircleMsr.DrawFrame(HDC, ZoomX, ZoomY, 0, 0);
        //                }
        //                if (this.plC_CheckBox_CCD01_01_基準圓量測_繪製量測線段.Checked)
        //                {
        //                    this.CCD01_01_左基準圓量測_AxCircleMsr.DrawFittedPrimitives(HDC, ZoomX, ZoomY, 0, 0);
        //                    this.CCD01_01_右基準圓量測_AxCircleMsr.DrawFittedPrimitives(HDC, ZoomX, ZoomY, 0, 0);
        //                }
        //                if (this.plC_CheckBox_CCD01_01_基準圓量測_繪製量測點.Checked)
        //                {
        //                    this.CCD01_01_左基準圓量測_AxCircleMsr.DrawPoints(HDC, ZoomX, ZoomY, 0, 0);
        //                    this.CCD01_01_右基準圓量測_AxCircleMsr.DrawPoints(HDC, ZoomX, ZoomY, 0, 0);
        //                }
        //                this.CCD01_01_左基準圓量測_AxCircleMsr.DrawFittedCenter(HDC, ZoomX, ZoomY, 0, 0, 0X0000FF);
        //                DrawingClass.Draw.十字中心(new PointF(CCD01_01_左基準圓量測_AxCircleMsr.CenterX, CCD01_01_左基準圓量測_AxCircleMsr.CenterY), 20, Color.Red, 2, g, ZoomX, ZoomY);

        //                this.CCD01_01_右基準圓量測_AxCircleMsr.DrawFittedCenter(HDC, ZoomX, ZoomY, 0, 0, 0X0000FF);
        //                DrawingClass.Draw.十字中心(new PointF(CCD01_01_右基準圓量測_AxCircleMsr.CenterX, CCD01_01_右基準圓量測_AxCircleMsr.CenterY), 20, Color.Red, 2, g, ZoomX, ZoomY);

        //                this.CCD01_01_基準線量測_AxLineRegression.DrawFittedPrimitives(HDC, ZoomX, ZoomY, 0, 0, 0X00FF00);
        //                DrawingClass.Draw.線段繪製(左圓, 右圓, Color.Lime, 3, g, ZoomX, ZoomY);
        //                // DrawingClass.Draw.水平線段繪製(0,10000,0,左圓.X, 左圓.Y, Color.Red, 3, g, ZoomX, ZoomY);
        //                DrawingClass.Draw.十字中心(new PointF(中心圓.X, 中心圓.Y), 100, Color.Red, 2, g, ZoomX, ZoomY);
        //                g.Dispose();
        //                g = null;
        //            }
        //        }
        //    }
        //    catch
        //    {

        //    }

        //    this.PLC_Device_CCD01_01_基準圓量測_RefreshCanvas.Bool = false;
        //}

        //private AxOvkMsr.TxAxCircleMsrDragHandle CCD01_01_AxOvkMsr_左基準圓量測_TxAxCircleMsrDragHandle = new AxOvkMsr.TxAxCircleMsrDragHandle();
        //private bool flag_CCD01_01_AxOvkMsr_左基準圓量測_MouseDown = false;
        //private AxOvkMsr.TxAxCircleMsrDragHandle CCD01_01_AxOvkMsr_右基準圓量測_TxAxCircleMsrDragHandle = new AxOvkMsr.TxAxCircleMsrDragHandle();
        //private bool flag_CCD01_01_AxOvkMsr_右基準圓量測_MouseDown = false;

        //private void H_Canvas_Tech_CCD01_01_基準圓量測_OnCanvasMouseDownEvent(int x, int y, float ZoomX, float ZoomY, ref int InUsedEventNum, int InUsedCanvasHandle)
        //{
        //    if (this.PLC_Device_CCD01_01_基準圓量測.Bool)
        //    {
        //        this.CCD01_01_AxOvkMsr_左基準圓量測_TxAxCircleMsrDragHandle = this.CCD01_01_左基準圓量測_AxCircleMsr.HitTest(x, y, ZoomX, ZoomY, 0, 0);
        //        if (this.CCD01_01_AxOvkMsr_左基準圓量測_TxAxCircleMsrDragHandle != AxOvkMsr.TxAxCircleMsrDragHandle.AX_CIRCLEMSR_NONE)
        //        {
        //            this.flag_CCD01_01_AxOvkMsr_左基準圓量測_MouseDown = true;
        //            InUsedEventNum = 10;
        //        }

        //        this.CCD01_01_AxOvkMsr_右基準圓量測_TxAxCircleMsrDragHandle = this.CCD01_01_右基準圓量測_AxCircleMsr.HitTest(x, y, ZoomX, ZoomY, 0, 0);
        //        if (this.CCD01_01_AxOvkMsr_右基準圓量測_TxAxCircleMsrDragHandle != AxOvkMsr.TxAxCircleMsrDragHandle.AX_CIRCLEMSR_NONE)
        //        {
        //            this.flag_CCD01_01_AxOvkMsr_右基準圓量測_MouseDown = true;
        //            InUsedEventNum = 10;
        //        }
        //    }

        //}
        //private void H_Canvas_Tech_CCD01_01_基準圓量測_OnCanvasMouseMoveEvent(int x, int y, float ZoomX, float ZoomY)
        //{
        //    if (this.flag_CCD01_01_AxOvkMsr_左基準圓量測_MouseDown)
        //    {
        //        this.CCD01_01_左基準圓量測_AxCircleMsr.DragFrame(this.CCD01_01_AxOvkMsr_左基準圓量測_TxAxCircleMsrDragHandle, x, y, ZoomX, ZoomY, 0, 0);
        //        this.PLC_Device_CCD01_01_左基準圓量測_量測圓心座標X.Value = CCD01_01_左基準圓量測_AxCircleMsr.CenterX;
        //        this.PLC_Device_CCD01_01_左基準圓量測_量測圓心座標Y.Value = CCD01_01_左基準圓量測_AxCircleMsr.CenterY;
        //        this.PLC_Device_CCD01_01_左基準圓量測_量測框架內圓半徑.Value = CCD01_01_左基準圓量測_AxCircleMsr.InnerRadius;
        //        this.PLC_Device_CCD01_01_左基準圓量測_量測框架外圓半徑.Value = CCD01_01_左基準圓量測_AxCircleMsr.OuterRadius;
        //    }
        //    if (this.flag_CCD01_01_AxOvkMsr_右基準圓量測_MouseDown)
        //    {
        //        this.CCD01_01_右基準圓量測_AxCircleMsr.DragFrame(this.CCD01_01_AxOvkMsr_右基準圓量測_TxAxCircleMsrDragHandle, x, y, ZoomX, ZoomY, 0, 0);
        //        this.PLC_Device_CCD01_01_右基準圓量測_量測圓心座標X.Value = CCD01_01_右基準圓量測_AxCircleMsr.CenterX;
        //        this.PLC_Device_CCD01_01_右基準圓量測_量測圓心座標Y.Value = CCD01_01_右基準圓量測_AxCircleMsr.CenterY;
        //        this.PLC_Device_CCD01_01_右基準圓量測_量測框架內圓半徑.Value = CCD01_01_右基準圓量測_AxCircleMsr.InnerRadius;
        //        this.PLC_Device_CCD01_01_右基準圓量測_量測框架外圓半徑.Value = CCD01_01_右基準圓量測_AxCircleMsr.OuterRadius;
        //    }

        //}
        //private void H_Canvas_Tech_CCD01_01_基準圓量測_OnCanvasMouseUpEvent(int x, int y, float ZoomX, float ZoomY)
        //{
        //    this.flag_CCD01_01_AxOvkMsr_左基準圓量測_MouseDown = false;
        //    this.flag_CCD01_01_AxOvkMsr_右基準圓量測_MouseDown = false;
        //}

        //int cnt_Program_CCD01_01_基準圓量測 = 65534;
        //void sub_Program_CCD01_01_基準圓量測()
        //{
        //    if (cnt_Program_CCD01_01_基準圓量測 == 65534)
        //    {

        //        this.h_Canvas_Tech_CCD01_01_拼接完成圖.OnCanvasMouseDownEvent += H_Canvas_Tech_CCD01_01_基準圓量測_OnCanvasMouseDownEvent;
        //        this.h_Canvas_Tech_CCD01_01_拼接完成圖.OnCanvasMouseMoveEvent += H_Canvas_Tech_CCD01_01_基準圓量測_OnCanvasMouseMoveEvent;
        //        this.h_Canvas_Tech_CCD01_01_拼接完成圖.OnCanvasMouseUpEvent += H_Canvas_Tech_CCD01_01_基準圓量測_OnCanvasMouseUpEvent;
        //        this.h_Canvas_Tech_CCD01_01_拼接完成圖.OnCanvasDrawEvent += H_Canvas_Tech_CCD01_01_基準圓量測_OnCanvasDrawEvent;

        //        PLC_Device_CCD01_01_基準圓量測.SetComment("PLC_CCD01_01_基準圓量測");
        //        PLC_Device_CCD01_01_基準圓量測.Bool = false;
        //        cnt_Program_CCD01_01_基準圓量測 = 65535;
        //    }
        //    if (cnt_Program_CCD01_01_基準圓量測 == 65535) cnt_Program_CCD01_01_基準圓量測 = 1;
        //    if (cnt_Program_CCD01_01_基準圓量測 == 1) cnt_Program_CCD01_01_基準圓量測_檢查按下(ref cnt_Program_CCD01_01_基準圓量測);
        //    if (cnt_Program_CCD01_01_基準圓量測 == 2) cnt_Program_CCD01_01_基準圓量測_初始化(ref cnt_Program_CCD01_01_基準圓量測);
        //    if (cnt_Program_CCD01_01_基準圓量測 == 3) cnt_Program_CCD01_01_基準圓量測_基準圓開始量測(ref cnt_Program_CCD01_01_基準圓量測);
        //    if (cnt_Program_CCD01_01_基準圓量測 == 4) cnt_Program_CCD01_01_基準圓量測_兩圓心成一直線(ref cnt_Program_CCD01_01_基準圓量測);
        //    if (cnt_Program_CCD01_01_基準圓量測 == 5) cnt_Program_CCD01_01_基準圓量測_直線開始量測(ref cnt_Program_CCD01_01_基準圓量測);
        //    if (cnt_Program_CCD01_01_基準圓量測 == 6) cnt_Program_CCD01_01_基準圓量測_求兩點中心(ref cnt_Program_CCD01_01_基準圓量測);
        //    if (cnt_Program_CCD01_01_基準圓量測 == 7) cnt_Program_CCD01_01_基準圓量測_開始繪製(ref cnt_Program_CCD01_01_基準圓量測);
        //    if (cnt_Program_CCD01_01_基準圓量測 == 8) cnt_Program_CCD01_01_基準圓量測 = 65500;
        //    if (cnt_Program_CCD01_01_基準圓量測 > 1) cnt_Program_CCD01_01_基準圓量測_檢查放開(ref cnt_Program_CCD01_01_基準圓量測);

        //    if (cnt_Program_CCD01_01_基準圓量測 == 65500)
        //    {
        //        PLC_Device_CCD01_01_基準圓量測.Bool = false;
        //        cnt_Program_CCD01_01_基準圓量測 = 65535;
        //    }
        //}
        //void cnt_Program_CCD01_01_基準圓量測_檢查按下(ref int cnt)
        //{
        //    if (PLC_Device_CCD01_01_基準圓量測.Bool) cnt++;
        //}
        //void cnt_Program_CCD01_01_基準圓量測_檢查放開(ref int cnt)
        //{
        //    if (!PLC_Device_CCD01_01_基準圓量測.Bool) cnt = 65500;
        //}
        //void cnt_Program_CCD01_01_基準圓量測_初始化(ref int cnt)
        //{
        //    this.PLC_Device_CCD01_01_基準圓量測_OK.Bool = true;
        //    this.CCD01_01_左基準圓量測_AxCircleMsr.SrcImageHandle = this.CCD01_01_SrcImageHandle_拼接完成圖;
        //    this.CCD01_01_左基準圓量測_AxCircleMsr.Hysteresis = PLC_Device_CCD01_01_基準圓量測_延伸變化強度.Value;
        //    this.CCD01_01_左基準圓量測_AxCircleMsr.DeriThreshold = PLC_Device_CCD01_01_基準圓量測_變化銳利度.Value;
        //    this.CCD01_01_左基準圓量測_AxCircleMsr.MinGreyStep = PLC_Device_CCD01_01_基準圓量測_灰階變化面積.Value;
        //    this.CCD01_01_左基準圓量測_AxCircleMsr.SmoothFactor = PLC_Device_CCD01_01_基準圓量測_雜訊抑制.Value;
        //    this.CCD01_01_左基準圓量測_AxCircleMsr.HalfProfileThickness = 5;
        //    this.CCD01_01_左基準圓量測_AxCircleMsr.SampleStep = 1;
        //    this.CCD01_01_左基準圓量測_AxCircleMsr.FilterCount = PLC_Device_CCD01_01_基準圓量測_最佳回歸線計算次數.Value;
        //    this.CCD01_01_左基準圓量測_AxCircleMsr.FilterThreshold = PLC_Device_CCD01_01_基準圓量測_最佳回歸線濾波.Value / 10;
        //    this.CCD01_01_左基準圓量測_AxCircleMsr.InnerRadius = PLC_Device_CCD01_01_左基準圓量測_量測框架內圓半徑.Value;
        //    this.CCD01_01_左基準圓量測_AxCircleMsr.OuterRadius = PLC_Device_CCD01_01_左基準圓量測_量測框架外圓半徑.Value;
        //    this.CCD01_01_左基準圓量測_AxCircleMsr.StartAngle = 0;
        //    this.CCD01_01_左基準圓量測_AxCircleMsr.SweepAngle = 360;

        //    if (this.PLC_Device_CCD01_01_左基準圓量測_量測圓心座標X.Value <= 0 || this.PLC_Device_CCD01_01_左基準圓量測_量測圓心座標X.Value >= 2500)
        //    {
        //        this.PLC_Device_CCD01_01_左基準圓量測_量測圓心座標X.Value = 100;
        //    }
        //    if (this.PLC_Device_CCD01_01_左基準圓量測_量測圓心座標Y.Value <= 0 || this.PLC_Device_CCD01_01_左基準圓量測_量測圓心座標Y.Value >= 1900)
        //    {
        //        this.PLC_Device_CCD01_01_左基準圓量測_量測圓心座標Y.Value = 200;
        //    }
        //    if (this.PLC_Device_CCD01_01_左基準圓量測_量測框架內圓半徑.Value <= 0)
        //    {
        //        this.PLC_Device_CCD01_01_左基準圓量測_量測框架內圓半徑.Value = 100;
        //    }
        //    if (this.PLC_Device_CCD01_01_左基準圓量測_量測框架外圓半徑.Value <= 0)
        //    {
        //        this.PLC_Device_CCD01_01_左基準圓量測_量測框架外圓半徑.Value = 200;
        //    }

        //    this.CCD01_01_左基準圓量測_AxCircleMsr.CenterX = PLC_Device_CCD01_01_左基準圓量測_量測圓心座標X.Value;
        //    this.CCD01_01_左基準圓量測_AxCircleMsr.CenterY = PLC_Device_CCD01_01_左基準圓量測_量測圓心座標Y.Value;

        //    this.CCD01_01_左基準圓量測_AxCircleMsr.EdgeType = (AxOvkMsr.TxAxTransitionType)PLC_Device_CCD01_01_基準圓量測_量測顏色變化.Value;

        //    this.CCD01_01_右基準圓量測_AxCircleMsr.SrcImageHandle = this.CCD01_01_SrcImageHandle_拼接完成圖;
        //    this.CCD01_01_右基準圓量測_AxCircleMsr.Hysteresis = PLC_Device_CCD01_01_基準圓量測_延伸變化強度.Value;
        //    this.CCD01_01_右基準圓量測_AxCircleMsr.DeriThreshold = PLC_Device_CCD01_01_基準圓量測_變化銳利度.Value;
        //    this.CCD01_01_右基準圓量測_AxCircleMsr.MinGreyStep = PLC_Device_CCD01_01_基準圓量測_灰階變化面積.Value;
        //    this.CCD01_01_右基準圓量測_AxCircleMsr.SmoothFactor = PLC_Device_CCD01_01_基準圓量測_雜訊抑制.Value;
        //    this.CCD01_01_右基準圓量測_AxCircleMsr.HalfProfileThickness = 5;
        //    this.CCD01_01_右基準圓量測_AxCircleMsr.SampleStep = 1;
        //    this.CCD01_01_右基準圓量測_AxCircleMsr.FilterCount = PLC_Device_CCD01_01_基準圓量測_最佳回歸線計算次數.Value;
        //    this.CCD01_01_右基準圓量測_AxCircleMsr.FilterThreshold = PLC_Device_CCD01_01_基準圓量測_最佳回歸線濾波.Value / 10;
        //    this.CCD01_01_右基準圓量測_AxCircleMsr.InnerRadius = PLC_Device_CCD01_01_右基準圓量測_量測框架內圓半徑.Value;
        //    this.CCD01_01_右基準圓量測_AxCircleMsr.OuterRadius = PLC_Device_CCD01_01_右基準圓量測_量測框架外圓半徑.Value;
        //    this.CCD01_01_右基準圓量測_AxCircleMsr.StartAngle = 0;
        //    this.CCD01_01_右基準圓量測_AxCircleMsr.SweepAngle = 360;

        //    if (this.PLC_Device_CCD01_01_右基準圓量測_量測圓心座標X.Value <= 0 || this.PLC_Device_CCD01_01_右基準圓量測_量測圓心座標X.Value >= 2500)
        //    {
        //        this.PLC_Device_CCD01_01_右基準圓量測_量測圓心座標X.Value = 100;
        //    }
        //    if (this.PLC_Device_CCD01_01_右基準圓量測_量測圓心座標Y.Value <= 0 || this.PLC_Device_CCD01_01_右基準圓量測_量測圓心座標Y.Value >= 1900)
        //    {
        //        this.PLC_Device_CCD01_01_右基準圓量測_量測圓心座標Y.Value = 200;
        //    }
        //    if (this.PLC_Device_CCD01_01_右基準圓量測_量測框架內圓半徑.Value <= 0)
        //    {
        //        this.PLC_Device_CCD01_01_右基準圓量測_量測框架內圓半徑.Value = 100;
        //    }
        //    if (this.PLC_Device_CCD01_01_右基準圓量測_量測框架外圓半徑.Value <= 0)
        //    {
        //        this.PLC_Device_CCD01_01_右基準圓量測_量測框架外圓半徑.Value = 200;
        //    }

        //    this.CCD01_01_右基準圓量測_AxCircleMsr.CenterX = PLC_Device_CCD01_01_右基準圓量測_量測圓心座標X.Value;
        //    this.CCD01_01_右基準圓量測_AxCircleMsr.CenterY = PLC_Device_CCD01_01_右基準圓量測_量測圓心座標Y.Value;

        //    this.CCD01_01_右基準圓量測_AxCircleMsr.EdgeType = (AxOvkMsr.TxAxTransitionType)PLC_Device_CCD01_01_基準圓量測_量測顏色變化.Value;
        //    PLC_Device_CCD01_01_基準圓量測_中心圓角度.Value = 0;
        //    cnt++;
        //}
        //void cnt_Program_CCD01_01_基準圓量測_基準圓開始量測(ref int cnt)
        //{
        //    if (CCD01_01_SrcImageHandle_拼接完成圖 != 0)
        //    {
        //        this.CCD01_01_左基準圓量測_AxCircleMsr.DetectPrimitives();
        //        this.CCD01_01_右基準圓量測_AxCircleMsr.DetectPrimitives();
        //    }

        //    cnt++;
        //}
        //void cnt_Program_CCD01_01_基準圓量測_兩圓心成一直線(ref int cnt)
        //{
        //    if (!CCD01_01_左基準圓量測_AxCircleMsr.CircleIsFitted || !CCD01_01_右基準圓量測_AxCircleMsr.CircleIsFitted)
        //    {
        //        this.PLC_Device_CCD01_01_基準圓量測_OK.Bool = false;
        //    }
        //    this.CCD01_01_基準線量測_AxLineRegression.PointIndex = 0;
        //    this.CCD01_01_基準線量測_AxLineRegression.PointX = CCD01_01_左基準圓量測_AxCircleMsr.MeasuredCenterX;
        //    this.CCD01_01_基準線量測_AxLineRegression.PointY = CCD01_01_左基準圓量測_AxCircleMsr.MeasuredCenterY;
        //    this.CCD01_01_基準線量測_AxLineRegression.PointIndex = 1;
        //    this.CCD01_01_基準線量測_AxLineRegression.PointX = CCD01_01_右基準圓量測_AxCircleMsr.MeasuredCenterX;
        //    this.CCD01_01_基準線量測_AxLineRegression.PointY = CCD01_01_右基準圓量測_AxCircleMsr.MeasuredCenterY;


        //    Point_CCD01_01_左基準圓心座標_量測點.X = (float)CCD01_01_左基準圓量測_AxCircleMsr.MeasuredCenterX;
        //    Point_CCD01_01_左基準圓心座標_量測點.Y = (float)CCD01_01_左基準圓量測_AxCircleMsr.MeasuredCenterY;
        //    Point_CCD01_01_右基準圓心座標_量測點.X = (float)CCD01_01_右基準圓量測_AxCircleMsr.MeasuredCenterX;
        //    Point_CCD01_01_右基準圓心座標_量測點.Y = (float)CCD01_01_右基準圓量測_AxCircleMsr.MeasuredCenterY;

        //    this.CCD01_01_基準線量測_AxLineRegression.RegressionOrientation = AxOvkMsr.TxAxLineRegressionOrientation.AX_QUASI_HORIZONTAL_REGRESSION;

        //    cnt++;
        //}
        //void cnt_Program_CCD01_01_基準圓量測_直線開始量測(ref int cnt)
        //{
        //    this.CCD01_01_基準線量測_AxLineRegression.DetectPrimitives();
        //    cnt++;
        //}
        //void cnt_Program_CCD01_01_基準圓量測_求兩點中心(ref int cnt)
        //{

        //    Point_CCD01_01_中心基準圓心座標_量測點.X = (Point_CCD01_01_左基準圓心座標_量測點.X + Point_CCD01_01_右基準圓心座標_量測點.X) / 2;
        //    Point_CCD01_01_中心基準圓心座標_量測點.Y = (Point_CCD01_01_左基準圓心座標_量測點.Y + Point_CCD01_01_右基準圓心座標_量測點.Y) / 2;
        //    if (!PLC_Device_CCD01_01_計算一次.Bool)
        //    {
        //        PLC_Device_CCD01_01_基準圓量測_中心圓座標X.Value = (int)(Point_CCD01_01_左基準圓心座標_量測點.X + Point_CCD01_01_右基準圓心座標_量測點.X) / 2;
        //        PLC_Device_CCD01_01_基準圓量測_中心圓座標Y.Value = (int)(Point_CCD01_01_左基準圓心座標_量測點.Y + Point_CCD01_01_右基準圓心座標_量測點.Y) / 2;
        //    }


        //    cnt++;
        //}
        //void cnt_Program_CCD01_01_基準圓量測_開始繪製(ref int cnt)
        //{
        //    this.PLC_Device_CCD01_01_基準圓量測_RefreshCanvas.Bool = true;
        //    if (this.PLC_Device_CCD01_01_基準圓量測按鈕.Bool)
        //    {
        //        this.h_Canvas_Tech_CCD01_01_拼接完成圖.RefreshCanvas();
        //    }

        //    cnt++;
        //}




        //#endregion

        private PLC_Device PLC_Device_CCD01_01_PIN量測參數_灰階門檻值_combobox = new PLC_Device("F650");
        void Program_CCD01_01_PIN量測_combobox()
        {
      

        }

        

        
        #region Event


        private void plC_RJ_Button_CCD01_01_拼接圖1_儲存圖片_MouseClickEvent(MouseEventArgs mevent)
        {
            this.Invoke(new Action(delegate {
                if (saveImageDialog.ShowDialog() == DialogResult.OK)
                {
                    this.h_Canvas_Tech_CCD01_01_拼接圖1.SaveImage(saveImageDialog.FileName);
                }
            }));

        }
        private void plC_RJ_Button_CCD01_01_拼接圖1_讀取圖片_MouseClickEvent(MouseEventArgs mevent)
        {
            this.Invoke(new Action(delegate {
                if (openImageDialog.ShowDialog() == DialogResult.OK)
                {
                    this.CCD01_AxImageBW8.LoadFile(openImageDialog.FileName);
                    try
                    {
                        this.h_Canvas_Tech_CCD01_01_拼接圖1.ImageCopy(CCD01_AxImageBW8.VegaHandle);
                        this.CCD01_01_SrcImageHandle_拼接圖1 = h_Canvas_Tech_CCD01_01_拼接圖1.VegaHandle;
                        this.h_Canvas_Tech_CCD01_01_拼接圖1.RefreshCanvas();
                    }
                    catch
                    {
                        err_message1 = MessageBox.Show("讀取圖片空白", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        if (err_message1 == DialogResult.OK)
                        {

                        }
                    }
                }
            }));


        }
        private void plC_RJ_Button_CCD01_01_拼接圖2_儲存圖片_MouseClickEvent(MouseEventArgs mevent)
        {
            this.Invoke(new Action(delegate {
                if (saveImageDialog.ShowDialog() == DialogResult.OK)
                {
                    this.h_Canvas_Tech_CCD01_01_拼接圖2.SaveImage(saveImageDialog.FileName);
                }
            }));
        }
        private void plC_RJ_Button_CCD01_01_拼接圖2_讀取圖片_MouseClickEvent(MouseEventArgs mevent)
        {
            this.Invoke(new Action(delegate {
                if (openImageDialog.ShowDialog() == DialogResult.OK)
                {
                    this.CCD01_AxImageBW8.LoadFile(openImageDialog.FileName);
                    try
                    {
                        this.h_Canvas_Tech_CCD01_01_拼接圖2.ImageCopy(CCD01_AxImageBW8.VegaHandle);
                        this.CCD01_01_SrcImageHandle_拼接圖2 = h_Canvas_Tech_CCD01_01_拼接圖2.VegaHandle;
                        this.h_Canvas_Tech_CCD01_01_拼接圖2.RefreshCanvas();
                    }
                    catch
                    {
                        err_message1 = MessageBox.Show("讀取圖片空白", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        if (err_message1 == DialogResult.OK)
                        {

                        }
                    }
                }
            }));
        }
        private void plC_RJ_Button_CCD01_01_拼接完成圖_儲存圖片_MouseClickEvent(MouseEventArgs mevent)
        {
            this.Invoke(new Action(delegate {
                if (saveImageDialog.ShowDialog() == DialogResult.OK)
                {
                    this.h_Canvas_Tech_CCD01_01_拼接完成圖.SaveImage(saveImageDialog.FileName);
                }
            }));
        }
        private void plC_RJ_Button_CCD01_01_拼接完成圖_讀取圖片_MouseClickEvent(MouseEventArgs mevent)
        {
            this.Invoke(new Action(delegate {
                if (openImageDialog.ShowDialog() == DialogResult.OK)
                {
                    this.CCD01_AxImageBW8.LoadFile(openImageDialog.FileName);
                    try
                    {
                        this.h_Canvas_Tech_CCD01_01_拼接完成圖.ImageCopy(CCD01_AxImageBW8.VegaHandle);
                        this.CCD01_01_SrcImageHandle_拼接完成圖 = h_Canvas_Tech_CCD01_01_拼接完成圖.VegaHandle;
                        this.h_Canvas_Tech_CCD01_01_拼接完成圖.RefreshCanvas();
                    }
                    catch
                    {
                        err_message1 = MessageBox.Show("讀取圖片空白", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        if (err_message1 == DialogResult.OK)
                        {

                        }
                    }
                }
            }));
        }
        private void plC_RJ_Button_Main_CCD01_01儲存圖片_MouseClickEvent(MouseEventArgs mevent)
        {
            this.Invoke(new Action(delegate {
                if (saveImageDialog.ShowDialog() == DialogResult.OK)
                {
                    this.h_Canvas_Main_CCD01_01_檢測畫面.SaveImage(saveImageDialog.FileName);
                }
            }));
        }

        private void plC_RJ_Button_Main_CCD01_01讀取圖片_MouseClickEvent(MouseEventArgs mevent)
        {
            this.Invoke(new Action(delegate {
                if (openImageDialog.ShowDialog() == DialogResult.OK)
                {
                    this.CCD01_AxImageBW8.LoadFile(openImageDialog.FileName);
                    try
                    {
                        this.h_Canvas_Main_CCD01_01_檢測畫面.ImageCopy(CCD01_AxImageBW8.VegaHandle);
                        this.CCD01_01_SrcImageHandle_拼接完成圖 = h_Canvas_Main_CCD01_01_檢測畫面.VegaHandle;
                        this.h_Canvas_Main_CCD01_01_檢測畫面.RefreshCanvas();
                    }
                    catch
                    {
                        err_message1 = MessageBox.Show("讀取圖片空白", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        if (err_message1 == DialogResult.OK)
                        {

                        }
                    }
                }
            }));
        }
        private void plC_Button_CCD01_01_儲存拼接檔案_btnClick(object sender, EventArgs e)
        {
            if (saveFileDialog_拼接校正檔.ShowDialog() == DialogResult.OK)
            {
                this.CCD01_01_AxImageSewer.SaveFile(saveFileDialog_拼接校正檔.FileName);
            }

        }
        private void plC_Button_CCD01_01_讀取拼接檔案_btnClick(object sender, EventArgs e)
        {
            if (openFileDialog_拼接校正檔.ShowDialog() == DialogResult.OK)
            {
                this.CCD01_01_AxImageSewer.LoadFile(@"C:\Users\aaa\Desktop\文信40PIN_CCD\Imagesewer_File\CCD01_01_Calibrate.cb");
            }
        }
        int CCD01_01接圖1拼接順序 = 0;
        int CCD01_01接圖2拼接順序 = 0;
        private void plC_Button_CCD01_01拼圖1校正SET_btnClick(object sender, EventArgs e)
        {
            if (PLC_Device_CCD01_01_校正量測框調整.Bool || !PLC_Device_CCD01_01_校正量測框調整.Bool)
            {
                if (CCD01_01接圖1拼接順序 == 0)
                {
                    PLC_Device_CCD01_01_校正量測框_拼圖1校正座標1_X.Value = PLC_Device_CCD01_01_校正量測框_拼圖1座標X.Value;
                    PLC_Device_CCD01_01_校正量測框_拼圖1校正座標1_Y.Value = PLC_Device_CCD01_01_校正量測框_拼圖1座標Y.Value;
                    CCD01_01接圖1拼接順序 = 1;
                }
                else if (CCD01_01接圖1拼接順序 == 1)
                {
                    PLC_Device_CCD01_01_校正量測框_拼圖1校正座標2_X.Value = PLC_Device_CCD01_01_校正量測框_拼圖1座標X.Value;
                    PLC_Device_CCD01_01_校正量測框_拼圖1校正座標2_Y.Value = PLC_Device_CCD01_01_校正量測框_拼圖1座標Y.Value;
                    CCD01_01接圖1拼接順序 = 2;
                }
                else if (CCD01_01接圖1拼接順序 == 2)
                {
                    PLC_Device_CCD01_01_校正量測框_拼圖1校正座標3_X.Value = PLC_Device_CCD01_01_校正量測框_拼圖1座標X.Value;
                    PLC_Device_CCD01_01_校正量測框_拼圖1校正座標3_Y.Value = PLC_Device_CCD01_01_校正量測框_拼圖1座標Y.Value;
                    CCD01_01接圖1拼接順序 = 3;
                }
                else if (CCD01_01接圖1拼接順序 == 3)
                {
                    PLC_Device_CCD01_01_校正量測框_拼圖1校正座標4_X.Value = PLC_Device_CCD01_01_校正量測框_拼圖1座標X.Value;
                    PLC_Device_CCD01_01_校正量測框_拼圖1校正座標4_Y.Value = PLC_Device_CCD01_01_校正量測框_拼圖1座標Y.Value;
                    CCD01_01接圖1拼接順序 = 0;
                    MyMessageBox.ShowDialog("拼圖1校正點輸入完成", "訊息", MyMessageBox.enum_BoxType.Asterisk, MyMessageBox.enum_Button.Confirm);
                   // MessageBox.Show("拼圖1校正點輸入完成", "訊息", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                }
            }
        }
        private void plC_Button_CCD01_01拼圖2校正SET_btnClick(object sender, EventArgs e)
        {
            if(PLC_Device_CCD01_01_校正量測框調整.Bool)
            {
                if (CCD01_01接圖2拼接順序 == 0)
                {
                    PLC_Device_CCD01_01_校正量測框_拼圖2校正座標1_X.Value = PLC_Device_CCD01_01_校正量測框_拼圖2座標X.Value;
                    PLC_Device_CCD01_01_校正量測框_拼圖2校正座標1_Y.Value = PLC_Device_CCD01_01_校正量測框_拼圖2座標Y.Value;
                    CCD01_01接圖2拼接順序 = 1;
                }
                else if (CCD01_01接圖2拼接順序 == 1)
                {
                    PLC_Device_CCD01_01_校正量測框_拼圖2校正座標2_X.Value = PLC_Device_CCD01_01_校正量測框_拼圖2座標X.Value;
                    PLC_Device_CCD01_01_校正量測框_拼圖2校正座標2_Y.Value = PLC_Device_CCD01_01_校正量測框_拼圖2座標Y.Value;
                    CCD01_01接圖2拼接順序 = 2;
                }
                else if (CCD01_01接圖2拼接順序 == 2)
                {
                    PLC_Device_CCD01_01_校正量測框_拼圖2校正座標3_X.Value = PLC_Device_CCD01_01_校正量測框_拼圖2座標X.Value;
                    PLC_Device_CCD01_01_校正量測框_拼圖2校正座標3_Y.Value = PLC_Device_CCD01_01_校正量測框_拼圖2座標Y.Value;
                    CCD01_01接圖2拼接順序 = 3;
                }
                else if (CCD01_01接圖2拼接順序 == 3)
                {
                    PLC_Device_CCD01_01_校正量測框_拼圖2校正座標4_X.Value = PLC_Device_CCD01_01_校正量測框_拼圖2座標X.Value;
                    PLC_Device_CCD01_01_校正量測框_拼圖2校正座標4_Y.Value = PLC_Device_CCD01_01_校正量測框_拼圖2座標Y.Value;
                    CCD01_01接圖2拼接順序 = 0;
                    MyMessageBox.ShowDialog("拼圖2校正點輸入完成", "訊息", MyMessageBox.enum_BoxType.Asterisk, MyMessageBox.enum_Button.Confirm);
                    //MessageBox.Show("拼圖2校正點輸入完成", "訊息", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                }
            }

        }

        #endregion
    }
}
