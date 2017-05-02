using System;
using System.Data;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Delimon.Win32;
using System.IO.Packaging;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;
using System.Threading;
using System.Collections.Generic;
using _3S.CoDeSys.Compression.Zip;
using System.Linq;

namespace Testing
{
  
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            Regex regexItem = new Regex(@"[\s~`!@#$%^&*()+=|\\{}':;.,<>/?[\]""-]");
            string s = "\" \"";
           // var regexItem = new Regex("^[a-zA-Z0-9 ]*$");
            if (regexItem.IsMatch(textBox1.Text))
            {
                MessageBox.Show("invalid");
            }
            else
            { MessageBox.Show("valid"); }

            //drvsCls cls = new drvsCls();
            //cls.GetStringInDoubleQuotes();
            //cls.method();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Assembly asm = Assembly.LoadFile((@"C:\Testing\ClassLibrary1\bin\Debug\ClassLibrary1.dll"));

            Type[] tps = asm.GetTypes();

            foreach (Type t in tps)
            {
                MemberInfo[] m = t.GetMembers();
                MethodInfo[] mthd = t.GetMethods();
                PropertyInfo[] prp = t.GetProperties();
            }

            
            // File anf = new File();
            string filepath = Directory.GetCurrentDirectory() + @"\abc.cs";
            File.Create(filepath).Close();
            
          //  var filestrm = asm.GetLoadedModules();//.GetFiles();
            MessageBox.Show("test");

            // string assemblyPath = Assembly.GetExecutingAssembly().GetName().Name + @"\I1";
            //  var typeinterface = Type.GetMembers(@"C:\Testing\Testing\bin\Debug\Testing.exe");//.GetType(assemblyPath);
            //if (typeinterface.IsInterface)
            //{
            //    var ABC = typeinterface.GetRuntimeMethods();
                
            //}
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult result1 = MessageBox.Show("Is Dot Net Perls awesome?",
    "Important Question",
    MessageBoxButtons.YesNo);
            if (result1 == DialogResult.Yes)
            { MessageBox.Show("ok"); }
            else if (result1 == DialogResult.No)
            { MessageBox.Show("no"); }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Preparing date to display in the grid
            DataSet ds = new DataSet();
            ds.ReadXml(@"C:\Users\INBAKAD\Desktop\CategoryInfo.xml");
            dataGridView1.DataSource = ds.Tables[0];
            DataTable dt = ds.Tables[0];
            MessageBox.Show("Copied");

            //Getting data data for pasting
            IDataObject dataobject = dataGridView1.GetClipboardContent();
            Clipboard.SetDataObject(dataobject);
           
        }

        private void PasteBackToGridView()
        {
            string clpbrdTxt = Clipboard.GetText();
            string[] clpbrdTxtLines = clpbrdTxt.Split('\n');//.Except();
            int RowsFromClipboard = clpbrdTxtLines.Length-1;//Num of rows
            string[] firstLineSplit = clpbrdTxtLines[0].Split('\t');
            int ColumnsFromExcel = firstLineSplit.Length;
            int iRow = 0;// dataGridView1.CurrentCell.RowIndex;
           // int iCol = 0;// dataGridView1.CurrentCell.ColumnIndex;
            DataGridViewCell oCell;

            if (RowsFromClipboard == dataGridView1.RowCount - 1 && ColumnsFromExcel == dataGridView1.ColumnCount)
            {
                PasteAllValueToView(clpbrdTxtLines);
            }
            else if (RowsFromClipboard < dataGridView1.RowCount - 1 && ColumnsFromExcel == dataGridView1.ColumnCount)
            {
                PasteSelectedRowsToView(clpbrdTxtLines);
            }
            else if (RowsFromClipboard == dataGridView1.RowCount - 1 && ColumnsFromExcel < dataGridView1.ColumnCount)
            {
                PasteSelectedColumnsToView(clpbrdTxtLines);
            }
            foreach (string line in clpbrdTxtLines)
            {
                if (iRow < dataGridView1.RowCount-1 && line.Length > 0)
                {
                    string[] sCells = line.Split('\t');
                    if (sCells.Length < this.dataGridView1.ColumnCount)
                    {
                        for (int iCol = dataGridView1.CurrentCell.ColumnIndex; iCol < sCells.GetLength(0); ++iCol)
                        {
                            {
                                oCell = dataGridView1[iCol, iRow];
                                if (!oCell.ReadOnly)
                                {
                                    {
                                        oCell.Value = Convert.ChangeType(sCells[iCol],
                                                              oCell.ValueType);
                                    }
                                }
                            }
                        }
                    }
                    else if (sCells.Length == this.dataGridView1.ColumnCount)
                    {
                        //for (int iCol = 0; iCol < sCells.GetLength(0); ++iCol)
                        //{
                        //    //      if (iCol  < this.dataGridView1.ColumnCount)
                        //    {
                        //        oCell = dataGridView1[iCol, iRow];
                        //        if (!oCell.ReadOnly)
                        //        {
                        //            // if (oCell.Value.ToString() != sCells[i])
                        //            {
                        //                oCell.Value = Convert.ChangeType(sCells[iCol],
                        //                                      oCell.ValueType);
                        //                // oCell.Style.BackColor = Color.Tomato;
                        //            }
                        //            //  else
                        //            //    iFail++;
                        //            //only traps a fail if the data has changed 
                        //            //and you are pasting into a read only cell
                        //        }
                        //    }
                        //    // else
                        //    // { break; }
                        //}
                        //iRow++;
                    }
                }
                //else
                //{ break; }
                //if (iFail > 0)
                //    MessageBox.Show(string.Format("{0} updates failed due" +
                //                    " to read only column setting", iFail));
            }
        }

        private void PasteSelectedColumnsToView(string[] clpbrdTxtLines)
        {
            try
            {
                int iRow = 0;
                DataGridViewSelectedColumnCollection iColCnt = dataGridView1.SelectedColumns;//.CurrentCell.ColumnIndex;
                int index = 0;
                foreach (DataGridViewColumn col in iColCnt)
                {
                    index = col.Index;

                }
                DataGridViewCell oCell;
              
                    foreach (string line in clpbrdTxtLines)
                    {
                        string[] sCells = line.Split('\t');
                        for (int iCol = 0; iCol < sCells.GetLength(0); ++iCol)
                        {
                            oCell = dataGridView1[index, iRow];
                            if (!oCell.ReadOnly)
                            {
                                {
                                    oCell.Value = Convert.ChangeType(sCells[iCol],
                                                          oCell.ValueType);
                                }
                            }
                        }
                        iRow++;
                    index++;
                    }

                    //----------------
                    //for (int i = iCol; i < sCells.GetLength(0); ++i)
                    //{
                    //    //      if (iCol  < this.dataGridView1.ColumnCount)
                    //    {
                    //        oCell = dataGridView1[i, iRow];
                    //        if (!oCell.ReadOnly)
                    //        {
                    //            // if (oCell.Value.ToString() != sCells[i])
                    //            {
                    //                oCell.Value = Convert.ChangeType(sCells[iRow],
                    //                                      oCell.ValueType);
                    //                // oCell.Style.BackColor = Color.Tomato;
                    //            }
                    //            //  else
                    //            //    iFail++;
                    //            //only traps a fail if the data has changed 
                    //            //and you are pasting into a read only cell
                    //        }
                    //    }
                    //    // else
                    //    // { break; }
                    //}
                    //iRow++;
                
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            //throw new NotImplementedException();
        }

        private void PasteSelectedRowsToView(string[] clpbrdTxtLines)
        {
            throw new NotImplementedException();
        }

        private void PasteAllValueToView(string[] clpbrdTxtLines)
        {
            try
            {
                int iRow = 0;
                DataGridViewCell oCell;
                foreach (string line in clpbrdTxtLines)
                {
                    string[] sCells = line.Split('\t');
                    for (int iCol = 0; iCol < sCells.GetLength(0); ++iCol)
                    {
                            oCell = dataGridView1[iCol, iRow];
                            if (!oCell.ReadOnly)
                            {
                                {
                                    oCell.Value = Convert.ChangeType(sCells[iCol],
                                                          oCell.ValueType);
                                }
                            }
                    }
                    iRow++;
                }
            } catch (Exception ex) { MessageBox.Show(ex.Message); }
            //throw new NotImplementedException();
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control & e.KeyCode == Keys.V)
            {
                PasteBackToGridView();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void treeView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control & e.KeyCode == Keys.A)
            {
                treeView1.Select();
                
                MessageBox.Show("CTR+A pressed");
            }
        }

        void testingabpckg()
        {
            //try
            //{

                string InputFolder = @"C:\Users\inbakad\Desktop\input";

                //------------

                using (System.IO.Packaging.Package ABpackage = System.IO.Packaging.Package.Open(@"C:\Users\inbakad\Desktop\output\zenon.abpkg", FileMode.Create))
                {
                    //get all files to be included in package in corresponding folder
                    string[] filenames = Directory.GetFiles(InputFolder, "*.*", SearchOption.AllDirectories);
                    foreach (string file in filenames)
                    {
                        //create packagePart for each file in folder
                        //uri shall be relative --> remove absolute path, uri shall start with "/", uri doesn't accept blanks --> replace with %20
                        if (!InputFolder.EndsWith(Path.DirectorySeparatorChar.ToString()))
                            InputFolder = InputFolder + Path.DirectorySeparatorChar;
                        string fileRelativePath = file.ToString().Replace(InputFolder, "/");
                    //prepare path for uri:
                    //fileRelativePath = fileRelativePath.Replace(" ", "%20");
                    //fileRelativePath = fileRelativePath.Replace("{", "%7b");
                    //fileRelativePath = fileRelativePath.Replace("}", "%7d");
                    //convert path info into uri format
                    fileRelativePath = fileRelativePath.Replace("\\", "/");
                        var packagePartUri = PackUriHelper.CreatePartUri(new Uri(fileRelativePath, UriKind.Relative));
                        string extension = Path.GetExtension(@file);
                        if (string.IsNullOrEmpty(extension))
                            extension = ".%00";
                        var packagePart = ABpackage.CreatePart(packagePartUri, "part/" + extension);
                        //get file content and write to package part
                        using (var packageStream = packagePart.GetStream(FileMode.Create, FileAccess.ReadWrite))
                        {
                            try
                            {
                                using (FileStream currentFileStream = new FileStream(file, FileMode.Open, FileAccess.Read))
                                {
                                    currentFileStream.CopyTo(packageStream);
                                    Console.WriteLine("Added file: " + file);
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            ABpackage.CreateRelationship(packagePart.Uri, TargetMode.Internal, "rel");
                        }
                    }
                    // Flush package to ensure all data is written to it
                    ABpackage.Flush();
                }


                //----------------------
                //using (System.IO.Packaging.Package ABpackage = System.IO.Packaging.Package.Open(@"C:\Users\inbakad\Desktop\output\test.abpkg", FileMode.Create)) ;
                //{
                   
                //   // get all files to be included in package in corresponding folder
                //    string[] filenames = Directory.GetFiles(InputFolder, "*.*", SearchOption.AllDirectories);
                //   // string[] encodefiles = new string[filenames.Length];
                //    int I = 0;
                //    foreach (string file in filenames)
                //    {
                //      //  create packagePart for each file in folder
        
                //      //  uri shall be relative-- > remove absolute path, uri shall start with "/", uri doesn't accept blanks --> replace with %20
                //        if (!InputFolder.EndsWith(Path.DirectorySeparatorChar.ToString()))
                //                InputFolder = InputFolder + Path.DirectorySeparatorChar;
                //        string fileRelativePath = file.ToString().Replace(InputFolder, "/");


                //        var packagePartUri = PackUriHelper.CreatePartUri(new Uri(fileRelativePath, UriKind.Relative));
                //        var pckg = PackUriHelper.CreatePartUri(new Uri(fileRelativePath));
                //       // encodefiles[I] = Uri.EscapeDataString(fileRelativePath);
                //       // I++;
                //        string escaprstr = Uri.EscapeDataString(filePath);
                //        //prepare path for uri:
                //        //remove blanks
                //        fileRelativePath = fileRelativePath.Replace(" ", "%20");
                //        fileRelativePath = fileRelativePath.Replace("{", "%7b");
                //        fileRelativePath = fileRelativePath.Replace("}", "%7d");
                //        convert path info into uri format
                //          fileRelativePath = fileRelativePath.Replace("\\", "/");
                //        var packagePartUri = PackUriHelper.CreatePartUri(new Uri(fileRelativePath, UriKind.Relative));
                //        // string extension = Path.GetExtension(@file);
                //        if (string.IsNullOrEmpty(extension))
                //            extension = ".%00";
                //        var packagePart = ABpackage.CreatePart(packagePartUri, "part/" + extension);
                //        get file content and write to package part
                //        using (var packageStream = packagePart.GetStream(FileMode.Create, FileAccess.ReadWrite))
                //        {
                //            try
                //            {
                //                using (FileStream currentFileStream = new FileStream(file, FileMode.Open, FileAccess.Read))
                //                {
                //                    currentFileStream.CopyTo(packageStream);
                //                    Console.WriteLine("Added file: " + file);
                //                }
                //            }
                //            catch (Exception ex)
                //            {
                //                Console.WriteLine(ex.Message);
                //            }
                //            // ABpackage.CreateRelationship(packagePart.Uri, TargetMode.Internal, "rel");
                //        }
                //    }
                   // Flush package to ensure all data is written to it
                   
                //}
                //ABpackage.Flush();
                      // return encodefiles ;
        }


        private static void AddFileToZip(string zipFilename, string fileToAdd, CompressionOption compression = CompressionOption.Normal)
        {
            using (Package zip = System.IO.Packaging.Package.Open(zipFilename, FileMode.OpenOrCreate))
            {
                string destFilename = ".\\" + Path.GetFileName(fileToAdd);
                Uri uri = PackUriHelper.CreatePartUri(new Uri(destFilename, UriKind.Relative));
                if (zip.PartExists(uri))
                {
                    zip.DeletePart(uri);
                }
                PackagePart part = zip.CreatePart(uri, "", compression);
                using (FileStream fileStream = new FileStream(fileToAdd, FileMode.Open, FileAccess.Read))
                {
                    using (Stream dest = part.GetStream())
                    {
                        fileStream.CopyTo(dest);
                    }
                }
            }
        }


        public static List<ZipEntry> GetPackageFile(string packagefile)
        {
            FileInfo zipFileInfo = new FileInfo(packagefile);
            List<ZipEntry> filenames = new List<ZipEntry>();
            //Read zip file and check content
            using (FileStream fileStreamRdr = File.OpenRead(zipFileInfo.FullName))
            {
                ZipInputStream zipInputFileStream = new ZipInputStream(fileStreamRdr);
                ZipEntry entry;
                //Write zip-file data to folder.
                while (null != (entry = zipInputFileStream.GetNextEntry()))
                {
                    filenames.Add(entry);
                }
            }

            return filenames;
        }

        public static int ExtractFiles(string packagefile, string destFolder)
        {
            //extract the package content to temp folder
            string tempfolder = Path.Combine(destFolder,
                                   Path.GetFileNameWithoutExtension(packagefile));

           // Path.GetFileNameWithoutExtension(fileFullPath)
            if (Directory.Exists(tempfolder))
            {
                Directory.Delete(tempfolder, true);
                //Wait till folder is deleted
                Thread.Sleep(1000);
            }
            Directory.CreateDirectory(tempfolder);
            try
            {
                using (System.IO.Packaging.Package ABpackage = System.IO.Packaging.Package.Open(@packagefile, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    PackageRelationshipCollection relationships = ABpackage.GetRelationships();
                    PackagePartCollection parts = ABpackage.GetParts();
                    List<ZipEntry> files = GetPackageFile(packagefile);
                    if (files.Count() - 1 != parts.Count()) //[Content_Types].xml is not considered as file part
                    {
                        if (files.Count() - 1 > parts.Count())
                        {
                            Console.WriteLine(String.Format("Package {0} is corrupt. Additional files found", packagefile));
                            return -1;
                        }
                        else if (files.Count() - 1 < parts.Count())
                        {
                            Console.WriteLine(String.Format("Package {0} is corrupt. Some files are missing", packagefile));
                            return -1;
                        }
                    }

                    List<PackagePart> originalParts = new List<PackagePart>();

                    foreach (PackagePart item in parts)
                    {
                        if ((item.ContentType == "application/vnd.openxmlformats-package.relationships+xml") ||
                            (item.ContentType == "application/vnd.openxmlformats-package.digital-signature-origin") ||
                            (item.ContentType == "application/vnd.openxmlformats-package.digital-signature-xmlsignature+xml"))
                        {

                        }
                        else
                        {
                            originalParts.Add(item);
                        }
                    }
                    //if (originalParts.Count != relationships.Count() - 1)
                    //{
                    //    if (originalParts.Count > relationships.Count() - 1)
                    //    {
                    //   //     ErrorBase.WriteToLog(String.Format("Package {0} is corrupt. Additional files found", packagefile));
                    //        return -1;
                    //    }
                    //    else if (originalParts.Count > relationships.Count() - 1)
                    //    {
                    //        //ErrorBase.WriteToLog(String.Format("Package {0} is corrupt. Some files are missing", packagefile));
                    //        return -1;
                    //    }
                    //}

                    foreach (PackageRelationship rel in relationships)
                    {
                        PackagePart packagePart = ABpackage.GetPart(rel.TargetUri);
                        if (!packagePart.ContentType.Contains("part/")) continue;

                        string lastModified = String.Empty;
                        ZipEntry entry = files.Find(e => e.Name.Equals(packagePart.Uri.ToString().TrimStart('/'), StringComparison.InvariantCultureIgnoreCase));
                        if (entry == null)
                        {
                            continue;
                        }

                        //prepare file path information
                        string partRelativePath = Uri.UnescapeDataString(packagePart.Uri.ToString());

                        //partRelativePath = (partRelativePath.TrimStart('/')).Replace("%20", " ");
                        //partRelativePath = partRelativePath.Replace("%7b", "{");
                        //partRelativePath = partRelativePath.Replace("%7d", "}");
                        //partRelativePath = partRelativePath.Replace("%7B", "{");
                        //partRelativePath = partRelativePath.Replace("%7D", "}");
                        //partRelativePath = partRelativePath.Replace("%C2%A0", " ");
                        //partRelativePath = partRelativePath.Replace("%C3%84", "Ä");
                        //partRelativePath = partRelativePath.Replace("%C3%A4", "ä");
                        //partRelativePath = partRelativePath.Replace("%C3%96", "Ö");
                        //partRelativePath = partRelativePath.Replace("%C3%B6", "ö");
                        //partRelativePath = partRelativePath.Replace("%C3%9C", "Ü");
                        //partRelativePath = partRelativePath.Replace("%C3%BC", "ü");
                        //partRelativePath = partRelativePath.Replace("%C3%9F", "ß");
                        //partRelativePath = partRelativePath.Replace("/", "\\");
                        string absolutePath = Path.Combine(tempfolder, partRelativePath.TrimStart('/'));
                        if (!Directory.Exists(Path.GetDirectoryName(absolutePath)))
                        {
                            Directory.CreateDirectory(Path.GetDirectoryName(absolutePath));
                        }

                        FileInfo extractFileInfo = new FileInfo(absolutePath);
                        //Hp --> Logic: Check if the zip entry is older than the file system version
                        //if yes don't overwrite the file system version.
                        if ((extractFileInfo.Exists) &&
                            (DateTime.Compare(extractFileInfo.LastWriteTime, entry.DateTime) >= 0))
                        {
                            continue;
                        }
                        // Create the file with the Part content
                        using (FileStream fileStream = new FileStream(absolutePath, FileMode.Create))
                        {
                            //ErrorBase.WriteToLog("Extracting file: " + absolutePath);
                            try
                            {
                                packagePart.GetStream().CopyTo(fileStream);
                            }
                            catch (Exception ex)
                            {
                                //ErrorBase.WriteToLog(ex.Message);
                                return 1;
                            }
                        }

                        extractFileInfo.Refresh();
                        //Hp --> Always remove ReadOnly file attribute
                        extractFileInfo.Attributes &= ~FileAttributes.ReadOnly;
                        //set creation and modification date to zipped file date
                        extractFileInfo.CreationTime = entry.DateTime;
                        extractFileInfo.LastWriteTime = entry.DateTime;
                    }
                }
                return 1;
            }
            catch (Exception ex)
            {
                //ErrorBase.WriteToLog(packagefile + "extraction encountered an exception." + ex.Message);
                //ErrorBase.WriteToLog("Cleanup extracted files / folders...");
                if (Directory.Exists(tempfolder))
                {
                    Directory.Delete(tempfolder, true);
                    //Wait till folder is deleted
                    Thread.Sleep(1000);
                }
                return -1;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
              //  AddFileToZip(@"C: \Users\inbakad\Desktop\input\AC500_V12\library\syslibs\test", @"C:\Users\inbakad\Desktop\input\AC500_V12\library\syslibs\SysLibAB B {{C fg.lib");

                string InputFolder = @"C:\Users\inbakad\Desktop\input\AC500_V12\library\syslibs\SysLibAB}} B {{C fg.lib";
                
                string url = Uri.EscapeUriString(InputFolder);
                  string url1 = Uri.UnescapeDataString(url);
                Uri acd = new Uri(InputFolder, UriKind.Relative);//.ToString();
               Uri acv = PackUriHelper.CreatePartUri(acd);
               // acd.
                //string unescaprstr1 = Uri.UnescapeDataString(acd);
            }
            catch (Exception ex)
            {
                
            }

              testingabpckg();

          


            //string filePath = @"C:\test folder\A+B\test%C3%84file.txt";// 
            //filePath = @"C:%C3%96\dec%C3%9Code %C3%84testing_ folder%7d%7Bzenon%C3%96Logic/ - Copy.pdf";
            //var encoded = WebUtility.UrlEncode(filePath.Replace('\\', '/'));
            //var decoded = WebUtility.UrlDecode(filePath.Replace('/', '\\'));

            // string escaprstr =   Uri.EscapeDataString(filePath);
            // string escapruristr = Uri.EscapeUriString(filePath);

            //foreach (string FIL in filename)
            //{
            //    string unescaprstr = Uri.UnescapeDataString(FIL);
            //  var ACD =  PackUriHelper.CreatePartUri(new Uri(FIL, UriKind.Relative));
            //}
            // Console.WriteLine(decoded);
        }

       // [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        //[return: MarshalAs(UnmanagedType.Bool)]

        //public static extern SafeFileHandle createFile(string filename);

    //    [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
    //    internal static extern SafeFileHandle CreateFile(
    //string lpFileName,
    //EFileAccess dwDesiredAccess,
    //EFileShare dwShareMode,
    //IntPtr lpSecurityAttributes,
    //ECreationDisposition dwCreationDisposition,
    //EFileAttributes dwFlagsAndAttributes,
  //  IntPtr hTemplateFile);
        //  {
        //try
        //{
        //    string path = @"C:\AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA\" +
        //                                           @"BBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB\" +
        //                                           @"CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC\" +
        //                                          @" DDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDD\" +
        //                                           @"EEEEEEEEEEE\" +
        //                                           @"HELLLLLLLLLLLLLLLLOOOOOOOOOOOOOOOOOOO1.txt";
        //    path = @"\\?\" + path;
        //    FileInfo extractFileInfo = new FileInfo(path);
        //}
        //catch (Exception ex) { MessageBox.Show(ex.Message); }

        // }
        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                //  StreamReader sr = new StreamReader(@" C:\AutomationBuilder\"+
                //  @"CommonInstaller\Build\config.txt");
               // Delimon.Win32.IO.dll
                string path = @"C:\AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA\" +
                                                    @"BBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB\" +
                                                    @"CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC\" +
                                                   @" DDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDD\" +
                                                    @"EEEEEEEEEEE\" +
                                                    @"HELLLLLLLLLLLLLLLLOOOOOOOOOOOOOOOOOOO.txt";
                  path =  @"\\?\"+path;
      //   SafeFileHandle fileHandle = CreateFile(path,
      //EFileAccess.GenericWrite, EFileShare.None, IntPtr.Zero,
      //ECreationDisposition.CreateAlways, IntPtr.Zero);
                //createFile(path);
                // Delimon.Win32.IO.Path
               // FileInfo extractFileInfo = new FileInfo(path);
                Delimon.Win32.IO.FileInfo extractFileInfo  = new Delimon.Win32.IO.FileInfo(path);
                //Delimon.Win32.IO.Directory dir = new Delimon.Win32.IO.Directory();
                //Delimon.Win32.IO.File fil = new Delimon.Win32.IO.File();

                FileStream fileStream = extractFileInfo.Create();
                // fileStream = new FileStream(path, FileMode.Create);
               //  Delimon.Win32.IO.Helpers hl = new Delimon.Win32.IO.Helpers();
               //  PackagePart packagePart = null;

                // packagePart.GetStream().CopyTo(extractFileInfo.Create());
                //  bool retValu = extractFileInfo.Exists == true;
                //  StreamReader sr = new StreamReader(path);
                //  Delimon.Win32.IO.FileInfo 
                // MessageBox.Show(retValu.ToString());
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }

        private void button8_Click(object sender, EventArgs e)
        {
            ExtractFiles(@"C:\Users\inbakad\Desktop\EnergyTest\ZenonEditor_7_50_0_X.abpkg", @"C:\Users\inbakad\Desktop\EnergyTest\batfilcheck");
        }
    }
    public interface I1
    {
        void method();
        string abb { get; }
    }
  public  interface I2
    {
        void method();
    }
    public class BaseCls : I1, I2
    {
        public string abb
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        void I2.method()
        {
            throw new NotImplementedException();
        }

        void I1.method()
        {
            throw new NotImplementedException();
        }
    }
    public class drvsCls : BaseCls
    {
     public   void  method()
        {
            MessageBox.Show("drvsCls");
        }

        public string GetStringInDoubleQuotes()
        {
            string profile = "Automation Builder 2.0";
            string result = null;
            string abc = "hi\\hello".Replace("\\", "");
            result = "--Profile="+"\"" + profile + "\"".Replace(@"\","");
            return result;

            //--Profile="Automation Builder 2.0"
        }
    }
}
