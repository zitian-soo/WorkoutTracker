using System;
using System.Drawing;
using System.Windows.Forms;

namespace WorkoutTracker
{
    // สร้างคลาส Form1 ขึ้นมาเองในนี้เลย (Single File)
    public class Form1 : Form
    {
        // ประกาศตัวแปรตามโจทย์
        private Label lblTitle;
        private Label lblID, lblName, lblIntensity, lblStatus;
        private TextBox txtID, txtName;
        private ComboBox cboIntensity, cboStatus;
        private Button btnAdd;

        public Form1()
        {
            // กำหนดขนาดฟอร์ม 800x600 ตามโจทย์
            this.Text = "โปรแกรมบันทึกการออกกำลังกาย";
            this.Size = new Size(800, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Font = new Font("Segoe UI", 10F); // ใช้ฟอนต์มาตรฐานให้อ่านง่าย

            InitializeCustomComponents();
        }

        private void InitializeCustomComponents()
        {
            int xLabel = 50;
            int xInput = 250;
            int y = 50;
            int gap = 60; // ระยะห่างบรรทัด

            // 1. ชื่อโปรเจกต์ (Label หัวข้อ)
            lblTitle = new Label();
            lblTitle.Text = "Workout Tracker System";
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(250, 20);
            lblTitle.ForeColor = Color.DarkBlue;
            this.Controls.Add(lblTitle);
            y += 70;

            // 2. ExerciseID (รหัสการออกกำลังกาย)
            lblID = CreateLabel("Exercise ID (รหัส):", xLabel, y);
            txtID = CreateTextBox(xInput, y);
            this.Controls.Add(lblID);
            this.Controls.Add(txtID);
            y += gap;

            // 3. ExerciseName (ชื่อท่า/กิจกรรม)
            lblName = CreateLabel("Exercise Name (ชื่อท่า):", xLabel, y);
            txtName = CreateTextBox(xInput, y);
            this.Controls.Add(lblName);
            this.Controls.Add(txtName);
            y += gap;

            // 4. Intensity (ระดับความหนัก - ComboBox)
            lblIntensity = CreateLabel("Intensity (ความหนัก):", xLabel, y);
            cboIntensity = new ComboBox();
            cboIntensity.Location = new Point(xInput, y);
            cboIntensity.Width = 300;
            cboIntensity.DropDownStyle = ComboBoxStyle.DropDownList; // ห้ามพิมพ์เอง ให้เลือกเท่านั้น
            cboIntensity.Items.AddRange(new string[] { "Low", "Medium", "High" });
            cboIntensity.SelectedIndex = 0; // เลือกตัวแรกเป็นค่าเริ่มต้น
            this.Controls.Add(lblIntensity);
            this.Controls.Add(cboIntensity);
            y += gap;

            // 5. Status (สถานะ - ComboBox)
            lblStatus = CreateLabel("Status (สถานะ):", xLabel, y);
            cboStatus = new ComboBox();
            cboStatus.Location = new Point(xInput, y);
            cboStatus.Width = 300;
            cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cboStatus.Items.AddRange(new string[] { "Planned", "In Progress", "Done" });
            cboStatus.SelectedIndex = 0;
            this.Controls.Add(lblStatus);
            this.Controls.Add(cboStatus);
            y += gap + 20;

            // 6. ปุ่ม Add (เพิ่มข้อมูล)
            btnAdd = new Button();
            btnAdd.Text = "Add Data";
            btnAdd.Location = new Point(xInput, y);
            btnAdd.Size = new Size(150, 45);
            btnAdd.BackColor = Color.SeaGreen;
            btnAdd.ForeColor = Color.White;
            btnAdd.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnAdd.Cursor = Cursors.Hand;
            btnAdd.Click += BtnAdd_Click; // ผูก Event คลิก
            this.Controls.Add(btnAdd);
        }

        // ฟังก์ชันเมื่อกดปุ่ม Add
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            // Validation: ตรวจสอบว่าช่องว่างหรือไม่
            if (string.IsNullOrWhiteSpace(txtID.Text) || string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("กรุณากรอกข้อมูล ExerciseID และ ExerciseName ให้ครบถ้วน",
                                "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Success: แสดงข้อมูล (ตามโจทย์)
            string result = $"บันทึกข้อมูลสำเร็จ!\n\n" +
                            $"รหัสกิจกรรม: {txtID.Text}\n" +
                            $"ชื่อกิจกรรม: {txtName.Text}\n" +
                            $"ระดับความหนัก: {cboIntensity.SelectedItem}\n" +
                            $"สถานะ: {cboStatus.SelectedItem}";

            MessageBox.Show(result, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ฟังก์ชันช่วยสร้าง Label (จะได้ไม่ต้องพิมพ์ซ้ำ)
        private Label CreateLabel(string text, int x, int y)
        {
            return new Label { Text = text, Location = new Point(x, y + 5), AutoSize = true, Font = new Font("Segoe UI", 11F) };
        }

        // ฟังก์ชันช่วยสร้าง TextBox
        private TextBox CreateTextBox(int x, int y)
        {
            return new TextBox { Location = new Point(x, y), Width = 300, Font = new Font("Segoe UI", 11F) };
        }
    }

    // Main Entry Point (จุดเริ่มโปรแกรม)
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1()); // สั่งให้รัน Form1 ที่เราเขียนข้างบน
        }
    }
}