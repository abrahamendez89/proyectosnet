   M S B A M L   `   `   `  ����A  =Vistas, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullw@clr-namespace:InterfazWPF.AdministracionSistema.ControlesUsuario2InterfazWPF.AdministracionSistema.ControlesUsuario  5   	   )clr-namespace:InterfazWPFInterfazWPF  6c   I    CInterfazWPF.Modulos.ProgramaSiembra.win_ps_importarCajasProyectadas   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   ]ControlesUsuario@clr-namespace:InterfazWPF.AdministracionSistema.ControlesUsuario     5   	   1InterfazWPFclr-namespace:InterfazWPF     6c     � Title$%  win_ps_importarCajasProyectadas��5   	   $��368.127��61   $��895.107��6B    � WindowState$ 	Maximized=�6R   .��5      �  � ColumnDefinitions 5   
   �� 5      .+�5
   
   �� $��Ruta BD Proyección:��6   $
��Left=�6.   $��	10,10,0,0q�6I   $	��Top=�6\   F   @InterfazWPF.AdministracionSistema.ControlesUsuario.TextboxNormal  5   
   -   5          Name$ txt_rutaArchivo��5   )   $��131,11,96,0q�6B   $	��Top=�6W      InterfazWPF.Boton  5   
   -   5          Name$ btn_BuscarCargarBD��5         InterfazWPF.Boton   MouseUp$  btn_BuscarCargarBD_MouseUp��6F      Text$ Buscar��68   $��Right=�6k   $��	0,14,10,0q�6�   $	��Top=�6�   $��70��6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ 	dgv_datos��5      $
��Left=�6&   $��
10,79,0,34q�6A   $	��414��6U      AlternatingRowBackground �	#FFF7BBBB	 �� AlternationCount$	 2��6�   )   #InterfazWPF.TextboxBusquedaCatalogo  5   
   -   5        
  Name$
 txt_buscadorTemporada��5   .   $
��Left=�6M   $��	85,48,0,0q�6h   $	��Top=�6{   $��23��6�   $	��232��6�   �� 5   
   $��	Temporada��6   $
��Left=�6$   $��	10,45,0,0q�6?   $	��Top=�6R   �� 5   
   -   5         ��Name$ cmb_versiones��5      $
��Left=�6\   $��
398,49,0,0q�6w   $	��Top=�6�   $	��171��6�   �� 5   
   $��	Versión:��6   $
��Left=�6$   $��
341,48,0,0q�6?   $	��Top=�6S     5   
   -   5        $ 
btn_cargar��5      $ btn_cargar_MouseUp��6K   $ Iniciar importación��60   $
��Left=�6h   $��	10,0,0,10q�6�   $��Bottom=�6�   $	��116��6�     5   
   -   5        $" btn_MostrarEnProgramaSiembra��5      $* $btn_MostrarEnProgramaSiembra_MouseUp��6B   $ Mostrar registros��6q   $��Right=�6�   $��	0,55,10,0q�6�   $	��Top=�6�    J� RenderTransformOrigin$ -0.001,0.797&�6�   $	��124��6�     5   
   -   5        $ dgv_cajasPorDia��5      $��453,79,10,48q�6-    �	#FFC2E4EC$	 2��6h     5   
   -	   5        $ btn_EnviarAExcel��5      $ btn_EnviarAExcel_MouseUp��6L   $ Enviar a excel��66   $��	0,0,10,10q�6o   $	��124��6�   $��19��6�   $��Bottom=�6�   $��Right=�6�   � 5   
   -
   5         �Name$) #pb_progresoExportacionExcelCajasImp��5      $��453,0,10,34q�6C   $��9��6X   $��Bottom=�6c   5      5      