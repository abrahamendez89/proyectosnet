Imports Sistema
Imports Sistema.Comunes.Comun.ClsTools

Public Class FrmEmpresas

    Dim DAO As DataAccessCls
    Dim vcBaseDeDatos As String

    Private Sub BtnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAceptar.Click


        Dim dt As DataTable = New DataTable()

        DAO.RegresaConsultaSQL("SELECT CBASEDDATOS,rfcEmisor,nSerie, crfc FROM EMPRESAS_CNT WHERE CCVE_CIA = '" & CboEmpresas.SelectedValue & "'", dt)

        vcBaseDeDatos = dt.Rows(0)("CBASEDDATOS")


        DatosEmpresaStatic.nSerie = dt.Rows(0)("nSerie")
        DatosEmpresaStatic.rfcEmisor = dt.Rows(0)("rfcEmisor")

        dt = New DataTable()

        DAO.RegresaConsultaSQL("select cRFC from EMPRESAS..FAC_EMISORES where nRFCEmisor = " & DatosEmpresaStatic.rfcEmisor, dt)



        DatosEmpresaStatic.CRFC = dt.Rows(0)("crfc")

        DAO.AccesoDeUsuario(DAO.GetNombreServidor, vcBaseDeDatos, DAO.GetLoginUsuario, DAO.GetPassUsuario)

        DAO.conexionGlobalAbierta = False
        DAO.AbreConexion()

        DialogResult = Windows.Forms.DialogResult.OK

        frmPrincipal.Servidor = DAO.GetNombreServidor()
        frmPrincipal.BD = DAO.GetNombreBaseDeDatos()
        frmPrincipal.Usuario = DAO.GetLoginUsuario()
        frmPrincipal.Contra = DAO.GetPassUsuario()

        Me.Close()

    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub FrmEmpresas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DAO = DataAccessCls.DevuelveInstancia
        DAO.RegresaConsultaSQL("SELECT CEMPRESA,CCVE_CIA FROM EMPRESAS_CNT", CboEmpresas)
    End Sub
End Class