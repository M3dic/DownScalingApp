using System.Diagnostics;

namespace DownScaleImageApplication
{
    public partial class Form1 : Form
    {
        private Bitmap imgFile;
        public Form1()
        {
            InitializeComponent();
            DownSizeBtn.Enabled = false;
            ScalingInput.Enabled = false;

        }

        private void SelectImg_Click(object sender, EventArgs e)
        {
            LoadFiles();
            DownSizeBtn.Enabled = true;
            ScalingInput.Enabled = true;
        }
        private void DownSizeBtn_Click(object sender, EventArgs e)
        {
            if (imgFile != null)
            {
                String scaling = ScalingInput.Text;
                int scale;
                if (scaling != null && int.TryParse(scaling, out scale))
                {
                    Stopwatch sw = new Stopwatch();
                    sw.Start();
                    Bitmap resizedImage = DownSizeHelper.downSize(imgFile, scale);
                    sw.Stop();
                    Stopwatch sw2 = new Stopwatch();
                    sw2.Start();
                    Bitmap resizedImageParallel = DownSizeHelper.downSizeParallel(imgFile, scale);
                    sw2.Stop();

                    PictureBox imageControl = new PictureBox();
                    imageControl.Height = resizedImage.Height;
                    imageControl.Width = resizedImage.Width;
                    PictureBox imageControlParallel = new PictureBox();
                    imageControlParallel.Height = resizedImageParallel.Height;
                    imageControlParallel.Width = resizedImageParallel.Width;

                    if (resizedImage.Width > Width / 2 || resizedImage.Height > Height / 2)
                    {
                        AutoScroll = true;
                    }

                    Image.GetThumbnailImageAbort myCallback =
                            new Image.GetThumbnailImageAbort(ThumbnailCallback);

                    Image myThumbnailStandart = resizedImage.GetThumbnailImage(resizedImage.Width, resizedImage.Height,
                        myCallback, IntPtr.Zero);
                    imageControl.Image = myThumbnailStandart;
                    Image myThumbnailParallel = resizedImageParallel.GetThumbnailImage(resizedImageParallel.Width, resizedImageParallel.Height,
                        myCallback, IntPtr.Zero);
                    imageControlParallel.Image = myThumbnailParallel;

                    pictureBox1.Size = new Size(imageControl.Width, imageControl.Height);
                    pictureBox2.Location = new Point(pictureBox1.Location.X + pictureBox1.Size.Width + 15, pictureBox1.Location.Y);
                    pictureBox1.Controls.Add(imageControl);
                    timeNoParallel.Text = sw.ElapsedMilliseconds.ToString();
                    pictureBox2.Location = new Point(pictureBox1.Location.X + pictureBox1.Size.Width + 15, pictureBox1.Location.Y);
                    pictureBox2.Size = new Size(imageControlParallel.Width, imageControlParallel.Height);
                    pictureBox2.Controls.Add(imageControlParallel);
                    TimeParallel.Text = sw2.ElapsedMilliseconds.ToString();
                    DownSizeBtn.Enabled = false;
                }
            }
        }

        private void LoadFiles()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = @"D:\",
                Title = "Browse Image Files",
                CheckFileExists = true,
                CheckPathExists = true,
                DefaultExt = "img",
                Filter = "img files (*.jpg)|*.jpg",
                FilterIndex = 2,
                RestoreDirectory = true,
                ReadOnlyChecked = true,
                ShowReadOnly = true
            };
            DialogResult dr = openFileDialog.ShowDialog();
            if (dr == DialogResult.OK)
            {
                foreach (String file in openFileDialog.FileNames)
                {
                    try
                    {
                        Image.GetThumbnailImageAbort myCallback = new Image.GetThumbnailImageAbort(ThumbnailCallback);
                        imgFile = new Bitmap(file);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }

            }
        }
        public bool ThumbnailCallback()
        {
            return false;
        }

    }
}
