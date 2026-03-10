namespace InstrumentRental
{
    partial class ExtendRentalForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblCurrentEndDate;
        private System.Windows.Forms.Label lblNewEndDate;
        private System.Windows.Forms.DateTimePicker dtpNewEndDate;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblCurrentEndDate = new System.Windows.Forms.Label();
            this.lblNewEndDate = new System.Windows.Forms.Label();
            this.dtpNewEndDate = new System.Windows.Forms.DateTimePicker();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // lblCurrentEndDate
            this.lblCurrentEndDate.AutoSize = true;
            this.lblCurrentEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblCurrentEndDate.Location = new System.Drawing.Point(20, 20);
            this.lblCurrentEndDate.Name = "lblCurrentEndDate";
            this.lblCurrentEndDate.Size = new System.Drawing.Size(200, 17);
            this.lblCurrentEndDate.TabIndex = 0;
            this.lblCurrentEndDate.Text = "Текущая дата окончания:";

            // lblNewEndDate
            this.lblNewEndDate.AutoSize = true;
            this.lblNewEndDate.Location = new System.Drawing.Point(20, 60);
            this.lblNewEndDate.Name = "lblNewEndDate";
            this.lblNewEndDate.Size = new System.Drawing.Size(113, 13);
            this.lblNewEndDate.TabIndex = 1;
            this.lblNewEndDate.Text = "Новая дата окончания:";

            // dtpNewEndDate
            this.dtpNewEndDate.Location = new System.Drawing.Point(140, 57);
            this.dtpNewEndDate.Name = "dtpNewEndDate";
            this.dtpNewEndDate.Size = new System.Drawing.Size(150, 20);
            this.dtpNewEndDate.TabIndex = 2;

            // btnOK
            this.btnOK.Location = new System.Drawing.Point(70, 100);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(80, 30);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);

            // btnCancel
            this.btnCancel.Location = new System.Drawing.Point(160, 100);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 30);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // ExtendRentalForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 151);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.dtpNewEndDate);
            this.Controls.Add(this.lblNewEndDate);
            this.Controls.Add(this.lblCurrentEndDate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExtendRentalForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Продление аренды";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}