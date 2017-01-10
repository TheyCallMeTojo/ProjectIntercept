using System;
using System.Linq;
using System.Management;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.Win32;
using ProjectIntercept.Log;
using ProjectIntercept.MySql;

namespace ProjectIntercept.Security
{
    internal class Computer
    {
        private static readonly Write Log = new Write(Application.StartupPath + "\\log.txt");
       

        public static bool CheckComputerExist()
        {
            try
            {
                var results = Commands.QueryGet(string.Format(Commands.CheckComputerQ, Hardware.GetPcId()));
                return results.Capacity > 0;
            }

            catch (Exception e)
            {
                Log.Line(e.Message, true);
                return false;
            }
        }

        public static bool RegisterPlayer(string email, string nickname)
        {
            if (!IsEmail(email))
            {
                MessageBox.Show(@"Invalid email entered!", @"Registration Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return false;
            }

            try
            {
                Commands.QueryEx(
                    string.Format(Commands.RegisterQ, email, Hardware.GetPcId(), Hardware.GetMachineId(), Environment.OSVersion, Hardware.GetOsProductKey(), Lobby.Player.GetMyIp(), nickname));
                Log.Line("Compuer registered ok! {" + email + "}");
                return true;
            }
            catch (Exception e)
            {
                Log.Line(e.Message, true);
                return false;
            }
        }

        public static bool IsEmail(string inputEmail)
        {
            if (string.IsNullOrEmpty(inputEmail))
            {
                throw new ArgumentNullException("inputEmail");
            }

            const string expression = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                                      @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                                      @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

            var regex = new Regex(expression);
            return regex.IsMatch(inputEmail);
        }
    }

    internal class Hardware
    {
        private const string MUnknown = "Unknown";
        public static string GetMachineId()
        {
            return
                Encryption.Md5(GetBoardProductId() + ":" + GetBoardSerNo() + ":" + GetBioSserNo() + ":" +
                               GetProcessorId() + GetMacAddress());
        }

        public static string GetHardDisks()
        {
            var searcher = new
                ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_LogicalDisk");

            var sb = new StringBuilder();
            foreach (var wmi in searcher.Get())
            {
                try
                {
                    sb.Append(wmi.GetPropertyValue("VolumeSerialNumber"));
                }
                catch
                {
                    return sb.ToString();
                }
            }

            return sb.ToString();
        }

        public static string GetBoardMaker()
        {
            var searcher = new
                ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_BaseBoard");

            foreach (var wmi in searcher.Get())
            {
                try
                {
                    return wmi.GetPropertyValue("Manufacturer").ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return null;
        }

        public static string GetBoardSerNo()
        {
            var searcher = new
                ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_BaseBoard");

            foreach (var wmi in searcher.Get())
            {
                try
                {
                    return wmi.GetPropertyValue("SerialNumber").ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return null;
        }

        public static string GetBoardProductId()
        {
            var searcher = new
                ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_BaseBoard");

            foreach (var wmi in searcher.Get())
            {
                try
                {
                    return wmi.GetPropertyValue("Product").ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return null;
        }

        public static string GetCdRomDrive()
        {
            var searcher = new
                ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_CDROMDrive");

            foreach (var wmi in searcher.Get())
            {
                try
                {
                    return wmi.GetPropertyValue("Drive").ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return null;
        }

        public static string GetAccount()
        {
            var searcher = new
                ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_UserAccount");

            foreach (var wmi in searcher.Get())
            {
                try
                {
                    return wmi.GetPropertyValue("Name").ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return null;
        }

        public static string GetBioScaption()
        {
            var searcher = new
                ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_BIOS");

            foreach (var wmi in searcher.Get())
            {
                try
                {
                    return wmi.GetPropertyValue("Caption").ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return null;
        }

        public static string GetBioSmaker()
        {
            var searcher = new
                ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_BIOS");

            foreach (var wmi in searcher.Get())
            {
                try
                {
                    return wmi.GetPropertyValue("Manufacturer").ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return null;
        }

        public static string GetBioSserNo()
        {
            var searcher = new
                ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_BIOS");

            foreach (var wmi in searcher.Get())
            {
                try
                {
                    return wmi.GetPropertyValue("SerialNumber").ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return null;
        }

        public static string GetProcessorId()
        {
            var sProcessorId = "";

            const string sQuery = "SELECT ProcessorId FROM Win32_Processor";

            var oManagementObjectSearcher = new ManagementObjectSearcher(sQuery);

            var oCollection = oManagementObjectSearcher.Get();

            foreach (var oManagementObject in oCollection)
            {
                sProcessorId = (string) oManagementObject["ProcessorId"];
            }

            return (sProcessorId);
        }

        public static string GetMacAddress()
        {
            try
            {
                var query = new ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapterConfiguration");

                var queryCollection = query.Get();

                foreach (var mo in
                    queryCollection.Cast<ManagementObject>().Where(mo => mo["MacAddress"] != null))
                {
                    return mo["MacAddress"].ToString();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Source);
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public static string GetPcId()
        {
            return Encryption.Md5(GetProcessorId() + GetMacAddress());
        }

        public static string GetOsProductKey()
        {
            try
            {
                // Open the Registry Key and then get the value (byte array) from the SubKey.
                var regKey = Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Windows NT\\CurrentVersion", false);
                if (regKey != null)
                {
                    var digitalPid = (byte[])regKey.GetValue("DigitalProductID");

                    if (digitalPid != null)
                    {
                        // Transfer only the needed bytes into our Key Array.
                        // Key starts at byte 52 and is 15 bytes long.
                        var key = new byte[15];
                        //0-14 = 15 bytes
                        Array.Copy(digitalPid, 52, key, 0, 15);

                        // Our "Array" of valid CD-Key characters.
                        const string characters = "BCDFGHJKMPQRTVWXY2346789";

                        // Finally, our decoded CD-Key to be returned
                        var productKey = "";

                        // How Microsoft encodes this to begin with, I'd love to know...
                        // but here's how we decode the byte array into a string containing the CD-KEY.
                        for (var j = 0; j <= 24; j++)
                        {
                            short curValue = 0;
                            for (var i = 14; i >= 0; i += -1)
                            {
                                curValue = Convert.ToInt16(curValue * 256 ^ key[i]);
                                key[i] = (byte)Convert.ToInt32(curValue / 24);
                                curValue = Convert.ToInt16(curValue % 24);
                            }
                            productKey = characters.Substring(curValue, 1) + productKey;
                        }

                        // Finally, insert the dashes into the string.
                        for (var i = 4; i >= 1; i += -1)
                        {
                            productKey = productKey.Insert(i * 5, "-");
                        }

                        return productKey;
                    }
                    return MUnknown;
                }
            }
            catch
            {
                return MUnknown;

            }
            return null;
        }
    }
}