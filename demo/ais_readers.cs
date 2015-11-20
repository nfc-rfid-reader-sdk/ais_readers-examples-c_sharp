using System;
using System.Runtime.InteropServices;
using System.Text;
using HND_AIS = System.UIntPtr;

// for Lib version 4.3.7-debug

namespace DL_AIS_Readers
{
    public enum DEVICE_TYPES : uint
    {
        DL_AIS_100 = 0,
        DL_AIS_20 = 1,
        DL_AIS_30 = 2,
        DL_AIS_35 = 3,
        DL_AIS_50 = 4,
        DL_AIS_110 = 5,
        DL_AIS_LOYALITY = 6,
        DL_AIS_37 = 7, // AIS START == BASE BAT USB
        //.
        DL_AIS_BMR = 11, // barcode
        DL_AIS_BASE_HD = 12, // new base half duplex
        DL_AIS_BASE_HD_XRCA = 20
    };

    // API card actions:
    public enum CARD_ACTION : uint
    {
        // CARD_FOREIGN
        // strange card - card from different system
        // BASE> LOG = 0x83 | RTE = 0x00
        ACTION_CARD_FOREIGN = 0x00,

        // DISCARDED
        // blocked card - card on blacklist, no valid access right, has no right of passage
        // BASE> LOG= 0xC3 | RTE= 0x20
        ACTION_CARD_DISCARDED = 0x20, // (32 dec)

        // CARD_HACKED
        // Mifare key OK - CRC OK - but bad user data
        // Bad protective data
        // BASE> LOG= 0x84 | RTE= 0x40
        ACTION_CARD_HACKED = 0x40, // (64 dec)

        // CARD_BAD_DATA
        // Mifare key OK - CRC BAD
        // Cards with invalid data - BAD CRC
        // BASE> LOG= 0x-- | RTE= 0x82
        ACTION_CARD_BAD_DATA = 0x50, // (80 dec)

        // CARD_NO_DATA
        // unreadable card - card without or unknown Mifare key
        // BASE> LOG= 0x-- | RTE= 0x81
        ACTION_CARD_NO_DATA = 0x60, // (96 dec)

        // UNLOCKED
        ACTION_QR_UNLOCKED = 0x70,
        ACTION_QR_BLOCKED = 0x71,
        ACTION_QR_UNKNOWN = 0x72,

        // state machines = 0xB000
        ERR_STATE_MACHINE = 0xB000,
        ERR_SM_IDLE__NO_RESPONSE,
        ERR_SM_COMMAND_IN_PROGRESS,
        ERR_SM_NOT_IDLE,
        ERR_SM_CMD_NOT_STARTED,

        // The correct card
        // BASE> LOG= 0xC2 | RTE= 0x80(+++)
        // TWR> 0x80 (128 dec) - A regular passage (P)
        // TWR> 0x90 (144 dec) - Official exit (S)
        // TWR> 0xA0 (160 dec) - Vehicle pass (V)
        // TWR> 0xB0 (176 dec) - Approved exit (O)
        ACTION_CARD_UNLOCKED = 0x80,
        ACTION_CARD_UNLOCKED_1 = 0x81,
        ACTION_CARD_UNLOCKED_2 = 0x82,
        ACTION_CARD_UNLOCKED_3 = 0x83,
        ACTION_CARD_UNLOCKED_4 = 0x84,
        ACTION_CARD_UNLOCKED_5 = 0x85,
        ACTION_CARD_UNLOCKED_6 = 0x86,
        ACTION_CARD_UNLOCKED_7 = 0x87,

        // not used anymore
        //#define CARD_OK			0x85

        // non valid status
        // not used status
        //	ACTION_DEVICE_MISSING = 0xA1,
        //	ACTION_BREAK_THROUGH = 0xA2,
        //	ACTION_DOOR_LEFT_OPEN = 0xA3,

    };

    public enum DL_STATUS : uint
    {
        DL_OK = 0x00,

        //----------------------------------------------------------------------
        // common - mostly used
        TIMEOUT_ERROR,

        NULL_POINTER,
        PARAMETERS_ERROR,

        MEMORY_ALLOCATION_ERROR,

        NOT_INITIALIZED,
        ALREADY_INITIALIZED,

        TIMESTAMP_INVALID,

        EVENT_BUSY,

        //----------------------------------------------------------------------
        // specific = 0x1000
        ERR_SPECIFIC = 0x1000,
        // USB RF
        CMD_BRAKE_RTE, // RTE arrived while CMD_IN_PROGRESS

        USB_RF_ACK_FAILED,
        NO_RF_PACKET_DATA,

        TRANSFER_WRITING_ERROR,

        EVENT_WAKEUP_BUSY,

        //----------------------------------------------------------------------
        // resource = 0x2000
        RESOURCE_NOT_ACQUIRED = 0x2000,
        RESOURCE_ALREADY_ACQUIRED,
        RESOURCE_BUSY,

        //----------------------------------------------------------------------
        // FILE = 0x3000
        FILE_OVERSIZE = 0x3000,
        FILE_EMPTY,
        FILE_LOCKED, // when file is fill, and not read yet
        FILE_NOT_FOUND,
        ERR_NO_FILE_NAME,
        ERR_DIR_CAN_NOT_CREATE,

        //----------------------------------------------------------------------
        // LOG = 0x4000
        ERR_DATA = 0x4000,
        ERR_BUFFER_EMPTY,    ///< 0x4001
        ERR_BUFFER_OVERFLOW, ///< 0x4002
        ERR_CHECKSUM, // CRC ERROR
        LOG_NOT_CORRECT,

        //----------------------------------------------------------------------
        //	0x5000,

        //----------------------------------------------------------------------
        //	0x6000,

        //----------------------------------------------------------------------
        // list operations = 0x7000
        LIST_ERROR = 0x7000,
        ITEM_IS_ALREADY_IN_LIST,
        ITEM_NOT_IN_LIST,

        //----------------------------------------------------------------------
        // devices = 0x8000
        NO_DEVICES = 0x8000, // NO_USB_RF_DEVICES
        //----------------------------------------------------------------------
        // open multiple devices
        DEVICE_OPENING_ERROR,
        DEVICE_CAN_NOT_OPEN,
        DEVICE_ALREADY_OPENED,
        DEVICE_NOT_OPENED,
        DEVICE_INDEX_OUT_OF_BOUND,
        DEVICE_CLOSE_ERROR,
        DEVICE_UNKNOWN,

        //----------------------------------------------------------------------
        // command response = 0x9000
        ERR_COMMAND_RESPONSE = 0x9000,
        CMD_RESPONSE_UNKNOWN_COMMAND,
        CMD_RESPONSE_WRONG_CMD,
        CMD_RESPONSE_COMMAND_FAILED,
        CMD_RESPONSE_UNSUCCESS,
        CMD_RESPONSE_NO_AUTHORIZATION,
        CMD_RESPONSE_SIZE_OVERFLOW,
        CMD_RESPONSE_NO_DATA,

        //----------------------------------------------------------------------
        // Threads and objects = 0xA000
        THREAD_FAILURE = 0xA000,
        //---------------------
        ERR_OBJ_NOT_CREATED,
        //---------------------

        //----------------------------------------------------------------------
        // state machines = 0xB000
        ERR_STATE_MACHINE = 0xB000,
        ERR_SM_IDLE__NO_RESPONSE,
        ERR_SM_COMMAND_IN_PROGRESS,
        ERR_SM_NOT_IDLE,

        //----------------------------------------------------------------------
        // readers errors = 0xD000
        READER_ERRORS_ = 0xD000,
        READER_UID_ERROR,
        READER_LOG_ERROR,

        //----------------------------------------------------------------------
        // HAMMING = 0xE000
        DL_HAMMING_ERROR = 0xE000,
        DL_HAMMING_NOT_ACK,
        DL_HAMMING_WRONG_ACK,
        DL_HAMMING_WRONG_REPLAY,

        ERROR_SOME_REPLAY_FALULT,

        //  Formatted transfer
        DL_HAMMING_TERR_TIMEOUT,
        DL_HAMMING_TERR_BAD_FRAME,
        DL_HAMMING_TERR_BAD_SUM,
        DL_HAMMING_TERR_BAD_CODE,
        DL_HAMMING_TERR_TOO_OLD,
        DL_HAMMING_TERR_NOISE, // Warning returned by DecodeFrame()
        DL_HAMMING_TERR_ERROR_MASK,

        //----------------------------------------------------------------------
        // FTDI = 0xF000
        NO_FTDI_COMM_DEVICES = 0xF000,
        NO_FTDI_COMM_DEVICES_OPENED,

        ERR_FTDI, // global
        ERR_FTDI_READ,
        ERR_FTDI_READ_LESS_DATA,
        ERR_FTDI_WRITE,
        ERR_FTDI_WRITE_LESS_DATA,

        DL_FT_ERROR_SET_TIMEOUT,

        // FTSTATUS
        DL_FT_ = 0xF100,
        DL_FT_INVALID_HANDLE,
        DL_FT_DEVICE_NOT_FOUND,
        DL_FT_DEVICE_NOT_OPENED,
        DL_FT_IO_ERROR,
        DL_FT_INSUFFICIENT_RESOURCES,
        DL_FT_INVALID_PARAMETER,
        DL_FT_INVALID_BAUD_RATE,

        DL_FT_DEVICE_NOT_OPENED_FOR_ERASE,
        DL_FT_DEVICE_NOT_OPENED_FOR_WRITE,
        DL_FT_FAILED_TO_WRITE_DEVICE,
        DL_FT_EEPROM_READ_FAILED,
        DL_FT_EEPROM_WRITE_FAILED,
        DL_FT_EEPROM_ERASE_FAILED,
        DL_FT_EEPROM_NOT_PRESENT,
        DL_FT_EEPROM_NOT_PROGRAMMED,
        DL_FT_INVALID_ARGS,
        DL_FT_NOT_SUPPORTED,
        DL_FT_OTHER_ERROR,
        DL_FT_DEVICE_LIST_NOT_READY,

        //----------------------------------------------------------------------
        NOT_IMPLEMENTED = 0xFFFFFFFE, //-2,
        UNKNOWN_ERROR = 0xFFFFFFFF, // - 1,
        MAX_DL_STATUS = 0xFFFFFFFF, // - 1,
        LAST_ERROR = 0xFFFFFFFF // - 1
    };

    public static class ais_readers
    {
        public const UInt32 MAX_DATE_TIME_DIFF_IN_SEC = 60;
        public const Int32 NFC_UID_MAX_LEN = 10;
        private const UInt32 MAX_RETRY_IF_BUSY = 5;

        //--------------------------------------------------------------------------------------------------------------

#if WIN64
        public const string DLL_NAME = "ais_readers-x86_64.dll"; // for x64 target
#else
        public const string DLL_NAME = "ais_readers-x86.dll"; // for x86 target
#endif

        //--------------------------------------------------------------------------------------------------------------

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, EntryPoint = "AIS_GetDLLVersion")]
        private static extern IntPtr AIS_GetDLLVersion();
        public static string GetDLLVersion()
        {
            IntPtr str_ret = AIS_GetDLLVersion();
            return Marshal.PtrToStringAnsi(str_ret);
        }

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, EntryPoint = "dbg_status2str")]
        private static extern IntPtr dbg_status2str(DL_STATUS status);
        public static string status2str(DL_STATUS status)
        {
            IntPtr str_ret = dbg_status2str(status);
            return Marshal.PtrToStringAnsi(str_ret);
        }

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, EntryPoint = "dbg_action2str")]
        private static extern IntPtr dbg_action2str(CARD_ACTION action);
        public static string action2str(CARD_ACTION action)
        {
            IntPtr str_ret = dbg_action2str(action);
            return Marshal.PtrToStringAnsi(str_ret);
        }

        //--------------------------------------------------------------------------------------------------------------

        /**
         * Function return which device will be checked.
         *
         * @return pair of Device type and ID on the bus delimited with ':'
         * 		Pairs of type:id are delimited with new line character
         */
        [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, EntryPoint = "AIS_List_GetDevicesForCheck")]
        private static extern IntPtr List_GetDevicesForCheck();
        public static string AIS_List_GetDevicesForCheck()
        {
            IntPtr str_ret = List_GetDevicesForCheck();
            return Marshal.PtrToStringAnsi(str_ret);
        }

        /**
         * AIS_List_EraseAllDevicesForCheck() : clear list of available devices for checking
         *
         */
        [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, EntryPoint = "AIS_List_EraseAllDevicesForCheck")]
        public static extern void AIS_List_EraseAllDevicesForCheck();

        /**
         * AIS_List_AddDeviceForCheck() : configure DLL - set list of available AIS readers
         *
         * @param device_type int device type by internal specification (enumeration)
         * @param device_id int Reader ID - set by Mifare Init Card
         * @return DL_STATUS
         */
        [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, EntryPoint = "AIS_List_AddDeviceForCheck")]
        public static extern DL_STATUS AIS_List_AddDeviceForCheck(UInt32 device_type, UInt32 device_id);

        /**
         * AIS_List_EraseDeviceForCheck() : configure DLL - remove reader from list for checking
         *
         * @param device_type int device type by internal specification (enumeration)
         * @param device_id int Reader ID - set by Mifare Init Card
         * @return DL_STATUS
         */
        [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, EntryPoint = "AIS_List_EraseDeviceForCheck")]
        public static extern DL_STATUS AIS_List_EraseDeviceForCheck(UInt32 device_type, UInt32 device_id);

        /**
         * AIS_List_UpdateAndGetCount()
         *
         * @return number of attached devices <br> <b>negative</b> value if error
         */
        [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, EntryPoint = "AIS_List_UpdateAndGetCount")]
        public static extern UInt32 AIS_List_UpdateAndGetCount();

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, EntryPoint = "AIS_List_GetInformation")]
        private static extern DL_STATUS List_GetInformation(
                out HND_AIS hnd_device, //// assigned Handle
                out IntPtr Device_Serial, //// device serial number
                out UInt32 Device_Type, //// device type
                out UInt32 Device_ID, //// device identification number (master)
                out UInt32 Device_FW_VER, //// version of firmware
                out UInt32 Device_CommSpeed, //// communication speed
                out IntPtr ptr_FTDI_Serial, //// FTDI COM port identification
                out UInt32 Device_isOpened, //// is Device opened
                out UInt32 Device_Status, //// actual device status
                out UInt32 System_Status //// actual system status
                );
        public static DL_STATUS AIS_List_GetInformation(
                out HND_AIS hnd_device, //// assigned Handle
                out string Device_Serial, //// device serial number
                out UInt32 Device_Type, //// device type
                out UInt32 Device_ID, //// device identification number (master)
                out UInt32 Device_FW_VER, //// version of firmware
                out UInt32 Device_CommSpeed, //// communication speed
                out string FTDI_Serial, //// FTDI COM port identification
                out UInt32 Device_isOpened, //// is Device opened
                out UInt32 Device_Status, //// actual device status
                out UInt32 System_Status //// actual system status
            )
        {
            DL_STATUS status = DL_STATUS.DL_OK;
            UInt32 i = 0;
            IntPtr ptr_Device_Serial;
            IntPtr ptr_FTDI_Serial; // Expected max 10 bytes for S/N

            do
            {
                status = List_GetInformation(
                    out hnd_device, //// assigned Handle
                    out ptr_Device_Serial, //// device serial number
                    out Device_Type, //// device type
                    out Device_ID, //// device identification number (master)
                    out Device_FW_VER, //// version of firmware
                    out Device_CommSpeed, //// communication speed
                    out ptr_FTDI_Serial, //// FTDI COM port identification
                    out Device_isOpened, //// is Device opened
                    out Device_Status, //// actual device status
                    out System_Status //// actual system status
                );
            } while ((status == DL_STATUS.RESOURCE_BUSY) && (i++ < MAX_RETRY_IF_BUSY));
            Device_Serial = Marshal.PtrToStringAnsi(ptr_Device_Serial);
            FTDI_Serial = Marshal.PtrToStringAnsi(ptr_FTDI_Serial);
            return status;
        }

        //--------------------------------------------------------------------------------------------------------------

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, EntryPoint = "AIS_Open")]
        private static extern DL_STATUS Open(HND_AIS hnd_device);
        public static DL_STATUS AIS_Open(HND_AIS hnd_device)
        {
            DL_STATUS status = DL_STATUS.DL_OK;
            UInt32 i = 0;

            do
            {
                status = Open(hnd_device);
            }
            while ((status == DL_STATUS.RESOURCE_BUSY) && (i++ < MAX_RETRY_IF_BUSY));
            return status;
        }

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, EntryPoint = "AIS_Close")]
        private static extern DL_STATUS Close(HND_AIS hnd_device);
        public static DL_STATUS AIS_Close(HND_AIS hnd_device)
        {
            DL_STATUS status = DL_STATUS.DL_OK;
            UInt32 i = 0;

            do
            {
                status = Close(hnd_device);
            }
            while ((status == DL_STATUS.RESOURCE_BUSY) && (i++ < MAX_RETRY_IF_BUSY));
            return status;
        }

        // kill object
        [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, EntryPoint = "AIS_Destroy")]
        private static extern DL_STATUS Destroy(HND_AIS hnd_device);
        public static DL_STATUS AIS_Destroy(HND_AIS hnd_device)
        {
            DL_STATUS status = DL_STATUS.DL_OK;
            UInt32 i = 0;

            do
            {
                status = Destroy(hnd_device);
            }
            while ((status == DL_STATUS.RESOURCE_BUSY) && (i++ < MAX_RETRY_IF_BUSY));
            return status;
        }

        // global reset service / DLL
        [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, EntryPoint = "AIS_Restart")]
        private static extern DL_STATUS Restart(HND_AIS hnd_device);
        public static DL_STATUS AIS_Restart(HND_AIS hnd_device)
        {
            DL_STATUS status = DL_STATUS.DL_OK;
            UInt32 i = 0;

            do
            {
                status = Restart(hnd_device);
            }
            while ((status == DL_STATUS.RESOURCE_BUSY) && (i++ < MAX_RETRY_IF_BUSY));
            return status;
        }

        //--------------------------------------------------------------------------------------------------------------
        // Info functions:

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, EntryPoint = "AIS_GetVersion")]
        private static extern DL_STATUS GetVersion(
                HND_AIS hnd_device,
                out UInt32 hardware_type, // hardware type
                out UInt32 firmware_version // firmware version
                );
        public static DL_STATUS AIS_GetVersion(
                HND_AIS hnd_device,
                out UInt32 hardware_type, // hardware type
                out UInt32 firmware_version // firmware version
                )
        {
            DL_STATUS status = DL_STATUS.DL_OK;
            UInt32 i = 0;

            do
            {
                status = GetVersion(
                    hnd_device,
                    out hardware_type,
                    out firmware_version);
            }
            while ((status == DL_STATUS.RESOURCE_BUSY) && (i++ < MAX_RETRY_IF_BUSY));
            return status;
        }

        //--------------------------------------------------------------------------------------------------------------
        // Main pump:

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, EntryPoint = "AIS_MainLoop")]
        private static extern DL_STATUS MainLoop(
            HND_AIS hnd_device,
            out UInt32 RealTimeEvents, // indicate new RealTimeEvent(s)
            out UInt32 LogEvent, // indicate new data in log buffer
            out UInt32 cmdFinished, // indicate command finish
            out UInt32 cmdPercent, // indicate percent of command execution
            out UInt32 TimeoutOccurred, // debug only
            out DL_STATUS Status // additional status
            );
        public static DL_STATUS AIS_MainLoop(
            HND_AIS hnd_device,
            out UInt32 RealTimeEvents, // indicate new RealTimeEvent(s)
            out bool LogEvent, // indicate new data in log buffer
            out bool CmdFinished, // indicate command finish
            out UInt32 CmdPercent, // indicate percent of command execution
            out bool TimeoutOccurred, // debug only
            out DL_STATUS Status // additional status
            )
        {
            DL_STATUS status = DL_STATUS.DL_OK;
            UInt32 i = 0, uiLogEvent, uiCmdFinished, uiTimeoutOccurred;

            do
            {
                status = MainLoop(
                    hnd_device,
                    out RealTimeEvents,
                    out uiLogEvent,
                    out uiCmdFinished,
                    out CmdPercent,
                    out uiTimeoutOccurred,
                    out Status);

                LogEvent = uiLogEvent != 0;
                CmdFinished = uiCmdFinished != 0;
                TimeoutOccurred = uiTimeoutOccurred != 0;
            }
            while ((status == DL_STATUS.RESOURCE_BUSY) && (i++ < MAX_RETRY_IF_BUSY));
            return status;
        }

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, EntryPoint = "AIS_DoCmd")]
        private static extern DL_STATUS DoCmd(
            HND_AIS device,
            out Int32 cmd_finish, // bool
            out UInt32 percent);
        public static DL_STATUS AIS_DoCmd(
            HND_AIS device,
            out bool cmd_finish,
            out UInt32 percent)
        {
            DL_STATUS status = DL_STATUS.DL_OK;
            UInt32 i = 0;
            Int32 lib_cmd_finish;

            do
            {
                status = DoCmd(device, out lib_cmd_finish, out percent);
            }
            while ((status == DL_STATUS.RESOURCE_BUSY) && (i++ < MAX_RETRY_IF_BUSY));
            cmd_finish = lib_cmd_finish != 0;
            return status;
        }

        //--------------------------------------------------------------------------------------------------------------
        // Change password:

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, EntryPoint = "AIS_ChangePassword")]
        private static extern DL_STATUS ChangePassword(
            HND_AIS device,
            StringBuilder str_old_password,
            StringBuilder str_new_password);
        public static DL_STATUS AIS_ChangePassword(
            HND_AIS device,
            string str_old_password,
            string str_new_password)
        {
            DL_STATUS status = DL_STATUS.DL_OK;
            UInt32 i = 0;
            StringBuilder ptr_old_password = new StringBuilder(str_old_password);
            StringBuilder ptr_new_password = new StringBuilder(str_new_password);

            do
            {
                status = ChangePassword(device, ptr_old_password, ptr_new_password);
            }
            while ((status == DL_STATUS.RESOURCE_BUSY) && (i++ < MAX_RETRY_IF_BUSY));
            return status;
        }
        //--------------------------------------------------------------------------------------------------------------
        // Info functions:

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, EntryPoint = "AIS_GetFTDISerial")]
        private static extern DL_STATUS GetFTDISerial(HND_AIS device, out IntPtr p_p_ftdi_serial);
        public static DL_STATUS AIS_GetFTDISerial(HND_AIS device, out string ftdi_serial)
        {
            IntPtr ptr;
            DL_STATUS status = DL_STATUS.DL_OK;
            UInt32 i = 0;

            do
            {
                status = GetFTDISerial(device, out ptr);
            }
            while ((status == DL_STATUS.RESOURCE_BUSY) && (i++ < MAX_RETRY_IF_BUSY));
            ftdi_serial = Marshal.PtrToStringAnsi(ptr);
            return status;
        }

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, EntryPoint = "AIS_BatteryGetInfo")]
        private static extern DL_STATUS BatteryGetInfo(
            HND_AIS device,
            out UInt32 battery_status,
            out UInt32 battery_available_percent);
        public static DL_STATUS AIS_BatteryGetInfo(
            HND_AIS device,
            out UInt32 battery_status,
            out UInt32 battery_available_percent)
        {
            DL_STATUS status = DL_STATUS.DL_OK;
            UInt32 i = 0;

            do
            {
                status = BatteryGetInfo(device, out battery_status, out battery_available_percent);
            }
            while ((status == DL_STATUS.RESOURCE_BUSY) && (i++ < MAX_RETRY_IF_BUSY));
            return status;
        }

        //--------------------------------------------------------------------------------------------------------------
        // Time functions:

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, EntryPoint = "AIS_GetTime")]
        private static extern DL_STATUS GetTime(HND_AIS device, out UInt64 unixTime, out Int32 timezone, out Int32 dst, out Int32 dst_bias); // timezone and dst_bias in min.
        public static DL_STATUS AIS_GetTime(HND_AIS device, out DateTime date_time, out Int32 timezone, out bool is_dst, out Int32 dst_bias)
        {
            DL_STATUS status = DL_STATUS.DL_OK;
            UInt32 i = 0;
            DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            UInt64 unixTime;
            Int32 dst;

            do
            {
                status = GetTime(device, out unixTime, out timezone, out dst, out dst_bias);
            }
            while ((status == DL_STATUS.RESOURCE_BUSY) && (i++ < MAX_RETRY_IF_BUSY));
            is_dst = dst != 0;
            date_time = DateTime.SpecifyKind(epoch.AddSeconds(unixTime), DateTimeKind.Utc);
            return status;
        }

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, EntryPoint = "AIS_SetTime")]
        private static extern DL_STATUS SetTime(
            HND_AIS device,
            StringBuilder password,
            UInt64 unixTime);
        public static DL_STATUS AIS_SetTime(
            HND_AIS device,
            string str_password,
            DateTime date_time) 
        {
            DL_STATUS status = DL_STATUS.DL_OK;
            UInt32 i = 0;
            DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            TimeSpan span = (date_time - epoch);
            UInt64 unixTime = (UInt64)span.TotalSeconds;

            StringBuilder password = new StringBuilder(str_password);
            do
            {
                status = SetTime(device, password, unixTime);
            }
            while ((status == DL_STATUS.RESOURCE_BUSY) && (i++ < MAX_RETRY_IF_BUSY));
            return status;
        }

        //--------------------------------------------------------------------------------------------------------------
        // RTE functions

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, EntryPoint = "AIS_ReadRTE_Count")]
        public static extern Int32 AIS_ReadRTE_Count(HND_AIS device);

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, EntryPoint = "AIS_ReadRTE")]
        private static extern DL_STATUS ReadRTE(
                HND_AIS device,
                out UInt32 log_index,
                out UInt32 log_action,
                out UInt32 log_reader_id,
                out UInt32 log_card_id,
                out UInt32 log_system_id,
                [In, Out] byte[] nfc_uid, // NFC_UID_MAX_LEN = 10
                out UInt32 nfc_uid_len,
                out UInt64 unixTime // time_t
            );
        public static DL_STATUS AIS_ReadRTE(
                HND_AIS device,
                out UInt32 log_index,
                out UInt32 log_action,
                out UInt32 log_reader_id,
                out UInt32 log_card_id,
                out UInt32 log_system_id,
                [In, Out] byte[] nfc_uid, // NFC_UID_MAX_LEN = 10
                out UInt32 nfc_uid_len,
                out DateTime date_time
            )
        {
            DL_STATUS status = DL_STATUS.DL_OK;
            UInt32 i = 0;
            DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            UInt64 unixTime;

            do
            {
                status = ReadRTE(device, out log_index, out log_action, out log_reader_id,
                                out log_card_id, out log_system_id, nfc_uid, out nfc_uid_len, out unixTime);
            }
            while ((status == DL_STATUS.RESOURCE_BUSY) && (i++ < MAX_RETRY_IF_BUSY));
            date_time = epoch.AddSeconds(unixTime);
            return status;
        }

        //--------------------------------------------------------------------------------------------------------------
        // LOG functions

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, EntryPoint = "AIS_GetLog")]
        private static extern DL_STATUS GetLog(HND_AIS device, StringBuilder password);
        public static DL_STATUS AIS_GetLog(HND_AIS device, string str_password)
        {
            DL_STATUS status = DL_STATUS.DL_OK;
            UInt32 i = 0;
            StringBuilder password = new StringBuilder(str_password);

            do
            {
                status = GetLog(device, password);
            }
            while ((status == DL_STATUS.RESOURCE_BUSY) && (i++ < MAX_RETRY_IF_BUSY));
            return status;
        }

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, EntryPoint = "AIS_GetLog_Set")]
        private static extern DL_STATUS GetLog_Set(HND_AIS device, StringBuilder password);
        public static DL_STATUS AIS_GetLog_Set(HND_AIS device, string str_password)
        {
            DL_STATUS status = DL_STATUS.DL_OK;
            UInt32 i = 0;
            StringBuilder password = new StringBuilder(str_password);

            do
            {
                status = GetLog_Set(device, password);
            }
            while ((status == DL_STATUS.RESOURCE_BUSY) && (i++ < MAX_RETRY_IF_BUSY));
            return status;
        }

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, EntryPoint = "AIS_GetLogByIndex")]
        private static extern DL_STATUS GetLogByIndex(HND_AIS device, StringBuilder password,
                                                      UInt32 start_index, UInt32 end_index);
        public static DL_STATUS AIS_GetLogByIndex(HND_AIS device, string str_password,
                                                  UInt32 start_index, UInt32 end_index)
        {
            DL_STATUS status = DL_STATUS.DL_OK;
            UInt32 i = 0;
            StringBuilder password = new StringBuilder(str_password);

            do
            {
                status = GetLogByIndex(device, password, start_index, end_index);
            }
            while ((status == DL_STATUS.RESOURCE_BUSY) && (i++ < MAX_RETRY_IF_BUSY));
            return status;
        }

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, EntryPoint = "AIS_ClearLog")]
        public static extern DL_STATUS AIS_ClearLog(HND_AIS device);

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, EntryPoint = "AIS_ReadLog_Count")]
        public static extern UInt32 AIS_ReadLog_Count(HND_AIS device);

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, EntryPoint = "AIS_ReadLog")]
        private static extern DL_STATUS ReadLog(
                HND_AIS device,
                out UInt32 log_index,
                out UInt32 log_action,
                out UInt32 log_reader_id,
                out UInt32 log_card_id,
                out UInt32 log_system_id,
                [In, Out] byte[] nfc_uid, // NFC_UID_MAX_LEN = 10
                out UInt32 nfc_uid_len,
                out UInt64 unixTime // time_t
                );
        public static DL_STATUS AIS_ReadLog(
                HND_AIS device,
                out UInt32 log_index,
                out UInt32 log_action,
                out UInt32 log_reader_id,
                out UInt32 log_card_id,
                out UInt32 log_system_id,
                [In, Out] byte[] nfc_uid, // NFC_UID_MAX_LEN = 10
                out UInt32 nfc_uid_len,
                out DateTime date_time
           )
        {
            DL_STATUS status = DL_STATUS.DL_OK;
            UInt32 i = 0;
            DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            UInt64 unixTime;

            do
            {
                status = ReadLog(device, out log_index, out log_action, out log_reader_id,
                                out log_card_id, out log_system_id, nfc_uid, out nfc_uid_len, out unixTime);
            }
            while ((status == DL_STATUS.RESOURCE_BUSY) && (i++ < MAX_RETRY_IF_BUSY));
            date_time = epoch.AddSeconds(unixTime);
            return status;
        }

        //--------------------------------------------------------------------------------------------------------------
        // Blacklist functions

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, EntryPoint = "AIS_Blacklist_Write")]
        private static extern DL_STATUS Blacklist_Write(HND_AIS device, StringBuilder password,
                                                        StringBuilder csv_blacklist);
        public static DL_STATUS AIS_Blacklist_Write(HND_AIS device, string str_password, string str_csv_blacklist)
        {
            DL_STATUS status = DL_STATUS.DL_OK;
            UInt32 i = 0;
            StringBuilder password = new StringBuilder(str_password);
            StringBuilder csv_blacklist = new StringBuilder(str_csv_blacklist);

            do
            {
                status = Blacklist_Write(device, password, csv_blacklist);
            }
            while ((status == DL_STATUS.RESOURCE_BUSY) && (i++ < MAX_RETRY_IF_BUSY));
            return status;
        }

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, EntryPoint = "AIS_Blacklist_GetSize")]
        private static extern DL_STATUS Blacklist_GetSize(HND_AIS device, StringBuilder password, out Int32 size);
        public static DL_STATUS AIS_Blacklist_GetSize(HND_AIS device, string str_password, out Int32 size)
        {
            DL_STATUS status = DL_STATUS.DL_OK;
            UInt32 i = 0;
            StringBuilder password = new StringBuilder(str_password);

            do
            {
                status = Blacklist_GetSize(device, password, out size);
            }
            while ((status == DL_STATUS.RESOURCE_BUSY) && (i++ < MAX_RETRY_IF_BUSY));
            return status;
        }

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, EntryPoint = "AIS_Blacklist_Read")]
        public static extern DL_STATUS AIS_Blacklist_Read(HND_AIS device, StringBuilder csv_blacklist);

        //--------------------------------------------------------------------------------------------------------------
        // WhiteList functions
        /**
         *
         * @param device : see info about device handle
         * @param password : see info about password
         * @param str_csv_whitelist : eg. "54:A3:34:12, 12.34.56.78, 01234567"
         * 			HEX pairs in UID can be delimited with: ':' or '.' or none
         * 			UID separators: ',' or ';' or other white space
         * 			! NULL or blank string erase white list in device
         * @return
         */
        [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, EntryPoint = "AIS_Whitelist_Write")]
        private static extern DL_STATUS Whitelist_Write(HND_AIS device, StringBuilder str_password, StringBuilder whitelist);
        public static DL_STATUS AIS_Whitelist_Write(HND_AIS device, string str_password, string str_whitelist)
        {
            DL_STATUS status = DL_STATUS.DL_OK;
            UInt32 i = 0;
            StringBuilder password = new StringBuilder(str_password);
            StringBuilder whitelist = new StringBuilder(str_whitelist);

            do
            {
                status = Whitelist_Write(device, password, whitelist);
            }
            while ((status == DL_STATUS.RESOURCE_BUSY) && (i++ < MAX_RETRY_IF_BUSY));
            return status;
        }

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, EntryPoint = "AIS_Whitelist_Read")]
        private static extern DL_STATUS Whitelist_Read(HND_AIS device, StringBuilder password, out IntPtr ptr_whitelist);
        public static DL_STATUS AIS_Whitelist_Read(HND_AIS device, string str_password, out string str_whitelist)
        {
            DL_STATUS status = DL_STATUS.DL_OK;
            UInt32 i = 0;
            StringBuilder password = new StringBuilder(str_password);
            IntPtr ptr_whitelist;

            do
            {
                status = Whitelist_Read(device, password, out ptr_whitelist);
            }
            while ((status == DL_STATUS.RESOURCE_BUSY) && (i++ < MAX_RETRY_IF_BUSY));

            str_whitelist = Marshal.PtrToStringAnsi(ptr_whitelist); ;
            return status;
        }

        //--------------------------------------------------------------------------------------------------------------
        // XRCA Base HD SDK

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, EntryPoint = "AIS_LockOpen")]
        public static extern DL_STATUS AIS_LockOpen(HND_AIS device, UInt32 pulse_duration);

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, EntryPoint = "AIS_RelayStateSet")]
        public static extern DL_STATUS AIS_RelayStateSet(HND_AIS device, UInt32 state);

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, EntryPoint = "AIS_GetIoState")]
        public static extern DL_STATUS AIS_GetIoState(HND_AIS device, out UInt32 intercom, out UInt32 door, out UInt32 relay_state);

        /**
         *
         * set value for light: 0 = off, not null = on
         * @param device
         * @param green_master control green light on master unit
         * @param red_master control red light on master unit
         * @param green_slave control green light on slave unit
         * @param red_slave control red light on slave unit
         * @return
         */
        [DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall, EntryPoint = "AIS_LightControl")]
        public static extern DL_STATUS AIS_LightControl(HND_AIS device,
                                                        UInt32 green_master, UInt32 red_master,
                                                        UInt32 green_slave, UInt32 red_slave);

        //--------------------------------------------------------------------------------------------------------------
    }
}
