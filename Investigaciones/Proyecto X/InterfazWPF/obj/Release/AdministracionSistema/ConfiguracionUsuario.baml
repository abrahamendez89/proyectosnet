   M S B A M L   `   `   `  ���� A  =Vistas, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:InterfazWPFInterfazWPF  <    6InterfazWPF.AdministracionSistema.ConfiguracionUsuario   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     1InterfazWPFclr-namespace:InterfazWPF       � Title$  ConfiguracionUsuario��$	��370��$	��393�� � AllowsTransparency .  � WindowStyle$
 None=� � WindowStartupLocation$ CenterScreen=���Z� .��� .+��� 
���   � �� RadiusY$
 22.5�� �� RadiusX$
 22.5��$��	0,36,0,10q�
���   � J� Opacity$	 0.5Q��� -   ���	#FFF4F4F5$��Right=�$	��107��$��0,3,18,0q�$
 11.5��$
 11.5��
���   �$	��Top=�$	��104���� -    ��Name$ img_fotoUsuario��$��Right=�$��89��$��	0,12,28,0q�$	��Top=�$��85�� � ToolTip$ Click para cambiar��$
��Fill=�   InterfazWPF.Boton  -   	  Name$	 btn_aceptar��   InterfazWPF.Boton
   	MouseDown$
 btn_aceptar_MouseDown��   Text$ Aceptar��$��Right=�$��23��$��	0,0,18,24q�$��Bottom=�$��85��  -   $	 btn_cancelar��$
 btn_cancelar_MouseDown��$ Cancelar��$��Right=�$��23��$��
0,0,108,24q�$��Bottom=�$��85���� $��Nombre:��$
��Left=�$��
30,123,0,0q�$	��Top=�
��������� -    ��Name$ 
txt_nombre��$
��Left=�$��25.96��$��91.447,123,0,0q�$	��Top=�$	��261���� $��Usuario:��$
��Left=�$��30,83.05,0,0q�$	��Top=�
��������� -    ��Name$ lbl_cuentaUsuario��$�� ��$
��Left=�$��87.943,83.05,0,0q�$	��Top=�
��������� $��Contraseña:��$
��Left=�$��30,242.96,0,0q�$	��Top=�
��������� $��Confirmar contraseña:��$
��Left=�$��30,273.92,0,0q�$	��Top=�
��������� $��Contraseña anterior:��$
��Left=�$��30,210.96,0,0q�$	��Top=�
��������� -    ��Name$ chb_cambiarContrase��$��Cambiar contraseña��$
��Left=�$��135,190,0,0q�$	��Top=�
�������G� -    G�Name$ txt_contraAnterior��$
��Left=�$��164,211,0,0q�$	��Top=�$	��188��$��26��{�.  G� -	   $ txt_contraNueva��$
��Left=�$��164,242,0,0q�$	��Top=�$	��188��$��26��{�.  G� -
   $ txt_contraConfirmacion��$
��Left=�$��164,273,0,0q�$	��Top=�$	��188��$��26��{�.  