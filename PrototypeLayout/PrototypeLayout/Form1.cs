using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrototypeLayout
{
    public partial class Dashboard : Form
    {
        Timer timer;
        Stopwatch sw;
        List<Record> records;

        public Dashboard()
        {
            InitializeComponent();
            InitialisePanels();
            InitialiseRecords();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonNews_Click(object sender, EventArgs e)
        {
            panelDashboard.Hide();
            panelNews.Show();
        }

        private void InitialisePanels()
        {
            panelDashboard.Show();
            panelNews.Hide();
            panelFitnessFunctionality.Hide();
            panelSessionExerciseType.Hide();
            panelCurrentSession.Hide();
            panelRecordExerciseType.Hide();
            panelRecordList.Hide();
            panelRecordInformation.Hide();
        }

        private void buttonRecordSession_Click(object sender, EventArgs e)
        {
            panelFitnessFunctionality.Hide();
            panelSessionExerciseType.Show();
        }

        private void buttonViewFitnessRecords_Click(object sender, EventArgs e)
        {
            panelFitnessFunctionality.Hide();
            panelRecordExerciseType.Show();
        }

        private void buttonFitness_Click(object sender, EventArgs e)
        {
            panelDashboard.Hide();
            panelFitnessFunctionality.Show();
        }

        private void buttonSessionRunning_Click(object sender, EventArgs e)
        {
            labelCurrentSessionExercise.Text = "Running";
            CurrentSessionInformation();
            panelSessionExerciseType.Hide();
            panelCurrentSession.Show();
        }

        private void buttonSessionCycling_Click(object sender, EventArgs e)
        {
            labelCurrentSessionExercise.Text = "Cycling";
            CurrentSessionInformation();
            panelSessionExerciseType.Hide();
            panelCurrentSession.Show();
        }

        private void buttonSessionRowing_Click(object sender, EventArgs e)
        {
            labelCurrentSessionExercise.Text = "Rowing";
            CurrentSessionInformation();
            panelSessionExerciseType.Hide();
            panelCurrentSession.Show();
        }

        private void InitialiseRecords()
        {
            records = new List<Record>();
            records.Add(new Record(DateTime.Now.AddDays(-2), "Cycling", 1200, 11733, 35.2));
            records.Add(new Record(DateTime.Now.AddDays(-1), "Running", 900, 3525, 14.1));
        }

        private void CurrentSessionInformation()
        {
            labelCurrentSessionDistance.Text = "0";
            labelCurrentSessionSpeed.Text = "0";
            timer = new Timer();
            sw = new Stopwatch();
            timer.Interval = (1000);
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
            sw.Start();

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            labelCurrentSessionDuration.Text = sw.Elapsed.Seconds.ToString();
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            sw.Stop();
            timer.Stop();
            records.Add(new Record(DateTime.Now, labelCurrentSessionExercise.Text, sw.Elapsed.Seconds, Double.Parse(labelCurrentSessionDistance.Text), Double.Parse(labelCurrentSessionSpeed.Text)));
            panelCurrentSession.Hide();
            panelFitnessFunctionality.Show();
        }

        private void panelCurrentSession_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            sw.Stop();
            timer.Stop();
            panelCurrentSession.Hide();
            panelSessionExerciseType.Show();
        }

        private void buttonSessionExerciseTypeBack_Click(object sender, EventArgs e)
        {
            panelSessionExerciseType.Hide();
            panelFitnessFunctionality.Show();
        }

        private void buttonFitnessFunctionalityBack_Click(object sender, EventArgs e)
        {
            panelFitnessFunctionality.Hide();
            panelDashboard.Show();
        }

        private void buttonRecordExerciseTypeBack_Click(object sender, EventArgs e)
        {
            panelRecordExerciseType.Hide();
            panelFitnessFunctionality.Show();
        }

        private void buttonNewsBack_Click(object sender, EventArgs e)
        {
            panelNews.Hide();
            panelDashboard.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonRecordRunning_Click(object sender, EventArgs e)
        {
            labelRecordsTitleType.Text = "Running";
            PopulateRecordsList("Running");
            listBoxRecords.Refresh();
            panelRecordExerciseType.Hide();
            panelRecordList.Show();
        }

        private void buttonRecordCycling_Click(object sender, EventArgs e)
        {
            labelRecordsTitleType.Text = "Cycling";
            PopulateRecordsList("Cycling");
            listBoxRecords.Refresh();
            panelRecordExerciseType.Hide();
            panelRecordList.Show();
        }

        private void buttonRecordRowing_Click(object sender, EventArgs e)
        {
            labelRecordsTitleType.Text = "Rowing";
            PopulateRecordsList("Rowing");
            listBoxRecords.Refresh();
            panelRecordExerciseType.Hide();
            panelRecordList.Show();
        }

        private void buttonRecordAll_Click(object sender, EventArgs e)
        {
            labelRecordsTitleType.Text = "All";
            PopulateRecordsList("All");
            listBoxRecords.Refresh();
            panelRecordExerciseType.Hide();
            panelRecordList.Show();
        }

        private void buttonRecordsBack_Click(object sender, EventArgs e)
        {
            panelRecordList.Hide();
            panelRecordExerciseType.Show();
        }

        private void PopulateRecordsList(String type)
        {
            listBoxRecords.Items.Clear();
            if (type.Equals("All"))
            {
                foreach(Record r in records)
                {
                    listBoxRecords.Items.Add(r.date);
                }
            }
            else
            {
                foreach (Record r in records)
                {
                    if (r.exerciseType.Equals(type))
                    {
                        listBoxRecords.Items.Add(r.date);
                    }
                }
            }
        }

        private void listBoxRecords_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listBoxRecords.SelectedItem != null)
            {
                Record selectedRecord = null;
                var date = listBoxRecords.SelectedItem;
                labelRecordInformationTitle.Text = date.ToString();
                for(int i = 0; i < records.Count(); i++)
                {
                    if (records[i].date.Equals(date))
                    {
                        selectedRecord = records[i];
                        break;
                    }
                }

                labelRecordExerciseTypeInformation.Text = selectedRecord.exerciseType.ToString();
                labelRecordDurationInformation.Text = selectedRecord.duration.ToString();
                labelRecordDistanceInformation.Text = selectedRecord.distance.ToString();
                labelRecordSpeedInformation.Text = selectedRecord.speed.ToString();

                panelRecordList.Hide();
                panelRecordInformation.Show();
            }
        }

        private void listBoxRecords_SelectedValueChanged(object sender, EventArgs e)
        {
            
        }

        private void buttonRecordInformationBack_Click(object sender, EventArgs e)
        {
            listBoxRecords.Refresh();
            panelRecordInformation.Hide();
            panelRecordList.Show();
        }

        private void panelRecordExerciseType_Paint(object sender, PaintEventArgs e)
        {

        }

        private void labelRecordExerciseTypeInformation_Click(object sender, EventArgs e)
        {

        }
    }
}
