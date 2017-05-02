using System;
using System.Windows.Controls;
using System.Windows.Forms;

namespace Testing
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            // Expander exp = new Expander();
            // exp.ExpandDirection = ExpandDirection.Down;
            //// exp.FlowDirection = 


         

            System.Windows.Controls.TextBox txtbx = new System.Windows.Controls.TextBox();
            txtbx.Text = "hello world";
         
          
            // expander.ActualHeight = 250;
            //expander.Size = new Size(250, 120);
            //expander.Left = 350;
            //expander.Top = 230;
            //expander.BorderStyle = BorderStyle.FixedSingle;

            // Label headerLabel = new System.Windows.Controls.Label();
            //System.Windows.Forms.Label headerLabel = new System.Windows.Forms.Label();
            //headerLabel.Text = "Click me";
            //headerLabel.AutoSize = false;
            //headerLabel.Font = new Font(headerLabel.Font, FontStyle.Bold);
            //headerLabel.TextAlign = ContentAlignment.MiddleLeft;
            //headerLabel.BackColor = SystemColors.ActiveBorder;

            //headerLabel.Click += delegate
            //{
            //    expander.Toggle();
            //    if (expander.Expanded)
            //        headerLabel.BackColor = SystemColors.ActiveBorder;
            //    else
            //        headerLabel.BackColor = SystemColors.ActiveCaption;
            //};

            //expander.Header = headerLabel;

            //Label labelContent = new Label();
            //labelContent.Text = "You are not limited to use the ExpanderHelper to create your header. Here is a example with a custom code and custom click event handler that change the header backcolor when the expander state change.";
            //labelContent.Size = new System.Drawing.Size(expander.Width, 75);
            //expander.Content = labelContent;

            //this.Controls.Add(expander);

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            if (checkBox2.Visible == true)
            {
                checkBox2.Visible = false;
               // linkLabel3.Visible = false;
            }
            else
            {
                checkBox2.Visible = true;
                //linkLabel3.Visible = true;
            }
            
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
