namespace Inspire.Direction.Client
{
    public partial class MainForm : System.Windows.Forms.Form
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
            this.btnGetImages = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnAddImage = new System.Windows.Forms.Button();
            this.btnDeleteImage = new System.Windows.Forms.Button();
            this.btnGetDirections = new System.Windows.Forms.Button();
            this.btnAddDirections = new System.Windows.Forms.Button();
            this.btnDeleteDirection = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGetImages
            // 
            this.btnGetImages.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetImages.Location = new System.Drawing.Point(516, 12);
            this.btnGetImages.Name = "btnGetImages";
            this.btnGetImages.Size = new System.Drawing.Size(135, 23);
            this.btnGetImages.TabIndex = 1;
            this.btnGetImages.Text = "Get Images";
            this.btnGetImages.Click += new System.EventHandler(this.ExecuteButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(507, 393);
            this.dataGridView1.TabIndex = 3;
            // 
            // btnAddImage
            // 
            this.btnAddImage.Location = new System.Drawing.Point(517, 42);
            this.btnAddImage.Name = "btnAddImage";
            this.btnAddImage.Size = new System.Drawing.Size(134, 23);
            this.btnAddImage.TabIndex = 4;
            this.btnAddImage.Text = "Add Image";
            this.btnAddImage.UseVisualStyleBackColor = true;
            this.btnAddImage.Click += new System.EventHandler(this.btnAddImage_Click);
            // 
            // btnDeleteImage
            // 
            this.btnDeleteImage.Location = new System.Drawing.Point(517, 72);
            this.btnDeleteImage.Name = "btnDeleteImage";
            this.btnDeleteImage.Size = new System.Drawing.Size(134, 23);
            this.btnDeleteImage.TabIndex = 5;
            this.btnDeleteImage.Text = "Delete Image";
            this.btnDeleteImage.UseVisualStyleBackColor = true;
            this.btnDeleteImage.Click += new System.EventHandler(this.btnDeleteImage_Click);
            // 
            // btnGetDirections
            // 
            this.btnGetDirections.Location = new System.Drawing.Point(517, 126);
            this.btnGetDirections.Name = "btnGetDirections";
            this.btnGetDirections.Size = new System.Drawing.Size(134, 23);
            this.btnGetDirections.TabIndex = 6;
            this.btnGetDirections.Text = "Get Directions";
            this.btnGetDirections.UseVisualStyleBackColor = true;
            this.btnGetDirections.Click += new System.EventHandler(this.btnGetDirections_Click);
            // 
            // btnAddDirections
            // 
            this.btnAddDirections.Location = new System.Drawing.Point(517, 156);
            this.btnAddDirections.Name = "btnAddDirections";
            this.btnAddDirections.Size = new System.Drawing.Size(134, 23);
            this.btnAddDirections.TabIndex = 7;
            this.btnAddDirections.Text = "Add Directions";
            this.btnAddDirections.UseVisualStyleBackColor = true;
            this.btnAddDirections.Click += new System.EventHandler(this.btnAddDirections_Click);
            // 
            // btnDeleteDirection
            // 
            this.btnDeleteDirection.Location = new System.Drawing.Point(517, 186);
            this.btnDeleteDirection.Name = "btnDeleteDirection";
            this.btnDeleteDirection.Size = new System.Drawing.Size(134, 23);
            this.btnDeleteDirection.TabIndex = 8;
            this.btnDeleteDirection.Text = "Delete Direction";
            this.btnDeleteDirection.UseVisualStyleBackColor = true;
            this.btnDeleteDirection.Click += new System.EventHandler(this.btnDeleteDirection_Click);
            // 
            // MainForm
            // 
            this.AcceptButton = this.btnGetImages;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 428);
            this.Controls.Add(this.btnDeleteDirection);
            this.Controls.Add(this.btnAddDirections);
            this.Controls.Add(this.btnGetDirections);
            this.Controls.Add(this.btnDeleteImage);
            this.Controls.Add(this.btnAddImage);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnGetImages);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGetImages;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnAddImage;
        private System.Windows.Forms.Button btnDeleteImage;
        private System.Windows.Forms.Button btnGetDirections;
        private System.Windows.Forms.Button btnAddDirections;
        private System.Windows.Forms.Button btnDeleteDirection;

    }
}