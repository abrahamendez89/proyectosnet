
Imports Access
Imports System.Drawing
Imports System.Text
Imports System.IO
Imports System.Windows.Forms


Namespace Comunes.Comun
    Public Class ClsImagen
        Inherits ClsBaseComun


        Private atrBuffer() As Byte

        Public Overrides Function FormatoFolio() As String
            FormatoFolio = ""
        End Function

        Public Overrides Function getNombreFolioAdministrado() As String
            Return "CTL_Imagenes"
        End Function

        Public Property Buffer() As Byte()
            Get
                Return atrBuffer
            End Get
            Set(ByVal Value As Byte())
                atrBuffer = Value
            End Set
        End Property

        Public Sub New(ByVal prmImagen As Integer, ByVal prmDescripcion As String, ByVal prmImagenBytes As Byte())
            Me.New(prmImagen, prmDescripcion)
            atrBuffer = prmImagenBytes
        End Sub

        Public Sub New(ByVal prmImagen As Integer, ByVal prmDescripcion As String)
            MyBase.New(prmImagen, prmDescripcion)
        End Sub

        Public Overrides Function Guardar() As Boolean

            If Not MyBase.GuardarBase Then
                Return False
            End If


            atrSql = "SELECT nImagen ,cDescripcion ,iImagen ,bActivo ,cUsuario_Registro" & vbCr
            atrSql &= " ,dFecha_Registro ,cMaquina_Registro ,cUsuario_UltimaModificacion ,dFecha_UltimaModificacion" & vbCr
            atrSql &= " ,cMaquina_UltimaModificacion ,cUsuario_Eliminacion ,dFecha_Eliminacion ,cMaquina_Eliminacion" & vbCr
            atrSql &= "" & vbCr
            atrSql &= "FROM CTL_Imagenes(NOLOCK)" & vbCr
            atrSql &= "WHERE nImagen = " & Folio & vbCr


            If Not MyBase.setRowAccion Then
                Return False
            End If

            atrRow("nImagen") = Folio
            atrRow("cDescripcion") = Descripcion
            atrRow("iImagen") = atrBuffer
            atrRow("bActivo") = Activo
            LLenaDatosRegistroComun(atrRow)


            If Not MyBase.GuardarGenerico() Then
                Return False
            End If

            Return True
        End Function

        Public Function getImageCargada() As Bitmap
            Try
                Return New Bitmap(New MemoryStream(atrBuffer))
            Catch ex As Exception
                MessageBox.Show("Error al descargar la imagen: " & ex.Message, "Imagenes", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return Nothing
            End Try
        End Function

        Public Function getImage() As Bitmap
            DAO = DataAccessCls.DevuelveInstancia
            atrSql = "SELECT iImagen FROM CTL_Imagenes(NOLOCK) WHERE nImagen = " & Folio
            atrBuffer = CType(DAO.RegresaDatoSQL(atrSql), Byte())
            Return getImageCargada()
        End Function


        Public Function setImage() As Boolean
            Dim vOpen As New OpenFileDialog
            vOpen.DefaultExt = "JPEG"
            vOpen.Filter = "Archivos de Imagen (*.JPG;*.JPEG;*.JPE;*.JFIF)|*.JPG;*.JPEG;*.JPE;*.JFIF"
            vOpen.InitialDirectory = "C:\"
            vOpen.Multiselect = False
            vOpen.FilterIndex = 0
            vOpen.CheckFileExists = True
            vOpen.CheckPathExists = True
            vOpen.AddExtension = False
            vOpen.Title = "Eleccion de imagen"
            If vOpen.ShowDialog = DialogResult.OK Then
                Return setImage(vOpen.FileName)
            End If
            Return False
        End Function

        Public Function setImage(ByVal prmNombreArchivo As String) As Boolean
            Try
                Dim vFile As New FileStream(prmNombreArchivo, FileMode.Open)
                Dim vFileInfo As New FileInfo(prmNombreArchivo)
                Dim vLength As Long = Convert.ToInt32(vFileInfo.Length)
                Dim vPicture(vLength) As Byte
                vFile.Read(vPicture, 0, vLength)
                vFile.Close()
                atrBuffer = vPicture
                Return True
            Catch ex As Exception
                MessageBox.Show("Error al cargar la imagen: " & ex.Message & " - RUTA: " & prmNombreArchivo, "Imagenes", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End Try
        End Function


        'parte agregada por guadalupe garcia torres
        Public Function getImage(ByVal prmImagen As Integer) As Bitmap
            DAO = DataAccessCls.DevuelveInstancia
            atrSql = "SELECT iImagen FROM CTL_Imagenes(NOLOCK) WHERE nImagen = " & prmImagen
            atrBuffer = CType(DAO.RegresaDatoSQL(atrSql), Byte())
            Return getImageCargada()
        End Function

        Public Overrides Function getRow() As ClsBaseComun.ObtenerRowEventHandler

        End Function
    End Class ' ClsImagen

End Namespace ' Logical Model