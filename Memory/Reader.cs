using System;
using System.Diagnostics;
using System.Text;

namespace ProjectIntercept.Memory
{
    internal class ReadProcMems
    {
        /// NOTES:  To read primitive values without boxing pass in a byte array to read the content. 
        ///         Use methods in the BitConverter class to convert the data. 
        /// <summary> The Process object of the process that will be accessed. </summary>
        public static Process MProcess;

        /// <summary> Constructor. </summary>
        /// <param name="process">Specifies the process to use for the direct memory operations.</param>
        public ReadProcMems(Process process)
        {
            MProcess = process;
        }

        /// <summary> Reads the specified number of bytes from unmanaged memory. </summary>
        /// <param name="memoryaddress"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static byte[] ReadBytes(IntPtr memoryaddress, uint size)
        {
            try
            {
                IntPtr ptrBytesRead;
                var bytBuffer = new byte[size];
                WinApi.Win32.ReadProcessMemory(MProcess.Handle, memoryaddress, bytBuffer, size, out ptrBytesRead);
                return bytBuffer;
            }
            catch
            {
                return null;
            }

        }

        /// <summary> Reads a single byte from unmanaged memory. </summary>
        /// <param name="memoryaddress"></param>
        /// <returns></returns>
        public static byte ReadByte(IntPtr memoryaddress)
        {
            try
            {
                var bytBuffer = ReadBytes(memoryaddress, 1);
                return bytBuffer[0];
            }
            catch
            {
                return 0;
            }

        }

        /// <summary> Reads a 16-bit signed interger from unmanaged memory. </summary>
        /// <param name="memoryaddress"></param>
        /// <returns></returns>
        public static short ReadInt16(IntPtr memoryaddress)
        {
            var bytBuffer = ReadBytes(memoryaddress, 2);
            return BitConverter.ToInt16(bytBuffer, 0);
        }

        /// <summary> Reads a 32-bit signed interger from unmanaged memory. </summary>
        /// <param name="memoryaddress"></param>
        /// <returns></returns>
        public static int ReadInt32(IntPtr memoryaddress)
        {
            var bytBuffer = ReadBytes(memoryaddress, 4);
            return BitConverter.ToInt32(bytBuffer, 0);
        }


        /// <summary> Reads a 64-bit signed interger from unmanaged memory. </summary>
        /// <param name="memoryaddress"></param>
        /// <returns></returns>
        public static long ReadInt64(IntPtr memoryaddress)
        {
            var bytBuffer = ReadBytes(memoryaddress, 8);
            return BitConverter.ToInt64(bytBuffer, 0);
        }

        /// <summary> Reads a fixed-length string from unmanaged memory. </summary>
        /// <param name="memoryaddress"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static string ReadString(IntPtr memoryaddress, uint size)
        {
            try
            {
                var bytBuffer = ReadBytes(memoryaddress, size);
                return Encoding.Default.GetString(bytBuffer);
            }
            catch
            {
                return null;
            }

        }

        /// <summary> Reads a variable length string from unmanaged memory. </summary>
        /// <param name="memoryaddress"></param>
        /// <returns></returns>
        public static string ReadString(IntPtr memoryaddress)
        {
            var buffer = "";
            var bytBuffer = new byte[1];
            var addy = (int)memoryaddress;

            do
            {
                bytBuffer[0] = ReadByte((IntPtr)addy++);
                if (bytBuffer[0] > 0)
                    buffer = buffer + Encoding.Default.GetString(bytBuffer);
            } while (bytBuffer[0] != 0);

            return buffer;
        }

        /// <summary> Writes the specified number of bytes to unmanaged memory. </summary>
        /// <param name="memoryaddress"></param>
        /// <param name="size"></param>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public static bool WriteBytes(IntPtr memoryaddress, uint size, byte[] buffer)
        {
            IntPtr ptrBytesWritten;
            return WinApi.Win32.WriteProcessMemory(MProcess.Handle, memoryaddress, buffer, size, out ptrBytesWritten);
        }

        /// <summary> Write a single byte value to unmanaged memory. </summary>
        /// <param name="memoryaddress"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public static bool WriteByte(IntPtr memoryaddress, byte val)
        {
            var bytBuffer = new byte[1];
            bytBuffer[0] = val;
            return WriteBytes(memoryaddress, 1, bytBuffer);
        }

        /// <summary> Writes a 16-bit signed integer to unmanaged memory. </summary>
        /// <param name="memoryaddress"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public static bool WriteInt16(IntPtr memoryaddress, short val)
        {
            var bytBuffer = BitConverter.GetBytes(val);
            return WriteBytes(memoryaddress, 2, bytBuffer);
        }

        /// <summary> Writes a 32-bit signed integer to unmanaged memory. </summary>
        /// <param name="memoryaddress"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public static bool WriteInt32(IntPtr memoryaddress, int val)
        {
            var bytBuffer = BitConverter.GetBytes(val);
            return WriteBytes(memoryaddress, 4, bytBuffer);
        }

        /// <summary> Writes a 64-bit signed integer to unmanaged memory. </summary>
        /// <param name="memoryaddress"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public static bool WriteInt64(IntPtr memoryaddress, long val)
        {
            var bytBuffer = BitConverter.GetBytes(val);
            return WriteBytes(memoryaddress, 8, bytBuffer);
        }

        /// <summary> Writes a string to unmanaged memory. </summary>
        /// <param name="memoryaddress"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public static bool WriteString(IntPtr memoryaddress, string val)
        {
            var oEncoder = new ASCIIEncoding();
            var bytBuffer = oEncoder.GetBytes(val);
            return WriteBytes(memoryaddress, (uint)val.Length, bytBuffer);
        }
    }
}