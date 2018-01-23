using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Patcher2
{
  public partial class FrmMain : Form
  {
        private const string _q = "?";
        private const string _qq = "??";
        private const string _ss = "**";
        private const string _b = ".bak";
        private const string _p = "proc:";
        private const string gz = ".gz";
        private static readonly string iam = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
        private static string path = Application.StartupPath;
        private static List<string[]> settings = new List<string[]>();
        private static int isconsole = 0;
        private static List<string> seen = new List<string>();
        private static string tarfilename = "";
        private static string exepath = "";
        private static string filepath = "";
        private static bool manualSearch = false;
        private static string defaultexepath = @"C:\\Program Files (x86)\\VSMSoftware\\5DEmbroidery\\5DOrganizer.exe";

        public FrmMain()
        {
            InitializeComponent();
        }

        private static string findOnly(string file, ref string[] svals)
        {
          byte[] bytes;
          bytes = File.ReadAllBytes(file);

          int[] locs = Patcher.BinaryPatternSearch(ref bytes, svals, false);


          if (locs.Length == 1)
            return string.Format("Pattern found at: {0}+{1:X8}", tarfilename, locs[0]);
          else if (locs.Length < 1)
            return "Pattern not found.";
          else
            return locs.Length.ToString() + " occurrences found.";
        }

        private static bool doPatch(string file, string search, string offset, string replace)
        {
          // Variable setup
          int off;
          if (!Int32.TryParse(offset, out off))
            return false;
          search = search.Trim();
          replace = replace.Trim();
          string[] svals = search.Replace(_qq, _q).Replace(_ss, _q).Split(' ');
          string[] rvals = replace.Replace(_qq, _q).Replace(_ss, _q).Split(' ');

          if (replace.Length == 0)
            //return findOnly(file, ref svals);

          // MemPatch! :) (Highly experimental!)
          if (file.Length > 5 && file.Substring(0, 5).ToLower() == _p)
            //return doMemPatch(file.Split(':'), svals, off, rvals);

          if (!File.Exists(file))
          {
            if (isconsole == 0)
              MessageBox.Show("File not found.");
            else if (isconsole == 2)
              Console.WriteLine(file + " not found.");
            return false;
          }

          // Get file contents
          byte[] bytes = File.ReadAllBytes(file);
          // Search binary data for pattern
          int[] locs = Patcher.BinaryPatternSearch(ref bytes, svals);
          // Make sure we only have 1 match
          if (!onlyOne(locs.Length, file, search))
            return false;
          // Replace
          int replaced = Patcher.BinaryPatternReplace(ref bytes, locs[0], rvals, off);
          if (replaced < 1)
            return false;

          // Write new file
          //if (!File.Exists(file + _b))
          // File.Move(file, file + _b);

          File.WriteAllBytes(file, bytes);
          return true;
        }

        private static string FindChange(string file, string search, string offset)
        {
            search = search.Trim();
            string[] svals = search.Replace(_qq, _q).Replace(_ss, _q).Split(' ');
            return findOnly(file, ref svals);
        }

        private static bool onlyOne(int locs, string file, string search)
        {
          if (locs == 1)
            return true;
          if (locs < 1)
          {
            if (isconsole == 0)
              MessageBox.Show("Pattern not found.");
            else if (isconsole == 2)
              Console.WriteLine("No match for pattern: \"" + search + "\" in: " + file);
          }
          else
            if (isconsole == 0)
              MessageBox.Show("More than one occurance of pattern found. This is not OK.");
            else if (isconsole == 2)
              Console.WriteLine("More than one occurance of pattern (" + search + ") found, aborting patching of " + file);
          return false;
        }

        private void Patchtarget(bool verify)
        {
            string patch_mod = "E9 7D 02 00 00 90 8D 4C 24 1C FF 15 9C B0 44 00 84 C0 0F 85 6A 02 00 00 8D 4C 24 14 FF 15 9C B0 44 00 84 C0 0F 85 58 02 00 00 8D 44 24 1C 50 8D 4C 24 1C 51 8D 54 24 28 52 E8 43 B5 FE FF 83 C4";
            string patch_org = "0F 85 7C 02 00 00 8D 4C 24 1C FF 15 9C B0 44 00 84 C0 0F 85 6A 02 00 00 8D 4C 24 14 FF 15 9C B0 44 00 84 C0 0F 85 58 02 00 00 8D 44 24 1C 50 8D 4C 24 1C 51 8D 54 24 28 52 E8 43 B5 FE FF 83 C4";
            if (verify == false)
            {
                if (doPatch(exepath, patch_org, "0", patch_mod))
                {
                    MessageBox.Show("Applied to executable.", "Target has been patched", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show(FindChange(exepath, patch_mod, "0"), "Verifying results", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Patch by StackerDEV, patching class and code by github.com/hdf", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnPatch_Click(object sender, EventArgs e)
        {
            if (!File.Exists(defaultexepath))
            {
                MessageBox.Show("5DOrganizer.exe was not found, please browse to the location manually.", "Target file not found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                OpenFileDialog OFD = new OpenFileDialog();
                OFD.InitialDirectory = "C:\\";
                OFD.FileName = "5DOrganizer.exe";
                OFD.Filter = "exe files (*.exe)|*.exe";
                OFD.FilterIndex = 1;
                OFD.RestoreDirectory = true;

                if (OFD.ShowDialog() == DialogResult.OK)
                {
                    tarfilename = OFD.SafeFileName;
                    filepath = OFD.FileName.Replace(OFD.SafeFileName, "");
                    exepath = OFD.FileName;
                }
                manualSearch = true;
            }
            else
            {
                exepath = defaultexepath;
            }

            /* Check fileversion */
            FileVersionInfo tarVersion = FileVersionInfo.GetVersionInfo(exepath);
            if (tarVersion.FileVersion != "9.5.0.0")
            {
                MessageBox.Show("Selected file has the wrong fileversion, must be 9.5.0.0/nSelected file has version: " + tarVersion.FileVersion.ToString(), "Patching was canceled", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            /* End check fileversion */

            /* Backup executable */
            if (cbBackup.Checked == true)
            {
                if(manualSearch == true)
                {
                    if(!File.Exists(filepath + tarfilename + "_original.bak"))
                    {
                        File.Copy(filepath + tarfilename, filepath + tarfilename + "_original.bak");
                    }
                } else {
                    if (!File.Exists(@"C:\\Program Files (x86)\\VSMSoftware\\5DEmbroidery\\5DOrganizer_original.exe.bak"))
                    {
                        File.Copy(defaultexepath, @"C:\\Program Files (x86)\\VSMSoftware\\5DEmbroidery\\5DOrganizer_original.exe.bak");
                    }
                }
            }
            /* End backup */

            /* Start patching */
            Patchtarget(false);
        }

        private void btnVerifyPatch_Click(object sender, EventArgs e)
        {
            Patchtarget(true);
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

    }
}