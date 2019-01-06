using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using YoutubeExtractor;

namespace TestStreaming
{
    public class YouTubeDownloader
    {

        public delegate void MostrarProgreso(YouTubeDownloader instancia, double progreso);
        public event MostrarProgreso mostrarProgreso;

        public delegate void TerminoDescarga(YouTubeDownloader instancia, String urlArchivo);
        public event TerminoDescarga terminoDescarga;

        public delegate void AgregarBytes(YouTubeDownloader instancia, byte[] bytes);
        public event AgregarBytes agregarBytes;

        public delegate void GetAbsoluteUri(String url);
        public event GetAbsoluteUri getAbsoluteUri;

        String rutaGuardado;
        String nombreArchivo;

        public String RutaArchivo { get { return Path.Combine(rutaGuardado, nombreArchivo); } }

        public Object Adjunto { get; set; }
        Downloader downloader;

        private string RemoveIllegalPathCharacters(string path)
        {
            string regexSearch = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());
            var r = new Regex(string.Format("[{0}]", Regex.Escape(regexSearch)));
            return r.Replace(path, "");
        }
        Boolean cancelarOperacion;
        public void CancelarDescarga()
        {
            if (downloader != null)
            {
                cancelarOperacion = true;
            }
        }
        private void DownloadVideo(IEnumerable<VideoInfo> videoInfos)
        {
            /*
             * Select the first .mp4 video with 360p resolution
             */
            VideoInfo video = videoInfos.First(info => info.VideoType == VideoType.Mp4 && info.Resolution == 360);

            /*
             * If the video has a decrypted signature, decipher it
             */
            if (video.RequiresDecryption)
            {
                DownloadUrlResolver.DecryptDownloadUrl(video);
            }

            /*
             * Create the video downloader.
             * The first argument is the video to download.
             * The second argument is the path to save the video file.
             */
            this.nombreArchivo = RemoveIllegalPathCharacters(video.Title) + video.VideoExtension;

            if (File.Exists(Path.Combine(rutaGuardado, nombreArchivo)))
            {
                videoDownloader_DownloadProgressChanged(null, new ProgressEventArgs(100));
                videoDownloader_DownloadFinished(null, null);
                return;
            }

            var videoDownloader = new VideoDownloader(video, Path.Combine(rutaGuardado, nombreArchivo), rutaGuardado);

            // Register the ProgressChanged event and print the current progress
            //videoDownloader.DownloadProgressChanged += (sender, args) => Console.WriteLine(args.ProgressPercentage);
            videoDownloader.DownloadProgressChanged += videoDownloader_DownloadProgressChanged;
            videoDownloader.DownloadFinished += videoDownloader_DownloadFinished;
            videoDownloader.addBytes += videoDownloader_addBytes;
            videoDownloader.getAbsoluteUri += videoDownloader_getAbsoluteUri;
            downloader = videoDownloader;
            /*
             * Execute the video downloader.
             * For GUI applications note, that this method runs synchronously.
             */
            videoDownloader.Execute();
        }

        void videoDownloader_getAbsoluteUri(string url)
        {
            getAbsoluteUri(url);
        }

        void videoDownloader_addBytes(byte[] bytes)
        {
            if (agregarBytes != null) agregarBytes(this,bytes);
        }

        void videoDownloader_DownloadFinished(object sender, EventArgs e)
        {
            if (terminoDescarga != null) terminoDescarga(this, Path.Combine(rutaGuardado, nombreArchivo));
        }

        void videoDownloader_DownloadProgressChanged(object sender, ProgressEventArgs e)
        {
            e.Cancel = cancelarOperacion;
            if (mostrarProgreso != null) mostrarProgreso(this, e.ProgressPercentage);
        }
        private void DownloadAudio(IEnumerable<VideoInfo> videoInfos)
        {
            /*
             * We want the first extractable video with the highest audio quality.
             */
            VideoInfo video = videoInfos
                .Where(info => info.CanExtractAudio)
                .OrderBy(info => info.AudioBitrate)
                .First();

            //List<VideoInfo> videos = videoInfos
            //    .OrderByDescending(info => info.Resolution)//.AudioBitrate)
            //    .ToList();

            //video = videos[0];
            /*
             * If the video has a decrypted signature, decipher it
             */
            if (video.RequiresDecryption)
            {
                DownloadUrlResolver.DecryptDownloadUrl(video);
            }

            /*
             * Create the audio downloader.
             * The first argument is the video where the audio should be extracted from.
             * The second argument is the path to save the audio file.
             */
            this.nombreArchivo = RemoveIllegalPathCharacters(video.Title) + video.AudioExtension;

            if (File.Exists(Path.Combine(rutaGuardado, nombreArchivo)))
            {
                audioDownloader_DownloadProgressChanged(null, new ProgressEventArgs(100));
                audioDownloader_DownloadFinished(null, null);
                return;
            }

            var audioDownloader = new AudioDownloader(video, Path.Combine(rutaGuardado, nombreArchivo), rutaGuardado);

            // Register the progress events. We treat the download progress as 85% of the progress
            // and the extraction progress only as 15% of the progress, because the download will
            // take much longer than the audio extraction.
            //audioDownloader.DownloadProgressChanged += (sender, args) => Console.WriteLine(args.ProgressPercentage * 0.85);
            //audioDownloader.AudioExtractionProgressChanged += (sender, args) => Console.WriteLine(85 + args.ProgressPercentage * 0.15);

            audioDownloader.DownloadProgressChanged += audioDownloader_DownloadProgressChanged;
            audioDownloader.AudioExtractionProgressChanged += audioDownloader_AudioExtractionProgressChanged;
            audioDownloader.DownloadFinished += audioDownloader_DownloadFinished;
            audioDownloader.addBytes += audioDownloader_addBytes;

            downloader = audioDownloader;
            /*
             * Execute the audio downloader.
             * For GUI applications note, that this method runs synchronously.
             */
            audioDownloader.Execute();
        }

        void audioDownloader_addBytes(byte[] bytes)
        {
            if (agregarBytes != null) agregarBytes(this, bytes);
        }

        void audioDownloader_DownloadFinished(object sender, EventArgs e)
        {
            if (terminoDescarga != null) terminoDescarga(this, Path.Combine(rutaGuardado, nombreArchivo));
        }

        void audioDownloader_AudioExtractionProgressChanged(object sender, ProgressEventArgs e)
        {
            e.Cancel = cancelarOperacion;
            if (mostrarProgreso != null) mostrarProgreso(this, 85 + e.ProgressPercentage * 0.15);
        }

        void audioDownloader_DownloadProgressChanged(object sender, ProgressEventArgs e)
        {
            e.Cancel = cancelarOperacion;
            if (mostrarProgreso != null) mostrarProgreso(this, e.ProgressPercentage * 0.85);
        }

        public void DescargarAudio(String urlYoutube, String rutaGuardado)
        {
            // Our test youtube link
            //const string link = "https://www.youtube.com/watch?v=mQWOAjSffHI";

            this.rutaGuardado = rutaGuardado;

            /*
             * Get the available video formats.
             * We'll work with them in the video and audio download examples.
             */
            IEnumerable<VideoInfo> videoInfos = DownloadUrlResolver.GetDownloadUrls(urlYoutube, false);

            DownloadAudio(videoInfos);
            //DownloadVideo(videoInfos);
        }

        public void DescargarVideo(String urlYoutube, String rutaGuardado)
        {
            // Our test youtube link
            //const string link = "https://www.youtube.com/watch?v=mQWOAjSffHI";

            this.rutaGuardado = rutaGuardado;

            /*
             * Get the available video formats.
             * We'll work with them in the video and audio download examples.
             */
            IEnumerable<VideoInfo> videoInfos = DownloadUrlResolver.GetDownloadUrls(urlYoutube, false);

            //DownloadAudio(videoInfos);
            DownloadVideo(videoInfos);
        }
    }
}
