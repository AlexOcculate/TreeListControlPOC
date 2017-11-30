using DevExpress.LookAndFeel;

namespace TreeListForm
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel();
            this.treeViewXUC1 = new TreeListForm.TreeViewXUC();
            this.SuspendLayout();
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Office 2010 Black";
            // 
            // treeViewXUC1
            // 
            this.treeViewXUC1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewXUC1.Location = new System.Drawing.Point(0, 0);
            this.treeViewXUC1.Name = "treeViewXUC1";
            this.treeViewXUC1.Size = new System.Drawing.Size(632, 278);
            this.treeViewXUC1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 278);
            this.Controls.Add(this.treeViewXUC1);
            this.Name = "Form1";
            this.Text = "TreeList POC";
            this.ResumeLayout(false);

        }

        #endregion

        private DefaultLookAndFeel defaultLookAndFeel1;
        public TreeViewXUC treeViewXUC1;
    }
}

