using System;
using mmind.apiSharp;
using System.Windows.Forms;
using CaptureCloudFromDepth;
using System.Collections.Generic;
using System.IO;


class sample
{
    
    static void showError(ErrorStatus status)
    {
        if (status.errorCode == (int)ErrorCode.MMIND_STATUS_SUCCESS)
            return;
        Console.WriteLine("Error Code : {0}, Error Description: {1}.", status.errorCode, status.errorDescription);
    }
    static void printDeviceInfo(MechEyeDeviceInfo deviceInfo)
    {
        Console.WriteLine("............................");
        Console.WriteLine("Camera Model Name: {0}", deviceInfo.model);
        Console.WriteLine("Camera ID:         {0}", deviceInfo.id);
        Console.WriteLine("Camera IP Address: {0}", deviceInfo.ipAddress);
        Console.WriteLine("Hardware Version:  V{0}", deviceInfo.hardwareVersion);
        Console.WriteLine("Firmware Version:  V{0}", deviceInfo.firmwareVersion);
        Console.WriteLine("............................");
        Console.WriteLine("");
    }

    private static int Main()
    {
        Console.WriteLine("Find Mech-Eye devices...");
        List <MechEyeDeviceInfo> deviceInfoList = MechEyeDevice.enumerateMechEyeDeviceList();

        if (deviceInfoList.Count == 0)
        {
            Console.WriteLine("No Mech-Eye Device found.");
            return -1;
        }

        for (int i = 0; i < deviceInfoList.Count; ++i)
        {
            Console.WriteLine("Mech-Eye device index : {0}", i);
            printDeviceInfo(deviceInfoList[i]);
        }

        Console.WriteLine("Please enter the device index you want to connect: ");
        int inputIndex = 0;

        while (true)
        {
            string input = Console.ReadLine();
            if (int.TryParse(input, out inputIndex) && inputIndex >= 0 && inputIndex < deviceInfoList.Count)
                break;
            Console.WriteLine("Input invalid! Please enter the device index you wnat to connect: ");
        }

        //MechEyeDeviceInfo deviceInfo = new MechEyeDeviceInfo() { model = "", id = "", hardwareVersion = "", firmwareVersion = "1.5.0", ipAddress = "192.168.23.240", port = 5577 };

        ErrorStatus status = new ErrorStatus();
        MechEyeDevice device = new MechEyeDevice();
        status = device.connect(deviceInfoList[inputIndex]);
        //status = device.connect("192.168.23.240");
        //status = device.connect(deviceInfo);

        if (status.errorCode != (int)ErrorCode.MMIND_STATUS_SUCCESS)
        {
            showError(status);
            return -1;
        }

        Console.WriteLine("Connected to the Mech-Eye device successfully.");

        MechEyeDeviceInfo deviceInfo = new MechEyeDeviceInfo();
        showError(device.getDeviceInfo(ref deviceInfo));
        printDeviceInfo(deviceInfo);

        ColorMap color = new ColorMap();
        //showError(device.captureColorMap(ref color));

        DepthMap depth = new DepthMap();
        //showError(device.captureDepthMap(ref depth));

        PointXYZMap pointXYZMap = new PointXYZMap();
        //showError(device.capturePointXYZMap(ref pointXYZMap));

        PointXYZBGRMap xyzbgr = new PointXYZBGRMap();
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        ShowMap a = new ShowMap();
        a.SetColor(ref color);
        a.SetDepth(ref depth);
        a.Device(ref device); 
        Application.Run(a);

        DeviceIntri deviceIntri = new DeviceIntri();
        showError(device.getDeviceIntri(ref deviceIntri));
        color.resize(xyzbgr.width(), xyzbgr.height());
        const string fileName = @"PointXYZ.ply";
        if (File.Exists(fileName))
        {
            File.Delete(fileName);
        }
        using (StreamWriter sw = File.CreateText(fileName))
        {
            sw.WriteLine("ply");
            sw.WriteLine("format ascii 1.0");
            sw.WriteLine("element vertex {0}", depth.width() * depth.height());
            sw.WriteLine("property float x");
            sw.WriteLine("property float y");
            sw.WriteLine("property float z");
            sw.WriteLine("end_header");
            pointXYZMap.resize(depth.width(), depth.height());
            for (uint m = 0; m < depth.height(); ++m)
                for (uint n = 0; n < depth.width(); ++n)
                {
                    float d;
                    try
                    {
                        d = depth.at(m, n).d;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Exception: {0}", e);
                        device.disconnect();
                        return 0;
                    }
                    color.at(m, n).b = xyzbgr.at(m, n).b;
                    color.at(m, n).g = xyzbgr.at(m, n).g;
                    color.at(m, n).r = xyzbgr.at(m, n).r;
                    sw.WriteLine("{0} {1} {2}",
                        ((float)n - (float)deviceIntri.depthCameraIntri.cx) * d / (float)deviceIntri.depthCameraIntri.fx,
                        ((float)m - (float)deviceIntri.depthCameraIntri.cy) * d / (float)deviceIntri.depthCameraIntri.fy,
                        d);
                }

        }


        device.disconnect();
        Console.WriteLine("Disconnected from the Mech-Eye device successfully.");

        return 0;
    }
}