   M S B A M L   `   `   `  ����A  =Vistas, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:InterfazWPFInterfazWPF  5      w@clr-namespace:InterfazWPF.AdministracionSistema.ControlesUsuario2InterfazWPF.AdministracionSistema.ControlesUsuario  6*   )    #InterfazWPF.BuscadorCatalogoVentana   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      +localclr-namespace:InterfazWPF     5      2InterfazWPF_AdministracionSistema_ControlesUsuario@clr-namespace:InterfazWPF.AdministracionSistema.ControlesUsuario     6*   @d2http://schemas.microsoft.com/expression/blend/2008     6�   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6�   -   5          �Name$  Window��5       � Title$ BuscadorCatalogoVentana��5      $��637.5��5      $	��370��6   .��5
      � -   5         �Name$ 
LayoutRoot��5
       � ColumnDefinitions 5   
   �� 5      .+�5   
   �� 
���   � �� RadiusY$	 4.5��6#    �� RadiusX$	 4.5��61   ���	#FF606060 J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5      5      � 5      $��18��6   $��289,13,10,0q�6   $	��Top=�6/    J� RenderTransformOrigin$ 0.5,0.5&�6G   z�5      V� 5      .~�5      �� �� 5      �� 5       �� Angle$	 180Q�6   T� 5      5      .+�5      �� -   5        	 ��Name$	 chb_IncluirDeshabilitados��5      $��15.931��61   $��136.819��6A   $��Incluir deshabilitados��6Q   $ 0.5,0.5&�6r   
�������$y�	Collapsed=�6�   z�5      V� 5      .~�5      �� �� 5       �� 5!      $ -180.013Q�6   T� 5"      5#      5%      �� 5&      -   5        $	 chb_SeleccionMultiple��5&      $��Selección múltiple��6-   $ 0.5,0.5&�6J   
�������$y�	Collapsed=�6}   z�5'      V� 5(      .~�5)      �� �� 5*      �� 5+      $	 180Q�6   T� 5,      5-      5/      50         InterfazWPF.Boton  52      -   5        
  Name$
 btn_aceptar��52         InterfazWPF.Boton   	MouseDown$ btn_aceptar_MouseDown��6�      Text$ Aceptar��6&   $��Right=�65   $��0,0,8,7q�6Q   $��Bottom=�6b   $��23��6}   $��74��6�   6�     53      -   5        $
 btn_cancelar��53      $ btn_cancelar_MouseDown��6p   $ Cancelar��6'   $��0,0,86,7q�67   $��Bottom=�6I   $��23��6d   $��Right=�6�   $��72��6�   �� 54      $
��Left=�6
   $��7,8,0,0q�6%   $��26��66   $��25��6A   $	��Top=�6M   $��1403319922_checklist.png��6e   &   System.Windows.Controls.DataGrid  55      -   5          Name$  dgr_GridResultadosBusqueda��55         SelectionMode$ Single=�61   $��	7,45,8,34q�6H   
�������   HorizontalGridLinesBrush
 �   �   VerticalGridLinesBrush
 �   � �� AlternationCount$ 2��6�      CanUserAddRows .     AlternatingRowBackground �	#FFA2FBCC
���   �   RowBackground �	#FFDDFFED6  F   @InterfazWPF.AdministracionSistema.ControlesUsuario.TextboxNormal  57      -   5          Name$ txt_palabraBusqueda��57   E   $��	48,10,0,0q�6b   $	��Top=�6u   $
��Left=�6�   $	��228��6�     58   
   -	   5        $
 btn_AccesoCatalogo��58      $ Acceder al catálogo��62   $
��Left=�6M   $��8,0,0,7q�6h   $��22��6y   $��Bottom=�6�   $��115.792��6�   $y�Hidden=�6�   5:      5;      