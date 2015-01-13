using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.IO;

namespace Snapshot_Maker
{
    public partial class SnapshotForm : Form
    {int foto = 1;
        public SnapshotForm( )
        {
            InitializeComponent( );
            

        }

        public void SetImage( Bitmap bitmap )
        {
            timeBox.Text = DateTime.Now.ToString("yyyyMMdd") + "_" + DateTime.Now.ToString("HHmmss")+".jpg";
           // timeBox.Text = DateTime.Now.ToString();
            label2.Text = DateTime.Now.ToString("dd/MM/yyyy") + " - " + DateTime.Now.ToString("HH:mm:ss");

            lock ( this )
            {
                Bitmap old = (Bitmap) pictureBox.Image;
                pictureBox.Image = bitmap;

                if ( old != null )
                {
                    old.Dispose( );
                }
            }
            Bitmap image = (Bitmap)pictureBox.Image;
           // image.Save(Convert.ToString(MainForm., ImageFormat.Jpeg);
            image.Save(Convert.ToString(timeBox.Text), ImageFormat.Jpeg);
            this.Text = "Çekilen Fotoğraf Sayısı : " + foto;
            foto = foto + 1;
            
        }

        private void SnapshotForm_Load(object sender, EventArgs e)
        {
            
            this.Text = ""; this.ControlBox = false; this.MaximizeBox = false; this.MinimizeBox = false;
        }

     /*   private void saveButton_Click( object sender, EventArgs e )
        {
            if ( saveFileDialog.ShowDialog( ) == DialogResult.OK )
            {
                string ext = Path.GetExtension( saveFileDialog.FileName ).ToLower( );
                ImageFormat format = ImageFormat.Jpeg;

                if ( ext == ".bmp" )
                {
                    format = ImageFormat.Bmp;
                }
                else if ( ext == ".png" )
                {
                    format = ImageFormat.Png;
                }

                try
                {
                    lock ( this )
                    {
                        Bitmap image = (Bitmap) pictureBox.Image;

                        image.Save( saveFileDialog.FileName, format );
                    }
                }
                catch ( Exception ex )
                {
                    MessageBox.Show( "Failed saving the snapshot.\n" + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
                }
            }
        }*/
    }
}
