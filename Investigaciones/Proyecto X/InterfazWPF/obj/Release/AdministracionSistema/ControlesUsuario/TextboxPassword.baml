   M S B A M L   `   `   `  ���� 
  VistasH    BInterfazWPF.AdministracionSistema.ControlesUsuario.TextboxPassword   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     $��25��  � 	Resources     OnMouseEnter1 �� TargetProperty �� 
TargetName8  2System.Windows.Media.Animation.EasingColorKeyFrame �� KeyTime �� Value  OnMouseLeave1��%�  &	        &	 0    �� .���� $* $(Shape.Fill).(SolidColorBrush.Color)�$ ellipse��.g�  $ 0:0:0.2��$ White���� $* $(Shape.Fill).(SolidColorBrush.Color)�$ ellipse1��.g�  $ 0:0:0.2��$ White���� $0 *(Panel.Background).(SolidColorBrush.Color)�$ txt_Algo��.g�  $ 0:0:0.2��$ White���� .���� $* $(Shape.Fill).(SolidColorBrush.Color)�$ ellipse��.g�  $ 0��$ White��  $ 0:0:0.3��$ 	#FFF0F0F0���� $* $(Shape.Fill).(SolidColorBrush.Color)�$ ellipse1��.g�  $ 0��$ White��  $ 0:0:0.3��$ 	#FFF0F0F0���� $0 *(Panel.Background).(SolidColorBrush.Color)�$ txt_Algo��.g�  $ 0��$ White��  $ 0:0:0.3��$ 	#FFF0F0F0�� � Triggers :�  :� RoutedEvent$ Mouse.MouseEnter��.[��� #��[  :� $ Mouse.MouseLeave��.[��� -    ��Name$# OnMouseLeave1_BeginStoryboard��#��[ .��� .+�A� -    A�Name$ ellipse�����	#FFF0F0F0$
��Left=�
���   �$��14��	 J� OpacityMask
	 �   �A� -   $ ellipse1�����	#FFF0F0F0
���   �$��Right=�$��14��
	 �   �F� ���P��j ��QUU�?	���	#FFF4F4F5$
��Left=�$��1��$��7,0.333,0,0q�
 �� Stretch$

 Fill=�
���   �$	��Top=�$��1��F� ������j � �@�� 	���	#FFF4F4F5$��1��$��6.062,0,5.602,0q�$

 Fill=�
���   �$	��Top=�F� ������j � �@�� 	���	#FFF4F4F5$��6.25,0,5.874,0q�$

 Fill=�
���   �$��1��$��Bottom=�G� -    G�Name$ txt_Algo��$��7,1,6,1q�
������� G� SelectionBrush �	#FF00D1FF$��0q�
	 �   ����	#FFF0F0F0$��Center=�