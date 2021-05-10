using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace HPMall.models
{
    public class DeviceInfo
    {
        public DeviceInfo() { }

        private static DeviceInfo _instance = null;
        public static DeviceInfo Instance()
        {
            return _instance = _instance ?? new DeviceInfo();
        }
        public string SerialNumber { get { return GetSerialNumber(); } }

        public string SSID { get { return GetBaseBoardProductId(); } }

        public string DeviceName { get { return GetDeviceName(); } }
        public string ProductNumber { get { return GetProductNumber(); } }
        public string SystemVersion { get { return GetSystemVersion(); } }
        private string GetSerialNumber()
        {
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("Select * From Win32_BIOS");
                string serailNumber = "";
                foreach (ManagementObject mo in searcher.Get())
                {
                    serailNumber = mo["SerialNumber"].ToString().Trim();
                    break;
                }
                return serailNumber;
            }
            catch
            {
                return "";
            }
        }

        private string GetBaseBoardProductId()
        {
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("Select * From Win32_BaseBoard");
                string serailNumber = "";
                foreach (ManagementObject mo in searcher.Get())
                {
                    serailNumber = mo["Product"].ToString().Trim();
                    break;
                }
                return serailNumber;
            }
            catch
            {
                return "";
            }
        }

        private string GetMotherBoardSerialNumber()
        {
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("Select * From Win32_BaseBoard");
                string serailNumber = "";
                foreach (ManagementObject mo in searcher.Get())
                {
                    serailNumber = mo["SerialNumber"].ToString().Trim();
                    break;
                }
                return serailNumber;
            }
            catch
            {
                return "";
            }
        }

        private string GetCPUSerialNumber()
        {
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("Select * From Win32_Processor");
                string sCpuSerailNumber = "";
                foreach (ManagementObject mo in searcher.Get())
                {
                    sCpuSerailNumber = mo["ProcessorId"].ToString().Trim();
                    break;
                }
                return sCpuSerailNumber;
            }
            catch
            {
                return "";
            }
        }

        private string GetNetCardMACAddress()
        {
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapter WHERE ((MACAddress Is Not NULL) AND (Manufacturer <> 'Microsoft'))");
                string NetCardMACAddress = "";
                foreach (ManagementObject mo in searcher.Get())
                {
                    NetCardMACAddress = mo["MACAddress"].ToString().Trim();
                    break;
                }
                return NetCardMACAddress;
            }
            catch
            {
                return "";
            }
        }

        private string GetDeviceName()
        {
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("Select * From Win32_ComputerSystem");
                string NetCardMACAddress = "";
                foreach (ManagementObject mo in searcher.Get())
                {
                    NetCardMACAddress = mo["Model"].ToString().Trim();
                    break;
                }
                return NetCardMACAddress;
            }
            catch
            {
                return "";
            }
        }
        private string GetProductNumber()
        {
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("Select * From Win32_ComputerSystemProduct");
                string SKU = "";
                //foreach (ManagementObject mo in searcher.Get())
                //{

                //    SKU = mo["SKUNumber"].ToString().Trim();
                //    break;
                //}
                return SKU;
            }
            catch
            {
                return "";
            }
        }

        private string GetSystemVersion()
        {
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("Select * From Win32_OperatingSystem");
                string systemVersion = "";
                foreach (ManagementObject mo in searcher.Get())
                {
                    systemVersion = mo["Caption"].ToString().Trim();
                    break;
                }
                return systemVersion;
            }
            catch
            {
                return "";
            }
        }
    }
}
