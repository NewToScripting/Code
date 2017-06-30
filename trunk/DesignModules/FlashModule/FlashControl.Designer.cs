using System;
using AxShockwaveFlashObjects;
using Inspire;


namespace FlashModule
{
    partial class FlashControl
    {
        private AxShockwaveFlash axShockwaveFlash;

        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        protected override void OnLoad(System.EventArgs e)
        {
            try
            {
                base.OnLoad(e);
                //axShockwaveFlash.Location = new System.Drawing.Point(50, 50);   
                this.Controls.Add(axShockwaveFlash);
                this.Show(); // Avoids InvalidActiveXStateException.
                axShockwaveFlash.AutoSize = true;
                axShockwaveFlash.CtlScale = "ExactFit";
                axShockwaveFlash.Loop = true;

                axShockwaveFlash.Movie = Url;

                double currentZoom = 1;

                if (InspireApp.DesignerZoomService != null)
                    currentZoom = InspireApp.DesignerZoomService.CurrentZoom;

                //* it is important to set Size after specifying Movie property
                //* if Size is specified before, it is ignored
                axShockwaveFlash.Size = new System.Drawing.Size(Convert.ToInt32(ControlWidth * (currentZoom)), Convert.ToInt32(ControlHeight * (currentZoom)));
                //Width = ControlWidth;
                //Height = ControlHeight;
                axShockwaveFlash.CtlScale = "ExactFit";
                axShockwaveFlash.AutoSize = true;
                axShockwaveFlash.Play();
            }
            catch (Exception)
            {
                
               // throw;
            }
            
        }

        public delegate void DispodeDelegate();


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

            while (axShockwaveFlash != null)
            {
                axShockwaveFlash.Dispose();
                axShockwaveFlash = null;
            }
            
            base.Dispose(disposing);
        }

        //public void DisposeFlash()
        //{
        //    if (axShockwaveFlash != null)
        //    {
                
        //    }
        //}


        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // FlashControl
            // 
            this.axShockwaveFlash = new AxShockwaveFlash();

            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "FlashControl";
           // this.Size = new System.Drawing.Size(0, 0);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
