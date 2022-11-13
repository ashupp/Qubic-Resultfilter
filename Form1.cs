using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using CsvHelper.Configuration;
using CsvHelper;
using Qubic_Resultfilter.Properties;
using System.Dynamic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Qubic_Resultfilter
{
    public partial class Form1 : Form
    {
        private enum QubicDocumentType
        {
            StatsBotScore,
            StatsBotRevenues,
            OfficialRewards,
            OfficialIntermediateRevenues,
            OfficialIntermediateScores
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Own IDs CSV file|*.csv";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Settings.Default.ownIDsPath = openFileDialog.FileName;
                    Settings.Default.Save();
                }
            }
        }

        private void btnSetOutputPath_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                folderBrowserDialog.ShowNewFolderButton = true;
                folderBrowserDialog.RootFolder = Environment.SpecialFolder.MyComputer;

                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    Settings.Default.outputFileDirectory = folderBrowserDialog.SelectedPath;
                    Settings.Default.Save();
                }
            }
        }

        private void groupBox2_DragDrop(object sender, DragEventArgs e)
        {
     
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length > 1)
            {
                MessageBox.Show("Only one File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (File.Exists(files[0]))
                {
                    Settings.Default.currentRewardsFile = files[0];
                    Settings.Default.Save();
                    if (Settings.Default.autoProcessWhenDroppedOrLoaded)
                    {
                        processFile();
                    }
                }
                else
                {
                    MessageBox.Show("File does not exist: " + files[0], "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }


        private void Form1_DragEnter_1(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Link;
        }

        private void groupBox2_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Link;
        }


        private void Log(string message)
        {
            if (listBoxLog.InvokeRequired)
            {
                Action logInvokeAction = delegate
                {
                    if (listBoxLog.Items.Count > 5000)
                    {
                        listBoxLog.Items.Clear();
                    }
                    listBoxLog.Items.Add(message);
                    listBoxLog.TopIndex = listBoxLog.Items.Count - 1;
                };
                listBoxLog.Invoke(logInvokeAction);
            }
            else
            {
                if (listBoxLog.Items.Count > 5000)
                {
                    listBoxLog.Items.Clear();
                }
                listBoxLog.Items.Add(message);
                listBoxLog.TopIndex = listBoxLog.Items.Count - 1;
            }
        }

        private void btnRunAgain_Click(object sender, EventArgs e)
        {
            processFile();
        }


        private void processFile()
        {
            var currentFile = Settings.Default.currentRewardsFile;
            
            Log("Start processing " + currentFile);


            //List<string> percentRewardsLines = new List<string>();
            //List<string> scoreRewardsLines = new List<string>();

            List<string> targetLines = new List<string>();

            // Read whole File to check type

            var currentFileContents = File.ReadAllText(currentFile);
            var currentFileLines = File.ReadAllLines(currentFile);

            if (currentFileContents.Contains("% (NoV: "))
            {
                // File type is: statsbot-revenues
                Log("File type: statsbot-revenues");

                foreach (var line in currentFileLines)
                {
                    //var revenueLine = line.Replace(" ", ";");
                    var revenueLine = Regex.Replace(line, @"\s+", ";");
                    targetLines.Add(revenueLine);
                }

                var targetString = string.Join(Environment.NewLine, targetLines);

                var dateTimeString = DateTime.Now.ToString("yyyyddM-HHmmss");

                var targetPercentageFile = Path.Combine(Settings.Default.outputFileDirectory, dateTimeString + "-qrf-statsbot-revenues-output.csv");
                CreateCSV(QubicDocumentType.StatsBotRevenues, Settings.Default.ownIDsPath, targetString, targetPercentageFile);
                Log("File created: " + targetPercentageFile);
                if (Settings.Default.openFileAfterGeneration)
                {
                    Process.Start(targetPercentageFile);
                }
            }
            else if (currentFileContents.Contains("   |   VOTES = "))
            {
                // File type should be: official intermediate result
                Log("File type: official intermediate result");


                bool scoreBlockReached = false;
                List<string> targetLinesRevs = new List<string>();
                List<string> targetLinesScore = new List<string>();


                foreach (var line in currentFileLines)
                {
                    // was score block already reached?
                    if (scoreBlockReached == false)
                    {
                        if (line.Contains("   |   VOTES = "))
                        {
                            scoreBlockReached = true;
                            continue;
                        }

                        var revLine = line.Replace("\t", ";");
                        targetLinesRevs.Add(revLine);

                    }
                    else
                    {
                        var tmpCopyOfLine = line;
                        // Special case when miner was kicked out - add score 0
                        if (tmpCopyOfLine.StartsWith("-"))
                        {
                            // führendes Zeichen tauschen
                            tmpCopyOfLine = tmpCopyOfLine.Replace("-", "");
                            tmpCopyOfLine += " - 0";
                        }

                        tmpCopyOfLine = tmpCopyOfLine.Replace(" - ", ";");
                        targetLinesScore.Add(tmpCopyOfLine);


                    }

                    




               

                    
                }


                Log("Processing first block (revenues");



                var targetString = string.Join(Environment.NewLine, targetLinesRevs);
                var dateTimeString = DateTime.Now.ToString("yyyyddM-HHmmss");

                var targetFileRevenues = Path.Combine(Settings.Default.outputFileDirectory, dateTimeString + "-qrf-intermediate-revenues-output.csv");
                CreateCSV(QubicDocumentType.OfficialIntermediateRevenues, Settings.Default.ownIDsPath, targetString, targetFileRevenues);
                Log("File created: " + targetFileRevenues);
                if (Settings.Default.openFileAfterGeneration)
                {
                    Process.Start(targetFileRevenues);
                }



                Log("Processing second block (scores");


                var targetStringScores = string.Join(Environment.NewLine, targetLinesScore);
                var dateTimeStringScores = DateTime.Now.ToString("yyyyddM-HHmmss");
                var targetFileScores = Path.Combine(Settings.Default.outputFileDirectory, dateTimeStringScores + "-qrf-intermediate-scores-output.csv");
                CreateCSV(QubicDocumentType.OfficialIntermediateScores, Settings.Default.ownIDsPath, targetStringScores, targetFileScores);
                Log("File created: " + targetFileScores);
                if (Settings.Default.openFileAfterGeneration)
                {
                    Process.Start(targetFileScores);
                }



            }
            else if (currentFileContents.Contains("/"))
            {
                // File type should be: statsbot-scores
                Log("File type: statsbot-scores");

                foreach (var line in currentFileLines)
                {
                    var scoreLine = line.Replace(" ", ";");
                    targetLines.Add(scoreLine);
                }

                var targetString = string.Join(Environment.NewLine, targetLines);

                var dateTimeString = DateTime.Now.ToString("yyyyddM-HHmmss");


                var targetPercentageFile = Path.Combine(Settings.Default.outputFileDirectory, dateTimeString + "-qrf-statsbot-scores-output.csv");
                CreateCSV(QubicDocumentType.StatsBotScore, Settings.Default.ownIDsPath, targetString, targetPercentageFile);
                Log("File created: " + targetPercentageFile);
                if (Settings.Default.openFileAfterGeneration)
                {
                    System.Diagnostics.Process.Start(targetPercentageFile);
                }


            }
            else if (currentFileContents.Contains("\t"))
            {
                // File type should be: official result
                Log("File type: official final result");

                foreach (var line in currentFileLines)
                {
                    var revenueLine = line.Replace("\t", ";");
                    targetLines.Add(revenueLine);
                }

                var targetString = string.Join(Environment.NewLine, targetLines);

                var dateTimeString = DateTime.Now.ToString("yyyyddM-HHmmss");

                var targetPercentageFile = Path.Combine(Settings.Default.outputFileDirectory, dateTimeString + "-qrf-final-result-output.csv");
                CreateCSV(QubicDocumentType.OfficialRewards, Settings.Default.ownIDsPath, targetString, targetPercentageFile);
                Log("File created: " + targetPercentageFile);
                if (Settings.Default.openFileAfterGeneration)
                {
                    Process.Start(targetPercentageFile);
                }

            }
            else
            {
                MessageBox.Show("File type could not be detected: " + currentFile, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

        }

        private void CreateCSV(QubicDocumentType qubicDocumentType, string myWalletsListFile, string csvData, string targetFile)
        {
            var readerMyWalletsListFile = new StreamReader(myWalletsListFile);
            var configWallet = new CsvConfiguration(CultureInfo.InvariantCulture);
            configWallet.HasHeaderRecord = true;
            configWallet.MissingFieldFound = null;
            configWallet.Delimiter = Settings.Default.csvDelimiter;
            


            var csvWalletList = new CsvReader(readerMyWalletsListFile, configWallet);
            

            var myWalletsRecords = csvWalletList.GetRecords<WalletListConfig>().ToList();

            // Neue Liste für zukünftige CSV
            var newList = new List<object> { };


            int i = 0;
            // Für jeden Eintrag in der Wallet Liste 
            foreach (var walletRecord in myWalletsRecords)
            {
                

                //Log("WalletRecord: " + walletRecord.Name);
                //Console.WriteLine("My: " + walletRecord.ID);

                // Den Passenden Wert in der rewards liste finden

                var readerRewardsList = new StringReader(csvData);
                var configRewards = new CsvConfiguration(CultureInfo.InvariantCulture);
                configRewards.HasHeaderRecord = false;
                configRewards.MissingFieldFound = null;
                configRewards.Delimiter = Settings.Default.csvDelimiter;
                var csvRewardsList = new CsvReader(readerRewardsList, configRewards);

               

                var rewardsListRecords = csvRewardsList.GetRecords<dynamic>().ToList();
                var rewardsListCount = rewardsListRecords.Count;


                bool walletRecordFound = false;
                int listIterator = 0;
                foreach (var rewardRecord in rewardsListRecords)
                {
                    listIterator++;

                    if (qubicDocumentType == QubicDocumentType.StatsBotScore)
                    {
                        if (rewardRecord.Field2.Trim() == walletRecord.ID.Trim())
                        {
                            Log("ID found: " + walletRecord.Name);
                            walletRecordFound = true;
                            var searchRes = newList.Find(x => ((dynamic)x).ID == walletRecord.ID);
                            if (searchRes == null)
                            {
                                dynamic record = new ExpandoObject();
                                record.Name = walletRecord.Name;
                                record.ID = walletRecord.ID;
                                record.Counter = rewardRecord.Field1.ToString();
                                record.Score = rewardRecord.Field3.ToString() + " \t";
                                record.DateTime = rewardRecord.Field4.ToString() + " " + rewardRecord.Field5.ToString();
                                newList.Add(record);

                            }

                            i++;
                            break;
                        }
                        if (walletRecordFound == false && listIterator == rewardsListCount && Settings.Default.showOwnIDsWithoutValueFound)
                        {
                            // ID not found - empty entry
                            dynamic record = new ExpandoObject();
                            record.Name = walletRecord.Name;
                            record.ID = walletRecord.ID;
                            record.Counter = "";
                            record.Score = "";
                            record.DateTime = "";
                            record.Note = "ID not found in file";
                            newList.Add(record);
                        }
                    }

                    if (qubicDocumentType == QubicDocumentType.StatsBotRevenues)
                    {

                        if (rewardRecord.Field1.Trim() == walletRecord.ID.Trim())
                        {
                            Log("ID found: " + walletRecord.Name);
                            walletRecordFound = true;
                            var searchRes = newList.Find(x => ((dynamic)x).ID == walletRecord.ID);
                            if (searchRes == null)
                            {
                                dynamic record = new ExpandoObject();
                                record.Name = walletRecord.Name;
                                record.ID = walletRecord.ID;
                                record.Revenues = rewardRecord.Field2.ToString();
                                record.RevenuePercent = rewardRecord.Field3.ToString();
                                record.NumberOfVotes = rewardRecord.Field4.ToString() + " " + rewardRecord.Field5.ToString();
                                newList.Add(record);
                            }
                            i++;
                            break;
                        }

                        if (walletRecordFound == false && listIterator == rewardsListCount && Settings.Default.showOwnIDsWithoutValueFound)
                        {
                            // ID not found - empty entry
                            dynamic record = new ExpandoObject();
                            record.Name = walletRecord.Name;
                            record.ID = walletRecord.ID;
                            record.Revenues = "";
                            record.RevenuePercent = "";
                            record.NumberOfVotes = "";
                            record.Note = "ID not found in file";
                            newList.Add(record);
                        }
                    }

                    if (qubicDocumentType == QubicDocumentType.OfficialRewards)
                    {

                        if (rewardRecord.Field1.Trim() == walletRecord.ID.Trim())
                        {
                            Log("ID found: " + walletRecord.Name);
                            walletRecordFound = true;
                            var searchRes = newList.Find(x => ((dynamic)x).ID == walletRecord.ID);
                            if (searchRes == null)
                            {
                                dynamic record = new ExpandoObject();
                                record.Name = walletRecord.Name;
                                record.ID = walletRecord.ID;
                                record.Revenues = rewardRecord.Field2.ToString();
                                newList.Add(record);
                            }
                            i++;
                            break;
                        }

                        if (walletRecordFound == false && listIterator == rewardsListCount && Settings.Default.showOwnIDsWithoutValueFound)
                        {
                            // ID not found - empty entry
                            dynamic record = new ExpandoObject();
                            record.Name = walletRecord.Name;
                            record.ID = walletRecord.ID;
                            record.Revenues = "";
                            record.Note = "ID not found in file";
                            newList.Add(record);
                        }
                    }

                    if (qubicDocumentType == QubicDocumentType.OfficialIntermediateRevenues)
                    {

                        if (rewardRecord.Field1.Trim() == walletRecord.ID.Trim())
                        {
                            Log("ID found: " + walletRecord.Name);
                            walletRecordFound = true;
                            var searchRes = newList.Find(x => ((dynamic)x).ID == walletRecord.ID);
                            if (searchRes == null)
                            {
                                dynamic record = new ExpandoObject();
                                record.Name = walletRecord.Name;
                                record.ID = walletRecord.ID;
                                record.Revenues = rewardRecord.Field2.ToString();
                                newList.Add(record);
                            }
                            i++;
                            break;
                        }

                        if (walletRecordFound == false && listIterator == rewardsListCount && Settings.Default.showOwnIDsWithoutValueFound)
                        {
                            // ID not found - empty entry
                            dynamic record = new ExpandoObject();
                            record.Name = walletRecord.Name;
                            record.ID = walletRecord.ID;
                            record.Revenues = "";
                            record.Note = "ID not found in file";
                            newList.Add(record);
                        }
                    }

                    if (qubicDocumentType == QubicDocumentType.OfficialIntermediateScores)
                    {

                        if (rewardRecord.Field1.Trim() == walletRecord.ID.Trim())
                        {
                            Log("ID found: " + walletRecord.Name);
                            walletRecordFound = true;
                            var searchRes = newList.Find(x => ((dynamic)x).ID == walletRecord.ID);
                            if (searchRes == null)
                            {
                                dynamic record = new ExpandoObject();
                                record.Name = walletRecord.Name;
                                record.ID = walletRecord.ID;
                                record.Score = rewardRecord.Field2.ToString();
                                newList.Add(record);
                            }
                            i++;
                            break;
                        }

                        if (walletRecordFound == false && listIterator == rewardsListCount && Settings.Default.showOwnIDsWithoutValueFound)
                        {
                            // ID not found - empty entry
                            dynamic record = new ExpandoObject();
                            record.Name = walletRecord.Name;
                            record.ID = walletRecord.ID;
                            record.Score = "";
                            record.Note= "ID not found in file";
                            newList.Add(record);
                        }
                    }

                }



            }


            using (var writer = new StreamWriter(targetFile))

            using (var csv = new CsvWriter(writer, CultureInfo.CurrentCulture))
            {
                csv.WriteRecords(newList);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Text = Text + " - " + Assembly.GetEntryAssembly()?.GetName().Version;
            Log("Launched...");
        }

        private void btnSelectRewardsFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Rewards or Score File |*.txt";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Settings.Default.currentRewardsFile = openFileDialog.FileName;
                    Settings.Default.Save();
                    if (Settings.Default.autoProcessWhenDroppedOrLoaded)
                    {
                        processFile();
                    }
                }
            }
        }

        private void listBoxLog_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (Settings.Default.outputFileDirectory != String.Empty && Directory.Exists(Settings.Default.outputFileDirectory))
            {
                Process.Start("explorer.exe", Settings.Default.outputFileDirectory);
            }
        }

    }
}
