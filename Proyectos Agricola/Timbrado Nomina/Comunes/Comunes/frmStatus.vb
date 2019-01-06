Option Strict On
Imports System
Imports System.Windows.Forms
Imports Access
Namespace Comunes.Comun

    Public Class frmStatus
        Inherits System.Windows.Forms.Form
        Private atrTerminoEjecutaConsulta As Boolean = False
        Private atrEjecutandoConsulta As Boolean = False
        Private atrMensaje As String
        Private atrCancelado As Boolean = False
        Private atrSql As String
        Private atrDataset As DataSet
        Private atrDataTable As DataTable
        Private atrparam() As Object
        Private atrPermiteCancelacion As Boolean
        Private atrEjecutaConsultaConStoredProcedure As Boolean
        Private atrEjecutaThreadIndependiente As Boolean = False

        Private atrSoloConsulta As Boolean = False



        Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        Dim ThreadRegresaConsulta As New System.Threading.Thread(AddressOf RegresaConsulta)

#Region " Windows Form Designer generated code "

        Public Sub New(ByVal PrmCadena As String, ByRef Prmdataset As DataSet, ByVal Prmparam() As Object, ByVal prmMensaje As String, Optional ByVal prmPermiteCancelacion As Boolean = False)
            'Esta sobrecarga aplica en caso de realizar la consulta a partir de un StoredProcedure
            atrSql = PrmCadena
            atrDataset = Prmdataset
            atrparam = Prmparam
            atrMensaje = prmMensaje
            atrPermiteCancelacion = prmPermiteCancelacion
            atrEjecutaConsultaConStoredProcedure = True
            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call


            If prmPermiteCancelacion Then
                Me.Width = 263
                Me.Height = 92
            Else
                Me.Width = 263
                Me.Height = 60
            End If

        End Sub

        Public Sub New(ByVal PrmCadena As String, ByRef PrmdataTable As DataTable, ByVal prmMensaje As String, Optional ByVal prmPermiteCancelacion As Boolean = False)
            'Esta sobrecarga aplica en caso de realizar la consulta a partir de un Query
            atrSql = PrmCadena
            atrDataTable = PrmdataTable
            atrMensaje = prmMensaje
            atrPermiteCancelacion = prmPermiteCancelacion
            atrEjecutaConsultaConStoredProcedure = False
            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call

            If prmPermiteCancelacion Then
                Me.Width = 263
                Me.Height = 92
            Else
                Me.Width = 263
                Me.Height = 60
            End If

        End Sub
        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call

            atrSql = ""
            atrPermiteCancelacion = False
        End Sub

        Public Sub New(ByVal prmMensaje As String)
            atrMensaje = prmMensaje
            atrEjecutaThreadIndependiente = True
            atrPermiteCancelacion = True
            InitializeComponent()
        End Sub
        'Form overrides dispose to clean up the component list.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If Not (components Is Nothing) Then
                    components.Dispose()
                End If
            End If
            MyBase.Dispose(disposing)
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        Public WithEvents lblStatus As System.Windows.Forms.Label
        Friend WithEvents Timer1 As System.Windows.Forms.Timer
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
        Friend WithEvents BtnCancelar As System.Windows.Forms.Button
        Public WithEvents atrProgress As System.Windows.Forms.ProgressBar
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmStatus))
            Me.lblStatus = New System.Windows.Forms.Label
            Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
            Me.Label1 = New System.Windows.Forms.Label
            Me.PictureBox1 = New System.Windows.Forms.PictureBox
            Me.atrProgress = New System.Windows.Forms.ProgressBar
            Me.BtnCancelar = New System.Windows.Forms.Button
            CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblStatus
            '
            Me.lblStatus.Location = New System.Drawing.Point(48, 23)
            Me.lblStatus.Name = "lblStatus"
            Me.lblStatus.Size = New System.Drawing.Size(208, 34)
            Me.lblStatus.TabIndex = 0
            Me.lblStatus.Text = "Label1"
            Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Timer1
            '
            '
            'Label1
            '
            Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.Location = New System.Drawing.Point(50, 8)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(208, 16)
            Me.Label1.TabIndex = 3
            Me.Label1.Text = "Favor de Esperar un Momento..."
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'PictureBox1
            '
            Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
            Me.PictureBox1.Location = New System.Drawing.Point(8, 8)
            Me.PictureBox1.Name = "PictureBox1"
            Me.PictureBox1.Size = New System.Drawing.Size(40, 48)
            Me.PictureBox1.TabIndex = 4
            Me.PictureBox1.TabStop = False
            '
            'atrProgress
            '
            Me.atrProgress.Location = New System.Drawing.Point(48, 32)
            Me.atrProgress.Name = "atrProgress"
            Me.atrProgress.Size = New System.Drawing.Size(200, 16)
            Me.atrProgress.TabIndex = 5
            Me.atrProgress.Visible = False
            '
            'BtnCancelar
            '
            Me.BtnCancelar.Location = New System.Drawing.Point(170, 60)
            Me.BtnCancelar.Name = "BtnCancelar"
            Me.BtnCancelar.Size = New System.Drawing.Size(75, 23)
            Me.BtnCancelar.TabIndex = 6
            Me.BtnCancelar.Text = "Cancelar"
            Me.BtnCancelar.UseVisualStyleBackColor = True
            '
            'frmStatus
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.SystemColors.Control
            Me.ClientSize = New System.Drawing.Size(257, 54)
            Me.ControlBox = False
            Me.Controls.Add(Me.BtnCancelar)
            Me.Controls.Add(Me.atrProgress)
            Me.Controls.Add(Me.PictureBox1)
            Me.Controls.Add(Me.Label1)
            Me.Controls.Add(Me.lblStatus)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "frmStatus"
            Me.ShowInTaskbar = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        Public Property SoloConsulta() As Boolean
            Get
                Return atrSoloConsulta
            End Get
            Set(ByVal value As Boolean)
                atrSoloConsulta = value
            End Set
        End Property

        Public Property PermiteCancelacion() As Boolean
            Get
                Return atrPermiteCancelacion
            End Get
            Set(ByVal value As Boolean)
                atrPermiteCancelacion = value
            End Set
        End Property

        Public Property Cancelado() As Boolean
            Get
                Return atrCancelado
            End Get
            Set(ByVal value As Boolean)
                atrCancelado = value
            End Set
        End Property


        Public Overloads Sub Show(ByVal Message As String, Optional ByVal prmModal As Boolean = False)

            If PermiteCancelacion Then
                Me.BtnCancelar.Enabled = True
            Else
                Me.BtnCancelar.Enabled = False
            End If

            atrMensaje = Message
            lblStatus.Text = Message


            If Not atrEjecutaThreadIndependiente Then
                If Not prmModal Then
                    Me.Show()
                    Me.BringToFront()
                    Me.Refresh()
                    DialogResult = DialogResult.OK
                End If

                If Not atrSql.Trim = "" And Not atrEjecutandoConsulta Then
                    Me.BringToFront()
                    Me.Refresh()
                    ThreadRegresaConsulta.Start()
                    atrEjecutandoConsulta = True
                End If
            End If


            Timer1.Enabled = True
        End Sub


        Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick


            Timer1.Enabled = False
            If atrTerminoEjecutaConsulta And atrEjecutandoConsulta Then
                BtnCancelar.Enabled = False
                Me.Close()
            End If
            Me.Refresh()
            Timer1.Enabled = True
        End Sub


        Public Sub ConfiguraProgress(ByVal numeroRegistros As Integer)
            Application.DoEvents()
            lblStatus.Visible = False
            atrProgress.Visible = True
            atrProgress.Minimum = 0
            atrProgress.Maximum = numeroRegistros
            atrProgress.Step = 1
            atrProgress.Value = 0
        End Sub

        Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
            If Not atrEjecutaThreadIndependiente Then
                Cancelado = True
                ThreadRegresaConsulta.Abort()
                Me.Close()
                Exit Sub
            End If

            If atrEjecutaThreadIndependiente Then
                Cancelado = True
                DialogResult = Windows.Forms.DialogResult.Cancel
            End If


        End Sub

        Private Sub frmStatus_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            Show(atrMensaje, True)
        End Sub

        Private Sub RegresaConsulta()
            If atrEjecutaConsultaConStoredProcedure Then
                If atrSoloConsulta Then
                    'DAO.RegresaConsultaSQLThread(atrSql, atrDataset, atrparam)
                Else
                    DAO.RegresaConsultaSQL(atrSql, atrDataset, atrparam)
                End If
            Else
                If atrSoloConsulta Then
                    'DAO.RegresaConsultaSQLThread(atrSql, atrDataTable)
                Else
                    DAO.RegresaConsultaSQL(atrSql, atrDataTable)
                End If
            End If

            atrTerminoEjecutaConsulta = True

            Try
                ThreadRegresaConsulta.Abort()
            Catch ex As Exception

            End Try
        End Sub
    End Class
End Namespace