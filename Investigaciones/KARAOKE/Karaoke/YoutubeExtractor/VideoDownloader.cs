using System;
using System.IO;
using System.Net;

namespace YoutubeExtractor
{
    /// <summary>
    /// Provides a method to download a video from YouTube.
    /// </summary>
    public class VideoDownloader : Downloader
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VideoDownloader"/> class.
        /// </summary>
        /// <param name="video">The video to download.</param>
        /// <param name="savePath">The path to save the video.</param>
        /// <param name="bytesToDownload">An optional value to limit the number of bytes to download.</param>
        /// <exception cref="ArgumentNullException"><paramref name="video"/> or <paramref name="savePath"/> is <c>null</c>.</exception>
        public VideoDownloader(VideoInfo video, string savePath, String folder, int? bytesToDownload = null)
            : base(video, savePath, folder, bytesToDownload)
        {
        }

        public delegate void GetAbsoluteUri(String url);
        public event GetAbsoluteUri getAbsoluteUri;

        /// <summary>
        /// Occurs when the downlaod progress of the video file has changed.
        /// </summary>
        public event EventHandler<ProgressEventArgs> DownloadProgressChanged;

        /// <summary>
        /// Starts the video download.
        /// </summary>
        /// <exception cref="IOException">The video file could not be saved.</exception>
        /// <exception cref="WebException">An error occured while downloading the video.</exception>
        public override void Execute()
        {
            this.OnDownloadStarted(EventArgs.Empty);

            var request = (HttpWebRequest)WebRequest.Create(this.Video.DownloadUrl);

            if (this.BytesToDownload.HasValue)
            {
                request.AddRange(0, this.BytesToDownload.Value - 1);
            }
            if (!Folder.Equals("") && !Directory.Exists(this.Folder))
                Directory.CreateDirectory(this.Folder);

            if (!Folder.Equals("") && File.Exists(this.Folder))
            {
                this.OnDownloadFinished(EventArgs.Empty);
                return;
            }
            //aqui puede dar error en el servidor remoto
            // the following code is alternative, you may implement the function after your needs
            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    bool cancel = false;

                    if (getAbsoluteUri != null)
                    {
                        getAbsoluteUri(response.ResponseUri.AbsoluteUri);
                        return;
                    }
                    else
                    {

                        using (Stream source = response.GetResponseStream())
                        {
                            using (FileStream target = File.Open(this.SavePath, FileMode.Create, FileAccess.Write))
                            {
                                var buffer = new byte[1024]; //1024 antes

                                int bytes;
                                int copiedBytes = 0;

                                while (!cancel && (bytes = source.Read(buffer, 0, buffer.Length)) > 0)
                                {
                                    target.Write(buffer, 0, bytes);

                                    copiedBytes += bytes;

                                    var eventArgs = new ProgressEventArgs((copiedBytes * 1.0 / response.ContentLength) * 100);
                                    //response.ResponseUri.AbsolutePath
                                    this.OnAddBytes(buffer);

                                    if (this.DownloadProgressChanged != null)
                                    {
                                        this.DownloadProgressChanged(this, eventArgs);

                                        if (eventArgs.Cancel)
                                        {
                                            cancel = true;
                                        }
                                    }
                                }
                            }
                        }
                        if (cancel)
                        {
                            File.Delete(SavePath);
                        }
                    }
                }
            }
            catch
            {
                this.OnError(EventArgs.Empty);
            }
            this.OnDownloadFinished(EventArgs.Empty);
        }
    }
}