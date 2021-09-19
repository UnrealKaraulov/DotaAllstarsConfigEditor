using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using IniParser;
using IniParser.Model;

namespace DotaAllstarsConfigEditor
{
    public partial class ConfigEditorForm : Form
    {
        public ConfigEditorForm()
        {
            InitializeComponent();
        }


        struct WarkeyData
        {
            public object obj;
            public string name;
            public uint data;
            public bool IsHotkey;
            public bool IsCheckBox;
            public bool IsTextBox;
            public string section;
        }

        List<WarkeyData> WarkeyDataList = new List<WarkeyData>();


        private void ConfigEditorForm_Load(object sender, EventArgs e)
        {
            WarkeyData tmpWarkeyData = new WarkeyData();
            tmpWarkeyData.data = 0;
            tmpWarkeyData.IsHotkey = true;
            tmpWarkeyData.IsTextBox = true;
            tmpWarkeyData.IsCheckBox = false;
            tmpWarkeyData.section = "HOTKEYS";


            tmpWarkeyData.obj = DisplayScoreboard;
            tmpWarkeyData.name = "DisplayScoreboard";
            WarkeyDataList.Add(tmpWarkeyData);

            /*warkey*/
            tmpWarkeyData.obj = WarkeySkillQ;
            tmpWarkeyData.name = "BindMove";
            WarkeyDataList.Add(tmpWarkeyData);

            tmpWarkeyData.obj = WarkeySkillW;
            tmpWarkeyData.name = "BindStop";
            WarkeyDataList.Add(tmpWarkeyData);

            tmpWarkeyData.obj = WarkeySkillE;
            tmpWarkeyData.name = "BindHold";
            WarkeyDataList.Add(tmpWarkeyData);

            tmpWarkeyData.obj = WarkeySkillR;
            tmpWarkeyData.name = "BindAttack";
            WarkeyDataList.Add(tmpWarkeyData);

            tmpWarkeyData.obj = WarkeySkillA;
            tmpWarkeyData.name = "BindPatrol";
            WarkeyDataList.Add(tmpWarkeyData);


            tmpWarkeyData.obj = WarkeySkillS;
            tmpWarkeyData.name = "SkillSlot5";
            WarkeyDataList.Add(tmpWarkeyData);


            tmpWarkeyData.obj = WarkeySkillD;
            tmpWarkeyData.name = "SkillSlot6";
            WarkeyDataList.Add(tmpWarkeyData);


            tmpWarkeyData.obj = WarkeySkillF;
            tmpWarkeyData.name = "BindOpenHeroSkills";
            WarkeyDataList.Add(tmpWarkeyData);

            tmpWarkeyData.obj = WarkeySkillZ;
            tmpWarkeyData.name = "SkillSlot1";
            WarkeyDataList.Add(tmpWarkeyData);

            tmpWarkeyData.obj = WarkeySkillX;
            tmpWarkeyData.name = "SkillSlot2";
            WarkeyDataList.Add(tmpWarkeyData);

            tmpWarkeyData.obj = WarkeySkillC;
            tmpWarkeyData.name = "SkillSlot3";
            WarkeyDataList.Add(tmpWarkeyData);

            tmpWarkeyData.obj = WarkeySkillV;
            tmpWarkeyData.name = "SkillSlot4";
            WarkeyDataList.Add(tmpWarkeyData);


            tmpWarkeyData.obj = WarkeyItem7;
            tmpWarkeyData.name = "ItemSlot1";
            WarkeyDataList.Add(tmpWarkeyData);


            tmpWarkeyData.obj = WarkeyItem8;
            tmpWarkeyData.name = "ItemSlot2";
            WarkeyDataList.Add(tmpWarkeyData);


            tmpWarkeyData.obj = WarkeyItem4;
            tmpWarkeyData.name = "ItemSlot3";
            WarkeyDataList.Add(tmpWarkeyData);


            tmpWarkeyData.obj = WarkeyItem5;
            tmpWarkeyData.name = "ItemSlot4";
            WarkeyDataList.Add(tmpWarkeyData);


            tmpWarkeyData.obj = WarkeyItem1;
            tmpWarkeyData.name = "ItemSlot5";
            WarkeyDataList.Add(tmpWarkeyData);


            tmpWarkeyData.obj = WarkeyItem2;
            tmpWarkeyData.name = "ItemSlot6";
            WarkeyDataList.Add(tmpWarkeyData);





            /*autocast*/

            tmpWarkeyData.obj = WarkeySkillZ;
            tmpWarkeyData.name = "ASkillSlot1";
            WarkeyDataList.Add(tmpWarkeyData);

            tmpWarkeyData.obj = WarkeySkillX;
            tmpWarkeyData.name = "ASkillSlot2";
            WarkeyDataList.Add(tmpWarkeyData);

            tmpWarkeyData.obj = WarkeySkillC;
            tmpWarkeyData.name = "ASkillSlot3";
            WarkeyDataList.Add(tmpWarkeyData);

            tmpWarkeyData.obj = WarkeySkillV;
            tmpWarkeyData.name = "ASkillSlot4";
            WarkeyDataList.Add(tmpWarkeyData);

            tmpWarkeyData.obj = WarkeySkillS;
            tmpWarkeyData.name = "ASkillSlot5";
            WarkeyDataList.Add(tmpWarkeyData);

            tmpWarkeyData.obj = WarkeySkillD;
            tmpWarkeyData.name = "ASkillSlot6";
            WarkeyDataList.Add(tmpWarkeyData);




            /*quickcast*/


            tmpWarkeyData.obj = QuickcastSkillZ;
            tmpWarkeyData.name = "QSkillSlot1";
            WarkeyDataList.Add(tmpWarkeyData);

            tmpWarkeyData.obj = QuickcastSkillX;
            tmpWarkeyData.name = "QSkillSlot2";
            WarkeyDataList.Add(tmpWarkeyData);

            tmpWarkeyData.obj = QuickcastSkillC;
            tmpWarkeyData.name = "QSkillSlot3";
            WarkeyDataList.Add(tmpWarkeyData);

            tmpWarkeyData.obj = QuickcastSkillV;
            tmpWarkeyData.name = "QSkillSlot4";
            WarkeyDataList.Add(tmpWarkeyData);

            tmpWarkeyData.obj = QuickcastSkillS;
            tmpWarkeyData.name = "QSkillSlot5";
            WarkeyDataList.Add(tmpWarkeyData);

            tmpWarkeyData.obj = QuickcastSkillD;
            tmpWarkeyData.name = "QSkillSlot6";
            WarkeyDataList.Add(tmpWarkeyData);




            tmpWarkeyData.obj = QuickcastItem7;
            tmpWarkeyData.name = "QItemSlot1";
            WarkeyDataList.Add(tmpWarkeyData);


            tmpWarkeyData.obj = QuickcastItem8;
            tmpWarkeyData.name = "QItemSlot2";
            WarkeyDataList.Add(tmpWarkeyData);


            tmpWarkeyData.obj = QuickcastItem4;
            tmpWarkeyData.name = "QItemSlot3";
            WarkeyDataList.Add(tmpWarkeyData);


            tmpWarkeyData.obj = QuickcastItem5;
            tmpWarkeyData.name = "QItemSlot4";
            WarkeyDataList.Add(tmpWarkeyData);


            tmpWarkeyData.obj = QuickcastItem1;
            tmpWarkeyData.name = "QItemSlot5";
            WarkeyDataList.Add(tmpWarkeyData);


            tmpWarkeyData.obj = QuickcastItem2;
            tmpWarkeyData.name = "QItemSlot6";
            WarkeyDataList.Add(tmpWarkeyData);





            /* other*/



            tmpWarkeyData.obj = DisplayTowerRangeHotkey;
            tmpWarkeyData.name = "DisplayTowerRangeHotkey";
            WarkeyDataList.Add(tmpWarkeyData);

            tmpWarkeyData.obj = DisplayNeutralsSpawnAreaHotkey;
            tmpWarkeyData.name = "DisplayNeutralsSpawnAreaHotkey";
            WarkeyDataList.Add(tmpWarkeyData);


            tmpWarkeyData.IsHotkey = false;


            tmpWarkeyData.section = "GAMEOPTIONS";


            tmpWarkeyData.obj = MaxFPS;
            tmpWarkeyData.name = "MaxFPS";
            WarkeyDataList.Add(tmpWarkeyData);

            tmpWarkeyData.section = "VISUALS";


            tmpWarkeyData.obj = Weather;
            tmpWarkeyData.name = "Weather";
            WarkeyDataList.Add(tmpWarkeyData);

            tmpWarkeyData.section = "ONSTART";

            tmpWarkeyData.obj = StartChatString1;
            tmpWarkeyData.name = "StartChatString1";
            WarkeyDataList.Add(tmpWarkeyData);

            tmpWarkeyData.obj = StartChatString2;
            tmpWarkeyData.name = "StartChatString2";
            WarkeyDataList.Add(tmpWarkeyData);

            tmpWarkeyData.obj = StartChatString3;
            tmpWarkeyData.name = "StartChatString3";
            WarkeyDataList.Add(tmpWarkeyData);

            tmpWarkeyData.obj = StartChatString4;
            tmpWarkeyData.name = "StartChatString4";
            WarkeyDataList.Add(tmpWarkeyData);

            tmpWarkeyData.obj = StartChatString5;
            tmpWarkeyData.name = "StartChatString5";
            WarkeyDataList.Add(tmpWarkeyData);

            tmpWarkeyData.obj = StartChatString6;
            tmpWarkeyData.name = "StartChatString6";
            WarkeyDataList.Add(tmpWarkeyData);

            tmpWarkeyData.obj = StartChatString7;
            tmpWarkeyData.name = "StartChatString7";
            WarkeyDataList.Add(tmpWarkeyData);

            tmpWarkeyData.obj = StartChatString8;
            tmpWarkeyData.name = "StartChatString8";
            WarkeyDataList.Add(tmpWarkeyData);

            tmpWarkeyData.obj = StartChatString9;
            tmpWarkeyData.name = "StartChatString9";
            WarkeyDataList.Add(tmpWarkeyData);

            tmpWarkeyData.obj = StartChatString10;
            tmpWarkeyData.name = "StartChatString10";
            WarkeyDataList.Add(tmpWarkeyData);

            tmpWarkeyData.obj = StartChatString11;
            tmpWarkeyData.name = "StartChatString11";
            WarkeyDataList.Add(tmpWarkeyData);

            tmpWarkeyData.obj = StartChatString12;
            tmpWarkeyData.name = "StartChatString12";
            WarkeyDataList.Add(tmpWarkeyData);

            tmpWarkeyData.obj = StartChatString13;
            tmpWarkeyData.name = "StartChatString13";
            WarkeyDataList.Add(tmpWarkeyData);

            tmpWarkeyData.obj = StartChatString14;
            tmpWarkeyData.name = "StartChatString14";
            WarkeyDataList.Add(tmpWarkeyData);

            tmpWarkeyData.obj = StartChatString15;
            tmpWarkeyData.name = "StartChatString15";
            WarkeyDataList.Add(tmpWarkeyData);

            tmpWarkeyData.IsTextBox = false;
            tmpWarkeyData.IsCheckBox = true;
            tmpWarkeyData.section = "HOTKEYS";

            tmpWarkeyData.obj = ShopsQWERTY;
            tmpWarkeyData.name = "ShopsQWERTY";
            WarkeyDataList.Add(tmpWarkeyData);

            tmpWarkeyData.section = "GAMEOPTIONS";


            tmpWarkeyData.obj = AutoFPSLimit;
            tmpWarkeyData.name = "AutoFPSLimit";
            WarkeyDataList.Add(tmpWarkeyData);



            tmpWarkeyData.obj = LockMouseAtWindow;
            tmpWarkeyData.name = "LockMouseAtWindow";
            WarkeyDataList.Add(tmpWarkeyData);

            tmpWarkeyData.obj = AutoselectHero;
            tmpWarkeyData.name = "AutoselectHero";
            WarkeyDataList.Add(tmpWarkeyData);

            tmpWarkeyData.obj = DotA2HPBars;
            tmpWarkeyData.name = "DotA2HPBars";
            WarkeyDataList.Add(tmpWarkeyData);


            tmpWarkeyData.obj = DisplayManabars;
            tmpWarkeyData.name = "DisplayManabars";
            WarkeyDataList.Add(tmpWarkeyData);


            tmpWarkeyData.obj = WideScreen;
            tmpWarkeyData.name = "WideScreen";
            WarkeyDataList.Add(tmpWarkeyData);


            tmpWarkeyData.obj = TeleportationCanOnlyBeStoppedSoft;
            tmpWarkeyData.name = "TeleportationCanOnlyBeStoppedSoft";
            WarkeyDataList.Add(tmpWarkeyData);


            tmpWarkeyData.obj = TeleportationCanOnlyBeStopped;
            tmpWarkeyData.name = "TeleportationCanOnlyBeStopped";
            WarkeyDataList.Add(tmpWarkeyData);


            tmpWarkeyData.obj = CloseWC3EveryGame;
            tmpWarkeyData.name = "CloseWC3EveryGame";
            WarkeyDataList.Add(tmpWarkeyData);


            tmpWarkeyData.obj = DoubleClickHelperEnabled;
            tmpWarkeyData.name = "DoubleClickHelperEnabled";
            WarkeyDataList.Add(tmpWarkeyData);


            tmpWarkeyData.section = "VISUALS";


            tmpWarkeyData.obj = AlwaysDisplayRangeMarkers;
            tmpWarkeyData.name = "AlwaysDisplayRangeMarkers";
            WarkeyDataList.Add(tmpWarkeyData);

            tmpWarkeyData.obj = RepeatGameMessagesIntoChatLog;
            tmpWarkeyData.name = "RepeatGameMessagesIntoChatLog";
            WarkeyDataList.Add(tmpWarkeyData);

            tmpWarkeyData.obj = AlwaysDisplayHPRegen;
            tmpWarkeyData.name = "AlwaysDisplayHPRegen";
            WarkeyDataList.Add(tmpWarkeyData);

            tmpWarkeyData.obj = SameSelectionCircleForEveryone;
            tmpWarkeyData.name = "SameSelectionCircleForEveryone";
            WarkeyDataList.Add(tmpWarkeyData);

            tmpWarkeyData.obj = AdvancedTooltips;
            tmpWarkeyData.name = "AdvancedTooltips";
            WarkeyDataList.Add(tmpWarkeyData);

            tmpWarkeyData.obj = CustomFPSInfo;
            tmpWarkeyData.name = "CustomFPSInfo";
            WarkeyDataList.Add(tmpWarkeyData);

            tmpWarkeyData.obj = EscClearsChat;
            tmpWarkeyData.name = "EscClearsChat";
            WarkeyDataList.Add(tmpWarkeyData);

            tmpWarkeyData.obj = EscClearsPlayersChat;
            tmpWarkeyData.name = "EscClearsPlayersChat";
            WarkeyDataList.Add(tmpWarkeyData);

            tmpWarkeyData.obj = GoodMinimap;
            tmpWarkeyData.name = "GoodMinimap";
            WarkeyDataList.Add(tmpWarkeyData);

            tmpWarkeyData.obj = ProperColorsForCreeps;
            tmpWarkeyData.name = "ProperColorsForCreeps";
            WarkeyDataList.Add(tmpWarkeyData);

            tmpWarkeyData.obj = AlliesAlwaysGreen;
            tmpWarkeyData.name = "AlliesAlwaysGreen";
            WarkeyDataList.Add(tmpWarkeyData);

            tmpWarkeyData.obj = BetterFPS;
            tmpWarkeyData.name = "BetterFPS";
            WarkeyDataList.Add(tmpWarkeyData);

            tmpWarkeyData.obj = DisableDefaultSpace;
            tmpWarkeyData.name = "DisableDefaultSpace";
            WarkeyDataList.Add(tmpWarkeyData);

            tmpWarkeyData.obj = DisableDefaultMouseWheel;
            tmpWarkeyData.name = "DisableDefaultMouseWheel";
            WarkeyDataList.Add(tmpWarkeyData);


            LoadConfig();
        }

        string ConfNotFound = "Configuration file not found!";
        string ConfReadBadFound = "Error while read config file!";
        string ConfWriteBadFound = "Error write config file!";

        void LoadConfig()
        {
            if (File.Exists(DotaConfigPath.Text))
            {
                string[] configdata = File.ReadAllLines(DotaConfigPath.Text);
                for(int i = 0; i < configdata.Length;i++)
                {
                    configdata[i] =  Regex.Replace(configdata[i], "(^\\s*)#(.*)", "$1;$2");
                }
                File.WriteAllLines(DotaConfigPath.Text, configdata);
            }
            if (File.Exists(DotaConfigPath.Text))
            {
                FileIniDataParser parser = new FileIniDataParser();
                // Создать хранилище INI данных 
                IniData data = new IniData();

                // Загрузить в data файл LauncherConfig.ini
                // try
                // {
                data = parser.ReadFile(DotaConfigPath.Text);
                // }
                // catch
                // {
                // MessageBox.Show(ConfReadBadFound);
                // return;
                //  }

                foreach (var x in WarkeyDataList)
                {
                    if (x.IsHotkey)
                    {
                        TextBox curitem = x.obj as TextBox;
                        try
                        {
                            curitem.Text = KeyHelperForDota.MyKeyToStr(Convert.ToUInt32(data[x.section][x.name], 16));
                        }
                        catch
                        {
                            curitem.Text = "";
                        }
                    }
                    else
                    {
                        if (x.IsTextBox)
                        {
                            TextBox curitem = x.obj as TextBox;
                            try
                            {
                                curitem.Text = data[x.section][x.name];
                            }
                            catch
                            {
                                curitem.Text = "";
                            }
                        }
                        else if (x.IsCheckBox)
                        {
                            CheckBox curitem = x.obj as CheckBox;
                            try
                            {
                                curitem.Checked = data[x.section][x.name] != "false";
                            }
                            catch
                            {
                                curitem.Checked = false;
                            }
                        }

                    }
                }

            }
            else
            {
                // MessageBox.Show(ConfNotFound);
            }
        }


        void ProcessKeyEvent(TextBox sender, MouseEventArgs mouse, KeyEventArgs keyboard, int keycount = 2)
        {
            sender.Text = KeyHelperForDota.KeyAllKeys(keycount);

            bool skipkey = false;
            if (mouse != null && KeyHelperForDota.latestkeycount == 1 && mouse.Button == MouseButtons.Left)
            {
                sender.Text = "";
                skipkey = true;
            }

            if (mouse == null && keyboard == null)
                skipkey = true;

            foreach (var x in WarkeyDataList)
            {
                if (x.obj == sender)
                {
                    try
                    {
                        FileIniDataParser parser = new FileIniDataParser();
                        // Создать хранилище INI данных 
                        IniData data = new IniData();

                        // Загрузить в data файл LauncherConfig.ini
                        // try
                        // {
                        data = parser.ReadFile(DotaConfigPath.Text);

                        if (skipkey)
                        {
                            data[x.section][x.name] = "";
                        }
                        else
                        {
                            data[x.section][x.name] = "0x" + KeyHelperForDota.KeyAllKeys_code(keycount).ToString( "X4" );
                        }
                        parser.WriteFile(DotaConfigPath.Text, data, Encoding.UTF8);
                    }
                    catch
                    {
                        MessageBox.Show(ConfWriteBadFound);
                    }
                }

            }
        }


        private void Warkey_MouseDown(object sender, MouseEventArgs e)
        {
            ProcessKeyEvent(sender as TextBox, e, null);
        }

        private void Warkey_KeyDown(object sender, KeyEventArgs e)
        {
            ProcessKeyEvent(sender as TextBox, null, e);
        }


        private void SingleKey_MouseDown(object sender, MouseEventArgs e)
        {
            ProcessKeyEvent(sender as TextBox, e, null, 1);
        }

        private void SingleKey_KeyDown(object sender, KeyEventArgs e)
        {
            ProcessKeyEvent(sender as TextBox, null, e, 1);
        }

        private void SaveTextValue(object sender, EventArgs e)
        {
            foreach (var x in WarkeyDataList)
            {
                if (x.obj == sender)
                {
                    try
                    {
                        FileIniDataParser parser = new FileIniDataParser();
                        // Создать хранилище INI данных 
                        IniData data = new IniData();

                        // Загрузить в data файл LauncherConfig.ini
                        // try
                        // {
                        data = parser.ReadFile(DotaConfigPath.Text);

                        data[x.section][x.name] = (sender as TextBox).Text;

                        parser.WriteFile(DotaConfigPath.Text, data, Encoding.UTF8);
                    }
                    catch
                    {
                        MessageBox.Show(ConfWriteBadFound);
                    }
                }

            }
        }

        private void ConfigBooleanValueCheckedChanged(object sender, EventArgs e)
        {
            foreach (var x in WarkeyDataList)
            {
                if (x.obj == sender)
                {
                    try
                    {
                        FileIniDataParser parser = new FileIniDataParser();
                        // Создать хранилище INI данных 
                        IniData data = new IniData();

                        // Загрузить в data файл LauncherConfig.ini
                        // try
                        // {
                        data = parser.ReadFile(DotaConfigPath.Text);

                        data[x.section][x.name] = (sender as CheckBox).Checked ? "true" : "false";

                        parser.WriteFile(DotaConfigPath.Text, data, Encoding.UTF8);
                    }
                    catch
                    {
                        MessageBox.Show(ConfWriteBadFound);
                    }
                }

            }
        }

        string ConfirmConfigClean = "Are you sure you want to clear the configuration file?";
        string WarningMessage = "Warning!";

        private void ClearDotaConfig_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(ConfirmConfigClean, WarningMessage, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                
                foreach (var x in WarkeyDataList)
                {
                    if (x.IsHotkey)
                    {
                        TextBox curitem = x.obj as TextBox;
                        curitem.Text = "";
                        ProcessKeyEvent(curitem, null, null);
                    }
                    else
                    {
                        if (x.IsTextBox)
                        {
                            TextBox curitem = x.obj as TextBox;
                            curitem.Text = "";
                        }
                        else if (x.IsCheckBox)
                        {
                            CheckBox curitem = x.obj as CheckBox;
                            curitem.Checked = false;
                        }
                    }
                }
            }
        }

        private void LoadDotaConfig_Click(object sender, EventArgs e)
        {
            LoadConfig();
        }
    }


    public class KeyHelperForDota
    {

        [DllImport("User32.dll")]
        private static extern short GetAsyncKeyState(int vKey);

        public static int latestkeycount = 0;
        public static string KeyAllKeys(int max)
        {
            latestkeycount = 0;
            string keyBuffer = string.Empty;
            bool pressed = false;
            for (int i = 0; i < 255; i++)
            {
                if (i == (int)Keys.ShiftKey)
                    continue;
                if (i == (int)Keys.Menu)
                    continue;
                if (i == (int)Keys.ControlKey)
                    continue;



                short x = GetAsyncKeyState(i);
                if ((x & 0x8000) > 0)
                {
                    if (i == (int)Keys.LShiftKey)
                    {
                        keyBuffer = "SHIFT+" + keyBuffer;
                    }
                    else if (i == (int)Keys.LMenu)
                    {
                        keyBuffer = "ALT+" + keyBuffer;
                    }
                    else if (i == (int)Keys.LControlKey)
                    {
                        keyBuffer = "CTRL+" + keyBuffer;
                    }
                    else
                    {
                        if (!pressed)
                        {
                            pressed = true;
                            keyBuffer = Enum.GetName(typeof(Keys), i) + "+" + keyBuffer;
                        }
                    }
                    latestkeycount++;
                    max--;
                    if (max == 0)
                        break;
                }

            }

            if (keyBuffer.Length > 1)
            {
                keyBuffer = keyBuffer.Remove(keyBuffer.Length - 1);
            }
            return keyBuffer;
        }


        public static string MyKeyToStr(uint val)
        {
            if (val == 0)
            {
                return string.Empty;
            }
            string keyBuffer = string.Empty;

            if ((val & 0x40000) > 0)
            {
                keyBuffer = "SHIFT+";
            }
            if ((val & 0x10000) > 0)
            {
                keyBuffer = "ALT+";
            }
            if ((val & 0x20000) > 0)
            {
                keyBuffer = "CTRL+";
            }

            int KeyVal = (int)(val & 0xFF);

            keyBuffer += Enum.GetName(typeof(Keys), KeyVal);

            return keyBuffer;
        }

        public static uint KeyAllKeys_code(int max)
        {
            uint code = 0;
            latestkeycount = 0;
            for (int i = 0; i < 255; i++)
            {
                if (i == (int)Keys.ShiftKey)
                    continue;
                if (i == (int)Keys.Menu)
                    continue;
                if (i == (int)Keys.ControlKey)
                    continue;



                short x = GetAsyncKeyState(i);
                if ((x & 0x8000) > 0)
                {
                    if (i == (int)Keys.LShiftKey)
                    {
                        code += 0x40000;
                    }
                    else if (i == (int)Keys.LMenu)
                    {
                        code += 0x10000;
                    }
                    else if (i == (int)Keys.LControlKey)
                    {
                        code += 0x20000;
                    }
                    else
                    {
                        if ((code & 0xFF) == 0)
                            code += (uint)i;
                    }
                    latestkeycount++;
                    max--;
                    if (max == 0)
                        break;
                }

            }

            return code;
        }
        // Karaulov 2017-....
    }
}
