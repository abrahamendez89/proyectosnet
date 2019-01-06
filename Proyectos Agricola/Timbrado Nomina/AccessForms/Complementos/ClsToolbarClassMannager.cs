// Type: Sistema.Complementos.ClsToolbarClassMannager
// Assembly: AccessForms, Version=1.0.4545.30908, Culture=neutral, PublicKeyToken=null
// MVID: 5901ABF0-835C-413E-A9D3-42261792F241
// Assembly location: C:\Users\abrahamm\Documents\Visual Studio 2012\Projects2\Facturacion\Timbrado Nomina\TimbradoNomina\bin\Debug\AccessForms.dll

using ControlesUsuario;

namespace Sistema.Complementos
{
  public class ClsToolbarClassMannager
  {
    private Toolbar atrToolBar;

    public bool Nuevo
    {
      get
      {
        return this.atrToolBar.Nuevo;
      }
      set
      {
        this.atrToolBar.Nuevo = value;
      }
    }

    public bool Guardar
    {
      get
      {
        return this.atrToolBar.Guardar;
      }
      set
      {
        this.atrToolBar.Guardar = value;
      }
    }

    public bool Borrar
    {
      get
      {
        return this.atrToolBar.Eliminar;
      }
      set
      {
        this.atrToolBar.Eliminar = value;
      }
    }

    public bool Imprimir
    {
      get
      {
        return this.atrToolBar.Imprimir;
      }
      set
      {
        this.atrToolBar.Imprimir = value;
      }
    }

    public bool Ejecutar
    {
      get
      {
        return this.atrToolBar.Ejecutar;
      }
      set
      {
        this.atrToolBar.Ejecutar = value;
      }
    }

    public bool Herramientas
    {
      get
      {
        return this.atrToolBar.Configurar;
      }
      set
      {
        this.atrToolBar.Configurar = value;
      }
    }

    public ClsToolbarClassMannager(Toolbar toolBar)
    {
      this.atrToolBar = toolBar;
    }
  }
}
