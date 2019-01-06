// Type: IniFileController.IniFileController
// Assembly: IniFileController, Version=1.0.1613.20860, Culture=neutral, PublicKeyToken=null
// MVID: 97F3BB47-0524-45E8-BD51-FFC7C05431FD
// Assembly location: C:\Users\abrahamm\Documents\Visual Studio 2012\Projects2\Facturacion\Timbrado Nomina\TimbradoNomina\bin\Debug\IniFileController.dll

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;

namespace Ini
{
    public class IniFileController
    {
        private IniFileController.EntryPair[] Entries;
        private short EntryCount;
        private bool MyIniIsOpen;
        private string MyIniFilePath;

        public bool IniIsOpen
        {
            get
            {
                return this.MyIniIsOpen;
            }
        }

        public string IniFilePath
        {
            get
            {
                return this.MyIniFilePath;
            }
        }

        public IniFileController()
        {
            this.Class_Initialize_Renamed();
        }

        public void AddEntry(string newKeyword, string newValue)
        {
            short num1 = checked((short)FileSystem.FreeFile());
            bool flag = false;
            if (!this.MyIniIsOpen)
                return;
            FileSystem.FileOpen((int)num1, this.MyIniFilePath, OpenMode.Input, OpenAccess.Read, OpenShare.Default, -1);
            while (!FileSystem.EOF((int)num1))
            {
                string str = Strings.Trim(FileSystem.LineInput((int)num1));
                if (StringType.StrCmp(str, "", false) != 0)
                {
                    short num2 = checked((short)Strings.InStr(str, "=", CompareMethod.Binary));
                    if (StringType.StrCmp(newKeyword, Strings.Left(str, checked((int)num2 - 1)), false) == 0)
                    {
                        flag = true;
                        break;
                    }
                }
            }
            FileSystem.FileClose(new int[1] { (int)num1 });
            if (!flag)
            {
                short num2 = checked((short)FileSystem.FreeFile());
                FileSystem.FileOpen((int)num2, this.MyIniFilePath, OpenMode.Append, OpenAccess.Write, OpenShare.Default, -1);
                FileSystem.PrintLine((int)num2, new object[1]
        {
          (object) (newKeyword + "=" + newValue)
        });
                FileSystem.FileClose(new int[1]
        {
          (int) num2
        });
            }
        }

        public void RemoveEntry(string whatKeyword)
        {
            if (!this.MyIniIsOpen)
                return;
            short num1 = checked((short)FileSystem.FreeFile());
            FileSystem.FileOpen((int)num1, this.MyIniFilePath, OpenMode.Input, OpenAccess.Read, OpenShare.Default, -1);
            bool flag = false;
            short num2 = (short)0;
            IniFileController.EntryPair[] entryPairArray = null;
            while (!FileSystem.EOF((int)num1))
            {
                checked { ++num2; }
                entryPairArray = (IniFileController.EntryPair[])Utils.CopyArray((Array)entryPairArray, (Array)new IniFileController.EntryPair[checked((int)num2 + 1)]);
                string str = Strings.Trim(FileSystem.LineInput((int)num1));
                if (StringType.StrCmp(str, "", false) != 0)
                {
                    short num3 = checked((short)Strings.InStr(str, "=", CompareMethod.Binary));
                    if (StringType.StrCmp(whatKeyword, Strings.Left(str, checked((int)num3 - 1)), false) == 0)
                    {
                        flag = true;
                        checked { --num2; }
                    }
                    else
                    {
                        entryPairArray[checked((int)num2 - 1)].keyword = Strings.Left(str, checked((int)num3 - 1));
                        entryPairArray[checked((int)num2 - 1)].value = Strings.Right(str, checked(Strings.Len(str) - (int)num3));
                    }
                }
                else
                    checked { --num2; }
            }
            FileSystem.FileClose(new int[1]
      {
        (int) num1
      });
            if (flag)
            {
                short num3 = checked((short)FileSystem.FreeFile());
                FileSystem.FileOpen((int)num3, this.MyIniFilePath, OpenMode.Output, OpenAccess.Write, OpenShare.Default, -1);
                int num4 = 0;
                short num5 = checked((short)((int)num2 - 1));
                for (short index = (short)num4; (int)index <= (int)num5; ++index)
                    FileSystem.PrintLine((int)num3, new object[1]
          {
            (object) (entryPairArray[(int) index].keyword + "=" + entryPairArray[(int) index].value)
          });
                FileSystem.FileClose(new int[1]
        {
          (int) num3
        });
            }
        }

        public string GetEntry(string whatKeyword)
        {
            try
            {
                string str1;
                if (this.MyIniIsOpen)
                {
                    short num1 = checked((short)FileSystem.FreeFile());
                    FileSystem.FileOpen((int)num1, this.MyIniFilePath, OpenMode.Input, OpenAccess.Read, OpenShare.Default, -1);
                    bool flag = false;
                    string str2 = "";
                    while (!FileSystem.EOF((int)num1))
                    {
                        string str3 = Strings.Trim(FileSystem.LineInput((int)num1));
                        if (StringType.StrCmp(str3, "", false) != 0)
                        {
                            short num2 = checked((short)Strings.InStr(str3, "=", CompareMethod.Binary));
                            if (StringType.StrCmp(Strings.Trim(Strings.UCase(whatKeyword)), Strings.Trim(Strings.UCase(Strings.Left(Strings.Trim(str3), checked((int)num2 - 1)))), false) == 0)
                            {
                                flag = true;
                                str2 = Strings.Right(str3, checked(Strings.Len(str3) - (int)num2));
                                break;
                            }
                        }
                    }
                    FileSystem.FileClose(new int[1] { (int)num1 });
                    str1 = !flag ? "" : str2;
                }
                else
                    str1 = "";
                return str1;
            }
            catch
            {
                return "";
            }
        }

        public void SetEntry(string whatKeyword, string newValue)
        {
            if (!this.MyIniIsOpen)
                return;
            short num1 = checked((short)FileSystem.FreeFile());
            FileSystem.FileOpen((int)num1, this.MyIniFilePath, OpenMode.Input, OpenAccess.Read, OpenShare.Default, -1);
            bool flag = false;
            short num2 = (short)0;
            IniFileController.EntryPair[] entryPairArray = null;
            while (!FileSystem.EOF((int)num1))
            {
                checked { ++num2; }
                entryPairArray = (IniFileController.EntryPair[])Utils.CopyArray((Array)entryPairArray, (Array)new IniFileController.EntryPair[checked((int)num2 + 1)]);
                string str = Strings.Trim(FileSystem.LineInput((int)num1));
                if (StringType.StrCmp(str, "", false) != 0)
                {
                    short num3 = checked((short)Strings.InStr(str, "=", CompareMethod.Binary));
                    if (StringType.StrCmp(whatKeyword, Strings.Left(str, checked((int)num3 - 1)), false) == 0)
                    {
                        entryPairArray[checked((int)num2 - 1)].keyword = Strings.Left(str, checked((int)num3 - 1));
                        entryPairArray[checked((int)num2 - 1)].value = newValue;
                        flag = true;
                    }
                    else
                    {
                        entryPairArray[checked((int)num2 - 1)].keyword = Strings.Left(str, checked((int)num3 - 1));
                        entryPairArray[checked((int)num2 - 1)].value = Strings.Right(str, checked(Strings.Len(str) - (int)num3));
                    }
                }
                else
                    checked { --num2; }
            }
            FileSystem.FileClose(new int[1]
      {
        (int) num1
      });
            short num4 = checked((short)FileSystem.FreeFile());
            if (flag)
            {
                FileSystem.FileOpen((int)num4, this.MyIniFilePath, OpenMode.Output, OpenAccess.Write, OpenShare.Default, -1);
                int num3 = 0;
                short num5 = checked((short)((int)num2 - 1));
                for (short index = (short)num3; (int)index <= (int)num5; ++index)
                    FileSystem.PrintLine((int)num4, new object[1]
          {
            (object) (entryPairArray[(int) index].keyword + "=" + entryPairArray[(int) index].value)
          });
            }
            else
            {
                FileSystem.FileOpen((int)num4, this.MyIniFilePath, OpenMode.Append, OpenAccess.Write, OpenShare.Default, -1);
                FileSystem.PrintLine((int)num4, new object[1]
        {
          (object) (whatKeyword + "=" + newValue)
        });
            }
            FileSystem.FileClose(new int[1]
      {
        (int) num4
      });
        }

        private void Class_Initialize_Renamed()
        {
            this.MyIniFilePath = "";
            this.MyIniIsOpen = false;
            this.EntryCount = (short)0;
        }

        public bool OpenINIFile(string FilePath)
        {
            // ISSUE: unable to decompile the method.
            this.MyIniFilePath = FilePath;
            this.MyIniIsOpen = true;
            this.EntryCount = (short)0;
            return true;
        }

        public void CloseINIFile()
        {
            this.MyIniFilePath = "";
            this.Entries = new IniFileController.EntryPair[1];
            this.EntryCount = (short)0;
            this.MyIniIsOpen = false;
        }

        public void CreateINIFile(string FilePath)
        {
            try
            {
                this.MyIniFilePath = FilePath;
                this.MyIniIsOpen = true;
                short num = checked((short)FileSystem.FreeFile());
                FileSystem.FileOpen((int)num, FilePath, OpenMode.Output, OpenAccess.Write, OpenShare.Default, -1);
                FileSystem.FileClose(new int[1]
      {
        (int) num
      });
            }
            catch
            {

            }
        }

        private struct EntryPair
        {
            public string keyword;
            public string value;
        }
    }
}
