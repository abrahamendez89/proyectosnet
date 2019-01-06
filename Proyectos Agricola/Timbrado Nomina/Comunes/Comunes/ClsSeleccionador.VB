Public Class ClsSeleccionador
    Inherits EventArgs

    Public Enum Botones
        Seleccion = 0
        QuitarSeleccion = 1
        Invertir = 2
    End Enum

    Public TipoBoton As Botones

    Public Sub New(ByVal prmTipoBoton As Botones)
        TipoBoton = prmTipoBoton
    End Sub

End Class
