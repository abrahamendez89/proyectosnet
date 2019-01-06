This is an *unofficial* FFmpeg Win32 build made by tripp.

built with mingw 4.2.4 core & gcc from TDM.
patched for ogm remux.


These files were originally hosted at: http://tripp.arrozcru.com/
The source code they were built with is also available.

FFmpeg revision number: 18639
FFmpeg license: GPL

Extra libraries included:
x264 SVN r1139
    http://developers.videolan.org/x264.html
libfaac 1.26
    http://www.audiocoding.com/
libfaad2 2.6.1
    http://www.audiocoding.com/
libmp3lame 3.98-2
    http://www.mp3dev.org/
libvorbis 1.2
    http://www.xiph.org/
libtheora 1.0
    http://www.xiph.org/
xvidcore cvs 21/04
    http://www.xvid.org/
libgsm 1.0.12
    http://kbs.cs.tu-berlin.de/~jutta/toast.html
pthreads-win32 2.8.0
    ftp://sources.redhat.com/pub/pthreads-win32


If you experience any other problems with this build, 
try please reporting them to:
http://ffmpeg.arrozcru.com/forum/


you can use presets under windows but use a full path to the preset,
-vpre "complete path\whaterver.ffpreset"
or if the preset file is in the same directory as ffmpeg 
-vpre "./whaterver.ffpreset"
e.g
ffmpeg -i input.avi -vcodec libx264 -vpre "path/libx264-max.ffpreset" out.mp4
